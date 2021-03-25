using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsEdit
{
    public partial class Form2 : Form
    {
        TextBox tbMemo1;
        Form1 frm;
        int LastPos = 0;
        public Form2(Form1 frm1)
        {
            InitializeComponent();
            tbMemo1 = frm1.tbMemo;
            frm = frm1;
            LastPos = tbMemo1.SelectionStart;
        }
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int pos = tbMemo1.Text.IndexOf(tbStr.Text,LastPos);
            if(pos != -1)
            {
                //int Y = tbMemo1.GetLineFromCharIndex(pos);
                //int X = pos - tbMemo1.GetFirstCharIndexFromLine(Y);
                tbMemo1.SelectionStart = pos;
                tbMemo1.SelectionLength = tbStr.Text.Length;
                tbMemo1.ScrollToCaret();
                LastPos = pos + tbStr.Text.Length;
                SetForegroundWindow(frm.Handle);
            }
            else
            {
                MessageBox.Show("더 이상 찾는 문자열이 없습니다.");
            }
        }
    }
}
