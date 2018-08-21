using DotSqlMap.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlMapDumper
{
    public partial class FormConfig : Form
    { 
        public BindingList<ScanHost> ScanHosts { get;private set; }
        public FormConfig()
        {
            InitializeComponent();
        }

        public void SetBinding(BindingList<ScanHost> hosts)
        {
            ScanHosts = hosts;
            dataGridScanHost.DataSource = ScanHosts;
        }
       

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var host = tbScanHost.Text.ToLower().Trim();
            var port = tbScanPort.Text.Trim();

            if (string.IsNullOrEmpty(host))
            {
                MessageBox.Show("Sqlmap扫描主机不能为空!", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!uint.TryParse(port,out var portValue))
            {
                MessageBox.Show("扫描端口不合法!", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ScanHosts.ToList().FindIndex(h=>h.Host==host&&h.Port==portValue)>=0)
            {
                MessageBox.Show("扫描节点已经存在，请勿重复添加!", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ScanHosts.Add(new ScanHost() { Host = host, Port = portValue });

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridScanHost.CurrentRow!=null)
            {
                ScanHosts.RemoveAt(dataGridScanHost.CurrentRow.Index);
            }
        }

        private void dataGridScanHost_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                var scanHost = ScanHosts[e.RowIndex];
                tbScanHost.Text = scanHost.Host;
                tbScanPort.Text = scanHost.Port.ToString();
            }
        }
    }
}
