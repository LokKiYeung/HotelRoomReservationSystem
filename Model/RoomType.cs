using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.Model
{

    public class RoomType
    {
        public string RoomTypeName { get; set; }
        public int Capacity { get; set; }
        public double Price { get; set; }
        public bool NonSmoking { get; set; }
        public string Description { get; set; }
    }

}
