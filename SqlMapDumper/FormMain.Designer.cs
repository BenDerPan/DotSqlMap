namespace SqlMapDumper
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("排队中 [0]");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("正在进行 [0]");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("已完成 [0]");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("失败 [0]");
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabelTarget = new System.Windows.Forms.ToolStripLabel();
            this.tbTarget = new System.Windows.Forms.ToolStripTextBox();
            this.btnAddTarget = new System.Windows.Forms.ToolStripButton();
            this.btnAddFromFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnStop = new System.Windows.Forms.ToolStripButton();
            this.btnStart = new System.Windows.Forms.ToolStripButton();
            this.btnConfigScanHost = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.panelMain = new System.Windows.Forms.Panel();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.groupBoxTarget = new System.Windows.Forms.GroupBox();
            this.treeViewTarget = new System.Windows.Forms.TreeView();
            this.imageListTarget = new System.Windows.Forms.ImageList(this.components);
            this.groupBoxTargetDetail = new System.Windows.Forms.GroupBox();
            this.tabControlDataView = new System.Windows.Forms.TabControl();
            this.tabPageStart = new System.Windows.Forms.TabPage();
            this.gridViewStart = new System.Windows.Forms.DataGridView();
            this.tabPageEnd = new System.Windows.Forms.TabPage();
            this.gridViewEnd = new System.Windows.Forms.DataGridView();
            this.groupBoxStatus = new System.Windows.Forms.GroupBox();
            this.listBoxStatus = new System.Windows.Forms.ListBox();
            this.toolStrip.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.groupBoxTarget.SuspendLayout();
            this.groupBoxTargetDetail.SuspendLayout();
            this.tabControlDataView.SuspendLayout();
            this.tabPageStart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewStart)).BeginInit();
            this.tabPageEnd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEnd)).BeginInit();
            this.groupBoxStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelTarget,
            this.tbTarget,
            this.btnAddTarget,
            this.btnAddFromFile,
            this.toolStripSeparator1,
            this.btnStop,
            this.btnStart,
            this.btnConfigScanHost});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1170, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripLabelTarget
            // 
            this.toolStripLabelTarget.Name = "toolStripLabelTarget";
            this.toolStripLabelTarget.Size = new System.Drawing.Size(32, 22);
            this.toolStripLabelTarget.Text = "目标";
            // 
            // tbTarget
            // 
            this.tbTarget.Name = "tbTarget";
            this.tbTarget.Size = new System.Drawing.Size(400, 25);
            this.tbTarget.Text = "http://testphp.vulnweb.com/listproducts.php?cat=2";
            // 
            // btnAddTarget
            // 
            this.btnAddTarget.Image = ((System.Drawing.Image)(resources.GetObject("btnAddTarget.Image")));
            this.btnAddTarget.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddTarget.Name = "btnAddTarget";
            this.btnAddTarget.Size = new System.Drawing.Size(76, 22);
            this.btnAddTarget.Text = "添加目标";
            this.btnAddTarget.Click += new System.EventHandler(this.btnAddTarget_Click);
            // 
            // btnAddFromFile
            // 
            this.btnAddFromFile.Image = ((System.Drawing.Image)(resources.GetObject("btnAddFromFile.Image")));
            this.btnAddFromFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddFromFile.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.btnAddFromFile.Name = "btnAddFromFile";
            this.btnAddFromFile.Size = new System.Drawing.Size(76, 22);
            this.btnAddFromFile.Text = "批量添加";
            this.btnAddFromFile.Click += new System.EventHandler(this.btnAddFromFile_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnStop
            // 
            this.btnStop.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnStop.Enabled = false;
            this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
            this.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStop.Margin = new System.Windows.Forms.Padding(10, 1, 50, 2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(76, 22);
            this.btnStop.Text = "停止执行";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnStart.Image = ((System.Drawing.Image)(resources.GetObject("btnStart.Image")));
            this.btnStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStart.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(76, 22);
            this.btnStart.Text = "开始执行";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnConfigScanHost
            // 
            this.btnConfigScanHost.Image = ((System.Drawing.Image)(resources.GetObject("btnConfigScanHost.Image")));
            this.btnConfigScanHost.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConfigScanHost.Name = "btnConfigScanHost";
            this.btnConfigScanHost.Size = new System.Drawing.Size(100, 22);
            this.btnConfigScanHost.Text = "配置扫描主机";
            this.btnConfigScanHost.Click += new System.EventHandler(this.btnConfigScanHost_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 610);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1170, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.Transparent;
            this.panelMain.Controls.Add(this.splitContainerMain);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 25);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1170, 585);
            this.panelMain.TabIndex = 2;
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.groupBoxTarget);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.groupBoxTargetDetail);
            this.splitContainerMain.Size = new System.Drawing.Size(1170, 585);
            this.splitContainerMain.SplitterDistance = 200;
            this.splitContainerMain.TabIndex = 0;
            // 
            // groupBoxTarget
            // 
            this.groupBoxTarget.Controls.Add(this.treeViewTarget);
            this.groupBoxTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTarget.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTarget.Name = "groupBoxTarget";
            this.groupBoxTarget.Size = new System.Drawing.Size(200, 585);
            this.groupBoxTarget.TabIndex = 0;
            this.groupBoxTarget.TabStop = false;
            this.groupBoxTarget.Text = "目标列表";
            // 
            // treeViewTarget
            // 
            this.treeViewTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewTarget.ImageIndex = 0;
            this.treeViewTarget.ImageList = this.imageListTarget;
            this.treeViewTarget.Location = new System.Drawing.Point(3, 17);
            this.treeViewTarget.Name = "treeViewTarget";
            treeNode1.ImageKey = "wait";
            treeNode1.Name = "nodeWaiting";
            treeNode1.Tag = "Task";
            treeNode1.Text = "排队中 [0]";
            treeNode2.ImageKey = "downloading";
            treeNode2.Name = "nodeRunning";
            treeNode2.Tag = "Task";
            treeNode2.Text = "正在进行 [0]";
            treeNode3.ImageKey = "finish";
            treeNode3.Name = "nodeFinished";
            treeNode3.Tag = "Task";
            treeNode3.Text = "已完成 [0]";
            treeNode4.ImageKey = "error";
            treeNode4.Name = "nodeFailed";
            treeNode4.Tag = "Task";
            treeNode4.Text = "失败 [0]";
            this.treeViewTarget.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            this.treeViewTarget.SelectedImageIndex = 6;
            this.treeViewTarget.Size = new System.Drawing.Size(194, 565);
            this.treeViewTarget.TabIndex = 0;
            this.treeViewTarget.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewTarget_AfterSelect);
            // 
            // imageListTarget
            // 
            this.imageListTarget.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTarget.ImageStream")));
            this.imageListTarget.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTarget.Images.SetKeyName(0, "wait");
            this.imageListTarget.Images.SetKeyName(1, "downloading");
            this.imageListTarget.Images.SetKeyName(2, "finish");
            this.imageListTarget.Images.SetKeyName(3, "error");
            this.imageListTarget.Images.SetKeyName(4, "directory");
            this.imageListTarget.Images.SetKeyName(5, "data");
            this.imageListTarget.Images.SetKeyName(6, "select");
            this.imageListTarget.Images.SetKeyName(7, "web");
            this.imageListTarget.Images.SetKeyName(8, "field");
            this.imageListTarget.Images.SetKeyName(9, "table");
            // 
            // groupBoxTargetDetail
            // 
            this.groupBoxTargetDetail.Controls.Add(this.tabControlDataView);
            this.groupBoxTargetDetail.Controls.Add(this.groupBoxStatus);
            this.groupBoxTargetDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTargetDetail.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTargetDetail.Name = "groupBoxTargetDetail";
            this.groupBoxTargetDetail.Size = new System.Drawing.Size(966, 585);
            this.groupBoxTargetDetail.TabIndex = 0;
            this.groupBoxTargetDetail.TabStop = false;
            this.groupBoxTargetDetail.Text = "目标详情";
            // 
            // tabControlDataView
            // 
            this.tabControlDataView.Controls.Add(this.tabPageStart);
            this.tabControlDataView.Controls.Add(this.tabPageEnd);
            this.tabControlDataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlDataView.Location = new System.Drawing.Point(3, 17);
            this.tabControlDataView.Name = "tabControlDataView";
            this.tabControlDataView.SelectedIndex = 0;
            this.tabControlDataView.Size = new System.Drawing.Size(960, 379);
            this.tabControlDataView.TabIndex = 2;
            // 
            // tabPageStart
            // 
            this.tabPageStart.Controls.Add(this.gridViewStart);
            this.tabPageStart.Location = new System.Drawing.Point(4, 22);
            this.tabPageStart.Name = "tabPageStart";
            this.tabPageStart.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStart.Size = new System.Drawing.Size(952, 353);
            this.tabPageStart.TabIndex = 0;
            this.tabPageStart.Text = "数据前N条抽样";
            this.tabPageStart.UseVisualStyleBackColor = true;
            // 
            // gridViewStart
            // 
            this.gridViewStart.AllowUserToAddRows = false;
            this.gridViewStart.AllowUserToDeleteRows = false;
            this.gridViewStart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridViewStart.Location = new System.Drawing.Point(3, 3);
            this.gridViewStart.Name = "gridViewStart";
            this.gridViewStart.ReadOnly = true;
            this.gridViewStart.RowTemplate.Height = 23;
            this.gridViewStart.Size = new System.Drawing.Size(946, 347);
            this.gridViewStart.TabIndex = 1;
            // 
            // tabPageEnd
            // 
            this.tabPageEnd.Controls.Add(this.gridViewEnd);
            this.tabPageEnd.Location = new System.Drawing.Point(4, 22);
            this.tabPageEnd.Name = "tabPageEnd";
            this.tabPageEnd.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEnd.Size = new System.Drawing.Size(952, 353);
            this.tabPageEnd.TabIndex = 1;
            this.tabPageEnd.Text = "数据后N条抽样";
            this.tabPageEnd.UseVisualStyleBackColor = true;
            // 
            // gridViewEnd
            // 
            this.gridViewEnd.AllowUserToAddRows = false;
            this.gridViewEnd.AllowUserToDeleteRows = false;
            this.gridViewEnd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridViewEnd.Location = new System.Drawing.Point(3, 3);
            this.gridViewEnd.Name = "gridViewEnd";
            this.gridViewEnd.ReadOnly = true;
            this.gridViewEnd.RowTemplate.Height = 23;
            this.gridViewEnd.Size = new System.Drawing.Size(946, 347);
            this.gridViewEnd.TabIndex = 2;
            // 
            // groupBoxStatus
            // 
            this.groupBoxStatus.Controls.Add(this.listBoxStatus);
            this.groupBoxStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBoxStatus.Location = new System.Drawing.Point(3, 396);
            this.groupBoxStatus.Name = "groupBoxStatus";
            this.groupBoxStatus.Size = new System.Drawing.Size(960, 186);
            this.groupBoxStatus.TabIndex = 1;
            this.groupBoxStatus.TabStop = false;
            this.groupBoxStatus.Text = "状态输出";
            // 
            // listBoxStatus
            // 
            this.listBoxStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxStatus.FormattingEnabled = true;
            this.listBoxStatus.ItemHeight = 12;
            this.listBoxStatus.Location = new System.Drawing.Point(3, 17);
            this.listBoxStatus.Name = "listBoxStatus";
            this.listBoxStatus.Size = new System.Drawing.Size(954, 166);
            this.listBoxStatus.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 632);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据抽样分析";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.groupBoxTarget.ResumeLayout(false);
            this.groupBoxTargetDetail.ResumeLayout(false);
            this.tabControlDataView.ResumeLayout(false);
            this.tabPageStart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewStart)).EndInit();
            this.tabPageEnd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEnd)).EndInit();
            this.groupBoxStatus.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabelTarget;
        private System.Windows.Forms.ToolStripTextBox tbTarget;
        private System.Windows.Forms.ToolStripButton btnAddTarget;
        private System.Windows.Forms.ToolStripButton btnAddFromFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnStop;
        private System.Windows.Forms.ToolStripButton btnStart;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.GroupBox groupBoxTarget;
        private System.Windows.Forms.TreeView treeViewTarget;
        private System.Windows.Forms.ImageList imageListTarget;
        private System.Windows.Forms.GroupBox groupBoxTargetDetail;
        private System.Windows.Forms.GroupBox groupBoxStatus;
        private System.Windows.Forms.ListBox listBoxStatus;
        private System.Windows.Forms.ToolStripButton btnConfigScanHost;
        private System.Windows.Forms.TabControl tabControlDataView;
        private System.Windows.Forms.TabPage tabPageStart;
        private System.Windows.Forms.DataGridView gridViewStart;
        private System.Windows.Forms.TabPage tabPageEnd;
        private System.Windows.Forms.DataGridView gridViewEnd;
    }
}

