﻿using Communication.BasicFramework;
using Communication.Core;
using Communication.Core.IMessage;
using Communication.Core.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Communication.Robot.EFORT
{
    /// <summary>
    /// 埃夫特机器人对应型号为ER7B-C10，此协议为旧版的定制版，使用前请测试
    /// </summary>
    public class ER7BC10Previous : NetworkDoubleBase<EFORTMessagePrevious, RegularByteTransform>, IRobotNet
    {
        #region Constructor

        /// <summary>
        /// 实例化一个默认的对象，并指定IP地址和端口号，端口号通常为8008
        /// </summary>
        /// <param name="ipAddress">Ip地址</param>
        /// <param name="port">端口号</param>
        public ER7BC10Previous( string ipAddress, int port )
        {
            IpAddress = ipAddress;
            Port = port;

            softIncrementCount = new SoftIncrementCount( ushort.MaxValue );
        }

        #endregion

        #region Request Create

        /// <summary>
        /// 获取发送的消息的命令
        /// </summary>
        /// <returns>字节数组命令</returns>
        public byte[] GetReadCommand( )
        {
            byte[] command = new byte[36];

            Encoding.ASCII.GetBytes( "MessageHead" ).CopyTo( command, 0 );
            BitConverter.GetBytes( (ushort)command.Length ).CopyTo( command, 15 );
            BitConverter.GetBytes( (ushort)1001 ).CopyTo( command, 17 );
            BitConverter.GetBytes( (ushort)softIncrementCount.GetCurrentValue( ) ).CopyTo( command, 19 );
            Encoding.ASCII.GetBytes( "MessageTail" ).CopyTo( command, 21 );

            return command;
        }

        #endregion

        #region IRobotNet Support

        /// <summary>
        /// 读取埃夫特机器人的原始的字节数据信息，该地址参数是没有任何作用的，随便填什么
        /// </summary>
        /// <param name="address">无效参数</param>
        /// <returns>带有成功标识的byte[]数组</returns>
        public OperateResult<byte[]> Read( string address )
        {
            return ReadFromCoreServer( GetReadCommand( ) );
        }

        /// <summary>
        /// 读取机器人的所有的数据信息，返回JSON格式的数据对象，地址参数无效
        /// </summary>
        /// <param name="address">地址信息</param>
        /// <returns>带有成功标识的字符串数据</returns>
        public OperateResult<string> ReadString( string address )
        {
            OperateResult<EfortData> read = ReadEfortData( );
            if (!read.IsSuccess) return OperateResult.CreateFailedResult<string>( read );

            return OperateResult.CreateSuccessResult( Newtonsoft.Json.JsonConvert.SerializeObject( read.Content, Newtonsoft.Json.Formatting.Indented ) );
        }

        /// <summary>
        /// 本机器人不支持该方法操作，将永远返回失败，无效的操作
        /// </summary>
        /// <param name="address">指定的地址信息，有些机器人可能不支持</param>
        /// <param name="value">原始的字节数据信息</param>
        /// <returns>是否成功的写入</returns>
        public OperateResult Write( string address, byte[] value )
        {
            return new OperateResult( StringResources.Language.NotSupportedFunction );
        }

        /// <summary>
        /// 本机器人不支持该方法操作，将永远返回失败，无效的操作
        /// </summary>
        /// <param name="address">指定的地址信息，有些机器人可能不支持</param>
        /// <param name="value">字符串的数据信息</param>
        /// <returns>是否成功的写入</returns>
        public OperateResult Write( string address, string value )
        {
            return new OperateResult( StringResources.Language.NotSupportedFunction );
        }
        
        /// <summary>
        /// 读取机器人的详细信息
        /// </summary>
        /// <returns>结果数据信息</returns>
        public OperateResult<EfortData> ReadEfortData( )
        {
            OperateResult<byte[]> read = Read( "" );
            if (!read.IsSuccess) return OperateResult.CreateFailedResult<EfortData>( read );

            return EfortData.PraseFromPrevious( read.Content );
        }
        
        #endregion

        #region Private Member

        private SoftIncrementCount softIncrementCount;              // 自增消息的对象

        #endregion

        #region Object Override

        /// <summary>
        /// 返回表示当前对象的字符串
        /// </summary>
        /// <returns>字符串</returns>
        public override string ToString( )
        {
            return $"ER7BC10 Pre Robot[{IpAddress}:{Port}]";
        }

        #endregion
    }
}