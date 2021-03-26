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

            sbPanel1.Text = "DB File Name";
            sbPanel2.Text = "Table List";
            sbPanel2.DropDownItems.Clear();
            sbPanel3.Text = "Initialized.";
            sqlConn.Close();
        }

        private void mnuMigration_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            StreamReader sr = new StreamReader(openFileDialog1.FileName);
            string buf = sr.ReadLine();     // 첫번째 Line에는 각 Column의 HeaderText
            string[] sArr = buf.Split(','); // .......   ',' 로 구분
        }
    }
}
