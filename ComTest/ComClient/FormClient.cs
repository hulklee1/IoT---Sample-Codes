using myLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComClient
{
    public partial class FormClient : Form
    {
        public FormClient()
        {
            InitializeComponent();
        }

        string Init_IP = "";
        int Init_Port = 0;
        Socket sock = null;
        Thread thread = null;
        Thread SessionThread = null;

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if(sock == null)
            {
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }
            sock.Connect(tbIP.Text, int.Parse(tbPort.Text));

            if(thread == null)
            {
                thread = new Thread(ClientProcess);
                thread.Start();
                SessionThread = new Thread(SessionProcess);
                SessionThread.Start();
            }
        }

        delegate void cbAddText(string str);

        void AddText(string str)
        {
            if(tbClient.InvokeRequired)
            {
                cbAddText at = new cbAddText(AddText);
                object[] oArr = { str };
                Invoke(at, oArr);
            }
            else
            {
                tbClient.Text += str;
            }
        }

        void ClientProcess()
        {
            while(true)
            {
                if(sock != null && sock.Connected)
                {
                    int n = sock.Available;   // 소켓에 읽을 데이타의 크기 
                    if(n > 0)
                    {
                        byte[] bArr = new byte[n];
                        sock.Receive(bArr);
                        AddText(Encoding.Default.GetString(bArr));
                        //tbClient.Text += Encoding.Default.GetString(bArr);
                    }
                }
                Thread.Sleep(100);
            }
        }

        void SessionProcess()
        {
            while(true)
            {
                if(sock != null)
                {
                    if (sock.Connected)
                        sblState.Text = "Connection Alive";
                    else
                    {
                        sblState.Text = "disconnected";
                        sock = null;
                    }
                }
                Thread.Sleep(100);
            }
        }
        iniFile ini;
        private void FormClient_Load(object sender, EventArgs e)
        {
            int x1, y1, x2, y2;

            ini = new iniFile(".\\ComClient.ini");

            Init_IP = ini.GetString("Comm", "IP", "127.0.0.1");
            Init_Port = int.Parse(ini.GetString("Comm", "Port", "9001"));
            x1 = int.Parse(ini.GetString("Form", "LocX", $"0"));
            y1 = int.Parse(ini.GetString("Form", "LocY", $"0"));
            x2 = int.Parse(ini.GetString("Form", "SizeX", $"500"));
            y2 = int.Parse(ini.GetString("Form", "SizeY", $"500"));
            splitContainer1.SplitterDistance = int.Parse(ini.GetString("Form", "Splitter", $"300"));

            Location = new Point(x1, y1);
            Size = new Size(x2, y2);
            tbIP.Text = Init_IP;
            tbPort.Text = $"{Init_Port}";
        }

        private void FormClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            ini.SetString("Comm", "IP", tbIP.Text);
            ini.SetString("Comm", "Port", tbPort.Text);
            ini.SetString("Form", "LocX", $"{Location.X}");
            ini.SetString("Form", "LocY", $"{Location.Y}");
            ini.SetString("Form", "SizeX", $"{Size.Width}");
            ini.SetString("Form", "SizeY", $"{Size.Height}");
            ini.SetString("Form", "Splitter", $"{splitContainer1.SplitterDistance}");

            if (thread != null) thread.Abort();
            if (SessionThread != null) SessionThread.Abort();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if(sock != null)
                sock.Send(Encoding.Default.GetBytes(tbClient.Text));
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (sock != null)
                sock.Close();            
        }
    }
}
