using HotelReservationSystem.Controller;
using HotelReservationSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelReservationSystem.View
{

    public partial class FrmPayment : Form
    {
        Staff handling_staff;
        int appointment_id;
        double roomprice;
        String[] payment_types = { "CASH", "CREDIT_CARD", "DEBIT_CARD" };
        List<PromotionType> promotion_types = new List<PromotionType>();

        public FrmPayment(Staff handling_staff, int appointment_id)
        {
            InitializeComponent();
            this.handling_staff = handling_staff;
            this.appointment_id = appointment_id;
        }

        private void FrmPayment_Load(object sender, EventArgs e)
        {
            cboPaymentType.Items.AddRange(payment_types);
            cboPaymentType.SelectedIndex = 0;
            cboPaymentType.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboPaymentType.AutoCompleteCustomSource.AddRange(payment_types);
            cboPaymentType.AutoCompleteMode = AutoCompleteMode.Suggest;

            DataTable dt = Util.getInstance().GetPromitionTypes();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PromotionType promotionType = new PromotionType();
                    promotionType.PromotionID = Convert.ToInt32(dt.Rows[i]["PROMOTIONID"].ToString());
                    promotionType.Name = dt.Rows[i]["NAME"].ToString();
                    promotionType.Description = dt.Rows[i]["DESCRIPTION"].ToString();
                    promotionType.DiscountRate = Convert.ToDouble(dt.Rows[i]["DISCOUNTRATE"].ToString());
                    promotion_types.Add(promotionType);
                    cboPromotionType.Items.Add(promotionType.Name);
                }
            }

            roomprice = DBController.getInstance().executeGetRoomPriceStoredProcedure(appointment_id);
            this.lbPaymentAmount.Text = "$" + roomprice.ToString() + "( GST: " + Math.Round((roomprice * 0.13), 2).ToString() + ")";
            this.lbDiscountPrice.Text = "Final Price $" + Math.Round((roomprice * 1.13), 2);
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            string paymenttype = cboPaymentType.SelectedItem.ToString();
            int promotionid = promotion_types.Where(x => x.Name == cboPromotionType.SelectedItem).FirstOrDefault()?.PromotionID ?? 0;

            int paymentid = DBController.getInstance().executeMakePaymentStoredProcedure(handling_staff.StaffID,appointment_id, paymenttype, roomprice, promotionid);
            if (paymentid != 0)
            {
                MessageBox.Show("Payment Made!", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Fail to make payment!", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboPromotionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            double discountrate = promotion_types.Where(x => x.Name == cboPromotionType.SelectedItem).FirstOrDefault()?.DiscountRate ?? 0;
            if (discountrate > 0)
            {
                this.lbDiscountPrice.Text = "Final Price $" + Math.Round((roomprice * 1.13 * (1 - discountrate)), 2);
            }
            else
            {
                this.lbDiscountPrice.Text = "Final Price $" + Math.Round((roomprice * 1.13), 2);
            }

        }
    }
}
