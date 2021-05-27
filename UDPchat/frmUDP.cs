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

namespace chatUDP
{
    public partial class frmUDP : Form
    {
        public frmUDP()
        {
            InitializeComponent();
        }

        Socket udpServer = null;
        Thread threadRead = null;
        private void mnuStart_Click(object sender, EventArgs e)
        {   // 1. socket 생성     2. EndPoint 구성      3. Binding         (4. Listening xxx)
            if(udpServer == null)
            {
                udpServer = new Socket(AddressFamily.InterNetwork,SocketType.Dgram,ProtocolType.Udp);
            }
            //IPEndPoint ep = new IPEndPoint(IPAddress.Parse(sbLabel3.Text), int.Parse(sbLabel4.Text)); // 특정 주소 (sbLabel3)로 들어오는 메시지 
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, int.Parse(sbLabel2.Text)); // sbLabel2 (개방포트)로 들어오는 모든 메시지 
            udpServer.Bind(ep);

            if(threadRead == null)
            {
                threadRead = new Thread(ReadProcess);
                threadRead.Start();
            }
        }

        delegate void cbAdd(string s);
        void AddText(string str)
        {
            if(tbMemo.InvokeRequired)
            {
                cbAdd cb = new cbAdd(AddText);
                Invoke(cb, new object[] { str });
            }
            else
            {
                tbMemo.AppendText(str);
            }
        }

        void ReadProcess()
        {
            while(true)
            {
                if(udpServer.Available > 0)
                {
                    byte[] bArr = new byte[udpServer.Available];
                    udpServer.Receive(bArr);
                    AddText(Encoding.Default.GetString(bArr));
                }
                Thread.Sleep(100);
            }
        }

        private void sbLabel1_DoubleClick(object sender, EventArgs e)
        {
            sbLabel1.Text = jslib.GetInput("IP Address");
        }
        private void sbLabel2_DoubleClick(object sender, EventArgs e) // Port change
        {
            sbLabel2.Text = jslib.GetInput("Port");
        }
        private void sbLabel3_DoubleClick(object sender, EventArgs e)
        {
            sbLabel3.Text = jslib.GetInput("IP Address");
        }
        private void sbLabel4_DoubleClick(object sender, EventArgs e)
        {
            sbLabel4.Text = jslib.GetInput("Port");
        }

        void UDPSend(string str)  // UDP 송신 : 1.Socket(1회성) 생성  2.EndPoint 구성   3.Send 끝
        {
            Socket lsock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(sbLabel1.Text), int.Parse(sbLabel2.Text));
            lsock.SendTo(Encoding.Default.GetBytes(str), ep);
        }
        private void mnuSend_Click(object sender, EventArgs e)  // UDP 송신 : 1.Socket(1회성) 생성  2.EndPoint 구성   3.Send 끝
        {
            UDPSend(tbSend.Text);
        }

        private void frmUDP_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(threadRead != null)  threadRead.Abort();
        }
    }
}
