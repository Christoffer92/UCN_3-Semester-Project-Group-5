﻿using SolvrLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolvrDesktopClient
{
    public partial class ReportPostForm : Form
    {
        private FormForside forside;
        private int reportId;
        private Post tempPost = null;

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
            //Post post = desktopController.GetPost(report.PostId); 
            tempPost = desktopController.GetPost(report.PostId);
            User user = desktopController.GetUser(report.UserId);

            lblUsername.Text = user.Username;
            lblTitle.Text = tempPost.Title;
            txtBoxTitle.Text = lblTitle.Text;
            lblDateTime.Text = tempPost.DateCreated.ToString();
            txtBoxPost.Text = tempPost.Description;
        }

        private void btnResolve_Click(object sender, EventArgs e)
        {
            DesktopController desktopController = new DesktopController();
            Report report = desktopController.GetReport(reportId);
            //Post post = desktopController.GetPost(report.PostId);
            Post post = tempPost;
            try
            {
                if (btnIgnore.BackColor == Color.YellowGreen)
                {
                    //TODO We need to take care of (Samtidigtheds problemet her)??
                    report.IsResolved = true;
                    desktopController.UpdateReport(report);
                    forside.Show();
                    forside.btnRefreshTable_Click(null, null);
                    this.Hide();
                }
                else if (btnEdit.BackColor == Color.YellowGreen)
                {
                    //TODO We need to take care of (Samtidigtheds problemet her)
                    post.Description = txtBoxPost.Text;
                    post.Title = txtBoxTitle.Text;
                    report.IsResolved = true;

                    desktopController.UpdatePost(post);
                    desktopController.UpdateReport(report);

                    forside.Show();
                    forside.btnRefreshTable_Click(null, null);
                    this.Hide();
                }
                else if (btnDelete.BackColor == Color.YellowGreen)
                {
                    //TODO We need to take care of (Samtidigtheds problemet her)??
                    int postId = desktopController.GetReport(reportId).PostId;
                    post.IsDisabled = true;
                    report.IsResolved = true;
                    desktopController.UpdatePost(post);
                    desktopController.UpdateReport(report);

                    forside.Show();
                    forside.btnRefreshTable_Click(null, null);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Please select one of the three options or click Cancel.");
                }
                tempPost = null;

            }
            catch (FaultException ex)
            {

                if (ex.Message.Contains("0917"))
                {
                    //concurrency handling
                    MessageBox.Show("The post has been edited by another admin or the owner, please re-read before resolving.", "The post was edited.", MessageBoxButtons.OK);
                    LoadPost();
                }
                else
                {
                    MessageBox.Show("Something went wrong. /nError: " + ex.Message, "An error has occured.", MessageBoxButtons.OK);
                    LoadPost();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong. /n Unidentified Error", "An error has occured.", MessageBoxButtons.OK);
                LoadPost(); ;
            }

        }

        private void lblTitleEditable(bool isEditable)
        {
            if (isEditable) {            
            lblTitle.Hide();
            txtBoxTitle.Text = lblTitle.Text;
            txtBoxTitle.Show();
            txtBoxTitle.Enabled = true;
            }
            else
            {
                txtBoxTitle.Hide();
                txtBoxTitle.Enabled = false;
                lblTitle.Text = txtBoxTitle.Text;
                lblTitle.Show();
            }
        }
    }
}
