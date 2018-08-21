using DotSqlMap.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlMapDumper
{
    public partial class FormMain : Form
    {
        TaskMananger manager;
        public FormMain()
        {
            InitializeComponent();
            this.Text += $"[V{Version()}]";
            manager = new TaskMananger(1);
            manager.ScanHosts.Add(new ScanHost() { Host="192.168.102.160",Port=8775});
            manager.MessageNotify += Manager_MessageNotify;
        }

        string Version()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void Manager_MessageNotify(object sender, MessageNotifyEventArgs e)
        {
            ReportMessage(e);
        }

        

        void SetEnable(bool enbale)
        {
            tbTarget.Enabled = enbale;
            btnAddTarget.Enabled = enbale;
            btnAddFromFile.Enabled = enbale;
            btnStart.Enabled = enbale;
            btnStop.Enabled = !enbale;
        }

        void ReportMessage(MessageNotifyEventArgs e)
        {
            switch (e.Type)
            {
                case MessageNotifyTypes.Info:
                    break;
                case MessageNotifyTypes.AddTask:
                    treeViewTarget.Invoke(new Action(() =>
                    {
                        TreeNode node = new TreeNode() { Name = e.TaskUnit.TargetUrl, Text = e.TaskUnit.Target,ImageKey="web" };
                        treeViewTarget.Nodes["nodeWaiting"].Nodes.Add(node);
                    }));
                    
                    break;
                case MessageNotifyTypes.AddTaskFailed:
                    
                    break;
                case MessageNotifyTypes.TaskStarted:
                    treeViewTarget.Invoke(new Action(() =>
                    {
                        var node = treeViewTarget.Nodes["nodeWaiting"].Nodes[e.TaskUnit.TargetUrl];
                        treeViewTarget.Nodes["nodeWaiting"].Nodes.Remove(node);
                        treeViewTarget.Nodes["nodeRunning"].Nodes.Add(node);

                    }));
                    break;
                case MessageNotifyTypes.TaskFinished:
                    treeViewTarget.Invoke(new Action(() =>
                    {
                        if (treeViewTarget.Nodes["nodeFinished"].Nodes.ContainsKey(e.TaskUnit.TargetUrl))
                        {
                            return;
                        }
                        var node = treeViewTarget.Nodes["nodeRunning"].Nodes[e.TaskUnit.TargetUrl];
                        treeViewTarget.Nodes["nodeRunning"].Nodes.Remove(node);
                        
                        treeViewTarget.Nodes["nodeFinished"].Nodes.Add(node);
                    }));
                    break;
                case MessageNotifyTypes.TaskFailed:
                    treeViewTarget.Invoke(new Action(() =>
                    {
                        var node = treeViewTarget.Nodes["nodeRunning"].Nodes[e.TaskUnit.TargetUrl];
                        treeViewTarget.Nodes["nodeRunning"].Nodes.Remove(node);
                        treeViewTarget.Nodes["nodeFailed"].Nodes.Add(node);
                    }));
                    break;
                default:
                    break;
            }
            treeViewTarget.Invoke(new Action(() =>
            {
                treeViewTarget.Nodes["nodeWaiting"].Text = string.Format("{0} [{1}]", treeViewTarget.Nodes["nodeWaiting"].Text.Split(' ')[0], treeViewTarget.Nodes["nodeWaiting"].Nodes.Count);
                treeViewTarget.Nodes["nodeRunning"].Text = string.Format("{0} [{1}]", treeViewTarget.Nodes["nodeRunning"].Text.Split(' ')[0], treeViewTarget.Nodes["nodeRunning"].Nodes.Count);
                treeViewTarget.Nodes["nodeFinished"].Text = string.Format("{0} [{1}]", treeViewTarget.Nodes["nodeFinished"].Text.Split(' ')[0], treeViewTarget.Nodes["nodeFinished"].Nodes.Count);
                treeViewTarget.Nodes["nodeFailed"].Text = string.Format("{0} [{1}]", treeViewTarget.Nodes["nodeFailed"].Text.Split(' ')[0], treeViewTarget.Nodes["nodeFailed"].Nodes.Count);
            }));
            listBoxStatus.Invoke(new Action(() =>
            {
                string message = string.Format("[{0}] [{1}]  {2}", e.Time.ToString("yyyy-MM-dd HH:mm:ss"),e.GetTypeDescrition(), e.Message);
                listBoxStatus.Items.Add(message);
            }));

            //加载结果到列表
            foreach (var taskKey in manager.Tasks.Keys)
            {
                var task = manager.Tasks[taskKey];
                if (task.Status==RunningStatus.Finished)
                {
                    var info = task.TargetInfo;
                    treeViewTarget.Invoke(new Action(() =>
                    {
                        
                        foreach (var dbName in info.Databases.Keys)
                        {
                            if (!treeViewTarget.Nodes["nodeFinished"].Nodes[task.TargetUrl].Nodes.ContainsKey(dbName))
                            {
                                var node = new TreeNode() { Text = dbName, Name = dbName,ImageKey="data" };
                                treeViewTarget.Nodes["nodeFinished"].Nodes[task.TargetUrl].Nodes.Add(node);
                            }

                            foreach (var tableName in info.Databases[dbName].Tables.Keys)
                            {
                                if (!treeViewTarget.Nodes["nodeFinished"].Nodes[task.TargetUrl].Nodes[dbName].Nodes.ContainsKey(tableName))
                                {
                                    var node = new TreeNode() { Text = $"{tableName} [{info.Databases[dbName].Tables[tableName].Count}]", Name = tableName,ImageKey="table",Tag="table" };
                                    treeViewTarget.Nodes["nodeFinished"].Nodes[task.TargetUrl].Nodes[dbName].Nodes.Add(node);
                                }

                                foreach (var colName in info.Databases[dbName].Tables[tableName].Columns.Keys)
                                {
                                    if (!treeViewTarget.Nodes["nodeFinished"].Nodes[task.TargetUrl].Nodes[dbName].Nodes[tableName].Nodes.ContainsKey(colName))
                                    {

                                        var node = new TreeNode() { Text = $"{colName} [{info.Databases[dbName].Tables[tableName].Columns[colName].Type}]",
                                            Name = colName,ImageKey="field" };
                                        treeViewTarget.Nodes["nodeFinished"].Nodes[task.TargetUrl].Nodes[dbName].Nodes[tableName].Nodes.Add(node);
                                    }
                                }
                            }

                        }
                    }));
                }
            }
        }

        private void btnAddTarget_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbTarget.Text.Trim()))
            {
                MessageBox.Show("任务目标不合法!", "错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            manager.AddTask(tbTarget.Text.Trim());
        }

        private void btnAddFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text File(*.txt)|*.txt";
            dialog.Multiselect = false;
            if (dialog.ShowDialog()==DialogResult.OK)
            {
                var fileName = dialog.FileName;
                try
                {
                    using (StreamReader r = new StreamReader(fileName))
                    {
                        while (r.Peek() > 0)
                        {
                            var line = r.ReadLine().Trim();
                            if (string.IsNullOrEmpty(line))
                            {
                                continue;
                            }
                            manager.AddTask(line);
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"批量添加目标失败：{ex.Message}", "批量添加失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            SetEnable(false);
            manager.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            SetEnable(true);
            manager.Stop();
        }

        private void treeViewTarget_AfterSelect(object sender, TreeViewEventArgs e)
        {
            gridViewStart.Columns.Clear();
            gridViewEnd.Columns.Clear();
            if (e.Node!=null&&e.Node.Tag!=null&&e.Node.Tag.ToString().ToLower()=="table")
            {
                
                var target = e.Node.Parent.Parent.Name;
                var dbName = e.Node.Parent.Name;
                var tableName = e.Node.Name;
                if (!manager.Tasks[target].TargetInfo.Databases.ContainsKey(dbName))
                {
                    return;
                }
                var info = manager.Tasks[target].TargetInfo;
                var colNames = info.Databases[dbName].Tables[tableName].SortedColumnNames;
                
                //生成GridView
                foreach (var colName in colNames)
                {
                    gridViewStart.Columns.Add(colName,colName);
                    gridViewEnd.Columns.Add(colName, colName);
                }

                for (int i = 0; i < info.Databases[dbName].Tables[tableName].StartExampleDatas.Count; i++)
                {
                    var row = info.Databases[dbName].Tables[tableName].StartExampleDatas[i].ToArray();
                    gridViewStart.Rows.Add(row);
                }

                for (int i = 0; i < info.Databases[dbName].Tables[tableName].EndExampleDatas.Count; i++)
                {
                    var row = info.Databases[dbName].Tables[tableName].EndExampleDatas[i].ToArray();
                    gridViewEnd.Rows.Add(row);
                }


            }
        }

        private void btnConfigScanHost_Click(object sender, EventArgs e)
        {
            FormConfig formConfig = new FormConfig();
            formConfig.SetBinding(new BindingList<ScanHost>(manager.ScanHosts));
            formConfig.ShowDialog();
        }
    }
}
