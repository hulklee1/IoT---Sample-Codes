namespace ChatSocket
{
    partial class frmSocket
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSocket));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStart = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuClientStart = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClientStop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuServerConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuServerIP = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuServerPort = new System.Windows.Forms.ToolStripMenuItem();
            this.clientConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClientIP = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClientPort = new System.Windows.Forms.ToolStripMenuItem();
            this.communicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSendEx = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sbLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Send = new System.Windows.Forms.ToolStripMenuItem();
            this.tbSend = new System.Windows.Forms.TextBox();
            this.tbReceive = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sbCombo1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.communicationToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(324, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStart,
            this.mnuStop,
            this.toolStripMenuItem1,
            this.mnuClientStart,
            this.mnuClientStop,
            this.toolStripMenuItem2,
            this.mnuExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mnuStart
            // 
            this.mnuStart.Checked = true;
            this.mnuStart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuStart.Name = "mnuStart";
            this.mnuStart.Size = new System.Drawing.Size(154, 22);
            this.mnuStart.Text = "Start Server";
            this.mnuStart.Click += new System.EventHandler(this.mnuStart_Click);
            // 
            // mnuStop
            // 
            this.mnuStop.Name = "mnuStop";
            this.mnuStop.Size = new System.Drawing.Size(154, 22);
            this.mnuStop.Text = "Stop";
            this.mnuStop.Click += new System.EventHandler(this.mnuStop_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(151, 6);
            // 
            // mnuClientStart
            // 
            this.mnuClientStart.Name = "mnuClientStart";
            this.mnuClientStart.Size = new System.Drawing.Size(154, 22);
            this.mnuClientStart.Text = "원격 서버 접속";
            this.mnuClientStart.Click += new System.EventHandler(this.mnuClientStart_Click);
            // 
            // mnuClientStop
            // 
            this.mnuClientStop.Name = "mnuClientStop";
            this.mnuClientStop.Size = new System.Drawing.Size(154, 22);
            this.mnuClientStop.Text = "접속 종료";
            this.mnuClientStop.Click += new System.EventHandler(this.mnuClientStop_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(151, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(154, 22);
            this.mnuExit.Text = "Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuServerConfig,
            this.clientConfigToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // mnuServerConfig
            // 
            this.mnuServerConfig.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuServerIP,
            this.mnuServerPort});
            this.mnuServerConfig.Name = "mnuServerConfig";
            this.mnuServerConfig.Size = new System.Drawing.Size(147, 22);
            this.mnuServerConfig.Text = "Server Config";
            // 
            // mnuServerIP
            // 
            this.mnuServerIP.Name = "mnuServerIP";
            this.mnuServerIP.Size = new System.Drawing.Size(133, 22);
            this.mnuServerIP.Text = "Server IP";
            this.mnuServerIP.Click += new System.EventHandler(this.mnuServerIP_Click);
            // 
            // mnuServerPort
            // 
            this.mnuServerPort.Name = "mnuServerPort";
            this.mnuServerPort.Size = new System.Drawing.Size(133, 22);
            this.mnuServerPort.Text = "Server Port";
            this.mnuServerPort.Click += new System.EventHandler(this.mnuServerPort_Click);
            // 
            // clientConfigToolStripMenuItem
            // 
            this.clientConfigToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuClientIP,
            this.mnuClientPort});
            this.clientConfigToolStripMenuItem.Name = "clientConfigToolStripMenuItem";
            this.clientConfigToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.clientConfigToolStripMenuItem.Text = "Client Config";
            // 
            // mnuClientIP
            // 
            this.mnuClientIP.Name = "mnuClientIP";
            this.mnuClientIP.Size = new System.Drawing.Size(96, 22);
            this.mnuClientIP.Text = "IP";
            this.mnuClientIP.Click += new System.EventHandler(this.mnuClientIP_Click);
            // 
            // mnuClientPort
            // 
            this.mnuClientPort.Name = "mnuClientPort";
            this.mnuClientPort.Size = new System.Drawing.Size(96, 22);
            this.mnuClientPort.Text = "Port";
            this.mnuClientPort.Click += new System.EventHandler(this.mnuClientPort_Click);
            // 
            // communicationToolStripMenuItem
            // 
            this.communicationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSendEx});
            this.communicationToolStripMenuItem.Name = "communicationToolStripMenuItem";
            this.communicationToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.communicationToolStripMenuItem.Text = "Communication";
            // 
            // mnuSendEx
            // 
            this.mnuSendEx.Name = "mnuSendEx";
            this.mnuSendEx.Size = new System.Drawing.Size(101, 22);
            this.mnuSendEx.Text = "Send";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.viewToolStripMenuItem.Text = "View";
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
            this.sbLabel2,
            this.sbLabel3,
            this.sbLabel4,
            this.sbCombo1});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 527);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(324, 24);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sbLabel1
            // 
            this.sbLabel1.AutoSize = false;
            this.sbLabel1.DoubleClickEnabled = true;
            this.sbLabel1.Name = "sbLabel1";
            this.sbLabel1.Size = new System.Drawing.Size(70, 19);
            this.sbLabel1.DoubleClick += new System.EventHandler(this.sbLabel1_DoubleClick);
            // 
            // sbLabel2
            // 
            this.sbLabel2.AutoSize = false;
            this.sbLabel2.DoubleClickEnabled = true;
            this.sbLabel2.Name = "sbLabel2";
            this.sbLabel2.Size = new System.Drawing.Size(34, 19);
            this.sbLabel2.DoubleClick += new System.EventHandler(this.sbLabel2_DoubleClick);
            // 
            // sbLabel3
            // 
            this.sbLabel3.AutoSize = false;
            this.sbLabel3.DoubleClickEnabled = true;
            this.sbLabel3.Name = "sbLabel3";
            this.sbLabel3.Size = new System.Drawing.Size(70, 19);
            this.sbLabel3.DoubleClick += new System.EventHandler(this.sbLabel3_DoubleClick);
            // 
            // sbLabel4
            // 
            this.sbLabel4.AutoSize = false;
            this.sbLabel4.DoubleClickEnabled = true;
            this.sbLabel4.Name = "sbLabel4";
            this.sbLabel4.Size = new System.Drawing.Size(40, 19);
            this.sbLabel4.DoubleClick += new System.EventHandler(this.sbLabel4_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Send});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(102, 26);
            // 
            // Send
            // 
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(101, 22);
            this.Send.Text = "Send";
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // tbSend
            // 
            this.tbSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSend.ContextMenuStrip = this.contextMenuStrip1;
            this.tbSend.Location = new System.Drawing.Point(3, 389);
            this.tbSend.Multiline = true;
            this.tbSend.Name = "tbSend";
            this.tbSend.Size = new System.Drawing.Size(318, 107);
            this.tbSend.TabIndex = 1;
            this.tbSend.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbSend_KeyUp);
            // 
            // tbReceive
            // 
            this.tbReceive.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbReceive.Location = new System.Drawing.Point(3, 3);
            this.tbReceive.Multiline = true;
            this.tbReceive.Name = "tbReceive";
            this.tbReceive.Size = new System.Drawing.Size(318, 380);
            this.tbReceive.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.tbReceive);
            this.panel1.Controls.Add(this.tbSend);
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(324, 499);
            this.panel1.TabIndex = 2;
            // 
            // sbCombo1
            // 
            this.sbCombo1.AutoSize = false;
            this.sbCombo1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sbCombo1.Image = ((System.Drawing.Image)(resources.GetObject("sbCombo1.Image")));
            this.sbCombo1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbCombo1.Name = "sbCombo1";
            this.sbCombo1.Size = new System.Drawing.Size(70, 22);
            // 
            // frmSocket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 551);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(340, 590);
            this.Name = "frmSocket";
            this.Text = "Socket Mamager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSocket_FormClosing);
            this.Load += new System.EventHandler(this.frmSocket_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuStart;
        private System.Windows.Forms.ToolStripMenuItem mnuStop;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuServerConfig;
        private System.Windows.Forms.ToolStripMenuItem communicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuSendEx;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sbLabel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox tbReceive;
        private System.Windows.Forms.ToolStripMenuItem Send;
        private System.Windows.Forms.TextBox tbSend;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem mnuServerIP;
        private System.Windows.Forms.ToolStripMenuItem mnuServerPort;
        private System.Windows.Forms.ToolStripMenuItem clientConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuClientIP;
        private System.Windows.Forms.ToolStripMenuItem mnuClientPort;
        private System.Windows.Forms.ToolStripStatusLabel sbLabel2;
        private System.Windows.Forms.ToolStripStatusLabel sbLabel3;
        private System.Windows.Forms.ToolStripStatusLabel sbLabel4;
        private System.Windows.Forms.ToolStripMenuItem mnuClientStart;
        private System.Windows.Forms.ToolStripMenuItem mnuClientStop;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripDropDownButton sbCombo1;
    }
}

