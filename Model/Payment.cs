using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivyaAirlineData.Model
{
   public class Payment
    {
        public int PaymentId { get; set; }
        public int BookingId { get; set; }
        public string CardNumber { get; set; }
        public int CVV { get; set; }
        public float Price { get; set; }
       
    }
}
