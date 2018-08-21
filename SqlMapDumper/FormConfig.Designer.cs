namespace SqlMapDumper
{
    partial class FormConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabConfigScanHost = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridScanHost = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tbScanHost = new System.Windows.Forms.TextBox();
            this.tbScanPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApiUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabConfigScanHost.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridScanHost)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabConfigScanHost);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(857, 486);
            this.tabControl1.TabIndex = 0;
            // 
            // tabConfigScanHost
            // 
            this.tabConfigScanHost.Controls.Add(this.dataGridScanHost);
            this.tabConfigScanHost.Controls.Add(this.panel1);
            this.tabConfigScanHost.Location = new System.Drawing.Point(4, 22);
            this.tabConfigScanHost.Name = "tabConfigScanHost";
            this.tabConfigScanHost.Padding = new System.Windows.Forms.Padding(3);
            this.tabConfigScanHost.Size = new System.Drawing.Size(849, 460);
            this.tabConfigScanHost.TabIndex = 0;
            this.tabConfigScanHost.Text = "扫描服务器配置";
            this.tabConfigScanHost.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.tbScanPort);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbScanHost);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(843, 30);
            this.panel1.TabIndex = 0;
            // 
            // dataGridScanHost
            // 
            this.dataGridScanHost.AllowUserToAddRows = false;
            this.dataGridScanHost.AllowUserToDeleteRows = false;
            this.dataGridScanHost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridScanHost.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNo,
            this.colHost,
            this.colPort,
            this.colApiUrl});
            this.dataGridScanHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridScanHost.Location = new System.Drawing.Point(3, 33);
            this.dataGridScanHost.MultiSelect = false;
            this.dataGridScanHost.Name = "dataGridScanHost";
            this.dataGridScanHost.RowTemplate.Height = 23;
            this.dataGridScanHost.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridScanHost.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridScanHost.ShowCellErrors = false;
            this.dataGridScanHost.ShowRowErrors = false;
            this.dataGridScanHost.Size = new System.Drawing.Size(843, 424);
            this.dataGridScanHost.TabIndex = 1;
            this.dataGridScanHost.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridScanHost_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "API地址";
            // 
            // tbScanHost
            // 
            this.tbScanHost.Location = new System.Drawing.Point(62, 4);
            this.tbScanHost.Name = "tbScanHost";
            this.tbScanHost.Size = new System.Drawing.Size(140, 21);
            this.tbScanHost.TabIndex = 1;
            // 
            // tbScanPort
            // 
            this.tbScanPort.Location = new System.Drawing.Point(272, 3);
            this.tbScanPort.MaxLength = 5;
            this.tbScanPort.Name = "tbScanPort";
            this.tbScanPort.Size = new System.Drawing.Size(38, 21);
            this.tbScanPort.TabIndex = 3;
            this.tbScanPort.Text = "8775";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "API端口";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(373, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(51, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(450, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(68, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "删除选中";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // colNo
            // 
            this.colNo.DataPropertyName = "Count";
            this.colNo.FillWeight = 50F;
            this.colNo.HeaderText = "No.";
            this.colNo.Name = "colNo";
            this.colNo.Width = 50;
            // 
            // colHost
            // 
            this.colHost.DataPropertyName = "Host";
            this.colHost.FillWeight = 150F;
            this.colHost.HeaderText = "主机地址";
            this.colHost.MaxInputLength = 128;
            this.colHost.Name = "colHost";
            this.colHost.ToolTipText = "API服务器地址";
            this.colHost.Width = 150;
            // 
            // colPort
            // 
            this.colPort.DataPropertyName = "Port";
            this.colPort.HeaderText = "API端口";
            this.colPort.MaxInputLength = 5;
            this.colPort.Name = "colPort";
            this.colPort.ToolTipText = "API访问端口";
            // 
            // colApiUrl
            // 
            this.colApiUrl.DataPropertyName = "ApiUrl";
            this.colApiUrl.FillWeight = 500F;
            this.colApiUrl.HeaderText = "API URL";
            this.colApiUrl.Name = "colApiUrl";
            this.colApiUrl.ToolTipText = "API 完整访问URL地址";
            this.colApiUrl.Width = 500;
            // 
            // FormConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 486);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormConfig";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "系统配置";
            this.tabControl1.ResumeLayout(false);
            this.tabConfigScanHost.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridScanHost)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabConfigScanHost;
        private System.Windows.Forms.DataGridView dataGridScanHost;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbScanPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbScanHost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApiUrl;
    }
}