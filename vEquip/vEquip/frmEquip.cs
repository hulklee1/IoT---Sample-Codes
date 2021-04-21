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

namespace vEquip
{
    public partial class frmEquip : Form
    {
        public frmEquip()
        {
            InitializeComponent();
        }

        iniFile ini = new iniFile(".\\vEquip.ini");
        private void Form1_Load(object sender, EventArgs e)
        {
            tbEqCode.Text  = ini.GetString("Equipment", "EqCode",  "00001");    // 5
            tbEqModel.Text = ini.GetString("Equipment", "EqModel", "000000");   // 6
            tbEqLine.Text  = ini.GetString("Equipment", "EqLine",  "00001");    // 5
            tbEqBatt.Text  = ini.GetString("Equipment", "EqBatt",  "00001");    // 5
            tbEqState.Text = ini.GetString("Equipment", "EqState", "00001");    // 1
            tbEqCount.Text = ini.GetString("Equipment", "EqCount", "00001");    // 5

            tbEqTemp.Text = ini.GetString("Environment", "EqTemp", "00001");      // 4
            tbEqHum.Text  = ini.GetString("Environment", "EqHum", "00001");       // 4
            tbEqWind.Text = ini.GetString("Environment", "EqWind", "00001");      // 4
            tbEqOzon.Text = ini.GetString("Environment", "EqOzon", "00001");      // 4
            tbEqAir.Text  = ini.GetString("Environment", "EqAir", "00001");       // 1
            tbEqTotal.Text = ini.GetString("Environment", "EqTotal", "00001");    // 4  : total 48 byte

            dtStart.Value = new DateTime(long.Parse(ini.GetString("Operation", "StartDate", "0")));
            dtStop.Value = new DateTime(long.Parse(ini.GetString("Operation", "StopDate", "0")));
            dtStartTime.Value = new DateTime(long.Parse(ini.GetString("Operation", "StartTime", "0")));
            dtStopTime.Value = new DateTime(long.Parse(ini.GetString("Operation", "StopTime", "0")));
            tbInterval.Text = ini.GetString("Operation", "Interval", "5");

            int x1, x2, y1, y2;
            sbLabel1.Text = ini.GetString("Server", "IP", "127.0.0.1");
            sbLabel2.Text = ini.GetString("Server", "Port", "9001");

            x1 = int.Parse(ini.GetString("Form", "LocationX", "0"));
            y1 = int.Parse(ini.GetString("Form", "LocationY", "0"));
            this.Location = new Point(x1, y1);

            x2 = int.Parse(ini.GetString("Form", "SizeX", "500"));
            y2 = int.Parse(ini.GetString("Form", "SizeY", "500"));
            this.Size = new Size(x2, y2);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ini.SetString("Equipment", "EqCode",  tbEqCode.Text );    // 5
            ini.SetString("Equipment", "EqModel", tbEqModel.Text);   // 6
            ini.SetString("Equipment", "EqLine",  tbEqLine.Text );    // 5
            ini.SetString("Equipment", "EqBatt",  tbEqBatt.Text );    // 5
            ini.SetString("Equipment", "EqState", tbEqState.Text);    // 1
            ini.SetString("Equipment", "EqCount", tbEqCount.Text);    // 5
                                                                
            ini.SetString("Environment", "EqTemp",tbEqTemp.Text );      // 4
            ini.SetString("Environment", "EqHum", tbEqHum.Text  );       // 4
            ini.SetString("Environment", "EqWind",tbEqWind.Text );      // 4
            ini.SetString("Environment", "EqOzon",tbEqOzon.Text );      // 4
            ini.SetString("Environment", "EqAir", tbEqAir.Text  );       // 1
            ini.SetString("Environment", "EqTotal",tbEqTotal.Text);    // 4  : total 48 byte

            ini.SetString("Operation", "StartDate", dtStart.Value.Ticks.ToString());
            ini.SetString("Operation", "StopDate", dtStop.Value.Ticks.ToString());
            ini.SetString("Operation", "StartTime", dtStartTime.Value.Ticks.ToString());
            ini.SetString("Operation", "StopTime", dtStopTime.Value.Ticks.ToString());
            ini.SetString("Operation", "Interval", tbInterval.Text);

            ini.SetString("Server", "IP", sbLabel1.Text);
            ini.SetString("Server", "Port", sbLabel2.Text);

            ini.SetString("Form", "LocationX", $"{Location.X}");
            ini.SetString("Form", "LocationY", $"{Location.Y}");
            ini.SetString("Form", "SizeX", $"{Size.Width}");
            ini.SetString("Form", "SizeY", $"{Size.Height}");

            if(threadRead != null) threadRead.Abort();
        }

        Socket sock = null;
        Thread threadRead = null;

        delegate void cbAddText(string str);
        void AddText(string str)
        {
            if (tbMonitor.InvokeRequired)
            {
                cbAddText cb = new cbAddText(AddText);
                Invoke(cb, new object[] { str });
            }
            else
            {
                tbMonitor.AppendText(str);
            }
        }

        void ReadProcess()
        {
            Socket lsock = sock;
            while(true)
            {
                lsock = sock;
                if(jslib.IsAlive(lsock) && lsock.Available > 0)
                {
                    byte[] bArr = new byte[lsock.Available];    // 필요한 버퍼 확보
                    lsock.Receive(bArr);
                    AddText(Encoding.Default.GetString(bArr) + "\r\n");
                }
                Thread.Sleep(100);
            }
        }

        private void mnuStart_Click(object sender, EventArgs e) // 처음 수행 시
        {
            if(sock != null) sock.Close();    // Re-Start 상황  
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sock.Connect(sbLabel1.Text, int.Parse(sbLabel2.Text));

            if(threadRead != null) threadRead.Abort(); // Re-Start 상황  
            threadRead = new Thread(ReadProcess);
            threadRead.Start();

            try
            {
                timer1.Interval = int.Parse(tbInterval.Text) * 1000;    // 주기적으로 계속 인터럽트 생성
                timer1.Start();
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void mnuStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (threadRead != null) { threadRead.Abort(); threadRead = null; }
            if (sock != null) { sock.Close(); sock = null; }
        }

        private void sbLabel1_DoubleClick(object sender, EventArgs e)
        {
            string str = jslib.GetInput("IP Address");
            if (str != "") sbLabel1.Text = str;
        }

        private void sbLabel2_DoubleClick(object sender, EventArgs e)
        {
            string str = jslib.GetInput("Port");
            if (str != "") sbLabel2.Text = str;
        }

        char STX = '\u0002';
        char ETX = '\u0003';

        //int n = 123;
        //string ss = "123";  // string ---> int.parse
        //string str = $"[{n}]";      // ===> [123] 
        //string str = $"[{n,6}]";        // ===> [___123] 
        //string str = $"[{n,-6}]";       // ===> [123___]
        //string str = $"[{n,6:D}]";      // ===> [___123] 
        //string str = $"[{n,6:D5}]";     	// ===> [_00123] 

        //  tbEqCode.Text   : String : 5
        //  tbEqModel.Text  ; String : 6
        //  tbEqLine.Text   : String : 5
        //  tbEqBatt.Text   : float  : 5  1.11
        //  tbEqState.Text  : int    : 1
        //  tbEqCount.Text  : int    : 5      
        //  tbEqTemp.Text   : int    : 4      
        //  tbEqHum.Text    : int    : 4      
        //  tbEqWind.Text   : int    : 4      
        //  tbEqOzon.Text   : int    : 4      
        //  tbEqAir.Text    : int    : 1      
        //  tbEqTotal.Text  : int    : 4
        //  ===========================48


        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            if(CheckInTime())
            {
                SetRandomValue();
            //  Packet 구성 : 패킷의 전후에 [02]STX  [03]ETX 문자를 덧붙인다.
                string str = $"{STX}";
                str       += $"{tbEqCode.Text,5}{tbEqModel.Text,6}{tbEqLine.Text,5}{float.Parse(tbEqBatt.Text),5:F2}";
                str       += $"{tbEqState.Text,1}{int.Parse(tbEqCount.Text):D5}";
                str       += $"{int.Parse(tbEqTemp.Text):D4}{int.Parse(tbEqHum.Text):D4}{int.Parse(tbEqWind.Text):D4}";
                str       += $"{int.Parse(tbEqOzon.Text):D4}{int.Parse(tbEqAir.Text):D1}{int.Parse(tbEqTotal.Text):D4}";
                str       += $"{ETX}";

                byte[] ba = Encoding.Default.GetBytes(str);
                if (jslib.IsAlive(sock))
                {
                    sock.Send(ba);
                    tbEqCount.Text = $"{int.Parse(tbEqCount.Text) + 1}"; 
                }
            }
            timer1.Start();
        }
        void SetRandomValue()
        {
            Random r = new Random();
            tbEqTemp.Text = $"{r.Next(-50,50)}";
            tbEqHum.Text  = $"{r.Next(0,99)}";
            tbEqWind.Text = $"{r.Next(0,99)}";
            tbEqOzon.Text = $"{r.Next(0,99)}";
        }

        bool CheckInTime()
        {
            DateTime dt = DateTime.Now;
            DateTime st = dtStart.Value.Date + dtStartTime.Value.TimeOfDay;
            DateTime et = dtStop.Value.Date + dtStopTime.Value.TimeOfDay;

            return st < dt && dt < et;
        }
    }
}
