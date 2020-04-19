using System;

namespace WebApplication1.Models
{
    public class BreakfastReservation
    {
        enum ChildOrAdult
        {

        }
        public class BreakfastReservation
        {
            public int ReservationId { get; set; }
            public DateTime Date { get; set; }
            public int NumberOfChildReservations { get; set; }
            public int NumberOfAdultReservations { get; set; }
            public int NumberOfChildrenCheckedIn { get; set; }
            public int NumberOfAdultsCheckedIn { get; set; }

            public Room room { get; set; }
            public int roomNumber { get; set; }
        }
    }
}
