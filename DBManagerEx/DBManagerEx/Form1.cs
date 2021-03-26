using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBManagerEx
{
    public partial class Form1 : Form
    {
        public Form1() 
        {
            InitializeComponent();
        }
        SqlConnection sqlConn = new SqlConnection();
        SqlCommand sqlCom = new SqlCommand();
        private void mnuNew_Click(object sender, EventArgs e)
        {
            dataGrid.Rows.Clear(); 
            dataGrid.Columns.Clear();

            sbDBname.Text = "DB File Name";
            sbTables.Text = "Table List";
            sbTables.DropDownItems.Clear();
            sbMessage.Text = "Initialized.";
            sqlConn.Close();
        }

        private void mnuMigration_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            StreamReader sr = new StreamReader(openFileDialog1.FileName);
            string buf = sr.ReadLine();     // 첫번째 Line에는 각 Column의 HeaderText
            string[] sArr = buf.Split(','); // .......   ',' 로 구분
            for(int i=0;i<sArr.Length;i++)
            {
                dataGrid.Columns.Add(sArr[i], sArr[i]);
            }
            while (true)
            {
                buf = sr.ReadLine();
                if (buf == null) break;
                sArr = buf.Split(',');  // string array
                dataGrid.Rows.Add(sArr);   // Rows.Add method의 4번째 오버로드
            }
            sr.Close();
        }

        private void mnuSaveCSV_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;
            StreamWriter sw = new StreamWriter(saveFileDialog1.FileName,false,Encoding.Default);
            string buf = "";
            for(int i=0;i<dataGrid.ColumnCount;i++)
            {
                buf += dataGrid.Columns[i].HeaderText;
                if (i < dataGrid.ColumnCount - 1) buf += ",";
            }
            sw.Write(buf+"\r\n");

            for(int k=0;k<dataGrid.RowCount;k++)
            {
                buf = "";
                for(int i=0;i<dataGrid.ColumnCount;i++)
                {
                    buf += dataGrid.Rows[k].Cells[i].Value;
                    if (i < dataGrid.ColumnCount - 1) buf += ",";
                }
                sw.Write(buf+"\r\n");
            }
            sw.Close();
        }
        string sCon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=;Integrated Security=True;Connect Timeout=30";
        private void mnuDBOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            try
            {
                string[] sArr = sCon.Split(';');
                sCon = $"{sArr[0]};{sArr[1]}{openFileDialog1.FileName};{sArr[2]};{sArr[3]}";
                sqlConn.ConnectionString = sCon;
                sqlConn.Open();
                sqlCom.Connection = sqlConn;
                sbDBname.Text = openFileDialog1.SafeFileName;
                sbDBname.BackColor = Color.Green;

                DataTable dt = sqlConn.GetSchema("Tables");
                for(int i=0;i<dt.Rows.Count;i++)
                {
                    sbTables.DropDownItems.Add(dt.Rows[i].ItemArray[2].ToString());
                }
                sbMessage.Text = "Success";
                sbMessage.BackColor = Color.Gray;
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message,"Error");
                sbMessage.Text = "Error";
                sbMessage.BackColor = Color.Red;
            }
        }

        private void sbTables_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            sbTables.Text = e.ClickedItem.Text;
            RunSql($"select * from {sbTables.Text}");
        }

        private void ClearGrid()
        {
            dataGrid.Rows.Clear();
            dataGrid.Columns.Clear();
        }

        public string GetToken(int i, string src, char del)
        {
            string[] sArr = src.Split(del);
            return sArr[i];
        }

        private void RunSql(string Sql)
        {  //  SELect id, fCode from Facility
            try
            {
                string ss = GetToken(0, Sql.Trim().ToLower(), ' ');
                sqlCom.CommandText = Sql;
                if(ss == "select")
                {
                    ClearGrid();
                    SqlDataReader sr = sqlCom.ExecuteReader();
                    for(int i=0;i<sr.FieldCount;i++)
                    {
                        dataGrid.Columns.Add(sr.GetName(i), sr.GetName(i));
                    }

                    for(int k=0;sr.Read();k++)
                    {
                        object[] oArr = new object[sr.FieldCount];
                        sr.GetValues(oArr);
                        dataGrid.Rows.Add(oArr);
                    }
                    sr.Close();
                }
                else
                {
                    sqlCom.ExecuteNonQuery();
                }
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void dataGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = ".";
        }

        private void mnuUpdate_Click(object sender, EventArgs e)
        {
            for(int i=0;i<dataGrid.RowCount;i++)
            {
                for(int j=0;j<dataGrid.ColumnCount;j++)
                {
                    if(dataGrid.Rows[i].Cells[j].ToolTipText == ".")
                    { //"update {TableName} set {currentCellHeader}={currentCellValue} where {idHeader}={id}"

                        string tn = sbTables.Text;
                        string ht = dataGrid.Columns[j].HeaderText;
                        object cv = dataGrid.Rows[i].Cells[j].Value;
                        string it = dataGrid.Columns[0].HeaderText;
                        object id = dataGrid.Rows[i].Cells[0].Value;

                        string sql = $"update {tn} set {ht}=N'{cv}' where {it}={id}";
                        RunSql(sql);
                    }
                }
            }
        }
    }
}
