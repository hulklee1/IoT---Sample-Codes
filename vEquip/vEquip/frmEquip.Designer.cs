namespace vEquip
{
    partial class frmEquip
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStart = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sbLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtStop = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbInterval = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbEqOzon = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbEqHum = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbEqTotal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbEqAir = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbEqWind = new System.Windows.Forms.TextBox();
            this.tbEqTemp = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbEqCount = new System.Windows.Forms.TextBox();
            this.tbEqBatt = new System.Windows.Forms.TextBox();
            this.tbEqModel = new System.Windows.Forms.TextBox();
            this.tbEqState = new System.Windows.Forms.TextBox();
            this.tbEqLine = new System.Windows.Forms.TextBox();
            this.tbEqCode = new System.Windows.Forms.TextBox();
            this.tbMonitor = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dtStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtStopTime = new System.Windows.Forms.DateTimePicker();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.configToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(647, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStart,
            this.mnuStop,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mnuStart
            // 
            this.mnuStart.Name = "mnuStart";
            this.mnuStart.Size = new System.Drawing.Size(180, 22);
            this.mnuStart.Text = "Start";
            this.mnuStart.Click += new System.EventHandler(this.mnuStart_Click);
            // 
            // mnuStop
            // 
            this.mnuStop.Name = "mnuStop";
            this.mnuStop.Size = new System.Drawing.Size(180, 22);
            this.mnuStop.Text = "Stop";
            this.mnuStop.Click += new System.EventHandler(this.mnuStop_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.configToolStripMenuItem.Text = "Config";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbLabel1,
            this.sbLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 466);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(647, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sbLabel1
            // 
            this.sbLabel1.AutoSize = false;
            this.sbLabel1.DoubleClickEnabled = true;
            this.sbLabel1.Name = "sbLabel1";
            this.sbLabel1.Size = new System.Drawing.Size(120, 17);
            this.sbLabel1.Text = "127.0.0.1";
            this.sbLabel1.DoubleClick += new System.EventHandler(this.sbLabel1_DoubleClick);
            // 
            // sbLabel2
            // 
            this.sbLabel2.AutoSize = false;
            this.sbLabel2.DoubleClickEnabled = true;
            this.sbLabel2.Name = "sbLabel2";
            this.sbLabel2.Size = new System.Drawing.Size(40, 17);
            this.sbLabel2.Text = "9001";
            this.sbLabel2.DoubleClick += new System.EventHandler(this.sbLabel2_DoubleClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbMonitor);
            this.splitContainer1.Size = new System.Drawing.Size(647, 442);
            this.splitContainer1.SplitterDistance = 319;
            this.splitContainer1.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtStopTime);
            this.groupBox3.Controls.Add(this.dtStartTime);
            this.groupBox3.Controls.Add(this.dtStop);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.dtStart);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.tbInterval);
            this.groupBox3.Location = new System.Drawing.Point(12, 313);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(296, 124);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "가동정보";
            // 
            // dtStop
            // 
            this.dtStop.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStop.Location = new System.Drawing.Point(76, 57);
            this.dtStop.Name = "dtStop";
            this.dtStop.Size = new System.Drawing.Size(91, 21);
            this.dtStop.TabIndex = 0;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(17, 61);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 1;
            this.label14.Text = "종료시간";
            // 
            // dtStart
            // 
            this.dtStart.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStart.Location = new System.Drawing.Point(76, 30);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(91, 21);
            this.dtStart.TabIndex = 0;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(150, 89);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(17, 12);
            this.label16.TabIndex = 1;
            this.label16.Text = "초";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(17, 89);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 1;
            this.label15.Text = "시간간격";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 34);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 1;
            this.label13.Text = "시작시간";
            // 
            // tbInterval
            // 
            this.tbInterval.Location = new System.Drawing.Point(76, 84);
            this.tbInterval.Name = "tbInterval";
            this.tbInterval.Size = new System.Drawing.Size(68, 21);
            this.tbInterval.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbEqOzon);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.tbEqHum);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.tbEqTotal);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.tbEqAir);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.tbEqWind);
            this.groupBox2.Controls.Add(this.tbEqTemp);
            this.groupBox2.Location = new System.Drawing.Point(12, 170);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(296, 137);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "환경정보";
            // 
            // tbEqOzon
            // 
            this.tbEqOzon.Location = new System.Drawing.Point(150, 60);
            this.tbEqOzon.MaxLength = 4;
            this.tbEqOzon.Name = "tbEqOzon";
            this.tbEqOzon.Size = new System.Drawing.Size(68, 21);
            this.tbEqOzon.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(224, 92);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 12);
            this.label12.TabIndex = 1;
            this.label12.Text = "종합(4)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(224, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "오존(4)";
            // 
            // tbEqHum
            // 
            this.tbEqHum.Location = new System.Drawing.Point(150, 33);
            this.tbEqHum.MaxLength = 4;
            this.tbEqHum.Name = "tbEqHum";
            this.tbEqHum.Size = new System.Drawing.Size(68, 21);
            this.tbEqHum.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(224, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "습도(4)";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbEqTotal
            // 
            this.tbEqTotal.Location = new System.Drawing.Point(150, 87);
            this.tbEqTotal.MaxLength = 4;
            this.tbEqTotal.Name = "tbEqTotal";
            this.tbEqTotal.Size = new System.Drawing.Size(68, 21);
            this.tbEqTotal.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "온도(4)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "풍속(4)";
            // 
            // tbEqAir
            // 
            this.tbEqAir.Location = new System.Drawing.Point(76, 87);
            this.tbEqAir.MaxLength = 1;
            this.tbEqAir.Name = "tbEqAir";
            this.tbEqAir.Size = new System.Drawing.Size(68, 21);
            this.tbEqAir.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 92);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 12);
            this.label11.TabIndex = 1;
            this.label11.Text = "대기(1)";
            // 
            // tbEqWind
            // 
            this.tbEqWind.Location = new System.Drawing.Point(76, 60);
            this.tbEqWind.MaxLength = 4;
            this.tbEqWind.Name = "tbEqWind";
            this.tbEqWind.Size = new System.Drawing.Size(68, 21);
            this.tbEqWind.TabIndex = 0;
            // 
            // tbEqTemp
            // 
            this.tbEqTemp.Location = new System.Drawing.Point(76, 33);
            this.tbEqTemp.MaxLength = 4;
            this.tbEqTemp.Name = "tbEqTemp";
            this.tbEqTemp.Size = new System.Drawing.Size(68, 21);
            this.tbEqTemp.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbEqCount);
            this.groupBox1.Controls.Add(this.tbEqBatt);
            this.groupBox1.Controls.Add(this.tbEqModel);
            this.groupBox1.Controls.Add(this.tbEqState);
            this.groupBox1.Controls.Add(this.tbEqLine);
            this.groupBox1.Controls.Add(this.tbEqCode);
            this.groupBox1.Location = new System.Drawing.Point(12, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 141);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "장비상태정보";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(224, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "가동횟수(5)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(224, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "BatteryV(5)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(224, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "장비모델(6)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "가동여부(1)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Line No.(5)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "장비코드(5)";
            // 
            // tbEqCount
            // 
            this.tbEqCount.Location = new System.Drawing.Point(150, 87);
            this.tbEqCount.MaxLength = 5;
            this.tbEqCount.Name = "tbEqCount";
            this.tbEqCount.Size = new System.Drawing.Size(68, 21);
            this.tbEqCount.TabIndex = 0;
            // 
            // tbEqBatt
            // 
            this.tbEqBatt.Location = new System.Drawing.Point(150, 60);
            this.tbEqBatt.MaxLength = 5;
            this.tbEqBatt.Name = "tbEqBatt";
            this.tbEqBatt.Size = new System.Drawing.Size(68, 21);
            this.tbEqBatt.TabIndex = 0;
            // 
            // tbEqModel
            // 
            this.tbEqModel.Location = new System.Drawing.Point(150, 33);
            this.tbEqModel.MaxLength = 6;
            this.tbEqModel.Name = "tbEqModel";
            this.tbEqModel.Size = new System.Drawing.Size(68, 21);
            this.tbEqModel.TabIndex = 0;
            // 
            // tbEqState
            // 
            this.tbEqState.Location = new System.Drawing.Point(76, 87);
            this.tbEqState.MaxLength = 1;
            this.tbEqState.Name = "tbEqState";
            this.tbEqState.Size = new System.Drawing.Size(68, 21);
            this.tbEqState.TabIndex = 0;
            // 
            // tbEqLine
            // 
            this.tbEqLine.Location = new System.Drawing.Point(76, 60);
            this.tbEqLine.MaxLength = 5;
            this.tbEqLine.Name = "tbEqLine";
            this.tbEqLine.Size = new System.Drawing.Size(68, 21);
            this.tbEqLine.TabIndex = 0;
            // 
            // tbEqCode
            // 
            this.tbEqCode.Location = new System.Drawing.Point(76, 33);
            this.tbEqCode.MaxLength = 5;
            this.tbEqCode.Name = "tbEqCode";
            this.tbEqCode.Size = new System.Drawing.Size(68, 21);
            this.tbEqCode.TabIndex = 0;
            // 
            // tbMonitor
            // 
            this.tbMonitor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMonitor.Location = new System.Drawing.Point(3, 3);
            this.tbMonitor.Multiline = true;
            this.tbMonitor.Name = "tbMonitor";
            this.tbMonitor.Size = new System.Drawing.Size(318, 436);
            this.tbMonitor.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dtStartTime
            // 
            this.dtStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtStartTime.Location = new System.Drawing.Point(173, 30);
            this.dtStartTime.Name = "dtStartTime";
            this.dtStartTime.ShowUpDown = true;
            this.dtStartTime.Size = new System.Drawing.Size(103, 21);
            this.dtStartTime.TabIndex = 2;
            // 
            // dtStopTime
            // 
            this.dtStopTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtStopTime.Location = new System.Drawing.Point(173, 57);
            this.dtStopTime.Name = "dtStopTime";
            this.dtStopTime.ShowUpDown = true;
            this.dtStopTime.Size = new System.Drawing.Size(103, 21);
            this.dtStopTime.TabIndex = 2;
            // 
            // frmEquip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 488);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(340, 520);
            this.Name = "frmEquip";
            this.Text = "Virtual Equipment";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuStart;
        private System.Windows.Forms.ToolStripMenuItem mnuStop;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sbLabel1;
        private System.Windows.Forms.ToolStripStatusLabel sbLabel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker dtStop;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbInterval;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbEqOzon;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbEqHum;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbEqTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbEqAir;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbEqWind;
        private System.Windows.Forms.TextBox tbEqTemp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbEqCount;
        private System.Windows.Forms.TextBox tbEqBatt;
        private System.Windows.Forms.TextBox tbEqModel;
        private System.Windows.Forms.TextBox tbEqState;
        private System.Windows.Forms.TextBox tbEqLine;
        private System.Windows.Forms.TextBox tbEqCode;
        private System.Windows.Forms.TextBox tbMonitor;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DateTimePicker dtStopTime;
        private System.Windows.Forms.DateTimePicker dtStartTime;
    }
}

