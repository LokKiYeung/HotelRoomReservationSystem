using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.Model
{
    public class Charge
    {
        public int ChargeID { get; set; }
        public int PaymentID { get; set; }
        public string ChargeType { get; set; }
        public float ChargeAmount { get; set; }
    }
}
