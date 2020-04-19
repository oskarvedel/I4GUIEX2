using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Room
    {
        public int RoomNumber { get; set; }

        public int NumberOfChildren { get; set; }
        public int NumberOfAdults { get; set; }

        public List<BreakfastReservation> BreakfastDates { get; set; }
    }
}
