using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Communication.Profinet.LSIS
{
    /// <summary>
    /// It is determined to be the XGK/I/R series through a reserved area
    /// </summary>
    public enum LSCpuInfo
    {
        /// <summary>
        /// XGK系列
        /// </summary>
        XGK = 1,
        /// <summary>
        /// XGI系列
        /// </summary>
        XGI,
        /// <summary>
        /// XGR系列
        /// </summary>
        XGR,
        /// <summary>
        /// XGB_MK系列
        /// </summary>
        XGB_MK,
        /// <summary>
        /// XGB_IEC系列
        /// </summary>
        XGB_IEC,
    }

    /// <summary>
    /// CPU状态
    /// </summary>
    public enum LSCpuStatus
    {
        /// <summary>
        /// 运行
        /// </summary>
        RUN = 1,
        /// <summary>
        /// 停止
        /// </summary>
        STOP,
        /// <summary>
        /// 错误
        /// </summary>
        ERROR,
        /// <summary>
        /// 调试
        /// </summary>
        DEBUG
    }
}
