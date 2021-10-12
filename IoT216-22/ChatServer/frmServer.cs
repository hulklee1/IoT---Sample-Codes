using jsLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatServer
{
    public partial class frmServer : Form
    {
        public frmServer()
        {
            InitializeComponent();
        }

        delegate void CB(string str);
        void AddText(string str)
        {
            if(tbReceive.InvokeRequired)
            {
                CB cb = new CB(AddText);
                Invoke(cb, new object[] { str });
            }
            else
            {
                tbReceive.AppendText(str);
            }
        }

        string TmpString = "";
        Thread threadServer = null;
        Thread threadRead = null;
        TcpListener listener = null;
        TcpClient tcp = null;
        private void btnStart_Click(object sender, EventArgs e)
        {
            if(listener == null)
            {
                listener = new TcpListener(int.Parse(tbPort.Text));
                listener.Start();
                sbLabel1.Text = "Server Started.";
            }
            //      ServerProcess();
            if (threadServer == null)
            {
                threadServer = new Thread(ServerProcess);
                threadServer.Start();
                threadRead = new Thread(ReadProcess);
            }
        }

        void ServerProcess()
        {
            while (true)
            {
                if (listener.Pending() == true) // 접속 요청이 있는 경우...
                {
                    tcp = listener.AcceptTcpClient(); // 블로킹 모드
                    AddText($"Remote EndPoint {tcp.Client.RemoteEndPoint.ToString()} 로부터 접속되었습니다.\r\n");
                    threadRead.Start();
                }
                Thread.Sleep(100);
            }
        }

        void ReadProcess()
        {
            if(tcp != null)
            {
                NetworkStream ns = tcp.GetStream();
                byte[] bArr = new byte[50];
                while (true)
                {
                    while (ns.DataAvailable)
                    {
                        int n = ns.Read(bArr, 0, 50);
                        AddText(Encoding.Default.GetString(bArr, 0, n)+"\r\n");
                        //tbReceive.Text += Encoding.Default.GetString(bArr, 0, n);
                    }
                }
            }
        }

        iniFile ini = new iniFile(".\\ChatServer.ini");
        private void frmServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            ini.SetString("Server", "Port", tbPort.Text);
            ini.SetString("Form", "LocationX", $"{Location.X}");
            ini.SetString("Form", "LocationY", $"{Location.Y}");
            ini.SetString("Form", "SizeX", $"{Size.Width}");
            ini.SetString("Form", "SizeY", $"{Size.Height}");

            if (threadServer != null)
                threadServer.Abort();
            if (threadRead != null)
                threadRead.Abort();
        }

        private void frmServer_Load(object sender, EventArgs e)
        {
            int x1, x2, y1, y2;
            tbPort.Text = ini.GetString("Server", "Port", "9001");

            x1 = int.Parse(ini.GetString("Form", "LocationX", "0"));
            y1 = int.Parse(ini.GetString("Form", "LocationY", "0"));
            this.Location = new Point(x1, y1);

            x2 = int.Parse(ini.GetString("Form", "SizeX", "500"));
            y2 = int.Parse(ini.GetString("Form", "SizeY", "500"));
            this.Size = new Size(x2, y2);
        }

        private void strSend(string str)
        {
            if(tcp != null)
            {
                NetworkStream ns = tcp.GetStream(); // Read & Write

                byte[] bArr = Encoding.Default.GetBytes(str);
                ns.Write(bArr, 0, bArr.Length);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            strSend(tbSend.Text);
        }

        private void tbSend_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                int lineNo = tbSend.GetLineFromCharIndex(tbSend.SelectionStart);
                string[] sArr = tbSend.Text.Split('\n');
                string str = sArr[lineNo - 1] + "\n";
                strSend(str);

                //strSend(tbSend.Text.Split('\n')[tbSend.GetLineFromCharIndex(tbSend.SelectionStart) - 1] + "\n");
            }
        }

        private void mnuSend_Click(object sender, EventArgs e)
        {
            strSend(tbSend.SelectedText);
        }
    }
}
