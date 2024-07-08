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
    public partial class FrmRevenue : Form
    {
        public FrmRevenue()
        {
            InitializeComponent();
        }

        private void btnGetRevenue_Click(object sender, EventArgs e)
        {
            DateTime dt = this.dtpPeriod.Value;
            double revenue = DBController.getInstance().executeGetRevenueStoredProcedure(dt.Year,dt.Month);
            this.lbRevenue.Text = "$" + revenue.ToString();
        }

        private void FrmRevenue_Load(object sender, EventArgs e)
        {
            this.dtpPeriod.Format = DateTimePickerFormat.Custom;
            this.dtpPeriod.CustomFormat = "MMMM yyyy";
            this.dtpPeriod.ShowUpDown = true;
        }
    }
}
