using HotelReservationSystem.Model;
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
    public partial class FrmEditStaffPassword : Form
    {
        public Staff handlingStaff;
        public Staff targetStaff;
        public FrmEditStaffPassword(Staff user,ref Staff staff)
        {
            InitializeComponent();
            this.handlingStaff = user;
            this.targetStaff = staff;
        }

        private void btnEditStaffPassword_Click(object sender, EventArgs e)
        {
            if (txtPasswordNew.Text == txtPasswordReenter.Text)
            {

                if (ChangePassword())
                {
                    MessageBox.Show("Password Updated!", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else {
                    MessageBox.Show("Fail to update password!", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
             
            }
            else
            {
                MessageBox.Show("Two password do not match", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool ChangePassword()
        {
            int nAffectedRows =  DBController.getInstance().executeUpdatePasswordStoredProcedure(this.handlingStaff.StaffID, targetStaff.StaffID, txtPasswordNew.Text);

            return (nAffectedRows > 0);

        }

        private void FrmEditStaffPassword_Load(object sender, EventArgs e)
        {

        }
    }
}
