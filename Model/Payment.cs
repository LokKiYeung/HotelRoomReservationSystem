using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.Model
{
    internal class Payment
    {
        public int PaymentID { get; set; }
        public string PaymentType { get; set; }
        public float TotalPayment { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PromotionID { get; set; }
    }
}
