using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivyaAirlineData.Model
{
    public class PassengerDetails
    {
        public int PassengerId { get; set; }
        public int FlightNo { get; set; }
        public string PassengerName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        
        public string Email { get; set; }
    }
}
