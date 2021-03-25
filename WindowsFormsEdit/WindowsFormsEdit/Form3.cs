using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsEdit
{
    public partial class Form3 : Form
    {
        int x, y;
        public Form3(int x1 = -1, int y1 = -1)
        {
            x = x1; y = y1;
            if(x < 0 || y < 0)
            {
               // Location = Location + new Size(this.Size.Width, this.Size.Height );
            }
            else this.Location = new Point(x, y);
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.Location = new Point(x, y);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Return)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            if(e.KeyChar == (char)Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }
    }
}
