using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.Model
{
    public class Staff
    {
        public Staff() { }
        public Staff(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
      
        public int StaffID { get; set; }
        public string StaffTitle { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Remark { get; set; }
    }
}
