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

namespace ChatSocket
{
    public partial class frmSocket : Form
    {
        public frmSocket()
        {
            InitializeComponent();
        }

        //byte[] sAddress = { 0, 0, 0, 0 };  // (127.0.0.1 XXX) : 서버에서 Bind 하기 위한 포트 어드레스
        string sAddress = "0.0.0.0";  // (127.0.0.1 XXX) : 서버에서 Bind 하기 위한 포트 어드레스
        string sPort = "9001";

        string cAddress = "";
        string cPort = "";

        Socket sockServer = null; // Socket을 이용한 서버 프로그램 (Listener 미사용)
        Socket sock = null;
        Thread threadServer = null;
        Thread threadRead = null;
        Thread threadSession = null;
        private void mnuStart_Click(object sender, EventArgs e)
        {
            mnuClientStart.Enabled = false;
            mnuClientStop.Enabled = false;
            this.Text = "Socket Manager - Server Mode";

            if (sockServer == null)
            {
                sockServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }
            else
            {
                if (threadServer != null)
                    threadServer.Abort();
                if (threadRead != null)
                    threadRead.Abort();
                if (threadSession != null)
                    threadSession.Abort();

                sockServer.Close();
                sockServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }
            if(threadServer == null)
            {
                threadServer = new Thread(ServerProcess);
                threadServer.Start();
            }
            if(threadRead == null)
            {
                threadRead = new Thread(ReadProcess);
                threadRead.Start();
            }
            if(threadSession == null)
            {
                threadSession = new Thread(SessionProcess);
                threadSession.Start();
            }
            AddText($"Chat server가 [{sPort}] 포트에서 시작되었습니다.\r\n");
        }

        private void mnuStop_Click(object sender, EventArgs e)
        {
            sock.Close();
            sockServer.Close();
            threadServer.Abort();
            threadRead.Abort();

            mnuClientStart.Enabled = true;
            mnuClientStop.Enabled = true;
            this.Text = "Socket Manage";

            AddText($"Chat server가 종료되었습니다.\r\n");
        }


        byte[] GetIPBytes(string str)  // str "127.0.0.1"  ==> byte[] bArr { 127, 0, 0, 1 }
        {
            string[] sa = str.Split('.');
            byte[] ba = new byte[4];
            if (sa.Length != 4) return null;  // 문자열 오류
            for(int i=0;i<4;i++) // foreach
            {
                ba[i] = byte.Parse(sa[i]);
            }
            return ba;
        }

        bool Pending = false;   // 외부로부터의 접속 요청 수신중
        IAsyncResult ar;
        private void OnAccept(IAsyncResult iar)
        {
            Pending = true;
            ar = iar;
        }
        private Socket acceptSocket()
        {
            Socket sock1 = sockServer.EndAccept(ar);                // non Blocking method End  :  실제 소켓을 전달     
            sockServer.BeginAccept(new AsyncCallback(OnAccept), null); // Start listening for next clients requirement
            Pending = false;
            return sock1;
        }

        void DoRead()  // 쓰레드 재 설정
        {
            if(threadRead != null)
            {
                threadRead.Abort(); threadRead = null;
            }
            threadRead = new Thread(ReadProcess);
            threadRead.Start();
        }

        void DoSession()  // 쓰레드 재 설정
        {
            if(threadSession != null)
            {
                threadSession.Abort(); threadSession = null;
            }
            threadSession = new Thread(SessionProcess);
            threadSession.Start();
        }

        //TcpListener listener;
        void ServerProcess()
        {
            //listener.Start();
            IPAddress IP = new IPAddress(GetIPBytes(sAddress));
            IPEndPoint ep = new IPEndPoint(IP, int.Parse(sPort));
            sockServer.Bind(ep);
            sockServer.Listen(10);
            
            sockServer.BeginAccept(new AsyncCallback(OnAccept),null);   // non Blocking method Start
            while (true)
            {
                if (Pending)
                {
                    sock = acceptSocket(); DoRead();
                    AddText($"Remote EndPoint {sock.RemoteEndPoint.ToString()} 로부터 접속되었습니다.\r\n");
                }
                Thread.Sleep(100);
            }
        }

        delegate void cbAddText(string str);
        void AddText(string str)
        {
            if(tbReceive.InvokeRequired)
            {
                cbAddText cb = new cbAddText(AddText);
                Invoke(cb, new object[] { str });
            }
            else
            {
                tbReceive.AppendText(str);
            }
        }

        void ReadProcess()
        {
            while(true)
            {
                if(sock != null && sock.Available > 0)
                {
                    byte[] bArr = new byte[sock.Available]; // 필요한 만큼 배열 선언
                    sock.Receive(bArr);
                    AddText($"{sock.RemoteEndPoint.ToString()}>{Encoding.Default.GetString(bArr)}\r\n");
                }
            }
        }

        void SendText(string str)
        {
            sock.Send(Encoding.Default.GetBytes(str));
            AddText($"=======> {tbSend.Text}\r\n");
        }

        private void Send_Click(object sender, EventArgs e)   // PopupMenu - Send (selected Text)
        {
            if(tbSend.SelectionLength > 0)
                SendText(tbSend.SelectedText);
            else SendText(tbSend.Text);
        }

        iniFile ini = new iniFile(".\\ChatSocket.ini");

        private void frmSocket_FormClosing(object sender, FormClosingEventArgs e)
        {
            ini.SetString("Server", "IP", sAddress);
            ini.SetString("Server", "Port", sPort);

            ini.SetString("Client", "IP", cAddress);
            ini.SetString("Client", "Port", cPort);

            ini.SetString("Form", "LocationX", $"{Location.X}");
            ini.SetString("Form", "LocationY", $"{Location.Y}");
            ini.SetString("Form", "SizeX", $"{Size.Width}");
            ini.SetString("Form", "SizeY", $"{Size.Height}");

            if (threadServer != null)
                threadServer.Abort();
            if (threadRead != null)
                threadRead.Abort();
            if (threadSession != null)
                threadSession.Abort();
        }

        private void frmSocket_Load(object sender, EventArgs e)
        {
            int x1, x2, y1, y2;

            sPort = ini.GetString("Server", "Port", "9001");
            sAddress = ini.GetString("Server", "IP", "0.0.0.0");

            cPort = ini.GetString("Client", "Port", "9001");
            cAddress = ini.GetString("Client", "IP", "127.0.0.1");

            sbLabel1.Text = sAddress; sbLabel2.Text = sPort;
            sbLabel3.Text = cAddress; sbLabel4.Text = cPort;

            x1 = int.Parse(ini.GetString("Form", "LocationX", "0"));
            y1 = int.Parse(ini.GetString("Form", "LocationY", "0"));
            this.Location = new Point(x1, y1);

            x2 = int.Parse(ini.GetString("Form", "SizeX", "500"));
            y2 = int.Parse(ini.GetString("Form", "SizeY", "500"));
            this.Size = new Size(x2, y2);
        }

        private void tbSend_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SendText(tbSend.Text);
                tbSend.Clear();
            }
        }

        private void mnuServerIP_Click(object sender, EventArgs e)
        {
            string str = jslib.GetInput("Server IP Address");
            if (str != "")  //  DialogResult.OK
                sAddress = str;
            sbLabel1.Text = sAddress;
        }

        private void mnuServerPort_Click(object sender, EventArgs e)
        {
            string str = jslib.GetInput("Server Port");
            if (str != "")  //  DialogResult.OK
            {
                try
                {
                    int n = int.Parse(str);
                    sPort = str;
                }
                catch(Exception e1)
                {
                    MessageBox.Show("포트 입력값에 문제가 있습니다.");
                }
                sbLabel2.Text = sPort;
            }
        }

        private void mnuClientIP_Click(object sender, EventArgs e)
        {
            string str = jslib.GetInput("Client IP Address");
            if (str != "")  //  DialogResult.OK
                cAddress = str;
            sbLabel3.Text = cAddress;
        }

        private void mnuClientPort_Click(object sender, EventArgs e)
        {
            string str = jslib.GetInput("Clien Port");
            if (str != "")  //  DialogResult.OK
            {
                try
                {
                    int n = int.Parse(str);
                    cPort = str;
                }
                catch(Exception e1)
                {
                    MessageBox.Show("포트 입력값에 문제가 있습니다.");
                }
                sbLabel4.Text = cPort;
            }
        }

        private void sbLabel1_DoubleClick(object sender, EventArgs e)
        {
            mnuServerIP_Click(sender, e);
        }

        private void sbLabel2_DoubleClick(object sender, EventArgs e)
        {
            mnuServerPort_Click( sender,  e);
        }

        private void sbLabel3_DoubleClick(object sender, EventArgs e)
        {
            mnuClientIP_Click( sender,  e);
        }

        private void sbLabel4_DoubleClick(object sender, EventArgs e)
        {
            mnuClientPort_Click(sender, e);
        }

        Socket csock = null;
        private void mnuClientStart_Click(object sender, EventArgs e)
        {
            mnuStart.Enabled = false;
            mnuStop.Enabled = false;
            this.Text = "Socket Manager - Client Mode";

            if (csock == null)
            {
                csock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }
            csock.Connect(cAddress, int.Parse(cPort));  // Blocking method
            sock = csock;
            DoRead();
            DoSession();
        }

        private void mnuClientStop_Click(object sender, EventArgs e)
        {
            mnuStart.Enabled = true;
            mnuStop.Enabled = true;
            this.Text = "Socket Manager";
        }
        delegate void cbThread(int n);

        void ChangeColor(int n)
        {
            if (statusStrip1.InvokeRequired)
            {
                cbThread cb = new cbThread(ChangeColor);
                Invoke(cb, new object[] { n });
            }
            else
            {
                if (n == 1)
                {
                    sbLabel1.BackColor = Color.GreenYellow;
                }
                else
                {
                    sbLabel1.BackColor = Color.PaleVioletRed;
                }
            }
        }

        void SessionProcess()
        {
            while(true)
            {
                if(sock != null && sock.Connected)
                {
                    ChangeColor(1);
                    //sbLabel1.BackColor = Color.GreenYellow;
                }
                else
                {
                    ChangeColor(2);
                    //sbLabel1.BackColor = Color.PaleVioletRed;
                    sock = null;
                }
                Thread.Sleep(100);
            }
        }
    }
}
