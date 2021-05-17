using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivyaAirlineData.Model
{
    public class BookingDetails
    {
        public int BookingId { get; set; }
        public int FlightNo { get; set; }
        public string Email { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string SeatType { get; set; }
        public float Price { get; set; }
        public int NoOfSeats { get; set; }
    }
}
