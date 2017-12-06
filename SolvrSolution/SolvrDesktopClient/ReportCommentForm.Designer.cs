namespace SolvrDesktopClient
{
    partial class ReportCommentForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnResolve = new System.Windows.Forms.Button();
            this.txtBoxComment = new System.Windows.Forms.TextBox();
            this.picBoxUserPicture = new System.Windows.Forms.PictureBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnIgnore = new System.Windows.Forms.Button();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 611);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(162, 50);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnResolve
            // 
            this.btnResolve.Location = new System.Drawing.Point(1088, 611);
            this.btnResolve.Name = "btnResolve";
            this.btnResolve.Size = new System.Drawing.Size(162, 50);
            this.btnResolve.TabIndex = 1;
            this.btnResolve.Text = "Resolve";
            this.btnResolve.UseVisualStyleBackColor = true;
            // 
            // txtBoxComment
            // 
            this.txtBoxComment.Location = new System.Drawing.Point(183, 177);
            this.txtBoxComment.Multiline = true;
            this.txtBoxComment.Name = "txtBoxComment";
            this.txtBoxComment.Size = new System.Drawing.Size(888, 250);
            this.txtBoxComment.TabIndex = 2;
            // 
            // picBoxUserPicture
            // 
            this.picBoxUserPicture.Location = new System.Drawing.Point(190, 96);
            this.picBoxUserPicture.Name = "picBoxUserPicture";
            this.picBoxUserPicture.Size = new System.Drawing.Size(75, 75);
            this.picBoxUserPicture.TabIndex = 3;
            this.picBoxUserPicture.TabStop = false;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(271, 154);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(73, 17);
            this.lblUsername.TabIndex = 4;
            this.lblUsername.Text = "Username";
            // 
            // btnIgnore
            // 
            this.btnIgnore.Location = new System.Drawing.Point(927, 433);
            this.btnIgnore.Name = "btnIgnore";
            this.btnIgnore.Size = new System.Drawing.Size(144, 44);
            this.btnIgnore.TabIndex = 5;
            this.btnIgnore.Text = "Ignore";
            this.btnIgnore.UseVisualStyleBackColor = true;
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Location = new System.Drawing.Point(196, 430);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(69, 17);
            this.lblDateTime.TabIndex = 7;
            this.lblDateTime.Text = "DateTime";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(777, 433);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(144, 44);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(245, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(757, 36);
            this.label1.TabIndex = 9;
            this.label1.Text = "This Form is under construction, click cancel to go back.";
            // 
            // ReportCommentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblDateTime);
            this.Controls.Add(this.btnIgnore);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.picBoxUserPicture);
            this.Controls.Add(this.txtBoxComment);
            this.Controls.Add(this.btnResolve);
            this.Controls.Add(this.btnCancel);
            this.Name = "ReportCommentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportCommentForm";
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnResolve;
        private System.Windows.Forms.TextBox txtBoxComment;
        private System.Windows.Forms.PictureBox picBoxUserPicture;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Button btnIgnore;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label1;
    }
}