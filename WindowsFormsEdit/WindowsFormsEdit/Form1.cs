using myLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsEdit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            DialogResult ret = openFileDialog1.ShowDialog();  // C++  DoModal
            if(ret == DialogResult.OK)
            {
                string fName = openFileDialog1.FileName;    // full path
                string fName1 = openFileDialog1.SafeFileName;   // File name only
                StreamReader sr = new StreamReader(fName);  // c:FILE*   c++:CFile
                string buf = sr.ReadToEnd();
                tbMemo.Text = buf;
                sr.Close();
                int n = myLib.Count('\\', fName); // fName에서의 '\\' 갯수
                string fName2 = myLib.GetToken(n, '\\', fName);  // fName에서 마지막 문자열
                this.Text += $"     [{fName2}]";           // == 파일명
            }
        }

        // Save AS...  
        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            DialogResult ret = saveFileDialog1.ShowDialog();  // C++  DoModal
            if (ret == DialogResult.OK)
            {
                string fName = saveFileDialog1.FileName;    // full path
                StreamWriter sw = new StreamWriter(fName);  // c:FILE*   c++:CFile
                string buf = tbMemo.Text;
                sw.Write(buf);
                sw.Close(); 
            }
        }

        //  1. file open 후 Memo 창에 표시한 경우 - 확인 (o) 수정(x)
        //  2. New 메뉴 선택 후 문서 편집 - file 명 없음
        //  3. 기존 문서 중 일부 수정  -  open file 명 있음

        int txtChanged = 0;
        private void tbMemo_TextChanged(object sender, EventArgs e)
        {
            if (true) txtChanged = 1;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(txtChanged == 1)
            {

            }
        }

        private void SetFontInfo()
        {
            sbLabel1.Text = tbMemo.Font.Name + $", {tbMemo.Font.Height}";
        }

        private void mnuViewFont_Click(object sender, EventArgs e)
        {
            DialogResult ret = fontDialog1.ShowDialog();
            if (ret == DialogResult.Cancel) return;

            Font fnt = fontDialog1.Font;
            tbMemo.Font = fnt;
            SetFontInfo();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetFontInfo();
        }

        private void mnuEditSearch_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(this);
            frm.Show();
        }

        private void mnuTest_Click(object sender, EventArgs e)
        {
        }

        private void popup메뉴테스트ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void popup메뉴테스트ToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            Point p = PointToScreen(new Point(e.X,e.Y));
            Form3 dlg = new Form3(p.X,p.Y);
            DialogResult ret = dlg.ShowDialog();
            MessageBox.Show($"Return value is {ret} 입니다");
        }
    }
}
