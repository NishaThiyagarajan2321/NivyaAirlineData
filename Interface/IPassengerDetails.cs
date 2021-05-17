using NivyaAirlineData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivyaAirlineData.Interface
{
    public interface IPassengerDetails
    {
        PassengerDetails GetPassengerDetails();
        Task<int> AddPassenger(PassengerDetails item);
    }
}
