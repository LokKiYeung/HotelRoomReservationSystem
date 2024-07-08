namespace HotelReservationSystem.View
{
    partial class FrmEditStaffPassword
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPasswordNew = new System.Windows.Forms.TextBox();
            this.txtPasswordReenter = new System.Windows.Forms.TextBox();
            this.btnEditStaffPassword = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "New password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Re-enter password";
            // 
            // txtPasswordNew
            // 
            this.txtPasswordNew.Location = new System.Drawing.Point(151, 18);
            this.txtPasswordNew.Name = "txtPasswordNew";
            this.txtPasswordNew.Size = new System.Drawing.Size(235, 27);
            this.txtPasswordNew.TabIndex = 2;
            this.txtPasswordNew.UseSystemPasswordChar = true;
            // 
            // txtPasswordReenter
            // 
            this.txtPasswordReenter.Location = new System.Drawing.Point(151, 61);
            this.txtPasswordReenter.Name = "txtPasswordReenter";
            this.txtPasswordReenter.Size = new System.Drawing.Size(234, 27);
            this.txtPasswordReenter.TabIndex = 3;
            this.txtPasswordReenter.UseSystemPasswordChar = true;
            // 
            // btnEditStaffPassword
            // 
            this.btnEditStaffPassword.Location = new System.Drawing.Point(291, 105);
            this.btnEditStaffPassword.Name = "btnEditStaffPassword";
            this.btnEditStaffPassword.Size = new System.Drawing.Size(94, 29);
            this.btnEditStaffPassword.TabIndex = 4;
            this.btnEditStaffPassword.Text = "OK";
            this.btnEditStaffPassword.UseVisualStyleBackColor = true;
            this.btnEditStaffPassword.Click += new System.EventHandler(this.btnEditStaffPassword_Click);
            // 
            // FrmEditStaffPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 153);
            this.Controls.Add(this.btnEditStaffPassword);
            this.Controls.Add(this.txtPasswordReenter);
            this.Controls.Add(this.txtPasswordNew);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(415, 200);
            this.Name = "FrmEditStaffPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit password";
            this.Load += new System.EventHandler(this.FrmEditStaffPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtPasswordNew;
        private TextBox txtPasswordReenter;
        private Button btnEditStaffPassword;
    }
}