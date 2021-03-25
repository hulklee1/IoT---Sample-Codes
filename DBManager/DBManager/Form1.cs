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

namespace DBManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void mnuMigration_Click(object sender, EventArgs e)
        {
            DialogResult ret = openFileDialog1.ShowDialog();
            if (ret != DialogResult.OK) return;
            string nFile = openFileDialog1.FileName; // full name

            StreamReader sr = new StreamReader(nFile);

            // ==========================================================
            //     Header 처리 프로세스
            // =========================================
            string buf = sr.ReadLine();     // 1 Line Read : Header Line
            if (buf == null) return;
            string[] sArr = buf.Split(',');
            for(int i=0; i<sArr.Length;i++)
            {
                dataGrid.Columns.Add(sArr[i], sArr[i]);
            }

            // ==========================================================
            //     Row 데이터 처리 프로세스
            // =========================================
            while(true)
            {
                buf = sr.ReadLine();     // 1 Line Read
                if (buf == null) break;
                sArr = buf.Split(',');
                //dataGrid.Rows.Add(sArr);
                int rIdx = dataGrid.Rows.Add();    // 1 Line 생성
                for (int i = 0; i < sArr.Length; i++)
                {
                    dataGrid.Rows[rIdx].Cells[i].Value = sArr[i];
                }
            }
        }

        SqlConnection sqlCon = new SqlConnection();
        SqlCommand sqlCmd = new SqlCommand();
        string sConn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=;Integrated Security=True;Connect Timeout=30";
        private void mnuDBOpen_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult ret = openFileDialog1.ShowDialog();  // db file
                if (ret != DialogResult.OK) return;
                string nFile = openFileDialog1.FileName; // full name
                string[] ss = sConn.Split(';');

                sqlCmd.Connection = sqlCon;
                sqlCon.ConnectionString = $"{ss[0]};{ss[1]}{nFile};{ss[2]};{ss[3]}";
                sqlCon.Open();
                sbPanel1.Text = openFileDialog1.SafeFileName;
                sbPanel2.Text = "Database opened success.";
                sbPanel1.BackColor = Color.Green;

                DataTable dt = sqlCon.GetSchema("Tables");
                for(int i=0;i<dt.Rows.Count;i++)
                {
                    string s = dt.Rows[i].ItemArray[2].ToString();
                    sbButton1.DropDownItems.Add(s);
                }

                //string sample = "column1,column2";
                //string[] sa = sample.Split(',');
                //string buf = "";

                //foreach (string col in sa)
                //{
                //    //buf += string.Format("{0," + 30 + "}", col);
                //    buf += $"{col,30}";
                //}
                //sbPanel2.Text = buf;
            }
            catch (SqlException e1)
            {
                MessageBox.Show(e1.Message);
                sbPanel2.Text = "Database cannnot open.";
                sbPanel2.BackColor = Color.Red;
            }
        }

        private void mnuDBClose_Click(object sender, EventArgs e)
        {
            sqlCon.Close();
            sbPanel1.Text = "DB File Name";
            sbPanel1.BackColor = Color.Gray;
            sbPanel2.Text = "Database Closed.";

            sbButton1.DropDownItems.Clear();
        }

        public string GetToken(int index, char deli, string str)
        {
            string[] Strs = str.Split(deli);
            string ret = Strs[index];
            return ret;
        }

        string TableName;  // 다른 메뉴에서 사용할 DB Table 이름. 현재 Open된 테이블
        int RunSql(string s1)
        {
            try
            {   // ex)  select * from fStatus : select id,fname,fdesc from ____
                string sql = s1.Trim();
                sqlCmd.CommandText = sql;   // insert into fstatus values ( 1,2,3,4)
                if (GetToken(0, ' ', sql).ToUpper() == "SELECT")
                {
                    SqlDataReader sr = sqlCmd.ExecuteReader();

                    TableName = GetToken(3, ' ', sql);
//                    sbPanel3.Text = TableName;
                    dataGrid.Rows.Clear();
                    dataGrid.Columns.Clear();

                    for (int i = 0; i < sr.FieldCount; i++) // Header 처리
                    {
                        string ss = sr.GetName(i);
                        dataGrid.Columns.Add(ss, ss);
                    }
                    for (int i=0;sr.Read();i++)  // 1 record read : 1 줄
                    {
                        int rIdx = dataGrid.Rows.Add();
                        for(int j=0;j<sr.FieldCount;j++)
                        {
                            object str = sr.GetValue(j);
                            dataGrid.Rows[rIdx].Cells[j].Value = str;
                        }
                    }
                    sr.Close();

                    //for (int i=0;sr.Read();i++)  // 1 record read : 1 줄
                    //{
                    //    string buf = "";
                    //    for(int j=0;j<sr.FieldCount;j++)
                    //    {
                    //        object str = sr.GetValue(j);
                    //        buf += $" {str} ";
                    //    }
                    //    tbSql.Text += $"\r\n{buf}";
                    //}
                    //sr.Close();
                }
                else
                {
                    sqlCmd.ExecuteNonQuery();   // select 문 제외 -- no return value
                                                // update, insert, delete, create, alt
                }
                sbPanel2.Text = "Success";
                sbPanel2.BackColor = Color.AliceBlue;
            }
            catch (SqlException e1)
            {
                MessageBox.Show(e1.Message);
                sbPanel2.Text = "Error";
                sbPanel2.BackColor = Color.Red;

            }
            catch (InvalidOperationException e2)
            { 
                MessageBox.Show(e2.Message);
                sbPanel2.Text = "Error";
                sbPanel2.BackColor = Color.Red;
            }
            return 0;
        }
        private void mnuExecSql_Click(object sender, EventArgs e)
        {
            RunSql(tbSql.Text);
        }

        private void mnuSelSql_Click(object sender, EventArgs e)
        {
            RunSql(tbSql.SelectedText);
        }

        private void tbSql_KeyDown(object sender, KeyEventArgs e)
        {
            if (!mnuEnterKey.Checked) return;
            if (e.KeyCode != Keys.Enter) return;

            string str = tbSql.Text;
            string[] sArr = str.Split('\n');    // 줄바꿈문자 : \r\n
            int n = sArr.Length;
            string sql = sArr[n - 1].Trim();
            RunSql(sql);
        }

        private void dataGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = ".";
        }

        private void mnuUpdate_Click(object sender, EventArgs e)
        {
            for(int i=0;i<dataGrid.Rows.Count;i++)
            {
                for(int j=0;j<dataGrid.Columns.Count;j++)
                {
                    string s = dataGrid.Rows[i].Cells[j].ToolTipText;
                    if(s == ".")
 // update [Table]   set [field]=(CellText) where [keyName]=(Key.CellText)
 // update [fStatus] set [Temp] =(10)       where [ID]     =(6)
                    {
                        string tn = TableName;
                        string fn = dataGrid.Columns[j].HeaderText;
                        object ct = dataGrid.Rows[i].Cells[j].Value;
                        string kn = dataGrid.Columns[0].HeaderText;
                        object kt = dataGrid.Rows[i].Cells[0].Value;
                        string sql = $"update {tn} set {fn}={ct} where {kn}={kt}";
                        RunSql(sql);
                    }
                }
            }
        }

        private void sbPanel3_Click(object sender, EventArgs e)
        {
 //           string sql = $"select * from {sbPanel3.Text}";
//            RunSql(sql);

        }

        private void sbButton1_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string s = e.ClickedItem.Text; // 사용할 테이블 명 
            string sql = $"select * from {s}";
            sbButton1.Text = s;
            RunSql(sql);
        }

        private void mnuAddRow_Click(object sender, EventArgs e)
        {
            dataGrid.Rows.Add();
        }

        private void mnuAddColumn_Click(object sender, EventArgs e)
        {
            frmInput dlg = new frmInput("Input Column Name");
            DialogResult ret = dlg.ShowDialog();
            if(ret == DialogResult.OK)
            {
                string s = dlg.sInput;
                dataGrid.Columns.Add(s, s);
            }
        }

        private void mnuEnterKey_Click(object sender, EventArgs e)
        {
            mnuEnterKey.Checked = !mnuEnterKey.Checked;
        }

        // Create table [TableName] (
        // [column1] nchar(20),
        // [column2] nchar(20),
        // [column3] nchar(20),
        //    ...
        // )
        private void mnuNewTable_Click(object sender, EventArgs e)
        {
            frmInput dlg = new frmInput("신규 테이블 명");
            if(dlg.ShowDialog() != DialogResult.OK) return;
            string tableName = dlg.sInput;

            string sql = $"Create table {tableName} ( ";
            for(int i=0;i<dataGrid.ColumnCount;i++)
            {
                sql += $"{dataGrid.Columns[i].HeaderText} nchar(20)";
                if (i < dataGrid.ColumnCount - 1) sql += ", ";
            }
            sql += ")";
            RunSql(sql);    // 신규 테이블 생성 완료

            //  insert into [TableName] values (
            //  [col_val_1], [col_val_2], ...
            // )
            for(int i=0;i<dataGrid.RowCount;i++)
            {
                sql = $"insert into {tableName} values (";
                for(int j=0;j<dataGrid.Columns.Count;j++)
                {
                    sql += $"'{dataGrid.Rows[i].Cells[j].Value}'";
                    if (j < dataGrid.ColumnCount - 1) sql += ", ";
                }
                sql += ")";
                RunSql(sql);
            }
        }
    }
}
