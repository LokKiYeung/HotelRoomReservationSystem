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
using System.Windows.Forms.VisualStyles;

namespace HotelReservationSystem.View
{

    public partial class FrmMakeReservation : Form
    {
        Staff handling_staff;
        string[] countries = { "Andorra", "United Arab Emirates", "Afghanistan", "Antigua and Barbuda", "Anguilla", "Albania", "Armenia", "Netherlands Antilles", "Angola", "Antarctica", "Argentina", "American Samoa", "Austria", "Australia", "Aruba", "Azerbaijan", "Bosnia and Herzegovina", "Barbados", "Bangladesh", "Belgium", "Burkina Faso", "Bulgaria", "Bahrain", "Burundi", "Benin", "Bermuda", "Brunei", "Bolivia", "Brazil", "Bahamas", "Bhutan", "Bouvet Island", "Botswana", "Belarus", "Belize", "Canada", "Cocos[Keeling] Islands", "Congo[DRC]", "Central African Republic", "Congo[Republic]", "Switzerland", "Côte d'Ivoire", "Cook Islands", "Chile", "Cameroon", "China", "Colombia", "Costa Rica", "Cuba", "Cape Verde", "Christmas Island", "Cyprus", "Czech Republic", "Germany", "Djibouti", "Denmark", "Dominica", "Dominican Republic", "Algeria", "Ecuador", "Estonia", "Egypt", "Western Sahara", "Eritrea", "Spain", "Ethiopia", "Finland", "Fiji", "Falkland Islands [Islas Malvinas]", "Micronesia", "Faroe Islands", "France", "Gabon", "United Kingdom", "Grenada", "Georgia", "French Guiana", "Guernsey", "Ghana", "Gibraltar", "Greenland", "Gambia", "Guinea", "Guadeloupe", "Equatorial Guinea", "Greece", "South Georgia and the South Sandwich Islands", "Guatemala", "Guam", "Guinea-Bissau", "Guyana", "Gaza Strip", "Hong Kong", "Heard Island and McDonald Islands", "Honduras", "Croatia", "Haiti", "Hungary", "Indonesia", "Ireland", "Israel", "Isle of Man", "India", "British Indian Ocean Territory", "Iraq", "Iran", "Iceland", "Italy", "Jersey", "Jamaica", "Jordan", "Japan", "Kenya", "Kyrgyzstan", "Cambodia", "Kiribati", "Comoros", "Saint Kitts and Nevis", "North Korea", "South Korea", "Kuwait", "Cayman Islands", "Kazakhstan", "Laos", "Lebanon", "Saint Lucia", "Liechtenstein", "Sri Lanka", "Liberia", "Lesotho", "Lithuania", "Luxembourg", "Latvia", "Libya", "Morocco", "Monaco", "Moldova", "Montenegro", "Madagascar", "Marshall Islands", "Macedonia [FYROM]", "Mali", "Myanmar [Burma]", "Mongolia", "Macau", "Northern Mariana Islands", "Martinique", "Mauritania", "Montserrat", "Malta", "Mauritius", "Maldives", "Malawi", "Mexico", "Malaysia", "Mozambique", "Namibia", "New Caledonia", "Niger", "Norfolk Island", "Nigeria", "Nicaragua", "Netherlands", "Norway", "Nepal", "Nauru", "Niue", "New Zealand", "Oman", "Panama", "Peru", "French Polynesia", "Papua New Guinea", "Philippines", "Pakistan", "Poland", "Saint Pierre and Miquelon", "Pitcairn Islands", "Puerto Rico", "Palestinian Territories", "Portugal", "Palau", "Paraguay", "Qatar", "Réunion", "Romania", "Serbia", "Russia", "Rwanda", "Saudi Arabia", "Solomon Islands", "Seychelles", "Sudan", "Sweden", "Singapore", "Saint Helena", "Slovenia", "Svalbard and Jan Mayen", "Slovakia", "Sierra Leone", "San Marino", "Senegal", "Somalia", "Suriname", "São Tomé and Príncipe", "El Salvador", "Syria", "Swaziland", "Turks and Caicos Islands", "Chad", "French Southern Territories", "Togo", "Thailand", "Tajikistan", "Tokelau", "Timor-Leste", "Turkmenistan", "Tunisia", "Tonga", "Turkey", "Trinidad and Tobago", "Tuvalu", "Taiwan", "Tanzania", "Ukraine", "Uganda", "U.S. Minor Outlying Islands", "United States", "Uruguay", "Uzbekistan", "Vatican City", "Saint Vincent and the Grenadines", "Venezuela", "British Virgin Islands", "U.S. Virgin Islands", "Vietnam", "Vanuatu", "Wallis and Futuna", "Samoa", "Kosovo", "Yemen", "Mayotte", "South Africa", "Zambia", "Zimbabwe" };
        string[] genders = { "N/A", "Male", "Female", "Other" };
        List<Room> rooms;

        public FrmMakeReservation(Staff user)
        {
            InitializeComponent();
            this.handling_staff = user;
        }

        private void FrmMakeReservation_Load(object sender, EventArgs e)
        {
            cboCountry.Items.AddRange(countries);
            cboCountry.SelectedIndex = 0;
            cboCountry.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboCountry.AutoCompleteCustomSource.AddRange(countries);
            cboCountry.AutoCompleteMode = AutoCompleteMode.Suggest;

            cboGender.Items.AddRange(genders);
            cboGender.SelectedIndex = 0;
            cboGender.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboGender.AutoCompleteCustomSource.AddRange(genders);
            cboGender.AutoCompleteMode = AutoCompleteMode.Suggest;

            rooms = Util.getInstance().GetRooms();

            cboRoom.Items.AddRange(rooms.Select(x => x.RoomNumber).ToArray());
            cboRoom.SelectedIndex = 0;
            cboRoom.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboRoom.AutoCompleteCustomSource.AddRange(rooms.Select(x => x.RoomNumber).ToArray());
            cboRoom.AutoCompleteMode = AutoCompleteMode.Suggest;


            txtFirst.Text = "Maple";
            txtLast.Text = "Leaf";
            txtPassport.Text = "X11223344";
            txtPhoneNumber.Text = "0011223344";
            txtEmail.Text = "Maple.Leaf@abc.com";
            txtRemark.Text = "Non smooking";
            txtAge.Text = "42";
            cboGender.SelectedIndex = 0;
            cboRoom.SelectedIndex = 0;
            cboCountry.SelectedIndex = 0;
            cboChild.SelectedIndex = 0;
            cboAdult.SelectedIndex = 0;
        }
        private void LoadRooms()
        {
            DataTable oDT = DBController.getInstance().executeQuery("select ROOMID, ROOMNUMBER,ROOMDESC,ROOMTYPE,ISCLEAN from ROOM");
            if (oDT != null && oDT.Rows.Count > 0)
            {
                for (int i = 0; i < oDT.Rows.Count; i++)
                {
                    Room room = new Room();
                    room.RoomID = Convert.ToInt32(oDT.Rows[i]["ROOMID"]);
                    room.RoomNumber = oDT.Rows[i]["ROOMNUMBER"].ToString();
                    room.RoomDesc = oDT.Rows[i]["ROOMDESC"].ToString();
                    room.RoomType = oDT.Rows[i]["ROOMTYPE"].ToString();
                    room.IsClean = Convert.ToBoolean(oDT.Rows[i]["ISCLEAN"]);
                    rooms.Add(room);
                }

            }

        }
        private void btnAddReservation_Click(object sender, EventArgs e)
        {
            // create guest
            string firstname = txtFirst.Text;
            string lastname = txtLast.Text;
            int gender = Util.getInstance().GenderTextToNum(cboGender.SelectedItem.ToString());


            int age = Convert.ToInt32(txtAge.Text);
            string phonenumer = txtPhoneNumber.Text;
            string email = txtEmail.Text;
            string country = cboCountry.SelectedItem.ToString();
            string passportid = txtPassport.Text;

            // create guest if not exist
            int guestid = DBController.getInstance().executeCreateGuestStoredProcedure(handling_staff.StaffID, firstname, lastname, gender, age, phonenumer, email, country, passportid);
            if (guestid != 0)
            {
                // make appointment
                string remark = txtRemark.Text;
                DateTime checkin = dtpCheckin.Value;
                DateTime checkout = dtpCheckout.Value;
                int numAdult = Convert.ToInt32(cboAdult.SelectedItem.ToString());
                int numChild = Convert.ToInt32(cboChild.SelectedItem.ToString());
                string roomNum = cboRoom.SelectedItem.ToString();
                int appointmentid = DBController.getInstance().executeCreateAppointmentStoredProcedure(handling_staff.StaffID, guestid, remark, checkin, checkout, numAdult, numChild, roomNum);
                if (appointmentid != 0)
                {
                    MessageBox.Show("Appointment made!", "Appointment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to make Appointment!", "Appointment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void dtpCheckOut_ValueChanged(object sender, EventArgs e)
        {
            if (dtpCheckout.Value < dtpCheckin.Value)
            {
                return;
            }

        }

        private void dtpCheckin_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
