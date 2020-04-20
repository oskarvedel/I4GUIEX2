using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace GUIEX2PROJECT.Models
{
    public class RoomBooking
    {

        
        public int BookingId { get; set; }
        [DisplayName("Date |")]
        public DateTime Date { get; set; }

        [DisplayName(" Children |")]
        public int NumOfChildrenInRoom  { get; set; }
        [DisplayName(" Adults ")]
        public int NumOfAdultsInRoom  { get; set; }
        [DisplayName(" Child Reservations ")]
        public int NumberOfChildBreakfastReservations { get; set; }
        [DisplayName(" Adult Reservations ")]
        public int NumberOfAdultBreakfastReservations { get; set; }
        [DisplayName(" Children Checked In ")]
        public int NumberOfChildrenCheckedInToBreakfast { get; set; }
        [DisplayName(" Adults Checked In ")]
        public int NumberOfAdultsCheckedInToBreakfast { get; set; }
        [DisplayName(" Room ")]
        public Room Room { get; set; }
        public int RoomNumber { get; set; }
        
    }
}