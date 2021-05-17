using NivyaAirlineData.Interface;
using NivyaAirlineData.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivyaAirlineData.Repo
{
    public class PaymentRepo : IPayment
    {
        string strcon = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
        SqlDataAdapter da;
        public async Task<int> AddPayment(Payment item)
        {

            int result = 0;
            using (SqlConnection con = new SqlConnection(strcon))
            {

                da = new SqlDataAdapter("proc_payment", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@book_id", item.BookingId);
                da.SelectCommand.Parameters.AddWithValue("@cardnumber", item.CardNumber);
                da.SelectCommand.Parameters.AddWithValue("@cvv", item.CVV);
                da.SelectCommand.Parameters.AddWithValue("@price", item.Price);
            }
            result = da.SelectCommand.ExecuteNonQuery();
            if (result > 0) { return result; }
            else { return 0; }

        }

        public Payment GetPaymentDetails()
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                SqlDataReader reader = null;
                da = new SqlDataAdapter("proc_get_Payment", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                con.Open();
                reader = da.SelectCommand.ExecuteReader();
                Payment payobj = null;
                while (reader.Read())
                {
                    payobj = new Payment();
                    payobj.BookingId = Convert.ToInt32(reader.GetValue(0));
                    payobj.CardNumber = reader.GetValue(1).ToString();
                    payobj.CVV = Convert.ToInt32(reader.GetValue(2));
                    payobj.Price = Convert.ToInt32(reader.GetValue(3));
                }
                return payobj;
            }
        }
    }
}
