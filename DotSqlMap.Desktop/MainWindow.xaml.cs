using DotSqlMap.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DotSqlMap.Desktop
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnScan_Click(object sender, RoutedEventArgs e)
        {
            TaskUnit api = new TaskUnit(tbHost.Text.Trim(), uint.Parse(tbPort.Text.Trim()));
            api.NewTask(tbTaskUrl.Text.Trim());
            api.StartGetDBTableColumnCount();
            while (!api.CheckTaskFinied())
            {
                Thread.Sleep(1000);
            }
            var data = api.GetTaskData();
            var targetInfo = api.ReadAllFromTaskData(data);
            tbResult.Text = Newtonsoft.Json.JsonConvert.SerializeObject(data,Newtonsoft.Json.Formatting.Indented);
        }

        private void btnNewTask_Click(object sender, RoutedEventArgs e)
        {


        }
    }
}
