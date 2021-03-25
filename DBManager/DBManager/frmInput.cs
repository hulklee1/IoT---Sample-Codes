using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBManager
{
    public partial class frmInput : Form
    {
        public frmInput(string sTitle = "input")
        {
            STITLE = sTitle;
            InitializeComponent();
        }

        private void frmInput_Load(object sender, EventArgs e)
        {
            lblInput.Text = STITLE;
        }

        public string sInput;
        string STITLE;
        private void btnInput_Click(object sender, EventArgs e)
        {
            if (tbInput.Text != "")
            {
                this.DialogResult = DialogResult.OK;
                sInput = tbInput.Text;
            }
            else this.DialogResult = DialogResult.Cancel;

            Close();
        }

        private void tbInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.DialogResult = DialogResult.OK;
                sInput = tbInput.Text;
                Close();

            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                Close();
            }
        }
    }
}
