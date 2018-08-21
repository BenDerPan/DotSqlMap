using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotSqlMap.Api
{
    public enum MessageNotifyTypes
    {
        Info,
        AddTask,
        AddTaskFailed,
        TaskStarted,
        TaskFinished,
        TaskFailed,
    }
    public class MessageNotifyEventArgs : EventArgs
    {
        public string Message { get; private set; }
        public MessageNotifyTypes Type { get; private set; }
        public DateTime Time { get; private set; }
        public TaskUnit TaskUnit { get; private set; }
        public MessageNotifyEventArgs(string message,MessageNotifyTypes type, TaskUnit task=null)
        {
            Time = DateTime.Now;
            Message = message;
            Type = type;
            TaskUnit = task;
        }

        public string GetTypeDescrition()
        {
            switch (Type)
            {
                case MessageNotifyTypes.Info:
                    return "常规信息";
                case MessageNotifyTypes.AddTask:
                    return "添加目标成功";
                case MessageNotifyTypes.AddTaskFailed:
                    return "添加目标失败";
                case MessageNotifyTypes.TaskStarted:
                    return "开始任务";
                case MessageNotifyTypes.TaskFinished:
                    return "任务完成";
                case MessageNotifyTypes.TaskFailed:
                    return "任务失败";
                default:
                    return "未知信息";
            }
        }

    }
    public class TaskMananger
    {
        public event EventHandler<MessageNotifyEventArgs> MessageNotify;
        public Dictionary<string, TaskUnit> Tasks { get; private set; }

        public Dictionary<string,TaskUnit> CompleteTasks { get; private set; }
        public List<ScanHost> ScanHosts { get; private set; }
        public int MaxHostThreads { get; set; }

        CancellationTokenSource ctx;

        public TaskMananger(int maxThread=2)
        {
            Tasks = new Dictionary<string, TaskUnit>();
            CompleteTasks = new Dictionary<string, TaskUnit>();
            ScanHosts = new List<ScanHost>();
            MaxHostThreads = maxThread;
        }

        public bool AddTask(string target)
        {
            if (!Tasks.ContainsKey(target))
            {
                try
                {
                    var host = ScanHosts.OrderBy(h => h.WaitTaskCount).First();
                    TaskUnit taskUnit = new TaskUnit(host.Host, host.Port);
                    if (taskUnit.NewTask(target))
                    {
                        Tasks.Add(target, taskUnit);
                        host.WaitTaskCount += 1;
                        OnMessageNotify($"成功添加目标[{target}]到执行主机[{host.Host}:{host.Port}]", MessageNotifyTypes.AddTask, taskUnit);
                    }
                    else
                    {
                        OnMessageNotify($"添加目标[{target}]到执行主机[{host.Host}:{host.Port}]失败!", MessageNotifyTypes.AddTaskFailed, taskUnit);
                    }
                    
                    
                }
                catch (Exception e)
                {
                    OnMessageNotify($"添加目标[{target}]失败:{e.Message}", MessageNotifyTypes.AddTaskFailed);
                    return false;
                }

            }
            else
            {
                OnMessageNotify($"目标[{target}]任务已添加,无需重复添加.", MessageNotifyTypes.Info);
            }
            
            return true;
        }

        public void AddTaskRange(List<string> targets)
        {
            for (int i = 0; i < targets.Count; i++)
            {
                AddTask(targets[i]);
            }
        }

        public void Start(bool allowRestart=false)
        {
            ctx = new CancellationTokenSource();
            Task.Factory.StartNew(() => { Start(allowRestart,ctx.Token); }, ctx.Token);
        }

        void Start( bool allowRestart,CancellationToken token)
        {
            try
            {
                while (true)
                {
                    foreach (var target in Tasks.Keys)
                    {
                        token.ThrowIfCancellationRequested();
                        if (Tasks[target].Status != RunningStatus.Waiting)
                        {
                            continue;
                        }
                        try
                        {
                            var host = ScanHosts.FirstOrDefault(h => h.Host == Tasks[target].ScanServerHost && h.Port == Tasks[target].ScanServerPort);
                            if (host.RunningTaskCount >= MaxHostThreads)
                            {
                                continue;
                            }
                            if (Tasks[target].StartGetDBTableColumnCount())
                            {
                                host.RunningTaskCount += 1;
                                OnMessageNotify($"启动任务{target}成功!", MessageNotifyTypes.TaskStarted, Tasks[target]);
                            }
                            else
                            {
                                OnMessageNotify($"启动任务{target}失败!", MessageNotifyTypes.TaskFailed, Tasks[target]);
                            }

                        }
                        catch (Exception e)
                        {
                            OnMessageNotify($"启动任务{target}失败:{e.Message}", MessageNotifyTypes.Info);
                        }
                    }

                    //检查是否完成
                    foreach (var target in Tasks.Keys)
                    {
                        token.ThrowIfCancellationRequested();
                        if (!Tasks[target].CheckTaskFinied()||CompleteTasks.ContainsKey(target))
                        {
                            continue;
                        }

                        try
                        {
                            var data = Tasks[target].GetTaskData();
                            Tasks[target].ReadAllFromTaskData(data);
                            var host = ScanHosts.FirstOrDefault(h => h.Host == Tasks[target].ScanServerHost && h.Port == Tasks[target].ScanServerPort);
                            host.RunningTaskCount -= 1;
                            CompleteTasks.Add(target, Tasks[target]);
                            OnMessageNotify($"任务{target}执行完成.", MessageNotifyTypes.TaskFinished, Tasks[target]);

                        }
                        catch (Exception e)
                        {
                            OnMessageNotify($"检查任务结果{target}失败:{e.Message}", MessageNotifyTypes.TaskFailed, Tasks[target]);
                        }
                    }

                    foreach (var target in CompleteTasks.Keys)
                    {
                        var targetUnit = CompleteTasks[target];
                        foreach (var dbName in targetUnit.TargetInfo.Databases.Keys)
                        {
                            var db = targetUnit.TargetInfo.Databases[dbName];
                            foreach (var tableName in db.Tables.Keys)
                            {
                                if (string.IsNullOrEmpty(targetUnit.CurrentTickTable))
                                {
                                    targetUnit.CurrentTickTable = $"{dbName}.{tableName}";
                                }
                                if (targetUnit.CurrentTickTable != $"{dbName}.{tableName}")
                                {
                                    continue;
                                }
                                var table = db.Tables[tableName];
                                switch (table.Status)
                                {
                                    case TableProcessingTypes.Waiting:
                                        if (targetUnit.StartRunSql(table.GetSqlExampleDataStart(dbName)))
                                        {
                                            table.Status = TableProcessingTypes.LoadingExampleDataStart;
                                        }
                                        break;
                                    case TableProcessingTypes.LoadingExampleDataStart:
                                        if (targetUnit.CheckTaskFinied())
                                        {
                                            try
                                            {
                                                var data = targetUnit.GetTaskData();
                                                var startDatas = targetUnit.ReadExampeData(data);
                                                table.StartExampleDatas = startDatas;
                                                table.Status = TableProcessingTypes.LoadExampleDataStartFinished;
                                            }
                                            catch (Exception ex)
                                            {
                                                table.Status = TableProcessingTypes.LoadExampleDataEndFinished;
                                                OnMessageNotify($"目标{targetUnit.Target}对表{dbName}.{tableName}获取前N条抽样数据失败.", MessageNotifyTypes.Info);
                                            }
                                        }
                                        break;
                                    case TableProcessingTypes.LoadExampleDataStartFinished:
                                        if (targetUnit.StartRunSql(table.GetSqlExampleDataEnd(dbName)))
                                        {
                                            table.Status = TableProcessingTypes.LoadingExampleDataEnd;
                                        }
                                        break;
                                    case TableProcessingTypes.LoadingExampleDataEnd:
                                        if (targetUnit.CheckTaskFinied())
                                        {
                                            try
                                            {
                                                var data = targetUnit.GetTaskData();
                                                var endDatas = targetUnit.ReadExampeData(data);
                                                table.EndExampleDatas = endDatas;
                                                table.Status = TableProcessingTypes.LoadExampleDataEndFinished;
                                            }
                                            catch (Exception ex)
                                            {
                                                table.Status = TableProcessingTypes.LoadExampleDataEndFinished;
                                                OnMessageNotify($"目标{targetUnit.Target}对表{dbName}.{tableName}获取后N条抽样数据失败.", MessageNotifyTypes.Info);
                                            }
                                        }
                                        break;
                                    case TableProcessingTypes.LoadExampleDataEndFinished:
                                        OnMessageNotify($"目标{targetUnit.Target}对表{dbName}.{tableName}获取抽样数据完成.", MessageNotifyTypes.Info);
                                        //仅采样数据
                                        targetUnit.CurrentTickTable = null;
                                        break;
                                        //if (table.CanDirectDumpAll)
                                        //{
                                        //    if (targetUnit.StartDumpTable(dbName,tableName))
                                        //    {
                                        //        table.Status = TableProcessingTypes.DumpingData;
                                        //        OnMessageNotify($"目标{targetUnit.Target}对表{dbName}.{tableName}开始下载数据...", MessageNotifyTypes.Info);
                                        //    }
                                            
                                        //}
                                        //else
                                        //{
                                        //    targetUnit.CurrentTickTable = null;
                                        //}
                                       

                                        //break;
                                    case TableProcessingTypes.DumpingData:
                                        if (targetUnit.CheckTaskFinied())
                                        {

                                            try
                                            {
                                                var data = targetUnit.GetTaskData();
                                                var saveFile = targetUnit.ReadDumpData(data);
                                                table.Status = TableProcessingTypes.DumpDataFinished;
                                                OnMessageNotify($"目标{targetUnit.Target}对表{dbName}.{tableName}数据下载完成:{saveFile}", MessageNotifyTypes.Info);
                                            }
                                            catch (Exception ex)
                                            {
                                                table.Status = TableProcessingTypes.LoadExampleDataEndFinished;
                                                OnMessageNotify($"目标{targetUnit.Target}对表{dbName}.{tableName}数据下载失败.", MessageNotifyTypes.Info);
                                            }
                                            
                                        }
                                        break;
                                    case TableProcessingTypes.DumpDataFinished:
                                        targetUnit.CurrentTickTable = null;
                                        break;
                                    default:
                                        targetUnit.CurrentTickTable = null;
                                        break;
                                }
                                
                            }
                        }
                    }

                    Thread.Sleep(500);
                }
            }
            catch (Exception)
            {
                return;
            }

        }

        public void Stop()
        {
            if (ctx!=null)
            {
                ctx.Cancel();
            }
            foreach (var task in Tasks.Values)
            {
                task.Stop();
            }
            OnMessageNotify($"任务执行已经取消!", MessageNotifyTypes.Info);
        }

        void OnMessageNotify(string message, MessageNotifyTypes type, TaskUnit task=null)
        {
            var handler = MessageNotify;
            if (handler!=null)
            {
                handler(this, new MessageNotifyEventArgs(message,type,task));
            }
        }

    }
}
