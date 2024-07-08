using HotelReservationSystem.Model;
using HotelReservationSystem.Controller;
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
    public partial class FrmGuest : Form
    {
        List<Guest> guests;
        public FrmGuest()
        {
            InitializeComponent();
        }
        private void LoadGuests()
        {
            guests = Util.getInstance().GetGuests();

            if (guests != null && guests.Count > 0)
            {
                this.dgvGuests.DataSource = guests;
            }

        }

        private void FrmGuest_Load(object sender, EventArgs e)
        {
            LoadGuests();
        }
    }
}