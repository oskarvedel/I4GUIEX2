using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace GUIEX2PROJECT.Models
{
    public class RoomBooking
    {
        public int BookingId { get; set; }
        [DisplayName("Date ")]
        public DateTime Date { get; set; }

        [DisplayName(" Children In Room")]
        public int NumOfChildrenInRoom  { get; set; }
        [DisplayName(" Adults In Room")]
        public int NumOfAdultsInRoom  { get; set; }
        [DisplayName(" Child Breakfast Reservations ")]
        public int NumberOfChildBreakfastReservations { get; set; }
        [DisplayName(" Adult Breakfast Reservations ")]
        public int NumberOfAdultBreakfastReservations { get; set; }
        [DisplayName(" Children Checked In To Breakfast ")]
        public int NumberOfChildrenCheckedInToBreakfast { get; set; }
        [DisplayName(" Adults Checked In To Breakfast ")]
        public int NumberOfAdultsCheckedInToBreakfast { get; set; }
        [DisplayName(" Room ")]
        public Room Room { get; set; }
        public int RoomNumber { get; set; }
        
    }
}