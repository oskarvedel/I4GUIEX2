﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace GUIEX2PROJECT.Models
{
    public class RoomBooking
    {
        public int BookingId { get; set; }
        [DisplayName("Date ")]
        public DateTime Date { get; set; }
        
        [DisplayName("| Children |")]
        public int NumOfChildrenInRoom  { get; set; }
        [DisplayName(" Adults |")]
        public int NumOfAdultsInRoom  { get; set; }

        [DisplayName(" Children Reservations |")]
        public int NumberOfChildBreakfastReservations { get; set; }
        [DisplayName(" Adult Reservation |")]
        public int NumberOfAdultBreakfastReservations { get; set; }

        [DisplayName(" Children checked in |")]
        public int NumberOfChildrenCheckedInToBreakfast { get; set; }
        [DisplayName(" Adult checked in |")]
        public int NumberOfAdultsCheckedInToBreakfast { get; set; }
        public Room Room { get; set; }
        public int RoomId { get; set; }
        
    }
}