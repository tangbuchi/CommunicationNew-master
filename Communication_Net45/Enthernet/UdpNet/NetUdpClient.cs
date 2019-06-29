using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Communication.Enthernet
{
    /// <summary>
    /// UDP客户端的类，只负责发送数据到服务器，该数据经过封装
    /// </summary>
    public class NetUdpClient : Core.Net.NetworkUdpBase
    {
        /// <summary>
        /// 实例化对象，指定发送的服务器地址和端口号
        /// </summary>
        /// <param name="ipAddress">服务器的Ip地址</param>
        /// <param name="port">端口号</param>
        public NetUdpClient(string ipAddress, int port)
        {
            IpAddress = ipAddress;
            Port = port;
        }
        #region 数据加密的方法

        /// <summary>
        /// 客户端向服务器进行请求，请求字符串数据，忽略了自定义消息反馈，加密数据
        /// </summary>
        /// <param name="customer">用户的指令头</param>
        /// <param name="send">发送数据</param>
        /// <returns>带返回消息的结果对象</returns>
        public OperateResult<string> ReadFromServer(NetHandle customer, string send = null)
        {
            var read = ReadFromServerBaseInstructionsFirstEnDe(InsideProtocol.CommandBytes(customer, Token, send));
            if (!read.IsSuccess) return OperateResult.CreateFailedResult<string>(read);

            return OperateResult.CreateSuccessResult(Encoding.Unicode.GetString(read.Content));
        }


        /// <summary>
        /// 客户端向服务器进行请求，请求字节数据，加密数据
        /// </summary>
        /// <param name="customer">用户的指令头</param>
        /// <param name="send">发送的字节内容</param>
        /// <returns>带返回消息的结果对象</returns>
        public OperateResult<byte[]> ReadFromServer(NetHandle customer, byte[] send)
        {
            return ReadFromServerBaseInstructionsFirstEnDe(InsideProtocol.CommandBytes(customer, Token, send));
        }

        /// <summary>
        /// 客户端向服务器进行请求，请求字符串数据，并返回状态信息，加密数据
        /// </summary>
        /// <param name="customer">用户的指令头</param>
        /// <param name="send">发送数据</param>
        /// <returns>带返回消息的结果对象</returns>
        public OperateResult<NetHandle, string> ReadCustomerFromServer(NetHandle customer, string send = null)
        {
            var read = ReadCustomerFromServerBaseInstructionsFirstEnDe(InsideProtocol.CommandBytes(customer, Token, send));
            if (!read.IsSuccess) return OperateResult.CreateFailedResult<NetHandle, string>(read);

            return OperateResult.CreateSuccessResult(read.Content1, Encoding.Unicode.GetString(read.Content2));
        }

        /// <summary>
        /// 客户端向服务器进行请求，请求字符串数据，并返回状态信息，加密数据
        /// </summary>
        /// <param name="customer">用户的指令头</param>
        /// <param name="send">发送数据</param>
        /// <returns>带返回消息的结果对象</returns>
        public OperateResult<NetHandle, byte[]> ReadCustomerFromServer(NetHandle customer, byte[] send)
        {
            return ReadCustomerFromServerBaseInstructionsFirstEnDe(InsideProtocol.CommandBytes(customer, Token, send));
        }
        #endregion

        #region 数据未加密的方法

        /// <summary>
        /// 客户端向服务器发送请求，未加密数据
        /// </summary>
        /// <param name="send">发送数据</param>
        /// <returns></returns>
        public OperateResult<string> ReadFromServer(string send = null)
        {
            var read = ReadFromServerBaseSimpleness(Communication.BasicFramework.SoftBasic.HexStringToBytes(send));
            if (!read.IsSuccess) return OperateResult.CreateFailedResult<string>(read);

            return OperateResult.CreateSuccessResult(Communication.BasicFramework.SoftBasic.ByteToHexString(read.Content));
        }

        #endregion
        /// <summary>
        /// 需要发送的底层数据、提炼数据，带网络指令头和数据加密解密
        /// </summary>
        /// <param name="send">需要发送的底层数据</param>
        /// <returns>带返回消息的结果对象</returns>
        private OperateResult<byte[]> ReadFromServerBaseInstructionsFirstEnDe(byte[] send)
        {
            var read = ReadCustomerFromServerBaseInstructionsFirstEnDe(send);
            if (!read.IsSuccess) return OperateResult.CreateFailedResult<byte[]>(read);

            return OperateResult.CreateSuccessResult(read.Content2);
        }


        /// <summary>
        /// 需要发送的底层数据、提炼数据，带网络指令头和数据加密解密
        /// </summary>
        /// <param name="send">需要发送的底层数据</param>
        /// <returns>带返回消息的结果对象</returns>
        private OperateResult<NetHandle, byte[]> ReadCustomerFromServerBaseInstructionsFirstEnDe(byte[] send)
        {
            // 核心数据交互
            var read = ReadFromCoreServer(send);
            if (!read.IsSuccess) return OperateResult.CreateFailedResult<NetHandle, byte[]>(read);

            // 提炼数据信息
            byte[] headBytes = new byte[InsideProtocol.HeadByteLength]; 
            byte[] contentBytes = new byte[read.Content.Length - InsideProtocol.HeadByteLength];

            Array.Copy(read.Content, 0, headBytes, 0, InsideProtocol.HeadByteLength);
            if (contentBytes.Length > 0) Array.Copy(read.Content, InsideProtocol.HeadByteLength, contentBytes, 0, read.Content.Length - InsideProtocol.HeadByteLength);

            int customer = BitConverter.ToInt32(headBytes, 4);
            contentBytes = InsideProtocol.CommandAnalysis(headBytes, contentBytes);

            return OperateResult.CreateSuccessResult((NetHandle)customer, contentBytes);
        }

        /// <summary>
        /// 需要发送的底层数据（简单）
        /// </summary>
        /// <param name="send">需要发送的底层数据</param>
        /// <returns>带返回消息的结果对象</returns>
        private OperateResult<byte[]> ReadFromServerBaseSimpleness(byte[] send)
        {
            var read = ReadCustomerFromServerBaseSimpleness(send);
            if (!read.IsSuccess) return OperateResult.CreateFailedResult<byte[]>(read);

            return OperateResult.CreateSuccessResult(read.Content);
        }


        /// <summary>
        /// 需要发送的底层数据（简单）
        /// </summary>
        /// <param name="send">需要发送的底层数据</param>
        /// <returns>带返回消息的结果对象</returns>
        private OperateResult<byte[]> ReadCustomerFromServerBaseSimpleness(byte[] send)
        {
            // 核心数据交互
            var read = ReadFromCoreServer(send);
            if (!read.IsSuccess) return OperateResult.CreateFailedResult<byte[]>(read);

            // 提炼数据信息
            byte[] contentBytes = new byte[read.Content.Length];
            if (contentBytes.Length > 0) Array.Copy(read.Content, 0, contentBytes, 0, read.Content.Length);

            return OperateResult.CreateSuccessResult(contentBytes);
        }

        #region Object Override

        /// <summary>
        /// 获取本对象的字符串表示形式
        /// </summary>
        /// <returns>字符串信息</returns>
        public override string ToString()
        {
            return $"NetUdpClient[{IpAddress}:{Port}]";
        }
        #endregion

    }
}
