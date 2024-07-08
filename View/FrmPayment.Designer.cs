namespace HotelReservationSystem.View
{
    partial class FrmPayment
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
            this.cboPaymentType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboPromotionType = new System.Windows.Forms.ComboBox();
            this.lbPaymentAmount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPay = new System.Windows.Forms.Button();
            this.lbDiscountPrice = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboPaymentType
            // 
            this.cboPaymentType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPaymentType.FormattingEnabled = true;
            this.cboPaymentType.Location = new System.Drawing.Point(169, 52);
            this.cboPaymentType.Name = "cboPaymentType";
            this.cboPaymentType.Size = new System.Drawing.Size(307, 28);
            this.cboPaymentType.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Payment Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Amount";
            // 
            // cboPromotionType
            // 
            this.cboPromotionType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPromotionType.FormattingEnabled = true;
            this.cboPromotionType.Location = new System.Drawing.Point(169, 96);
            this.cboPromotionType.Name = "cboPromotionType";
            this.cboPromotionType.Size = new System.Drawing.Size(307, 28);
            this.cboPromotionType.TabIndex = 3;
            this.cboPromotionType.SelectedIndexChanged += new System.EventHandler(this.cboPromotionType_SelectedIndexChanged);
            // 
            // lbPaymentAmount
            // 
            this.lbPaymentAmount.AutoSize = true;
            this.lbPaymentAmount.Location = new System.Drawing.Point(169, 17);
            this.lbPaymentAmount.Name = "lbPaymentAmount";
            this.lbPaymentAmount.Size = new System.Drawing.Size(17, 20);
            this.lbPaymentAmount.TabIndex = 4;
            this.lbPaymentAmount.Text = "$";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Promotion Type";
            // 
            // btnPay
            // 
            this.btnPay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPay.Location = new System.Drawing.Point(382, 152);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(94, 29);
            this.btnPay.TabIndex = 6;
            this.btnPay.Text = "Pay";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // lbDiscountPrice
            // 
            this.lbDiscountPrice.AutoSize = true;
            this.lbDiscountPrice.Location = new System.Drawing.Point(329, 17);
            this.lbDiscountPrice.Name = "lbDiscountPrice";
            this.lbDiscountPrice.Size = new System.Drawing.Size(17, 20);
            this.lbDiscountPrice.TabIndex = 7;
            this.lbDiscountPrice.Text = "$";
            // 
            // FrmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 193);
            this.Controls.Add(this.lbDiscountPrice);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbPaymentAmount);
            this.Controls.Add(this.cboPromotionType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboPaymentType);
            this.MinimumSize = new System.Drawing.Size(510, 240);
            this.Name = "FrmPayment";
            this.Text = "Make Payment";
            this.Load += new System.EventHandler(this.FrmPayment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cboPaymentType;
        private Label label1;
        private Label label2;
        private ComboBox cboPromotionType;
        private Label lbPaymentAmount;
        private Label label3;
        private Button btnPay;
        private Label lbDiscountPrice;
    }
}