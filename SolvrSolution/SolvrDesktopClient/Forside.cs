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
    public partial class FormForside : Form
    {

        int i = 0;
        public FormForside()
        {
            InitializeComponent();
            timerConnectionStatus.Start();
            timerOverview.Start();
        }


        private void toolTipReportsLbl_Popup(object sender, PopupEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblPostsStatus_Click(object sender, EventArgs e)
        {

        }

        private void lblReportsUnresolved_Click(object sender, EventArgs e)
        {

        }

        private void timerConnectionStatus_Tick(object sender, EventArgs e)
        {
            //TODO needs to get info if the connection to the database is up.
            if (i%2 == 0)
            {
                lblConnectionStatus.BackColor = Color.Green;
            }
            else
            {
                lblConnectionStatus.BackColor = Color.Red;
            }
            i++;
        }

        private void timerOverview_Tick(object sender, EventArgs e)
        {
            //Gets the text from the labels  //TODO this needs to get some real data.
            lblReportsUnresolvedAmount.Text = i.ToString(); //desktopCtr.GetUnresolveReportsCount();
            lblReportsResolvedAmount.Text   = i.ToString(); 
            lblReportsTotalAmount.Text      = i.ToString(); 
            lblPostsReportedAmount.Text     = i.ToString();
            lblPostsResolvedAmount.Text     = i.ToString();
            lblPostsTotalAmount.Text        = i.ToString();
            lblCommentsReportedAmount.Text  = i.ToString();
            lblCommentsResolvedAmount.Text  = i.ToString();
            lblCommentsTotalAmount.Text     = i.ToString();
            lblUsersReportedAmount.Text     = i.ToString();
            lblUsersResolvedAmount.Text     = i.ToString();
            lblUsersTotalAmount.Text        = i.ToString();
            UpdateStatusLbls();

            i++; //only to see something.
        }

        private void UpdateStatusLbls()
        {
            int postsReportsUnresolved = Int32.Parse(lblPostsReportedAmount.Text);
            int commentsReportsUnresolved = Int32.Parse(lblCommentsReportedAmount.Text);
            int usersReportsUnresolved = Int32.Parse(lblUsersReportedAmount.Text);

            UpdateStatusLbl(lblPostsStatus, postsReportsUnresolved);
            UpdateStatusLbl(lblCommentsStatus, commentsReportsUnresolved);
            UpdateStatusLbl(lblUsersStatus, usersReportsUnresolved);
        }

        private void UpdateStatusLbl(Label lblStatus, int amount)
        {
            if (amount == 0)
                lblStatus.BackColor = Color.Green;
            if (amount > 0 && amount < 10)
                lblStatus.BackColor = Color.Orange;
            if (amount >= 10)
                lblStatus.BackColor = Color.Red;
        }

        private void lblPostsReportedAmount_Click(object sender, EventArgs e)
        {

        }

        private void progressBarOverviewStatus_Click(object sender, EventArgs e)
        {

        }
    }
}
