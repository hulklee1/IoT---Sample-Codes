namespace EquipManager
{
    partial class frmEquipManager
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuServerStart = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuServerStop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbLoc2 = new System.Windows.Forms.CheckBox();
            this.cbName = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbLoc1 = new System.Windows.Forms.CheckBox();
            this.cbModel = new System.Windows.Forms.CheckBox();
            this.tbLoc2 = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbLoc1 = new System.Windows.Forms.TextBox();
            this.tbModel = new System.Windows.Forms.TextBox();
            this.cbDesc = new System.Windows.Forms.CheckBox();
            this.cbCode = new System.Windows.Forms.CheckBox();
            this.tbDesc = new System.Windows.Forms.TextBox();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.gridStatus = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbInterval = new System.Windows.Forms.TextBox();
            this.tbServerPort = new System.Windows.Forms.TextBox();
            this.tbMonitor = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnUp = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridStatus)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 474);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(710, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(710, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuServerStart,
            this.mnuServerStop,
            this.toolStripMenuItem1,
            this.mnuExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mnuServerStart
            // 
            this.mnuServerStart.Name = "mnuServerStart";
            this.mnuServerStart.Size = new System.Drawing.Size(99, 22);
            this.mnuServerStart.Text = "Start";
            this.mnuServerStart.Click += new System.EventHandler(this.mnuServerStart_Click);
            // 
            // mnuServerStop
            // 
            this.mnuServerStop.Name = "mnuServerStop";
            this.mnuServerStop.Size = new System.Drawing.Size(99, 22);
            this.mnuServerStop.Text = "Stop";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(96, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(99, 22);
            this.mnuExit.Text = "Exit";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(710, 444);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(702, 418);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Console";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gridStatus);
            this.splitContainer2.Size = new System.Drawing.Size(696, 412);
            this.splitContainer2.SplitterDistance = 180;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnUp);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbLoc2);
            this.groupBox1.Controls.Add(this.cbName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbLoc1);
            this.groupBox1.Controls.Add(this.cbModel);
            this.groupBox1.Controls.Add(this.tbLoc2);
            this.groupBox1.Controls.Add(this.tbName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbLoc1);
            this.groupBox1.Controls.Add(this.tbModel);
            this.groupBox1.Controls.Add(this.cbDesc);
            this.groupBox1.Controls.Add(this.cbCode);
            this.groupBox1.Controls.Add(this.tbDesc);
            this.groupBox1.Controls.Add(this.tbCode);
            this.groupBox1.Location = new System.Drawing.Point(18, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(532, 103);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Equip Info";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(304, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "fLoc2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(300, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "fName";
            // 
            // cbLoc2
            // 
            this.cbLoc2.AutoSize = true;
            this.cbLoc2.Location = new System.Drawing.Point(404, 69);
            this.cbLoc2.Name = "cbLoc2";
            this.cbLoc2.Size = new System.Drawing.Size(15, 14);
            this.cbLoc2.TabIndex = 2;
            this.cbLoc2.UseVisualStyleBackColor = true;
            // 
            // cbName
            // 
            this.cbName.AutoSize = true;
            this.cbName.Location = new System.Drawing.Point(404, 31);
            this.cbName.Name = "cbName";
            this.cbName.Size = new System.Drawing.Size(15, 14);
            this.cbName.TabIndex = 2;
            this.cbName.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(159, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "fLoc1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "fModel";
            // 
            // cbLoc1
            // 
            this.cbLoc1.AutoSize = true;
            this.cbLoc1.Location = new System.Drawing.Point(259, 69);
            this.cbLoc1.Name = "cbLoc1";
            this.cbLoc1.Size = new System.Drawing.Size(15, 14);
            this.cbLoc1.TabIndex = 2;
            this.cbLoc1.UseVisualStyleBackColor = true;
            // 
            // cbModel
            // 
            this.cbModel.AutoSize = true;
            this.cbModel.Location = new System.Drawing.Point(259, 31);
            this.cbModel.Name = "cbModel";
            this.cbModel.Size = new System.Drawing.Size(15, 14);
            this.cbModel.TabIndex = 2;
            this.cbModel.UseVisualStyleBackColor = true;
            // 
            // tbLoc2
            // 
            this.tbLoc2.Location = new System.Drawing.Point(344, 66);
            this.tbLoc2.Name = "tbLoc2";
            this.tbLoc2.Size = new System.Drawing.Size(54, 21);
            this.tbLoc2.TabIndex = 0;
            this.tbLoc2.TextChanged += new System.EventHandler(this.tbLoc2_TextChanged);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(344, 28);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(54, 21);
            this.tbName.TabIndex = 0;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "fDesc";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "fCode";
            // 
            // tbLoc1
            // 
            this.tbLoc1.Location = new System.Drawing.Point(199, 66);
            this.tbLoc1.Name = "tbLoc1";
            this.tbLoc1.Size = new System.Drawing.Size(54, 21);
            this.tbLoc1.TabIndex = 0;
            this.tbLoc1.TextChanged += new System.EventHandler(this.tbLoc1_TextChanged);
            // 
            // tbModel
            // 
            this.tbModel.Location = new System.Drawing.Point(199, 28);
            this.tbModel.Name = "tbModel";
            this.tbModel.Size = new System.Drawing.Size(54, 21);
            this.tbModel.TabIndex = 0;
            this.tbModel.TextChanged += new System.EventHandler(this.tbModel_TextChanged);
            // 
            // cbDesc
            // 
            this.cbDesc.AutoSize = true;
            this.cbDesc.Location = new System.Drawing.Point(121, 69);
            this.cbDesc.Name = "cbDesc";
            this.cbDesc.Size = new System.Drawing.Size(15, 14);
            this.cbDesc.TabIndex = 2;
            this.cbDesc.UseVisualStyleBackColor = true;
            // 
            // cbCode
            // 
            this.cbCode.AutoSize = true;
            this.cbCode.Location = new System.Drawing.Point(121, 31);
            this.cbCode.Name = "cbCode";
            this.cbCode.Size = new System.Drawing.Size(15, 14);
            this.cbCode.TabIndex = 2;
            this.cbCode.UseVisualStyleBackColor = true;
            // 
            // tbDesc
            // 
            this.tbDesc.Location = new System.Drawing.Point(61, 66);
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.Size = new System.Drawing.Size(54, 21);
            this.tbDesc.TabIndex = 0;
            this.tbDesc.TextChanged += new System.EventHandler(this.tbDesc_TextChanged);
            // 
            // tbCode
            // 
            this.tbCode.Location = new System.Drawing.Point(61, 28);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(54, 21);
            this.tbCode.TabIndex = 0;
            // 
            // gridStatus
            // 
            this.gridStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridStatus.Location = new System.Drawing.Point(3, 3);
            this.gridStatus.Name = "gridStatus";
            this.gridStatus.RowTemplate.Height = 23;
            this.gridStatus.Size = new System.Drawing.Size(690, 222);
            this.gridStatus.TabIndex = 0;
            this.gridStatus.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridStatus_RowHeaderMouseDoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(702, 418);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Environment";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.tbInterval);
            this.splitContainer1.Panel1.Controls.Add(this.tbServerPort);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbMonitor);
            this.splitContainer1.Size = new System.Drawing.Size(696, 412);
            this.splitContainer1.SplitterDistance = 239;
            this.splitContainer1.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(177, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "초";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(65, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "Interval";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server TCP Port";
            // 
            // tbInterval
            // 
            this.tbInterval.Location = new System.Drawing.Point(116, 70);
            this.tbInterval.Name = "tbInterval";
            this.tbInterval.Size = new System.Drawing.Size(61, 21);
            this.tbInterval.TabIndex = 0;
            this.tbInterval.Text = "5";
            this.tbInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbServerPort
            // 
            this.tbServerPort.Location = new System.Drawing.Point(116, 43);
            this.tbServerPort.Name = "tbServerPort";
            this.tbServerPort.Size = new System.Drawing.Size(61, 21);
            this.tbServerPort.TabIndex = 0;
            this.tbServerPort.Text = "9001";
            this.tbServerPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbMonitor
            // 
            this.tbMonitor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMonitor.Location = new System.Drawing.Point(3, 3);
            this.tbMonitor.Multiline = true;
            this.tbMonitor.Name = "tbMonitor";
            this.tbMonitor.Size = new System.Drawing.Size(447, 406);
            this.tbMonitor.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(444, 32);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(69, 54);
            this.btnUp.TabIndex = 3;
            this.btnUp.Text = "Upload";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // frmEquipManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 496);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmEquipManager";
            this.Text = "Equipment Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEquipManager_FormClosing);
            this.Load += new System.EventHandler(this.frmEquipManager_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridStatus)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox tbMonitor;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuServerStart;
        private System.Windows.Forms.ToolStripMenuItem mnuServerStop;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbServerPort;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbLoc2;
        private System.Windows.Forms.CheckBox cbName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbLoc1;
        private System.Windows.Forms.CheckBox cbModel;
        private System.Windows.Forms.TextBox tbLoc2;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbLoc1;
        private System.Windows.Forms.TextBox tbModel;
        private System.Windows.Forms.CheckBox cbDesc;
        private System.Windows.Forms.CheckBox cbCode;
        private System.Windows.Forms.TextBox tbDesc;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.DataGridView gridStatus;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbInterval;
        private System.Windows.Forms.Button btnUp;
    }
}

