using System.Collections.Generic;

namespace GUIEX2PROJECT.Models
{
    public class Room
    {
        public int RoomNumber { get; set; }

        public List<RoomBooking> RoomBookings{ get; set; }
    }
}