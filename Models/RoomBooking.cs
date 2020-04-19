using System;
using System.Collections.Generic;

namespace GUIEX2PROJECT.Models
{
    public class RoomBooking
    {
        public int BookingId { get; set; }
        public DateTime Date { get; set; }
        
        public int NumOfChildrenInRoom  { get; set; }
        public int NumOfAdultsInRoom  { get; set; }
        
        public int NumberOfChildBreakfastReservations { get; set; }
        public int NumberOfAdultBreakfastReservations { get; set; }
        
        public int NumberOfChildrenCheckedInToBreakfast { get; set; }
        public int NumberOfAdultsCheckedInToBreakfast { get; set; }

        public Room room { get; set; }
        public int RoomNumber { get; set; }
        
    }
}