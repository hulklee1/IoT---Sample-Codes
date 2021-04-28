using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.Data.SqlClient;

namespace jsLibrary
{
    public partial class frmInput: Form
    {   // frmInput dlg = new frmInput("입력하세요");
        // if(dlg.DoModal() == OK) str = dlg.retString;
        public frmInput(string cap)
        {
            InitializeComponent();
            lblCaption.Text = cap;
        }
        public string retString = "";

        private void tbInput_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                retString = tbInput.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
            else if(e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }
    }
    public class iniFile
    {
        [DllImport("kernel32")]
        static extern int GetPrivateProfileString(string s, string k, string d, StringBuilder sb, int n, string p);
        [DllImport("kernel32")]
        static extern int WritePrivateProfileString(string s, string k, string v, string p);

        public string iniFilePath = "";
        public iniFile(string path)
        {
            iniFilePath = path;
        }
        public string GetString(string s, string k, string d = "")
        {
            StringBuilder sb = new StringBuilder(512);
            GetPrivateProfileString(s, k, d, sb, 512, iniFilePath);
            return sb.ToString();
        }
        public int SetString(string s, string k, string v)
        {
            return WritePrivateProfileString(s, k, v, iniFilePath);
        }
    }
    public class SqlDatabase
    {
        string ConnectionString = null;
        SqlConnection sqlConn = null;
        SqlCommand sqlCmd = null;
        public SqlDatabase(string connStr)
        {
            ConnectionString = connStr;
            sqlConn = new SqlConnection(ConnectionString);
            sqlConn.Open();
            sqlCmd = new SqlCommand("", sqlConn);
        }
        public object run(string sql)
        {
            sqlCmd.CommandText = sql;   // "  select count(*) from fstatus    "
            if (jslib.GetToken(0, sql.Trim(), ' ').ToUpper() == "SELECT") // "[SELECT] count(*) from fstatus"
            {
                SqlDataReader sr = sqlCmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sr);
                sr.Close();

                return dt;
            }
            else
            {
                return sqlCmd.ExecuteNonQuery();  // insert, update, delete, create, alter 등 조회결과가 없는 SQL문 처리
            }
        }
        public object runScalar(string sql)
        {
            try
            {
                sqlCmd.CommandText = sql;   // "  select count(*) from fstatus    "
                return sqlCmd.ExecuteScalar();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
    }
    public static class jslib
    {
        public static string GetToken(int n, string str, char d)
        {
            string[] sArr = str.Split(d);
            return sArr[n];
        }

        public static void WriteLog(string str)
        {
            StreamWriter sw = new StreamWriter(@".\errLog.log", true);
            sw.Write($"{DateTime.Now}:{str}\r\n");
            sw.Close();
        }

        public static string GetInput(string str = "Input")
        {
            frmInput dlg = new frmInput(str);
            if (dlg.ShowDialog() == DialogResult.OK)
                return dlg.retString;
            else return "";
        }

        public static bool IsAlive(Socket ss) // 소켓 ss 가 현재 유효한지 아닌지 판단
        {
            if (ss == null) return false;
            if (!ss.Connected) return false;
            if (ss.Poll(1000, SelectMode.SelectRead) && ss.Available == 0) return false;  // ???
            try
            {
                ss.Send(new byte[1], 0, SocketFlags.OutOfBand);  // 실제 전송되는 데이터 바이트는 0
                return true;
            }
            catch { return false; }
        }
    }
    public class SQLDB
    {
        //  클래스 변수 정의
        SqlConnection sqlConn = new SqlConnection();
        SqlCommand sqlCmd = new SqlCommand();
        string ConnStr;

        //  클래스 생성자 정의 - 클래스 명과 동일
        public SQLDB(string s) // s : connection string 연결 문자열
        {
            ConnStr = s;
            sqlConn.ConnectionString = ConnStr;
            sqlConn.Open();
            sqlCmd.Connection = sqlConn;
        }

        //  클래스 함수(메쏘드) 정의 
        public object Run(string sql)
        {
            try
            {
                sqlCmd.CommandText = sql;   // "  select * from fstatus    "
                if (jslib.GetToken(0, sql.Trim(), ' ').ToUpper() == "SELECT") // "[SELECT] count(*) from fstatus"
                {
                    SqlDataReader sr = sqlCmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(sr);
                    sr.Close();

                    return dt;
                }
                else
                {
                    return sqlCmd.ExecuteNonQuery();  // insert, update, delete, create, alter 등 조회결과가 없는 SQL문 처리
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
        public object Get(string sql)   // 단일 필드 데이터 반환
        {
            try
            {
                sqlCmd.CommandText = sql;   // "  select count(*) from fstatus    "
                if (jslib.GetToken(0, sql.Trim(), ' ').ToUpper() == "SELECT") // "[SELECT] count(*) from fstatus"
                {
                    return sqlCmd.ExecuteScalar();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }
    }
}
