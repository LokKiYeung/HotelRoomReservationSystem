using HotelReservationSystem.Controller;
using HotelReservationSystem.Model;
using Microsoft.VisualBasic.ApplicationServices;
using System.Data;
using System.Data.Common;

namespace HotelReservationSystem.View
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Staff user = new Staff(txtUsername.Text, txtPassword.Text);

            try {
                if (CheckLogin(ref user))
                {
                    this.Hide();
                    FrmMain oform = new FrmMain(user);
                    oform.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.Message, "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }

        private void FrmReservation_Load(object sender, EventArgs e)
        {

        }

        public bool CheckLogin(ref Staff staff)
        {
            try
            {

                int staffid = DBController.getInstance().executeGetUserStoredProcedure(staff.UserName, staff.Password);


                if (staffid != 0)
                {
                    staff.StaffID = staffid;
                    DataTable dt = DBController.getInstance().executeQuery(string.Format("SELECT stafftitle, email, phonenumber, address, remark FROM STAFF WHERE STAFFID = {0}",staff.StaffID));
                    if (dt != null && dt.Rows.Count>0)
                    {
                        staff.StaffTitle = dt.Rows[0]["stafftitle"].ToString();
                        staff.Email = dt.Rows[0]["email"].ToString();
                        staff.PhoneNumber = dt.Rows[0]["phonenumber"].ToString();
                        staff.Address = dt.Rows[0]["address"].ToString();
                        staff.Remark = dt.Rows[0]["remark"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw(ex);

            }

            return staff.StaffID > 0;
        }
    }
}