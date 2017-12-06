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
    public partial class ReportCommentForm : Form
    {
        FormForside forside;
        public ReportCommentForm(FormForside forside)
        {
            InitializeComponent();
            this.forside = forside;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            forside.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }
    }
}
