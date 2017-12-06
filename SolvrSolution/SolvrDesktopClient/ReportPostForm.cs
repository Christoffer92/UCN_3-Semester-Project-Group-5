using SolvrLibrary;
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
        private Report report;
        private int reportId;

        public ReportPostForm(FormForside forside, int reportId)
        {
            InitializeComponent();
            this.forside = forside;
            this.reportId = reportId;
            LoadPost();
            txtBoxPost.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            forside.Show();
            this.Hide();
            btnIgnore.BackColor = SystemColors.Control;
            btnDelete.BackColor = SystemColors.Control;
            btnEdit.BackColor = SystemColors.Control;
        }

        private void btnIgnore_Click(object sender, EventArgs e)
        {
            
            btnDelete.BackColor = SystemColors.Control;
            btnEdit.BackColor   = SystemColors.Control;
            btnIgnore.BackColor = Color.YellowGreen;
            txtBoxPost.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            btnIgnore.BackColor = SystemColors.Control;
            btnEdit.BackColor = SystemColors.Control;
            btnDelete.BackColor = Color.YellowGreen;
            txtBoxPost.Enabled = false;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnIgnore.BackColor = SystemColors.Control;
            btnDelete.BackColor = SystemColors.Control;
            btnEdit.BackColor   = Color.YellowGreen;
            txtBoxPost.Enabled = true;
        }

        public void LoadPost()
        {
            DesktopController desktopController = new DesktopController();
            Report report = desktopController.GetReport(reportId);
            User user = desktopController.GetUser(report.UserId);

            lblTitle.Text = report.Post.Title;
            lblUsername.Text = user.Username;
            lblDateTime.Text = report.DateCreated.ToString();
            txtBoxPost.Text = report.Post.Description;
        }

        private void btnResolve_Click(object sender, EventArgs e)
        {
            DesktopController desktopController = new DesktopController();
            Report report = desktopController.GetReport(reportId);
            

            if (btnIgnore.BackColor == Color.YellowGreen)
            {
                desktopController.SetReportToResolved(reportId);
            }
            
        }
    }
}
