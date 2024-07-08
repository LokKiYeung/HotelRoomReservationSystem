using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.Model
{
    internal class PromotionType
    {
        public int PromotionID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double DiscountRate { get; set; }
    }
}
