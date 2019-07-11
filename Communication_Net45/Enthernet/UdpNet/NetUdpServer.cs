using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Communication.Core;
using Communication.Core.Net;

namespace Communication.Enthernet
{
    /// <summary>
    /// Udp网络的服务器端类
    /// </summary>
    public class NetUdpServer : NetworkServerBase
    {

        /// <summary>
        /// 获取或设置一次接收时的数据长度，默认2KB数据长度
        /// </summary>
        public int ReceiveCacheLength { get; set; } = 2048;


        /// <summary>
        /// 根据指定的端口启动Upd侦听
        /// </summary>
        /// <param name="port">端口号信息</param>
        public override void ServerStart(int port)
        {
            if (!IsStarted)
            {
                CoreSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                //绑定网络地址
                CoreSocket.Bind(new IPEndPoint(IPAddress.Any, port));
                RefreshReceive();
                LogNet?.WriteInfo(ToString(), StringResources.Language.NetEngineStart);
                IsStarted = true;
            }
        }

        /// <summary>
        /// 关闭引擎的操作
        /// </summary>
        protected override void CloseAction()
        {
            AcceptString = null;
            AcceptByte = null;
            base.CloseAction();
        }

        /// <summary>
        /// 重新开始接收数据
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        private void RefreshReceive()
        {
            AppSession session = new AppSession();
            session.WorkSocket = CoreSocket;
            session.UdpEndPoint = new IPEndPoint(IPAddress.Any, 0);
            session.BytesContent = new byte[ReceiveCacheLength];
            // WorkSocket.BeginReceiveFrom(state.BytesHead, 0, 8, SocketFlags.None, ref state.UdpEndPoint, new AsyncCallback(ReceiveAsyncCallback), state);
            CoreSocket.BeginReceiveFrom(session.BytesContent, 0, ReceiveCacheLength, SocketFlags.None, ref session.UdpEndPoint, new AsyncCallback(AsyncCallback), session);
        }

        private void AsyncCallback(IAsyncResult ar)
        {
            if (ar.AsyncState is AppSession session)
            {
                try
                {
                    int received = session.WorkSocket.EndReceiveFrom(ar, ref session.UdpEndPoint);
                    // 马上开始重新接收，提供性能保障
                    RefreshReceive();
                    session.IpEndPoint = (IPEndPoint)session.UdpEndPoint;

                    int contentLength = session.BytesContent[2] * 256 + session.BytesContent[3];
                    byte[] dtuNumArray = new byte[11];
                    byte[] publicNetworkArray = new byte[4];
                    byte[] publicPortArray = new byte[2];

                    if (contentLength > 0)
                    {
                        Array.Copy(session.BytesContent, 4, dtuNumArray, 0, 11);
                        Array.Copy(session.BytesContent, 15, publicNetworkArray, 0, 4);
                        Array.Copy(session.BytesContent, 19, publicPortArray, 0, 2);
                    }
                    if (session.BytesContent[0] == 0x7b) // 代表宏电DDP协议
                    {
                        string dtuNum = Encoding.ASCII.GetString(dtuNumArray, 0, 11).Trim();
                        // 解析内容
                        if (session.BytesContent[1] == 0x01 && contentLength == 22) // 0x01 终端请求注册
                        {
                            string publicNetwork = BasicFramework.SoftBasic.ByteToHexTenString(publicNetworkArray, '.'); // 终端内网IP
                            int publicPort = Convert.ToInt32(BasicFramework.SoftBasic.ByteToHexString(publicPortArray), 16); //终端内网端口
                            SendBytesAsync(session, BuildDtuNumCommand(dtuNumArray));
                            LogNet?.WriteInfo(ToString(), $"请求注册 终端号码：{dtuNum} 终端公网IP：{session.IpEndPoint} 终端内网IP：{publicNetwork}:{publicPort}");
                        }

                        if (session.BytesContent[1] == 0x02 && contentLength == 16) // 0x02 终端请求注销
                        {
                            LogNet?.WriteInfo(ToString(), $"请求注销 终端号码：{dtuNum}");
                        }

                        if (session.BytesContent[1] == 0x09) // 0x09 发送给DSC的用户数据包
                        {
                            byte[] instructArray = new byte[session.BytesContent[18]]; // 接收的指令长度（不包含宏电数据头）
                            Array.Copy(session.BytesContent, 16, instructArray, 0, session.BytesContent[18]);

                            LogNet?.WriteInfo(ToString(), $"发送给DSC的用户数据包 终端号码：{dtuNum} 数据捕获：{BasicFramework.SoftBasic.ByteToHexString(instructArray, ' ')}");
                        }

                    }
                    else
                    {
                        LogNet?.WriteWarn(ToString(), $"数据捕获：{BasicFramework.SoftBasic.ByteToHexString(session.BytesContent, ' ')}");
                    }
                }
                catch (ObjectDisposedException)
                {
                    //主程序退出的时候触发
                }
                catch (Exception ex)
                {
                    LogNet?.WriteException(ToString(), StringResources.Language.SocketEndReceiveException, ex);
                    //重新接收，此处已经排除掉了对象释放的异常
                    RefreshReceive();
                }
                finally
                {
                    //state = null;
                }

            }
        }
        /// <summary>
        /// 生成一个读取返回注册包的方法 ->
        /// 
        /// </summary>
        public static byte[] BuildDtuNumCommand(byte[] dtuNumArray)
        {
            byte[] _Command = new byte[16];
            _Command[0] = 0x7b;                 // 固定格式
            _Command[1] = 0x81;
            _Command[2] = 0x00;
            _Command[3] = 0x10;
            _Command[4] = dtuNumArray[0];       // 终端号码
            _Command[5] = dtuNumArray[1];
            _Command[6] = dtuNumArray[2];
            _Command[7] = dtuNumArray[3];
            _Command[8] = dtuNumArray[4];
            _Command[9] = dtuNumArray[5];
            _Command[10] = dtuNumArray[6];
            _Command[11] = dtuNumArray[7];
            _Command[12] = dtuNumArray[8];
            _Command[13] = dtuNumArray[9];
            _Command[14] = dtuNumArray[10];
            _Command[15] = 0x7b;

            return _Command;
        }

        /***********************************************************************************************************
         * 
         *    无法使用如下的字节头接收来确认网络传输，总是报错为最小
         * 
         ***********************************************************************************************************/

        //private void ReceiveAsyncCallback(IAsyncResult ar)
        //{
        //    if (ar.AsyncState is AsyncStateOne state)
        //    {
        //        try
        //        {
        //            state.AlreadyReceivedHead += state.WorkSocket.EndReceiveFrom(ar, ref state.UdpEndPoint);
        //            if (state.AlreadyReceivedHead < state.HeadLength)
        //            {
        //                //接续接收头数据
        //                WorkSocket.BeginReceiveFrom(state.BytesHead, state.AlreadyReceivedHead, state.HeadLength - state.AlreadyReceivedHead, SocketFlags.None,
        //                    ref state.UdpEndPoint, new AsyncCallback(ReceiveAsyncCallback), state);
        //            }
        //            else
        //            {
        //                //开始接收内容
        //                int ReceiveLenght = BitConverter.ToInt32(state.BytesHead, 4);
        //                if (ReceiveLenght > 0)
        //                {
        //                    state.BytesContent = new byte[ReceiveLenght];
        //                    WorkSocket.BeginReceiveFrom(state.BytesContent, state.AlreadyReceivedContent, state.BytesContent.Length - state.AlreadyReceivedContent, 
        //                        SocketFlags.None, ref state.UdpEndPoint, new AsyncCallback(ContentReceiveAsyncCallback), state);
        //                }
        //                else
        //                {
        //                    //没有内容了
        //                    ThreadDealWithReveice(state, BitConverter.ToInt32(state.BytesHead, 0), state.BytesContent);
        //                    state = null;
        //                    RefreshReceive();
        //                }
        //            }
        //        }
        //        catch(Exception ex)
        //        {
        //            LogHelper.SaveError(StringResources.Language.异步数据结束挂起发送出错, ex);
        //        }


        //    }
        //}

        //private void ContentReceiveAsyncCallback(IAsyncResult ar)
        //{
        //    if (ar.AsyncState is AsyncStateOne state)
        //    {
        //        try
        //        {
        //            state.AlreadyReceivedContent += state.WorkSocket.EndReceiveFrom(ar, ref state.UdpEndPoint);
        //            if (state.AlreadyReceivedContent < state.BytesContent.Length)
        //            {
        //                //还需要继续接收
        //                WorkSocket.BeginReceiveFrom(state.BytesContent, state.AlreadyReceivedContent, state.BytesContent.Length - state.AlreadyReceivedContent,
        //                        SocketFlags.None, ref state.UdpEndPoint, new AsyncCallback(ContentReceiveAsyncCallback), state);
        //            }
        //            else
        //            {
        //                //接收完成了
        //                ThreadDealWithReveice(state, BitConverter.ToInt32(state.BytesHead, 0), new byte[0]);
        //                state = null;
        //                RefreshReceive();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            LogHelper.SaveError(StringResources.Language.异步数据结束挂起发送出错, ex);
        //        }


        //    }
        //}

        #region Data Process Center

        /// <summary>
        /// 数据处理中心
        /// </summary>
        /// <param name="receive"></param>
        /// <param name="protocol"></param>
        /// <param name="customer"></param>
        /// <param name="content"></param>
        internal override void DataProcessingCenter(AppSession receive, int protocol, int customer, byte[] content)
        {
            if (protocol == InsideProtocol.ProtocolUserBytes)
            {
                AcceptByte?.Invoke(receive, customer, content);
            }
            else if (protocol == InsideProtocol.ProtocolUserString)
            {
                // 接收到文本数据
                string str = Encoding.Unicode.GetString(content);
                AcceptString?.Invoke(receive, customer, str);
            }
        }

        /// <summary>
        /// 向指定的通信对象发送字符串数据
        /// </summary>
        /// <param name="session">通信对象</param>
        /// <param name="customer">用户的指令头</param>
        /// <param name="str">实际发送的字符串数据</param>
        public void SendMessage(AppSession session, int customer, string str)
        {
            SendBytesAsync(session, InsideProtocol.CommandBytes(customer, Token, str));
        }
        /// <summary>
        /// 向指定的通信对象发送字节数据
        /// </summary>
        /// <param name="session">连接对象</param>
        /// <param name="customer">用户的指令头</param>
        /// <param name="bytes">实际的数据</param>
        public void SendMessage(AppSession session, int customer, byte[] bytes)
        {
            SendBytesAsync(session, InsideProtocol.CommandBytes(customer, Token, bytes));
        }

        private new void SendBytesAsync(AppSession session, byte[] data)
        {
            try
            {
                session.WorkSocket.SendTo(data, data.Length, SocketFlags.None, session.UdpEndPoint);
            }
            catch (Exception ex)
            {
                LogNet?.WriteException("SendMessage", ex);
            }
        }

        #endregion

        #region Event Handle

        /// <summary>
        /// 当接收到文本数据的时候,触发此事件
        /// </summary>
        public event Action<AppSession, NetHandle, string> AcceptString;


        /// <summary>
        /// 当接收到字节数据的时候,触发此事件
        /// </summary>
        public event Action<AppSession, NetHandle, byte[]> AcceptByte;


        #endregion

        #region Object Override

        /// <summary>
        /// 获取本对象的字符串表示形式
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "NetUdpServer";
        }
        #endregion

    }
}
