namespace HotelReservationSystem.View
{
    partial class FrmRevenue
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
            this.dtpPeriod = new System.Windows.Forms.DateTimePicker();
            this.btnGetRevenue = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbRevenue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtpPeriod
            // 
            this.dtpPeriod.Location = new System.Drawing.Point(26, 12);
            this.dtpPeriod.Name = "dtpPeriod";
            this.dtpPeriod.Size = new System.Drawing.Size(250, 27);
            this.dtpPeriod.TabIndex = 0;
            // 
            // btnGetRevenue
            // 
            this.btnGetRevenue.Location = new System.Drawing.Point(305, 13);
            this.btnGetRevenue.Name = "btnGetRevenue";
            this.btnGetRevenue.Size = new System.Drawing.Size(94, 29);
            this.btnGetRevenue.TabIndex = 1;
            this.btnGetRevenue.Text = "Calculate";
            this.btnGetRevenue.UseVisualStyleBackColor = true;
            this.btnGetRevenue.Click += new System.EventHandler(this.btnGetRevenue_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Revenue";
            // 
            // lbRevenue
            // 
            this.lbRevenue.AutoSize = true;
            this.lbRevenue.Location = new System.Drawing.Point(26, 97);
            this.lbRevenue.Name = "lbRevenue";
            this.lbRevenue.Size = new System.Drawing.Size(17, 20);
            this.lbRevenue.TabIndex = 3;
            this.lbRevenue.Text = "$";
            // 
            // FrmRevenue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 153);
            this.Controls.Add(this.lbRevenue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGetRevenue);
            this.Controls.Add(this.dtpPeriod);
            this.MinimumSize = new System.Drawing.Size(450, 200);
            this.Name = "FrmRevenue";
            this.Text = "Revenue";
            this.Load += new System.EventHandler(this.FrmRevenue_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DateTimePicker dtpPeriod;
        private Button btnGetRevenue;
        private Label label1;
        private Label lbRevenue;
    }
}