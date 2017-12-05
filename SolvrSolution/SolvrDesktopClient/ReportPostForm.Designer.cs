namespace SolvrDesktopClient
{
    partial class ReportPostForm
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
            this.txtBoxPost = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.picBoxUserPicture = new System.Windows.Forms.PictureBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnIgnore = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 611);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(162, 50);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnResolve
            // 
            this.btnResolve.Location = new System.Drawing.Point(1088, 611);
            this.btnResolve.Name = "btnResolve";
            this.btnResolve.Size = new System.Drawing.Size(162, 50);
            this.btnResolve.TabIndex = 2;
            this.btnResolve.Text = "Resolve";
            this.btnResolve.UseVisualStyleBackColor = true;
            // 
            // txtBoxPost
            // 
            this.txtBoxPost.Location = new System.Drawing.Point(157, 176);
            this.txtBoxPost.Multiline = true;
            this.txtBoxPost.Name = "txtBoxPost";
            this.txtBoxPost.Size = new System.Drawing.Size(888, 250);
            this.txtBoxPost.TabIndex = 3;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(151, 35);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(71, 36);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Title";
            // 
            // picBoxUserPicture
            // 
            this.picBoxUserPicture.Location = new System.Drawing.Point(157, 87);
            this.picBoxUserPicture.Name = "picBoxUserPicture";
            this.picBoxUserPicture.Size = new System.Drawing.Size(100, 84);
            this.picBoxUserPicture.TabIndex = 5;
            this.picBoxUserPicture.TabStop = false;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(273, 153);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(73, 17);
            this.lblUsername.TabIndex = 6;
            this.lblUsername.Text = "Username";
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Location = new System.Drawing.Point(157, 438);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(69, 17);
            this.lblDateTime.TabIndex = 8;
            this.lblDateTime.Text = "DateTime";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(750, 438);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(144, 44);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(600, 438);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(144, 44);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnIgnore
            // 
            this.btnIgnore.Location = new System.Drawing.Point(900, 438);
            this.btnIgnore.Name = "btnIgnore";
            this.btnIgnore.Size = new System.Drawing.Size(144, 44);
            this.btnIgnore.TabIndex = 11;
            this.btnIgnore.Text = "Ignore";
            this.btnIgnore.UseVisualStyleBackColor = true;
            this.btnIgnore.Click += new System.EventHandler(this.btnIgnore_Click);
            // 
            // ReportPostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.btnIgnore);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lblDateTime);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.picBoxUserPicture);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtBoxPost);
            this.Controls.Add(this.btnResolve);
            this.Controls.Add(this.btnCancel);
            this.Name = "ReportPostForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportPostForm";
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnResolve;
        private System.Windows.Forms.TextBox txtBoxPost;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox picBoxUserPicture;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnIgnore;
    }
}