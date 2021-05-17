using NivyaAirlineData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivyaAirlineData.Interface
{
    public interface IRegistration
    {
        Registration GetRegistrationDetails();
        Task<int> AddUser(Registration item);
    }
}
