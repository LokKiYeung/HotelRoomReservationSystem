using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.Model
{
    public class AuditLog
    {
        public int AuditID { get; set; }
        public string Action { get; set; }
        public int StaffID { get; set; }
        public DateTime AuditDate { get; set; }
    }
}
