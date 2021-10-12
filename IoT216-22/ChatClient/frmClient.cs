using jsLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatManager
{
    public partial class frmClient : Form
    {
        public frmClient()
        {
            InitializeComponent();
        }

        delegate void cbAddText(string s);
        void AddText(string str)
        {
            if(tbReceive.InvokeRequired)
            {
                cbAddText cb = new cbAddText(AddText);
                object[] oArr = { str };
                Invoke(cb, oArr);
                //Invoke(cb, new object[] { str });
            }
            else
            {
                tbReceive.AppendText(str) ;  // byte[]의 Size 만큼 변환 (NULL 포함)
            }
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            int size1 = 200; // splitContainer1.Panel2 의 사이즈

            splitContainer1.SplitterDistance = splitContainer1.Size.Width - size1;
        }

        Thread threadClient = null;
        Socket sock = null;        

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if(sock == null)
                {
                    sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                }
                else
                {
                    if(threadClient != null)
                    {
                        threadClient.Abort();
                        threadClient = null;
                    }
                    sock.Close();
                    //sock = null;
                    sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                }
                sock.Connect(tbIP.Text, int.Parse(tbPort.Text));    // Blocking mode : TimeOut 발생 전까지 (2~4초)
                //Thread ConThread = new Thread(ConnectProcess);
                //ConThread.Start();
                //while (true)
                //{
                //    if (!ConThread.IsAlive) break;
                //}

                sbLabel1.Text = ((IPEndPoint)(sock.RemoteEndPoint)).Address.ToString();
                sbLabel2.Text = ((IPEndPoint)(sock.RemoteEndPoint)).Port.ToString();

                if(threadClient == null)
                {
                    threadClient = new Thread(ClientProcess);
                    threadClient.Start();
                }
            }
            catch(Exception e1)
            {
                tbReceive.AppendText(e1.Message + "\r\n");
            }
        }

        void ConnectProcess()
        {
            sock.Connect(tbIP.Text, int.Parse(tbPort.Text));
            return;
        }

        void ClientProcess()    // Thread 등록 프로세스
        {
            while(true)
            {
                int n = sock.Available;
                if(n>0 && sock.Connected)
                {
                    byte[] bArr = new byte[n];
                    sock.Receive(bArr);  // c#에서의 통신은 byte[] - Byte Array :      c/c++ char
                    AddText(Encoding.Default.GetString(bArr));
                    //tbReceive.AppendText(Encoding.Default.GetString(bArr)) ;  // byte[]의 Size 만큼 변환 (NULL 포함)
                }
            }
        }

        private void brnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if(sock.Connected == true)
                {
                    string str = tbSend.Text.Trim();  // multi line  \r\n CRLF
                    string[] sArr = str.Split('\r');
                    string sLast = sArr[sArr.Length - 1];
                    sock.Send(Encoding.Default.GetBytes(sLast));
                }
                else
                {
                    AddText("서버와의 통신이 원활하지 않습니다.\r\n 연결을 점검하고 다시 시도하세요\r\n");
                }
            }
            catch(Exception e1)
            {
                AddText(e1.Message);
            }
        }

        iniFile ini = new iniFile(".\\ChatClient.ini");
        private void frmClient_Load(object sender, EventArgs e)
        {
            int x1, x2, y1, y2;
            tbIP.Text = ini.GetString("Server", "IP", "127.0.0.1");
            tbPort.Text = ini.GetString("Server", "Port", "9001");

            x1 = int.Parse(ini.GetString("Form", "LocationX", "0"));
            y1 = int.Parse(ini.GetString("Form", "LocationY", "0"));
            this.Location = new Point(x1, y1);

            x2 = int.Parse(ini.GetString("Form", "SizeX", "500"));
            y2 = int.Parse(ini.GetString("Form", "SizeY", "500"));
            this.Size = new Size(x2, y2);
        }

        private void frmClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            ini.SetString("Server", "IP", tbIP.Text );    
            ini.SetString("Server", "Port", tbPort.Text); 
            ini.SetString("Form", "LocationX", $"{Location.X}");
            ini.SetString("Form", "LocationY", $"{Location.Y}");
            ini.SetString("Form", "SizeX", $"{Size.Width}");   
            ini.SetString("Form", "SizeY", $"{Size.Height}");

            if (threadClient != null)
                threadClient.Abort();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s1 = "123";
            string s2 = "456123";
            string s3 = "789123";
            int s4 = int.Parse(textBox1.Text);

            string str = $"s1:{s1,-05}    s2:{s2,07}   s3:{s3,7}   s4:{s4,-10:D7}";
            AddText(str);
        }
    }
}
