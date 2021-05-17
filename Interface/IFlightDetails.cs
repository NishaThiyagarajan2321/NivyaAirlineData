using NivyaAirlineData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivyaAirlineData.Interface
{
    public interface IFlightDetails
    {
        FlightDetails GetFlightDetails();
        Task<int> AddFlight(FlightDetails item);
        List<FlightDetails> SearchFlight(string source, string destination);


    }
}
