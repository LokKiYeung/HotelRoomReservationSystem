using HotelReservationSystem.Model;
using HotelReservationSystem.Controller;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelReservationSystem.View
{
    public partial class FrmMain : Form
    {
        private Staff current_user;
        public FrmMain(Staff user)
        {
            InitializeComponent();
            current_user = user;
            this.Text = string.Format("Staff: {0} (Title: {1})", user.StaffID, user.StaffTitle);
            if (current_user.StaffTitle == "General Manager")
            {
                btnStaff.Enabled = true;
            }
            else
            {
                btnStaff.Enabled = false;
            }
        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            FrmRooms frm = new FrmRooms();
            frm.ShowDialog();
            LoadAppointment();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            FrmStaff frm = new FrmStaff(current_user);
            frm.ShowDialog();
            LoadAppointment();
        }

        private void btnGuest_Click(object sender, EventArgs e)
        {
            FrmGuest frm = new FrmGuest();
            frm.ShowDialog();
            LoadAppointment();
        }

        private void btnMakeReservation_Click(object sender, EventArgs e)
        {
            FrmMakeReservation frm = new FrmMakeReservation(current_user);
            frm.ShowDialog();
            LoadAppointment();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (this.dgvAppointment.SelectedRows.Count > 0)
            {
                int appointmentid = Convert.ToInt32(this.dgvAppointment.SelectedRows[0].Cells["APPOINTMENTID"].Value);
                
                if (this.dgvAppointment.SelectedRows[0].Cells["PAYMENT_ID"].Value is  DBNull)
                {
                    FrmPayment frm = new FrmPayment(current_user, appointmentid);
                    frm.ShowDialog();
                    LoadAppointment();
                }
                else {
                    MessageBox.Show("Payment made already!", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  
                }
            
            }
           
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            LoadAppointment();
        }

        private void LoadAppointment() {
            DataTable dt = Util.getInstance().GetAppointments();
            if (dt != null)
            {
                dt.Columns.Add("Guest_Gender", typeof(string));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["Guest_Gender"] = Util.getInstance().GenderNumToText(Convert.ToInt16(dt.Rows[i]["GENDER"]));
                }
                this.dgvAppointment.DataSource = dt;
                this.dgvAppointment.Columns["GENDER"].Visible = false;
            }

        }

        private void btnCancelAppointment_Click(object sender, EventArgs e)
        {
            if (this.dgvAppointment.SelectedRows.Count > 0)
            {
                int appointmentid = Convert.ToInt32(this.dgvAppointment.SelectedRows[0].Cells["APPOINTMENTID"].Value);
                int affectedrow = DBController.getInstance().executeCancelAppointmentStoredProcedure(current_user.StaffID, appointmentid);
                if (affectedrow > 0) { 
                    MessageBox.Show("Appointment Cancelled!","Appointment",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    LoadAppointment();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmRevenue frm = new FrmRevenue();
            frm.ShowDialog();
        }
    }
}
