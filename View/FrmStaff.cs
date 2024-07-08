using HotelReservationSystem.Controller;
using HotelReservationSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HotelReservationSystem.View
{
    public partial class FrmStaff : Form
    {
        List<Staff> staffs ;
        Staff handling_staff;
        public FrmStaff(Staff user)
        {
            InitializeComponent();
            this.handling_staff = user;
        }
        private void LoadStaffs()
        {

            staffs = Util.getInstance().GetStaffs();
            if (staffs != null && staffs.Count > 0) {
                this.dgvStaff.DataSource = staffs;
                this.dgvStaff.Columns["PASSWORD"].Visible = false;
            }
        }

        private void FrmStaff_Load(object sender, EventArgs e)
        {
            LoadStaffs();
        }

        private void btnEditStaff_Click(object sender, EventArgs e)
        {
            if (dgvStaff.SelectedRows.Count > 0)
            {
                Staff targetStaff = (Staff)dgvStaff.CurrentRow.DataBoundItem; ;
                FrmEditStaffPassword frm = new FrmEditStaffPassword(handling_staff, ref targetStaff);
                frm.ShowDialog();
            }

        }
    }
}