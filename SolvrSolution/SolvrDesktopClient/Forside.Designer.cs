namespace SolvrDesktopClient
{
    partial class FormForside
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormForside));
            this.picBoxTitle = new System.Windows.Forms.PictureBox();
            this.grpBoxReports = new System.Windows.Forms.GroupBox();
            this.lblUsersTotalAmount = new System.Windows.Forms.Label();
            this.lblUsersResolvedAmount = new System.Windows.Forms.Label();
            this.lblUsersReported = new System.Windows.Forms.Label();
            this.lblUsersTotal = new System.Windows.Forms.Label();
            this.lblUsersStatus = new System.Windows.Forms.Label();
            this.lblUsersResolved = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblUsersReportedAmount = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblCommentsResolvedAmount = new System.Windows.Forms.Label();
            this.lblCommentsResolved = new System.Windows.Forms.Label();
            this.lblCommentsTotalAmount = new System.Windows.Forms.Label();
            this.lblCommentsStatus = new System.Windows.Forms.Label();
            this.lblCommentsTotal = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCommentsReportedAmount = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblCommentsReported = new System.Windows.Forms.Label();
            this.lblPostsTotalAmount = new System.Windows.Forms.Label();
            this.lblPostsResolvedAmount = new System.Windows.Forms.Label();
            this.lblPostsResolved = new System.Windows.Forms.Label();
            this.lblPostsTotal = new System.Windows.Forms.Label();
            this.lblPostsStatus = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPostsReportedAmount = new System.Windows.Forms.Label();
            this.lblReportsResolvedAmount = new System.Windows.Forms.Label();
            this.lblPostsReported = new System.Windows.Forms.Label();
            this.lblReportsUnresolved = new System.Windows.Forms.Label();
            this.lblReportsUnresolvedAmount = new System.Windows.Forms.Label();
            this.lblReportsResolved = new System.Windows.Forms.Label();
            this.lblReportsTotalAmount = new System.Windows.Forms.Label();
            this.lblReportsTotal = new System.Windows.Forms.Label();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.lblConnection = new System.Windows.Forms.Label();
            this.comboBoxTypes = new System.Windows.Forms.ComboBox();
            this.dataTable = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.administrateReport = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtBoxSearch = new System.Windows.Forms.TextBox();
            this.timerConnectionStatus = new System.Windows.Forms.Timer(this.components);
            this.btnRefreshTable = new System.Windows.Forms.Button();
            this.timerOverview = new System.Windows.Forms.Timer(this.components);
            this.timerRefreshTimeOut = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxTitle)).BeginInit();
            this.grpBoxReports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxTitle
            // 
            this.picBoxTitle.BackgroundImage = global::SolvrDesktopClient.Properties.Resources.Logo;
            this.picBoxTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picBoxTitle.Location = new System.Drawing.Point(424, 28);
            this.picBoxTitle.Name = "picBoxTitle";
            this.picBoxTitle.Size = new System.Drawing.Size(285, 122);
            this.picBoxTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picBoxTitle.TabIndex = 0;
            this.picBoxTitle.TabStop = false;
            // 
            // grpBoxReports
            // 
            this.grpBoxReports.Controls.Add(this.lblUsersTotalAmount);
            this.grpBoxReports.Controls.Add(this.lblUsersResolvedAmount);
            this.grpBoxReports.Controls.Add(this.lblUsersReported);
            this.grpBoxReports.Controls.Add(this.lblUsersTotal);
            this.grpBoxReports.Controls.Add(this.lblUsersStatus);
            this.grpBoxReports.Controls.Add(this.lblUsersResolved);
            this.grpBoxReports.Controls.Add(this.label12);
            this.grpBoxReports.Controls.Add(this.lblUsersReportedAmount);
            this.grpBoxReports.Controls.Add(this.label13);
            this.grpBoxReports.Controls.Add(this.lblCommentsResolvedAmount);
            this.grpBoxReports.Controls.Add(this.lblCommentsResolved);
            this.grpBoxReports.Controls.Add(this.lblCommentsTotalAmount);
            this.grpBoxReports.Controls.Add(this.lblCommentsStatus);
            this.grpBoxReports.Controls.Add(this.lblCommentsTotal);
            this.grpBoxReports.Controls.Add(this.label8);
            this.grpBoxReports.Controls.Add(this.lblCommentsReportedAmount);
            this.grpBoxReports.Controls.Add(this.label9);
            this.grpBoxReports.Controls.Add(this.lblCommentsReported);
            this.grpBoxReports.Controls.Add(this.lblPostsTotalAmount);
            this.grpBoxReports.Controls.Add(this.lblPostsResolvedAmount);
            this.grpBoxReports.Controls.Add(this.lblPostsResolved);
            this.grpBoxReports.Controls.Add(this.lblPostsTotal);
            this.grpBoxReports.Controls.Add(this.lblPostsStatus);
            this.grpBoxReports.Controls.Add(this.label5);
            this.grpBoxReports.Controls.Add(this.label4);
            this.grpBoxReports.Controls.Add(this.lblPostsReportedAmount);
            this.grpBoxReports.Controls.Add(this.lblReportsResolvedAmount);
            this.grpBoxReports.Controls.Add(this.lblPostsReported);
            this.grpBoxReports.Controls.Add(this.lblReportsUnresolved);
            this.grpBoxReports.Controls.Add(this.lblReportsUnresolvedAmount);
            this.grpBoxReports.Controls.Add(this.lblReportsResolved);
            this.grpBoxReports.Controls.Add(this.lblReportsTotalAmount);
            this.grpBoxReports.Controls.Add(this.lblReportsTotal);
            this.grpBoxReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxReports.Location = new System.Drawing.Point(12, 28);
            this.grpBoxReports.Name = "grpBoxReports";
            this.grpBoxReports.Size = new System.Drawing.Size(356, 639);
            this.grpBoxReports.TabIndex = 1;
            this.grpBoxReports.TabStop = false;
            this.grpBoxReports.Text = "Overview of Reports";
            // 
            // lblUsersTotalAmount
            // 
            this.lblUsersTotalAmount.AutoSize = true;
            this.lblUsersTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsersTotalAmount.Location = new System.Drawing.Point(173, 606);
            this.lblUsersTotalAmount.Name = "lblUsersTotalAmount";
            this.lblUsersTotalAmount.Size = new System.Drawing.Size(23, 25);
            this.lblUsersTotalAmount.TabIndex = 21;
            this.lblUsersTotalAmount.Text = "0";
            // 
            // lblUsersResolvedAmount
            // 
            this.lblUsersResolvedAmount.AutoSize = true;
            this.lblUsersResolvedAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsersResolvedAmount.Location = new System.Drawing.Point(173, 573);
            this.lblUsersResolvedAmount.Name = "lblUsersResolvedAmount";
            this.lblUsersResolvedAmount.Size = new System.Drawing.Size(23, 25);
            this.lblUsersResolvedAmount.TabIndex = 2;
            this.lblUsersResolvedAmount.Text = "0";
            // 
            // lblUsersReported
            // 
            this.lblUsersReported.AutoSize = true;
            this.lblUsersReported.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsersReported.Location = new System.Drawing.Point(41, 537);
            this.lblUsersReported.Name = "lblUsersReported";
            this.lblUsersReported.Size = new System.Drawing.Size(91, 25);
            this.lblUsersReported.TabIndex = 11;
            this.lblUsersReported.Text = "Reported";
            // 
            // lblUsersTotal
            // 
            this.lblUsersTotal.AutoSize = true;
            this.lblUsersTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsersTotal.Location = new System.Drawing.Point(41, 606);
            this.lblUsersTotal.Name = "lblUsersTotal";
            this.lblUsersTotal.Size = new System.Drawing.Size(56, 25);
            this.lblUsersTotal.TabIndex = 10;
            this.lblUsersTotal.Text = "Total";
            // 
            // lblUsersStatus
            // 
            this.lblUsersStatus.AutoSize = true;
            this.lblUsersStatus.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblUsersStatus.Location = new System.Drawing.Point(220, 497);
            this.lblUsersStatus.Name = "lblUsersStatus";
            this.lblUsersStatus.Size = new System.Drawing.Size(36, 26);
            this.lblUsersStatus.TabIndex = 18;
            this.lblUsersStatus.Text = "    ";
            // 
            // lblUsersResolved
            // 
            this.lblUsersResolved.AutoSize = true;
            this.lblUsersResolved.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsersResolved.Location = new System.Drawing.Point(41, 573);
            this.lblUsersResolved.Name = "lblUsersResolved";
            this.lblUsersResolved.Size = new System.Drawing.Size(93, 25);
            this.lblUsersResolved.TabIndex = 7;
            this.lblUsersResolved.Text = "Resolved";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 497);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 26);
            this.label12.TabIndex = 20;
            this.label12.Text = "Users";
            // 
            // lblUsersReportedAmount
            // 
            this.lblUsersReportedAmount.AutoSize = true;
            this.lblUsersReportedAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsersReportedAmount.Location = new System.Drawing.Point(173, 537);
            this.lblUsersReportedAmount.Name = "lblUsersReportedAmount";
            this.lblUsersReportedAmount.Size = new System.Drawing.Size(23, 25);
            this.lblUsersReportedAmount.TabIndex = 9;
            this.lblUsersReportedAmount.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label13.Location = new System.Drawing.Point(5, 490);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(276, 26);
            this.label13.TabIndex = 19;
            this.label13.Text = "______________________";
            // 
            // lblCommentsResolvedAmount
            // 
            this.lblCommentsResolvedAmount.AutoSize = true;
            this.lblCommentsResolvedAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommentsResolvedAmount.Location = new System.Drawing.Point(173, 409);
            this.lblCommentsResolvedAmount.Name = "lblCommentsResolvedAmount";
            this.lblCommentsResolvedAmount.Size = new System.Drawing.Size(23, 25);
            this.lblCommentsResolvedAmount.TabIndex = 17;
            this.lblCommentsResolvedAmount.Text = "0";
            // 
            // lblCommentsResolved
            // 
            this.lblCommentsResolved.AutoSize = true;
            this.lblCommentsResolved.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommentsResolved.Location = new System.Drawing.Point(41, 409);
            this.lblCommentsResolved.Name = "lblCommentsResolved";
            this.lblCommentsResolved.Size = new System.Drawing.Size(93, 25);
            this.lblCommentsResolved.TabIndex = 13;
            this.lblCommentsResolved.Text = "Resolved";
            // 
            // lblCommentsTotalAmount
            // 
            this.lblCommentsTotalAmount.AutoSize = true;
            this.lblCommentsTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommentsTotalAmount.Location = new System.Drawing.Point(173, 446);
            this.lblCommentsTotalAmount.Name = "lblCommentsTotalAmount";
            this.lblCommentsTotalAmount.Size = new System.Drawing.Size(23, 25);
            this.lblCommentsTotalAmount.TabIndex = 11;
            this.lblCommentsTotalAmount.Text = "0";
            // 
            // lblCommentsStatus
            // 
            this.lblCommentsStatus.AutoSize = true;
            this.lblCommentsStatus.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblCommentsStatus.Location = new System.Drawing.Point(220, 332);
            this.lblCommentsStatus.Name = "lblCommentsStatus";
            this.lblCommentsStatus.Size = new System.Drawing.Size(36, 26);
            this.lblCommentsStatus.TabIndex = 14;
            this.lblCommentsStatus.Text = "    ";
            // 
            // lblCommentsTotal
            // 
            this.lblCommentsTotal.AutoSize = true;
            this.lblCommentsTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommentsTotal.Location = new System.Drawing.Point(41, 446);
            this.lblCommentsTotal.Name = "lblCommentsTotal";
            this.lblCommentsTotal.Size = new System.Drawing.Size(56, 25);
            this.lblCommentsTotal.TabIndex = 10;
            this.lblCommentsTotal.Text = "Total";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 332);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 26);
            this.label8.TabIndex = 16;
            this.label8.Text = "Comments";
            // 
            // lblCommentsReportedAmount
            // 
            this.lblCommentsReportedAmount.AutoSize = true;
            this.lblCommentsReportedAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommentsReportedAmount.Location = new System.Drawing.Point(173, 373);
            this.lblCommentsReportedAmount.Name = "lblCommentsReportedAmount";
            this.lblCommentsReportedAmount.Size = new System.Drawing.Size(23, 25);
            this.lblCommentsReportedAmount.TabIndex = 9;
            this.lblCommentsReportedAmount.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label9.Location = new System.Drawing.Point(6, 325);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(276, 26);
            this.label9.TabIndex = 15;
            this.label9.Text = "______________________";
            // 
            // lblCommentsReported
            // 
            this.lblCommentsReported.AutoSize = true;
            this.lblCommentsReported.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommentsReported.Location = new System.Drawing.Point(41, 373);
            this.lblCommentsReported.Name = "lblCommentsReported";
            this.lblCommentsReported.Size = new System.Drawing.Size(91, 25);
            this.lblCommentsReported.TabIndex = 7;
            this.lblCommentsReported.Text = "Reported";
            // 
            // lblPostsTotalAmount
            // 
            this.lblPostsTotalAmount.AutoSize = true;
            this.lblPostsTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPostsTotalAmount.Location = new System.Drawing.Point(173, 291);
            this.lblPostsTotalAmount.Name = "lblPostsTotalAmount";
            this.lblPostsTotalAmount.Size = new System.Drawing.Size(23, 25);
            this.lblPostsTotalAmount.TabIndex = 13;
            this.lblPostsTotalAmount.Text = "0";
            // 
            // lblPostsResolvedAmount
            // 
            this.lblPostsResolvedAmount.AutoSize = true;
            this.lblPostsResolvedAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPostsResolvedAmount.Location = new System.Drawing.Point(173, 256);
            this.lblPostsResolvedAmount.Name = "lblPostsResolvedAmount";
            this.lblPostsResolvedAmount.Size = new System.Drawing.Size(23, 25);
            this.lblPostsResolvedAmount.TabIndex = 11;
            this.lblPostsResolvedAmount.Text = "0";
            // 
            // lblPostsResolved
            // 
            this.lblPostsResolved.AutoSize = true;
            this.lblPostsResolved.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPostsResolved.Location = new System.Drawing.Point(41, 256);
            this.lblPostsResolved.Name = "lblPostsResolved";
            this.lblPostsResolved.Size = new System.Drawing.Size(93, 25);
            this.lblPostsResolved.TabIndex = 12;
            this.lblPostsResolved.Text = "Resolved";
            // 
            // lblPostsTotal
            // 
            this.lblPostsTotal.AutoSize = true;
            this.lblPostsTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPostsTotal.Location = new System.Drawing.Point(41, 291);
            this.lblPostsTotal.Name = "lblPostsTotal";
            this.lblPostsTotal.Size = new System.Drawing.Size(56, 25);
            this.lblPostsTotal.TabIndex = 10;
            this.lblPostsTotal.Text = "Total";
            // 
            // lblPostsStatus
            // 
            this.lblPostsStatus.AutoSize = true;
            this.lblPostsStatus.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblPostsStatus.Location = new System.Drawing.Point(220, 172);
            this.lblPostsStatus.Name = "lblPostsStatus";
            this.lblPostsStatus.Size = new System.Drawing.Size(36, 26);
            this.lblPostsStatus.TabIndex = 2;
            this.lblPostsStatus.Text = "    ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 26);
            this.label5.TabIndex = 10;
            this.label5.Text = "Posts";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label4.Location = new System.Drawing.Point(6, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(276, 26);
            this.label4.TabIndex = 9;
            this.label4.Text = "______________________";
            // 
            // lblPostsReportedAmount
            // 
            this.lblPostsReportedAmount.AutoSize = true;
            this.lblPostsReportedAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPostsReportedAmount.Location = new System.Drawing.Point(173, 219);
            this.lblPostsReportedAmount.Name = "lblPostsReportedAmount";
            this.lblPostsReportedAmount.Size = new System.Drawing.Size(23, 25);
            this.lblPostsReportedAmount.TabIndex = 9;
            this.lblPostsReportedAmount.Text = "0";
            // 
            // lblReportsResolvedAmount
            // 
            this.lblReportsResolvedAmount.AutoSize = true;
            this.lblReportsResolvedAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportsResolvedAmount.Location = new System.Drawing.Point(142, 85);
            this.lblReportsResolvedAmount.Name = "lblReportsResolvedAmount";
            this.lblReportsResolvedAmount.Size = new System.Drawing.Size(23, 25);
            this.lblReportsResolvedAmount.TabIndex = 8;
            this.lblReportsResolvedAmount.Text = "0";
            // 
            // lblPostsReported
            // 
            this.lblPostsReported.AutoSize = true;
            this.lblPostsReported.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPostsReported.Location = new System.Drawing.Point(41, 219);
            this.lblPostsReported.Name = "lblPostsReported";
            this.lblPostsReported.Size = new System.Drawing.Size(91, 25);
            this.lblPostsReported.TabIndex = 7;
            this.lblPostsReported.Text = "Reported";
            // 
            // lblReportsUnresolved
            // 
            this.lblReportsUnresolved.AutoSize = true;
            this.lblReportsUnresolved.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportsUnresolved.Location = new System.Drawing.Point(21, 48);
            this.lblReportsUnresolved.Name = "lblReportsUnresolved";
            this.lblReportsUnresolved.Size = new System.Drawing.Size(111, 25);
            this.lblReportsUnresolved.TabIndex = 7;
            this.lblReportsUnresolved.Text = "Unresolved";
            // 
            // lblReportsUnresolvedAmount
            // 
            this.lblReportsUnresolvedAmount.AutoSize = true;
            this.lblReportsUnresolvedAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportsUnresolvedAmount.Location = new System.Drawing.Point(142, 48);
            this.lblReportsUnresolvedAmount.Name = "lblReportsUnresolvedAmount";
            this.lblReportsUnresolvedAmount.Size = new System.Drawing.Size(23, 25);
            this.lblReportsUnresolvedAmount.TabIndex = 6;
            this.lblReportsUnresolvedAmount.Text = "0";
            // 
            // lblReportsResolved
            // 
            this.lblReportsResolved.AutoSize = true;
            this.lblReportsResolved.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportsResolved.Location = new System.Drawing.Point(21, 85);
            this.lblReportsResolved.Name = "lblReportsResolved";
            this.lblReportsResolved.Size = new System.Drawing.Size(93, 25);
            this.lblReportsResolved.TabIndex = 5;
            this.lblReportsResolved.Text = "Resolved";
            // 
            // lblReportsTotalAmount
            // 
            this.lblReportsTotalAmount.AutoSize = true;
            this.lblReportsTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportsTotalAmount.Location = new System.Drawing.Point(142, 123);
            this.lblReportsTotalAmount.Name = "lblReportsTotalAmount";
            this.lblReportsTotalAmount.Size = new System.Drawing.Size(23, 25);
            this.lblReportsTotalAmount.TabIndex = 4;
            this.lblReportsTotalAmount.Text = "0";
            // 
            // lblReportsTotal
            // 
            this.lblReportsTotal.AutoSize = true;
            this.lblReportsTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportsTotal.Location = new System.Drawing.Point(21, 123);
            this.lblReportsTotal.Name = "lblReportsTotal";
            this.lblReportsTotal.Size = new System.Drawing.Size(56, 25);
            this.lblReportsTotal.TabIndex = 3;
            this.lblReportsTotal.Text = "Total";
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.AutoSize = true;
            this.lblConnectionStatus.BackColor = System.Drawing.Color.Red;
            this.lblConnectionStatus.Location = new System.Drawing.Point(1175, 44);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(28, 17);
            this.lblConnectionStatus.TabIndex = 14;
            this.lblConnectionStatus.Text = "     ";
            // 
            // lblConnection
            // 
            this.lblConnection.AutoSize = true;
            this.lblConnection.Location = new System.Drawing.Point(1090, 44);
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Size = new System.Drawing.Size(79, 17);
            this.lblConnection.TabIndex = 15;
            this.lblConnection.Text = "Connection";
            // 
            // comboBoxTypes
            // 
            this.comboBoxTypes.Enabled = false;
            this.comboBoxTypes.FormattingEnabled = true;
            this.comboBoxTypes.Items.AddRange(new object[] {
            "Posts",
            "Comments",
            "Users"});
            this.comboBoxTypes.Location = new System.Drawing.Point(549, 170);
            this.comboBoxTypes.Name = "comboBoxTypes";
            this.comboBoxTypes.Size = new System.Drawing.Size(150, 24);
            this.comboBoxTypes.TabIndex = 16;
            this.comboBoxTypes.Text = "Types of Reports";
            // 
            // dataTable
            // 
            this.dataTable.AllowUserToAddRows = false;
            this.dataTable.AllowUserToDeleteRows = false;
            this.dataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Title,
            this.Type,
            this.dateCreated,
            this.administrateReport});
            this.dataTable.Location = new System.Drawing.Point(400, 200);
            this.dataTable.Name = "dataTable";
            this.dataTable.ReadOnly = true;
            this.dataTable.RowTemplate.Height = 24;
            this.dataTable.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataTable.Size = new System.Drawing.Size(800, 460);
            this.dataTable.TabIndex = 17;
            this.dataTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataTable_CellContentClick);
            // 
            // id
            // 
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.id.DefaultCellStyle = dataGridViewCellStyle1;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 50;
            // 
            // Title
            // 
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            this.Title.Width = 170;
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Type.Width = 75;
            // 
            // dateCreated
            // 
            this.dateCreated.HeaderText = "Date Created";
            this.dateCreated.Name = "dateCreated";
            this.dateCreated.ReadOnly = true;
            this.dateCreated.Width = 130;
            // 
            // administrateReport
            // 
            this.administrateReport.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.administrateReport.HeaderText = "Administrate";
            this.administrateReport.Name = "administrateReport";
            this.administrateReport.ReadOnly = true;
            this.administrateReport.Text = "";
            this.administrateReport.ToolTipText = "Buttons to Administrate the specific Report.";
            this.administrateReport.Width = 115;
            // 
            // txtBoxSearch
            // 
            this.txtBoxSearch.Enabled = false;
            this.txtBoxSearch.Location = new System.Drawing.Point(412, 172);
            this.txtBoxSearch.Name = "txtBoxSearch";
            this.txtBoxSearch.Size = new System.Drawing.Size(109, 22);
            this.txtBoxSearch.TabIndex = 18;
            this.txtBoxSearch.Text = "Search...";
            // 
            // timerConnectionStatus
            // 
            this.timerConnectionStatus.Interval = 5000;
            this.timerConnectionStatus.Tick += new System.EventHandler(this.timerConnectionStatus_Tick);
            // 
            // btnRefreshTable
            // 
            this.btnRefreshTable.Location = new System.Drawing.Point(730, 170);
            this.btnRefreshTable.Name = "btnRefreshTable";
            this.btnRefreshTable.Size = new System.Drawing.Size(135, 23);
            this.btnRefreshTable.TabIndex = 20;
            this.btnRefreshTable.Text = "Refresh Table";
            this.btnRefreshTable.UseVisualStyleBackColor = true;
            this.btnRefreshTable.Click += new System.EventHandler(this.btnRefreshTable_Click);
            // 
            // timerOverview
            // 
            this.timerOverview.Interval = 10000;
            this.timerOverview.Tick += new System.EventHandler(this.timerOverview_Tick);
            // 
            // timerRefreshTimeOut
            // 
            this.timerRefreshTimeOut.Interval = 5000;
            this.timerRefreshTimeOut.Tick += new System.EventHandler(this.timerRefreshTimeOut_Tick);
            // 
            // FormForside
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.btnRefreshTable);
            this.Controls.Add(this.txtBoxSearch);
            this.Controls.Add(this.dataTable);
            this.Controls.Add(this.comboBoxTypes);
            this.Controls.Add(this.lblConnection);
            this.Controls.Add(this.lblConnectionStatus);
            this.Controls.Add(this.grpBoxReports);
            this.Controls.Add(this.picBoxTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1280, 720);
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "FormForside";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SolvrAdminstrator";
            ((System.ComponentModel.ISupportInitialize)(this.picBoxTitle)).EndInit();
            this.grpBoxReports.ResumeLayout(false);
            this.grpBoxReports.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxTitle;
        private System.Windows.Forms.GroupBox grpBoxReports;
        private System.Windows.Forms.Label lblReportsTotal;
        private System.Windows.Forms.Label lblReportsTotalAmount;
        private System.Windows.Forms.Label lblReportsUnresolved;
        private System.Windows.Forms.Label lblReportsUnresolvedAmount;
        private System.Windows.Forms.Label lblReportsResolved;
        private System.Windows.Forms.Label lblUsersResolved;
        private System.Windows.Forms.Label lblUsersResolvedAmount;
        private System.Windows.Forms.Label lblUsersTotal;
        private System.Windows.Forms.Label lblUsersReportedAmount;
        private System.Windows.Forms.Label lblPostsResolvedAmount;
        private System.Windows.Forms.Label lblPostsTotal;
        private System.Windows.Forms.Label lblPostsReportedAmount;
        private System.Windows.Forms.Label lblPostsReported;
        private System.Windows.Forms.Label lblPostsStatus;
        private System.Windows.Forms.Label lblCommentsTotalAmount;
        private System.Windows.Forms.Label lblCommentsTotal;
        private System.Windows.Forms.Label lblCommentsReportedAmount;
        private System.Windows.Forms.Label lblCommentsReported;
        private System.Windows.Forms.Label lblConnectionStatus;
        private System.Windows.Forms.Label lblConnection;
        private System.Windows.Forms.Label lblUsersReported;
        private System.Windows.Forms.Label lblPostsResolved;
        private System.Windows.Forms.Label lblCommentsResolved;
        private System.Windows.Forms.ComboBox comboBoxTypes;
        private System.Windows.Forms.DataGridView dataTable;
        private System.Windows.Forms.TextBox txtBoxSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblReportsResolvedAmount;
        private System.Windows.Forms.Label lblPostsTotalAmount;
        private System.Windows.Forms.Label lblUsersStatus;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblCommentsResolvedAmount;
        private System.Windows.Forms.Label lblCommentsStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblUsersTotalAmount;
        private System.Windows.Forms.Timer timerConnectionStatus;
        private System.Windows.Forms.Button btnRefreshTable;
        private System.Windows.Forms.Timer timerOverview;
        private System.Windows.Forms.Timer timerRefreshTimeOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCreated;
        private System.Windows.Forms.DataGridViewButtonColumn administrateReport;
    }
}

