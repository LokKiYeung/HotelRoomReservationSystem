using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.Model
{
    internal class Appointment
    {
        public int AppointmentID { get; set; }
        public string Status { get; set; }
        public int StaffID { get; set; }
        public int GuestID { get; set; }
        public string Remark { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int NumAdult { get; set; }
        public int NumChild { get; set; }
        public int PaymentID { get; set; }
    }
}
