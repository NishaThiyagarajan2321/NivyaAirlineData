using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivyaAirlineData.Model
{
    public class FlightDetails
    {
        public int FlightNo { get; set; }
        public string FlightName { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        [DataType(DataType.Time)]
        public DateTime Departure { get; set; }
        [DataType(DataType.Time)]
        public DateTime Arrival { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string SeatType { get; set; }
        public float Price { get; set; }
        public int NoOfSeats { get; set; }


    }
}
