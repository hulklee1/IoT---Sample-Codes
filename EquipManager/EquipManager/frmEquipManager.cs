using jsLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquipManager
{
    public partial class frmEquipManager : Form
    {
        public frmEquipManager()
        {
            InitializeComponent();
        }

        delegate void cbAddText(string str);
        void AddText(string str)
        {
            if(tbMonitor.InvokeRequired)
            {
                cbAddText cb = new cbAddText(AddText);
                Invoke(cb,new object[] { str });
            }
            else
            {
                tbMonitor.AppendText(str);
            }
        }

        List<Socket> socks = new List<Socket>();
        Socket sock = null;  // Client - Server
        TcpListener listener = null;
        Thread threadServer = null;
        Thread threadRead = null;

        private void mnuServerStart_Click(object sender, EventArgs e)
        {
            if(listener == null) listener = new TcpListener(int.Parse(tbServerPort.Text)); // 9001
            else  listener.Stop();  // 임시 정지
            listener.Start();

            if(threadServer != null) threadServer.Abort();  // 완전 종결
            threadServer = new Thread(ServerProcess);
            threadServer.Start();

            if(threadRead != null) threadRead.Abort();  // 완전 종결
            threadRead = new Thread(ReadProcess);
            threadRead.Start();
        }

        void ServerProcess()
        {
            while(true)
            {
                if(listener.Pending()) // 접속요청이 있는가?   :  non-Blocking
                {
                    Socket sockT = listener.AcceptSocket();    // 외부로부터의 접속 요청 수락  : Blocking Method - 아무것도 못하고 기다림
                    socks.Add(sockT);
                }
                Thread.Sleep(100);
            }
        }

        void ReadProcess()
        {
            while(true)
            {
                for(int i=0;i<socks.Count;i++)
                {
                    Socket lsock = socks[i];
                    if (jslib.IsAlive(lsock) == false) continue;
                    if(lsock.Available > 0)
                    {
                        byte[] bArr = new byte[lsock.Available];
                        lsock.Receive(bArr);
                        ReadProc(lsock, bArr);
                    }
                }
                Thread.Sleep(100);
            }
        }

        string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HulkL\source\repos\EquipManager\EquipDatabase.mdf;Integrated Security=True;Connect Timeout=30";
        SQLDB db1 = null;   // for Read Thread
        SQLDB db2 = null;   // for Timer
        string sTable = "fStatus";
        //2021-04-22 오후 2:56:03:[02]00001000000    113.14100297001100770059006011234[03]
        //2021-04-22 오후 2:56:04:[02]00001000000    113.14100293000900220001005811234[03] : size 50
        void ReadProc(Socket ss, byte[] bArr)
        {
            string str = Encoding.Default.GetString(bArr);

            string sCode  = str.Substring( 1, 5);  //: String : 5  0
            string sModel = str.Substring( 6, 6);  //; String : 6  5
            string sLine  = str.Substring(12, 5);  //: String : 5  11
            string sBatt  = str.Substring(17, 5);  //: float  : 5  16     _1.11
            string sState = str.Substring(22, 1);  //: int    : 1  21
            string sCount = str.Substring(23, 5);  //: int    : 5  22
            string sTemp  = str.Substring(28, 4);  //: int    : 4  27
            string sHum   = str.Substring(32, 4);  //: int    : 4  31
            string sWind  = str.Substring(36, 4);  //: int    : 4  35
            string sOzon  = str.Substring(40, 4);  //: int    : 4  39
            string sAir   = str.Substring(44, 1);  //: int    : 1  43
            string sTotal = str.Substring(45, 4);  //: int    : 4  44
            string sTime  = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            jslib.WriteLog(str);    // write Log 
            AddText(ss.RemoteEndPoint.ToString() + "> ");  // 127.0.0.1:12345> ==> 줄바꿈 없음.
            AddText(str + "\r\n");
            // AddText($"{sCode},{sModel},{sLine},{sBatt},{sState},{sCount},{sTemp},{sHum},{sWind},{sOzon},{sAir},{sTotal}\r\n");
            // 127.0.0.1:12345> [02]00001000000    113.14100293000900220001005811234[03]
            //  00001,000000,    1,13.14,1,00293,0009,0022,0001,0058,1,1234

            // 1. 수신한 데이터에 대한 기존 기록 검색  :  ExcuteScalar
            //   - 기존(fCode)가 없다면  ----> Insert
            //   -               있다면  ----> Update
            //                                 기존 기록중 가장 마지막 기록을 검색하여 update
            //   update fstatus set fbatt=00.00 select top 1 * from fstatus where fcode=00001 order by ftime desc

            string sql;
            int n = (int)db1.Get($"select count(*) from {sTable} where fCode='{sCode}'");
            ////DataTable dt = (DataTable)RunSql(sql,1);
            ////int n = (int)dt.Rows[0].Field<object>(0);
            ////int n = (int)sqlCmd.ExecuteScalar();

            if(n == 0) // 기존(fCode)가 없음  ----> Insert
            {
                sql = $"insert into {sTable} values ('{sCode}','{sModel}','{sLine}','{sBatt}','{sState}','{sCount}'" +
                      $",'{sTemp}','{sHum}','{sWind}','{sOzon}','{sAir}','{sTotal}','{sTime}')";
            }
            else       // 있음  ----> Update
            {
                string st1 = db1.Get($"select top 1 fTime from {sTable} where fCode = '{sCode}' order by fTime desc").ToString();
                string st2 = DateTime.Parse(st1).ToString("yyyy-MM-dd HH:mm:ss"); //'2021-04-26 9:18:46'

                sql = $"update {sTable} set fModel='{sModel}',fLine='{sLine}',fBatt='{sBatt}',fState='{sState}',fCount='{sCount}'" +
                      $",fTemp='{sTemp}',fHum='{sHum}',fWind='{sWind}',fOzon='{sOzon}',fAir='{sAir}',fTotal='{sTotal}',fTime='{sTime}' " +
                      $" where fcode = '{sCode}' and ftime = '{st2}'";
            }
            db1.Run(sql);
        }

        iniFile ini = new iniFile(".\\EquipManager.ini");
        private void frmEquipManager_Load(object sender, EventArgs e)
        {
            int x1, x2, y1, y2;
            tbServerPort.Text = ini.GetString("Server", "Port", "9001");

            x1 = int.Parse(ini.GetString("Form", "LocationX", "0"));
            y1 = int.Parse(ini.GetString("Form", "LocationY", "0"));
            this.Location = new Point(x1, y1);

            x2 = int.Parse(ini.GetString("Form", "SizeX", "500"));
            y2 = int.Parse(ini.GetString("Form", "SizeY", "500"));
            this.Size = new Size(x2, y2);

            tabControl1.SelectedIndex = int.Parse(ini.GetString("Form", "TabIndex", "1"));

            conString = ini.GetString("Database", "ConnectionString", @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\HulkL\source\repos\EquipManager\EquipDatabase.mdf; Integrated Security = True; Connect Timeout = 30");
            db1 = new SQLDB(conString);
            db2 = new SQLDB(conString);

            timer1.Interval = int.Parse(tbInterval.Text);
            timer1.Start();
        }

        private void frmEquipManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            ini.SetString("Server", "Port", tbServerPort.Text);

            ini.SetString("Form", "LocationX", $"{Location.X}");
            ini.SetString("Form", "LocationY", $"{Location.Y}");
            ini.SetString("Form", "SizeX", $"{Size.Width}");
            ini.SetString("Form", "SizeY", $"{Size.Height}");
            ini.SetString("Form", "TabIndex", $"{tabControl1.SelectedIndex}");
            ini.SetString("Database", "ConnectionString", conString);

            if (threadServer != null) threadServer.Abort();  // 완전 종결
            if (threadRead != null) threadRead.Abort();  // 완전 종결
        }

        void SetGrid()
        {
            gridStatus.DataSource = (DataTable)db2.Run("select * from fStatus");
            ////////gridStatus.Rows.Clear();
            ////////gridStatus.Columns.Clear();
            ////////for (int i = 0; i < dt.Columns.Count; i++) // Header 처리
            ////////{
            ////////    gridStatus.Columns.Add(dt.Columns[i].ColumnName, dt.Columns[i].ColumnName);
            ////////}
            ////////gridStatus.Rows.Add(dt.Rows.Count);
            ////////for (int i = 0; i < dt.Rows.Count; i++)  // 1 record read : 1 줄
            ////////{
            ////////    for (int j = 0; j < dt.Columns.Count; j++)
            ////////    {
            ////////        gridStatus.Rows[i].Cells[j].Value = dt.Rows[i][j];
            ////////    }
            ////////}
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            SetGrid();
            timer1.Start();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            int n = (int)db2.Get($"select count(*) from EquipInfo where fCode='{tbCode.Text}'");

            string sql;
            if(n == 0)  // INSERT
            {
                sql = $"insert into EquipInfo values (N'{tbCode.Text}',N'{tbModel.Text}',N'{tbName.Text}',N'{tbDesc.Text}',N'{tbLoc1.Text}',N'{tbLoc2.Text}')";
            }
            else   // UPDATE
            {
                sql = $"update EquipInfo set fCode=N'{tbCode.Text}'";
                if(cbModel.Checked) sql += $",fModel=N'{tbModel.Text}' ";
                if(cbName.Checked)  sql += $",fName=N'{tbName.Text}' ";
                if(cbDesc.Checked)  sql += $",fDesc=N'{tbDesc.Text}' ";
                if(cbLoc1.Checked)  sql += $",fLoc1=N'{tbLoc1.Text}' ";
                if(cbLoc2.Checked)  sql += $",fLoc2=N'{tbLoc2.Text}' ";
                sql += $" where fCode='{tbCode.Text}'";
            }
            db2.Run(sql);
        }

        private void gridStatus_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string sCode = (string)gridStatus.Rows[e.RowIndex].Cells[0].Value;
            DataTable dt = (DataTable)db2.Run($"select * from EquipInfo where fCode='{sCode}'");
            if (dt.Rows.Count > 0)
            {
                tbCode.Text = dt.Rows[0][0].ToString();
                tbModel.Text = dt.Rows[0][1].ToString();
                tbName.Text = dt.Rows[0][2].ToString();
                tbDesc.Text = dt.Rows[0][3].ToString();
                tbLoc1.Text = dt.Rows[0][4].ToString();
                tbLoc2.Text = dt.Rows[0][5].ToString();
            }
        }

        private void tbModel_TextChanged(object sender, EventArgs e)
        {
            cbModel.Checked = true;
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            cbName.Checked = true;
        }

        private void tbDesc_TextChanged(object sender, EventArgs e)
        {
            cbDesc.Checked = true;
        }

        private void tbLoc1_TextChanged(object sender, EventArgs e)
        {
            cbLoc1.Checked = true;
        }

        private void tbLoc2_TextChanged(object sender, EventArgs e)
        {
            cbLoc2.Checked = true;
        }
    }
}
