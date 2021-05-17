using NivyaAirlineData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivyaAirlineData.Interface
{
    public interface IBookingDetails
    {
        BookingDetails GetBookingDetails();
        Task<int> AddBooking(BookingDetails item);
    }
}
