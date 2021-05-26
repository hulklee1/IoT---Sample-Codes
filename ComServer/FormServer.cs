using myLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComTest
{
    public partial class FormServer : Form
    {
        public FormServer()
        {
            InitializeComponent();
        }

        delegate void cbAddText(string str);  // string str을 인수로 받아서 tbServer에 출력하는 콜백 함수
        //    invoke
        void AddText(string str)    // Thread 내부에서 호출될 함수  tbServer 출력
        {
            if(tbServer.InvokeRequired)
            {
                cbAddText at = new cbAddText(AddText);
                object[] oArr = { str };
                Invoke(at, oArr);
            }
            else
            {
                tbServer.Text += str;   // Thread에서 수행해야 할 본래의 작업
            }
        }

        Thread thread = null;
        TcpListener listener = null;
        string mainMsg = "";
        private void btnStart_Click(object sender, EventArgs e)
        {
          //  ServerProcess();
            if (thread == null)
            {
                thread = new Thread(ServerProcess);
                thread.Start();
            }
            timer1.Start();
            sbServerMessage.Text = "Listener started..";
            AddText($"ServerProcess now started... Open Port is {tbServerPort}.");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            thread.Abort(); // thread.Suspend(); thread.Resume();
            thread = null;
            timer1.Stop();
            sbServerMessage.Text = "Server stopped..";
        }
        Socket sock = null;
        void ServerProcess()
        {
            while(true)
            {
                if (listener == null)
                {
                    listener = new TcpListener(int.Parse(tbServerPort.Text));
                    listener.Start();
                }
                if (listener.Pending())  // Non-Blocking Method
                {
                    //TcpClient tcp = listener.AcceptTcpClient();     // Blocking Method

                    //EndPoint ep = tcp.Client.RemoteEndPoint;
                    //sbServerLabel2.Text = ep.ToString(); // xxx.xxx.xxx.xxx  :xxxxx
                    //NetworkStream ns = tcp.GetStream();
                    //byte[] bArr = new byte[200];
                    //while(ns.DataAvailable)
                    //{
                    //    int n = ns.Read(bArr, 0, 200);
                    //    //tbServer.Text += Encoding.Default.GetString(bArr,0,n);  // Cross-thread error
                    //    //mainMsg += Encoding.Default.GetString(bArr,0,n);  // Cross-thread error
                    //    AddText(Encoding.Default.GetString(bArr, 0, n));
                    //}
                    if (sock != null) sock.Close();
                    sock = listener.AcceptSocket();    // Mission : TcpClient 가 아닌 Socket 을 이용해서 Accept 및 입력 stream 처리
                    ////////byte[] bArr = new byte[sock.Available];
                    ////////int n = sock.Receive(bArr);
                    ////////AddText(Encoding.Default.GetString(bArr, 0, n));

                    ////////sock.Send(Encoding.Default.GetBytes("OK"));

                    //IPEndPoint ep = (IPEndPoint)sock.RemoteEndPoint;  // 127.0.0.1:76543
                    //sbServerLabel2.Text = $"{ep.Address}:{ep.Port}";  // xxx.xxx.xxx.xxx  :xxxxx

                    sbServerLabel2.Text = $"{  mylib.GetToken(0, sock.RemoteEndPoint.ToString(), ':')}";  // xxx.xxx.xxx.xxx  :xxxxx
                    int j = mylib.Add(1, 2);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)  //     1/1000 초 단위로 tick 발생 
        {
            timer1.Stop();
            if(sock != null)
            {
                int n = sock.Available;
                if(n>0)
                {
                    byte[] bArr = new byte[n];
                    int m = sock.Receive(bArr);
                    AddText(Encoding.Default.GetString(bArr, 0, m));
                }
            }
            //////tbServer.Text += mainMsg;
            //////mainMsg = "";
            timer1.Start();
        }

        iniFile ini;
        private void FormServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            ini.SetString("Form", "LocX",$"{Location.X}");
            ini.SetString("Form", "LocY",$"{Location.Y}");

            ini.SetString("Form", "SizeX", $"{Size.Width}");
            ini.SetString("Form", "SizeY", $"{Size.Height}");

            ini.SetString("Form", "Splitter", $"{splitContainer1.SplitterDistance}");

            if(thread != null)
                thread.Abort(); // Thread 종료
        }

        private void FormServer_Load(object sender, EventArgs e)
        {
            int x1, y1, x2, y2;

            ini = new iniFile("");

            ini.ChangeFileName(".\\ComServer.ini");

            x1 = int.Parse(ini.GetString("Form", "LocX","0"));
            y1 = int.Parse(ini.GetString("Form", "LocY","0"));
            Location = new Point(x1, y1);

            x2 = int.Parse(ini.GetString("Form", "SizeX", "500"));
            y2 = int.Parse(ini.GetString("Form", "SizeY", "500"));
            Size = new Size(x2, y2);

            splitContainer1.SplitterDistance = int.Parse(ini.GetString("Form", "Splitter", "300"));
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

            sock.Send(Encoding.Default.GetBytes(tbClient.Text));
        }
    }
}
