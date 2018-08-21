using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotSqlMap.Api
{
    /// <summary>
    /// 结果数据内容类型
    /// </summary>
    public enum CONTENT_TYPE
    {
        TARGET = 0,
        TECHNIQUES = 1,
        DBMS_FINGERPRINT = 2,
        BANNER = 3,
        CURRENT_USER = 4,
        CURRENT_DB = 5,
        HOSTNAME = 6,
        IS_DBA = 7,
        USERS = 8,
        PASSWORDS = 9,
        PRIVILEGES = 10,
        ROLES = 11,
        /// <summary>
        /// 数据库名称列表
        /// </summary>
        DBS = 12,
        /// <summary>
        /// 表名称列表
        /// </summary>
        TABLES = 13,
        /// <summary>
        /// 表字段列表
        /// </summary>
        COLUMNS = 14,
        SCHEMA = 15,
        COUNT = 16,
        DUMP_TABLE = 17,
        SEARCH = 18,
        /// <summary>
        /// 执行SQL语句结果
        /// </summary>
        SQL_QUERY = 19,
        COMMON_TABLES = 20,
        COMMON_COLUMNS = 21,
        FILE_READ = 22,
        FILE_WRITE = 23,
        OS_CMD = 24,
        REG_READ = 25,
    }

    /// <summary>
    /// 结果数据状态
    /// </summary>
    public enum CONTENT_STATUS
    {
        IN_PROGRESS = 0,
        COMPLETE = 1
    }


    /// <summary>
    /// 任务运行状态
    /// </summary>
    public enum RunningStatus
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknown,
        /// <summary>
        /// 正在等待执行
        /// </summary>
        Waiting,
        /// <summary>
        /// 正在执行
        /// </summary>
        Running,
        /// <summary>
        /// 任务执行完成
        /// </summary>
        Finished,
        /// <summary>
        /// 任务执行失败
        /// </summary>
        Failed,
        /// <summary>
        /// 任务被停止
        /// </summary>
        Stopped,
    }

    public enum TableProcessingTypes
    {
        /// <summary>
        /// 等待处理
        /// </summary>
        Waiting,
        /// <summary>
        /// 正在加载抽样数据
        /// </summary>
        LoadingExampleDataStart,
        /// <summary>
        /// 加载抽样数据完成
        /// </summary>
        LoadExampleDataStartFinished,
        /// <summary>
        /// 正在加载抽样数据
        /// </summary>
        LoadingExampleDataEnd,
        /// <summary>
        /// 加载抽样数据完成
        /// </summary>
        LoadExampleDataEndFinished,
        /// <summary>
        /// 正在下载数据
        /// </summary>
        DumpingData,
        /// <summary>
        /// 下载数据完成
        /// </summary>
        DumpDataFinished,
    }
}
