using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotSqlMap.Api
{
    public class TaskUnit
    {
        SqlmapRawApi api;
        public string TaskID { get; private set; }
        public string TargetUrl { get; private set; }
        public string Target => GetTargetHost();
        public TargetInfo TargetInfo { get; private set; }
        public string ScanServerHost { get { return api.Host; } }
        public uint ScanServerPort { get { return api.Port; } }

        public RunningStatus Status { get;private set; }

        public string CurrentTickTable { get; set; }

        public TaskUnit(string host,uint port)
        {
            api = new SqlmapRawApi(host, port);
            Status = RunningStatus.Unknown;
        }

        public void SetTaskID(string taskID)
        {
            TaskID = taskID;
        }

        string GetTargetHost()
        {
            Uri uri = new Uri(TargetUrl);
            return uri.Host;
        }

        public bool NewTask(string url)
        {
            TargetUrl = url;
            TaskID = null;
            var res = api.NewTask();
            if (res.IsSuccess)
            {
                TaskID= res.ContentJToken.SelectToken("taskid").ToString();
            }
            Status = RunningStatus.Waiting;
            return res.IsSuccess;

        }

        public bool Stop()
        {
            var res = api.StopScan(TaskID);
            Status = RunningStatus.Stopped;
            return res.IsSuccess;
        }

        void CheckTaskIDException()
        {
            if (string.IsNullOrEmpty(TaskID))
            {
                throw new NullReferenceException("任务ID为空，请创建任务后再执行");
            }
        }

        public bool StartTestSqlInjection()
        {
            CheckTaskIDException();
            var res = api.StartScan(TaskID, new { url = TargetUrl, batch=true });
            return res.IsSuccess;
        }

        public bool CheckTaskFinied()
        {
            var res = api.GetScanStatus(TaskID);
            if (res.IsSuccess)
            {
                if (res.ContentJToken.SelectToken("status").ToString() == "terminated")
                {
                    Status = RunningStatus.Finished;
                    return true;
                }
            }
            return false;
        }

        public JToken GetTaskData()
        {
            var res = api.GetScanData(TaskID);
            if (res.IsSuccess)
            {
                Status = RunningStatus.Finished;
                return res.ContentJToken;
            }
            return null;
        }

        public JToken GetLogs()
        {
            var res = api.GetLog(TaskID);
            if (res.IsSuccess)
            {
                return res.ContentJToken;
            }
            return null;
        }

        public bool StartGetDBs()
        {
            var res = api.StartScan(TaskID, new { url = TargetUrl,getDbs=true, threads = 5, batch = true });
            Status = res.IsSuccess?RunningStatus.Running:RunningStatus.Failed;
            return res.IsSuccess;
        }

        public bool StartGetTables(string dbName)
        {
            var res = api.StartScan(TaskID, new { url = TargetUrl,db=dbName, getTables = true, threads = 5, batch = true });
            Status = res.IsSuccess ? RunningStatus.Running : RunningStatus.Failed;
            return res.IsSuccess;
        }

        public bool StartGetColumns(string dbName,string tableName)
        {
            var res = api.StartScan(TaskID, new { url = TargetUrl, db = dbName,tbl=tableName, getColumns = true, threads = 5, batch = true });
            Status = res.IsSuccess ? RunningStatus.Running : RunningStatus.Failed;
            return res.IsSuccess;
        }

        public bool StartGetCount(string dbName,string tableName)
        {
            var res = api.StartScan(TaskID, new { url = TargetUrl, db = dbName, tbl = tableName, getCount = true, threads = 5, batch = true });
            Status = res.IsSuccess ? RunningStatus.Running : RunningStatus.Failed;
            return res.IsSuccess;
        }

        public bool StartGetAll()
        {
            var res = api.StartScan(TaskID, new { url = TargetUrl, getAll = true, threads = 5, batch = true });
            Status = res.IsSuccess ? RunningStatus.Running : RunningStatus.Failed;
            return res.IsSuccess;
        }

        public bool StartGetDBTableColumnCount()
        {
            var res = api.StartScan(TaskID, new { url = TargetUrl, getDbs = true, getTables = true, getColumns = true, getCount = true, threads = 5, batch = true });
            Status = res.IsSuccess ? RunningStatus.Running : RunningStatus.Failed;
            return res.IsSuccess;
        }
        
        public bool StartRunSql(string sql)
        {
            var res = api.StartScan(TaskID, new { url = TargetUrl, query=sql,threads=5, batch = true });
            Status = res.IsSuccess ? RunningStatus.Running : RunningStatus.Failed;
            return res.IsSuccess;
        }

        public bool StartDumpTable(string dbName,string tableName)
        {
            var res = api.StartScan(TaskID, new { url = TargetUrl, db = dbName, tbl = tableName, dumpTable = true, threads = 5, batch = true });
            Status = res.IsSuccess ? RunningStatus.Running : RunningStatus.Failed;
            return res.IsSuccess;
        }

        public List<List<string>> ReadExampeData(JToken data)
        {
            var exampleData = new List<List<string>>();
            var dataList = data.SelectToken("data");
            foreach (var item in dataList)
            {
                var status = int.Parse(item.SelectToken("status").ToString());
                var typeItem = item.SelectToken("type");
                if (typeItem.Type!=JTokenType.Integer)
                {
                    continue;
                }
                var type = (CONTENT_TYPE)int.Parse(typeItem.ToString());
                var value = item.SelectToken("value");
                switch (type)
                {
                    case CONTENT_TYPE.SQL_QUERY:
                        var rowCount = value.Count(); 
                        if (rowCount<=0)
                        {
                            break;
                        }
                        var isRowArray = value.GetType() == typeof(JArray);
                        var isRowCellArray = value[0].GetType()==typeof(JArray);
                        if (rowCount>0&&isRowCellArray)
                        {
                            for (int i = 0; i < value.Count(); i++)
                            {
                                var row = value[i];

                                var dataRow = new List<string>();
                                for (int j = 0; j < row.Count(); j++)
                                {
                                    dataRow.Add(row[j].ToString());
                                }
                                exampleData.Add(dataRow);
                            }
                        }
                        else if (rowCount>0&&isRowArray&&!isRowCellArray)
                        {
                            //单条记录情况
                            var dataRow = new List<string>();
                            for (int i = 0; i < value.Count(); i++)
                            {
                                dataRow.Add(value[i].ToString());

                            }
                            exampleData.Add(dataRow);
                        }
                        
                        
                        break;
                    
                }
            }

            return exampleData;
        }

        public string ReadDumpData(JToken data)
        {
            var fileName = string.Empty;
            var dataList = data.SelectToken("data");
            foreach (var item in dataList)
            {
                var status = int.Parse(item.SelectToken("status").ToString());
                var typeItem = item.SelectToken("type");
                if (typeItem.Type != JTokenType.Integer)
                {
                    continue;
                }
                var type = (CONTENT_TYPE)int.Parse(typeItem.ToString());
                var value = item.SelectToken("value");
                switch (type)
                {
                    case CONTENT_TYPE.DUMP_TABLE:
                        var tableInfos = value.SelectToken("__infos__");
                        var dbName = tableInfos.SelectToken("db").ToString();
                        var tableName = tableInfos.SelectToken("table").ToString();
                        
                        var count = int.Parse(tableInfos.SelectToken("count").ToString());
                        var columns = TargetInfo.Databases[dbName].Tables[tableName].SortedColumnNames;
                        var dbPath= Utils.CheckTargetDBDirectoryExist(Target, dbName);
                        fileName = Path.Combine(dbPath, $"{tableName}.txt");
                       
                        using (FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate))
                        {
                            using (StreamWriter w = new StreamWriter(stream, Encoding.UTF8))
                            {
                                w.WriteLine(string.Join("\t", columns));

                                for (int i = 0; i < count; i++)
                                {
                                    var row = new List<string>();
                                    for (int j = 0; j < columns.Count; j++)
                                    {
                                        var cellData = value.SelectToken(columns[j]).SelectToken("values")[i].ToString();
                                        row.Add(cellData);
                                    }

                                    w.WriteLine(string.Join("\t", row));
                                }
                            }
                        }
                        break;

                }
            }

            return fileName;
        }



        public TargetInfo ReadAllFromTaskData(JToken data)
        {
            var targetInfo = new TargetInfo();
            var dataList = data.SelectToken("data");
            foreach (var item in dataList)
            {
                var status = int.Parse(item.SelectToken("status").ToString());
                var type = (CONTENT_TYPE)int.Parse(item.SelectToken("type").ToString());
                var value = item.SelectToken("value");
                switch (type)
                {
                    case CONTENT_TYPE.TARGET:
                        //解析目标相关信息
                        targetInfo.Url = value.SelectToken("url").ToString();
                        targetInfo.Query = value.SelectToken("query").ToString();
                        targetInfo.Data = value.SelectToken("data");
                        break;
                    case CONTENT_TYPE.TECHNIQUES:
                        break;
                    case CONTENT_TYPE.DBMS_FINGERPRINT:
                        break;
                    case CONTENT_TYPE.BANNER:
                        break;
                    case CONTENT_TYPE.CURRENT_USER:
                        break;
                    case CONTENT_TYPE.CURRENT_DB:
                        
                        break;
                    case CONTENT_TYPE.HOSTNAME:
                        break;
                    case CONTENT_TYPE.IS_DBA:
                        break;
                    case CONTENT_TYPE.USERS:
                        break;
                    case CONTENT_TYPE.PASSWORDS:
                        break;
                    case CONTENT_TYPE.PRIVILEGES:
                        break;
                    case CONTENT_TYPE.ROLES:
                        break;
                    case CONTENT_TYPE.DBS:
                        //解析数据库列表
                        foreach (var db in value)
                        {
                            var dbName = db.ToString();
                            targetInfo.Databases.Add(dbName, new Database() { Name = dbName });
                        }
                        break;
                    case CONTENT_TYPE.TABLES:
                        //解析数据库表
                        foreach (var dbName in targetInfo.Databases.Keys)
                        {
                            var tables = value.SelectToken(dbName);
                            foreach (var table in tables)
                            {
                                var tableName = table.ToString();
                                targetInfo.Databases[dbName].Tables.Add(tableName, new Table() { Name = tableName });
                            }
                        }
                        break;
                    case CONTENT_TYPE.COLUMNS:
                        //解析数据库表字段
                        foreach (var dbName in targetInfo.Databases.Keys)
                        {
                            foreach (var tableName in targetInfo.Databases[dbName].Tables.Keys)
                            {
                                JToken table=null;
                                try
                                {
                                    table = value.SelectToken(dbName).SelectToken(tableName);
                                }
                                catch (NullReferenceException)
                                {
                                    continue;
                                }
                                foreach (var c in table.Children())
                                {
                                    var column = c as JProperty;
                                    var columnDefine = column.Value.ToString();
                                    var fieldName = column.Name;
                                    var fieldType = columnDefine;
                                    int length = 0;
                                    if (columnDefine.Contains("("))
                                    {
                                        var defines = columnDefine.Replace(")",string.Empty).Split('(');
                                        fieldType = defines[0];
                                        if (defines[1].Contains(" "))
                                        {
                                            //处理 int(10) unsigned 类型
                                            fieldType = defines[0] + " " + defines[1].Split(' ')[1];
                                            length = int.Parse(defines[1].Split(' ')[0]);
                                        }
                                        else
                                        {
                                            length = int.Parse(defines[1]);
                                        }
                                        
                                    }
                                    

                                    targetInfo.Databases[dbName].Tables[tableName].Columns.Add(column.Name,new Column()
                                        {
                                            FieldName = fieldName,
                                            Length = length,
                                            Type=fieldType,
                                        });
                                }
                            }
                        }
                        break;
                    case CONTENT_TYPE.SCHEMA:
                        break;
                    case CONTENT_TYPE.COUNT:
                        foreach (var dbName in targetInfo.Databases.Keys)
                        {
                            var db = value.SelectToken(dbName);
                            foreach (var countObj in db)
                            {
                                var countProperty = countObj as JProperty;
                                var count = int.Parse(countProperty.Name);
                                foreach (var table in countProperty.Value)
                                {
                                    var tableName = table.ToString();
                                    targetInfo.Databases[dbName].Tables[tableName].Count = count;
                                }
                            }
                        }
                        break;
                    case CONTENT_TYPE.DUMP_TABLE:
                        break;
                    case CONTENT_TYPE.SEARCH:
                        break;
                    case CONTENT_TYPE.SQL_QUERY:
                        break;
                    case CONTENT_TYPE.COMMON_TABLES:
                        break;
                    case CONTENT_TYPE.COMMON_COLUMNS:
                        break;
                    case CONTENT_TYPE.FILE_READ:
                        break;
                    case CONTENT_TYPE.FILE_WRITE:
                        break;
                    case CONTENT_TYPE.OS_CMD:
                        break;
                    case CONTENT_TYPE.REG_READ:
                        break;
                    default:
                        break;
                }
            }
            TargetInfo = targetInfo;
            return targetInfo;
        }

    }
}
