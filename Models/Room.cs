using System.Collections.Generic;

namespace GUIEX2PROJECT.Models
{
    public class Room
    {
        public int RoomNumber { get; set; }

        public int NumberOfChildren { get; set; }
        public int NumberOfAdults { get; set; }

        public List<BreakfastReservation> BreakfastDates { get; set; }
    }
}
