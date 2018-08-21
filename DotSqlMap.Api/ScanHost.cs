using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotSqlMap.Api
{
    /// <summary>
    /// SqlMap API服务器主机类
    /// </summary>
    public class ScanHost
    {
        /// <summary>
        /// 服务器计数
        /// </summary>
        static int _Count = 0;
        /// <summary>
        /// 服务器地址
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// API端口
        /// </summary>
        public uint Port { get; set; }
        /// <summary>
        /// 当前主机计数值
        /// </summary>
        public int Count { get; private set; }
        /// <summary>
        /// 完整API地址
        /// </summary>
        public string ApiUrl => $"http://{Host}:{Port}";
        /// <summary>
        /// 等待执行的任务数
        /// </summary>
        public int WaitTaskCount { get; set; }
        /// <summary>
        /// 正在执行的任务数
        /// </summary>
        public int RunningTaskCount { get; set; }

        /// <summary>
        /// 初始化
        /// </summary>
        public ScanHost()
        {
            WaitTaskCount = 0;
            RunningTaskCount = 0;
            _Count++;
            Count = _Count;
        }
    }
}
