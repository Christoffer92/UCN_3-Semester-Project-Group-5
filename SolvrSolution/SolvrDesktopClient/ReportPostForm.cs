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
        private int reportId;

        public ReportPostForm(FormForside forside, int reportId)
        {
            InitializeComponent();
            this.forside = forside;
            this.reportId = reportId;
            LoadPost();
            txtBoxPost.Enabled = false;
            txtBoxTitle.Text = lblTitle.Text;
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
            lblTitle.Enabled = false;
            lblTitleEditable(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            btnIgnore.BackColor = SystemColors.Control;
            btnEdit.BackColor = SystemColors.Control;
            btnDelete.BackColor = Color.YellowGreen;
            txtBoxPost.Enabled = false;
            lblTitle.Enabled = false;
            lblTitleEditable(false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnIgnore.BackColor = SystemColors.Control;
            btnDelete.BackColor = SystemColors.Control;
            btnEdit.BackColor   = Color.YellowGreen;
            txtBoxPost.Enabled = true;
            lblTitle.Enabled = true;
            lblTitleEditable(true);
        }

        public void LoadPost()
        {
            DesktopController desktopController = new DesktopController();
            Report report = desktopController.GetReport(reportId);
            Post post = desktopController.GetPost(report.PostId); 
            User user = desktopController.GetUser(report.UserId);

            lblUsername.Text = user.Username;
            lblTitle.Text = post.Title;
            lblDateTime.Text = post.DateCreated.ToString();
            txtBoxPost.Text = post.Description;
        }

        private void btnResolve_Click(object sender, EventArgs e)
        {
            DesktopController desktopController = new DesktopController();
            Report report = desktopController.GetReport(reportId);
            Post post = desktopController.GetPost(report.Id);

            if (btnIgnore.BackColor == Color.YellowGreen)
            {
                //TODO We need to take care of (Samtidigtheds problemet her)
                report.IsResolved = true;
                desktopController.UpdateReport(report);
                forside.Show();
                forside.btnRefreshTable_Click(null, null);
                this.Hide();
            }
            else if (btnEdit.BackColor == Color.YellowGreen)
            {
                //TODO We need to take care of (Samtidigtheds problemet her)
                
                report.Post.Description = txtBoxPost.Text;
                report.Post.Title = lblTitle.Text;
                report.IsResolved = true;
                                
                desktopController.UpdatePost(post);
                desktopController.UpdateReport(report);

                forside.Show();
                forside.btnRefreshTable_Click(null, null);
                this.Hide();
            }
            else if (btnDelete.BackColor == Color.YellowGreen)
            {
                //TODO We need to take care of (Samtidigtheds problemet her)
                    int postId = desktopController.GetReport(reportId).PostId;
                    report.Post.IsDisabled = true;
                    report.IsResolved = true;
                    desktopController.UpdateReport(report);
                    
                    forside.Show();
                    forside.btnRefreshTable_Click(null, null);
                    this.Hide();
            }
            else
            {
                MessageBox.Show("Please select one of the three options or click Cancel.");
            }
        }

        private void lblTitleEditable(bool isEditable)
        {
            if (isEditable) {            
            lblTitle.Hide();
            txtBoxTitle.Text = lblTitle.Text;
            txtBoxTitle.Show();
            txtBoxTitle.Enabled = true;
            txtBoxTitle.KeyDown += TxtBoxTitle_KeyDown;
            }
            else
            {
                txtBoxTitle.Hide();
                txtBoxTitle.Enabled = false;
                lblTitle.Text = txtBoxTitle.Text;
                lblTitle.Show();
            }
        }

        private void TxtBoxTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lblTitle.Text = txtBoxTitle.Text;
            }
        }
    }
}
