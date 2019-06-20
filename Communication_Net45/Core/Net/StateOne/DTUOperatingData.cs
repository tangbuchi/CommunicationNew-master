using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Communication.Core.Net
{
    /// <summary>
    /// 异形客户端的异步对象
    /// </summary>
    public class DTUOperatingData
    {
        /// <summary>
        /// DTU模块的运行参数
        /// </summary>
        public DTUOperatingData()
        {
            IsStatusOk = true;
        }


        /// <summary>
        /// 网络套接字
        /// </summary>
        public Socket Socket { get; set; }

        /// <summary>
        /// 指示当前的网络状态
        /// </summary>
        public bool IsStatusOk { get; set; }
        /// <summary>
        /// 终端模块号码
        /// </summary>
        public string TerminalNumber { get; set; }
        /// <summary>
        /// 接收到数据包的时间
        /// </summary>
        public string UpdateTime { get; set; }
        /// <summary>
        /// 缓存接收到的数据
        /// </summary>
        public byte[] DataBuffer { get; set; }

        /// <summary>
        /// 接收到的数据包长度
        /// </summary>
        public ushort DataLength { get; set; }
        /// <summary>
        /// 接收到的数据包类型
        /// </summary>
        public byte DataType { get; set; }

    }
}
