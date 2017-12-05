using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolvrDesktopClient
{
    public partial class ReportPostForm : Form
    {
        private FormForside forside;
        public ReportPostForm(FormForside forside)
        {
            InitializeComponent();
            this.forside = forside;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            forside.Show();
        }

        private void btnIgnore_Click(object sender, EventArgs e)
        {
            
            btnDelete.BackColor = SystemColors.Control;
            btnEdit.BackColor   = SystemColors.Control;
            btnIgnore.BackColor = Color.YellowGreen;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            btnIgnore.BackColor = SystemColors.Control;
            btnEdit.BackColor = SystemColors.Control;
            btnDelete.BackColor = Color.YellowGreen;
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnIgnore.BackColor = SystemColors.Control;
            btnDelete.BackColor = SystemColors.Control;
            btnEdit.BackColor   = Color.YellowGreen;
        }
    }
}
