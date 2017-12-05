using SolvrServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SolvrLibrary;

namespace SolvrDesktopClient
{
    public partial class FormForside : Form
    {
        private Form reportCommentForm;
        private Form reportPostForm;

        public FormForside()
        {
            InitializeComponent();
            timerConnectionStatus.Start();
            timerOverview.Start();
            reportCommentForm = new ReportCommentForm(this);
            reportPostForm = new ReportPostForm(this);
        }

        private void timerConnectionStatus_Tick(object sender, EventArgs e)
        {
            ISolvrServices proxy = new SolvrService();
            bool isConnected = proxy.IsConnectedToDatabase();

            if (isConnected)
            {
                lblConnectionStatus.BackColor = Color.Green;
            }
            else
            {
                lblConnectionStatus.BackColor = Color.Red;
            }
        }

        private void timerOverview_Tick(object sender, EventArgs e)
        {
            DesktopController desktopController = new DesktopController();
            int[] reportCounts = desktopController.GetReportCounts();

            //Gets the text from the labels
            lblReportsUnresolvedAmount.Text = reportCounts[0].ToString();
            lblReportsResolvedAmount.Text   = reportCounts[1].ToString();
            lblReportsTotalAmount.Text      = reportCounts[2].ToString();
            lblPostsReportedAmount.Text     = reportCounts[3].ToString();
            lblPostsResolvedAmount.Text     = reportCounts[4].ToString();
            lblPostsTotalAmount.Text        = reportCounts[5].ToString();
            lblCommentsReportedAmount.Text  = reportCounts[6].ToString();
            lblCommentsResolvedAmount.Text  = reportCounts[7].ToString();
            lblCommentsTotalAmount.Text     = reportCounts[8].ToString();
            lblUsersReportedAmount.Text     = reportCounts[9].ToString();
            lblUsersResolvedAmount.Text     = reportCounts[10].ToString();
            lblUsersTotalAmount.Text        = reportCounts[11].ToString();
            UpdateStatusLbls();
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

        private void btnRefreshTable_Click(object sender, EventArgs e)
        {
            DesktopController desktopController = new DesktopController();
            List<Report> reports = desktopController.GetAllReports();
            
            //Clears and Fills the dataTable with the reports.
            dataTable.Rows.Clear();
            foreach (Report report in reports)
            {
                dataTable.Rows.Add(report.Id, report.Title, report.ReportType, report.DateCreated);
            }

            //Sorts the data by dateTime.
            dataTable.Sort(dataTable.Columns[3], ListSortDirection.Ascending);

            //Sets the timeout for the refresh button so it cant be spammed.
            btnRefreshTable.Enabled = false;
            timerRefreshTimeOut.Start();
        }

        private void dataTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.RowIndex >= 0)
            {
                string type = (string)dataTable[2, e.RowIndex].Value;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    e.RowIndex >= 0)
                {
                    if (type.Equals("comment"))
                    {
                        reportCommentForm.Show();
                        this.Hide();
                    }
                    if (type.Equals("post"))
                    {
                        reportPostForm.Show();
                        this.Hide();

                    }
                    if (type.Equals("user"))
                    {
                        MessageBox.Show("Not Implementet yet.", "Error");
                    }
                }
            }
        }

        private void timerRefreshTimeOut_Tick(object sender, EventArgs e)
        {
            btnRefreshTable.Enabled = true;
        }
    }
}