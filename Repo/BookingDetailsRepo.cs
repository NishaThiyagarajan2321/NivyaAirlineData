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
    public class BookingDetailsRepo :IBookingDetails
    {
        string strcon = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
        SqlDataAdapter da;
        public BookingDetails GetBookingDetails()
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                SqlDataReader reader = null;
                da = new SqlDataAdapter("proc_get_Booking", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                con.Open();
                reader = da.SelectCommand.ExecuteReader();
                BookingDetails details = null;
                while (reader.Read())
                {
                    details = new BookingDetails();
                    details.BookingId = Convert.ToInt32(reader.GetValue(0));
                    details.FlightNo = Convert.ToInt32(reader.GetValue(1));
                    details.Email = reader.GetValue(2).ToString();
                    details.Source = reader.GetValue(3).ToString();
                    details.Destination = reader.GetValue(4).ToString();
                    details.SeatType = reader.GetValue(5).ToString();
                    details.NoOfSeats = Convert.ToInt32(reader.GetValue(6));
                    details.Price = Convert.ToInt32(reader.GetValue(7));
                }
                return details;
            }
        }

        public async Task<int> AddBooking(BookingDetails item)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(strcon))
            {

                da = new SqlDataAdapter("proc_Booking", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@book_id", item.BookingId);
                da.SelectCommand.Parameters.AddWithValue("@flightno", item.FlightNo);
                da.SelectCommand.Parameters.AddWithValue("@reg_email", item.Email);
                da.SelectCommand.Parameters.AddWithValue("@source", item.Source);
                da.SelectCommand.Parameters.AddWithValue("@destination", item.Destination);
                da.SelectCommand.Parameters.AddWithValue("@seat_type", item.SeatType);
                da.SelectCommand.Parameters.AddWithValue("@no_of_seats", item.NoOfSeats);
                da.SelectCommand.Parameters.AddWithValue("@price", item.Price);
               

            }
            result = da.SelectCommand.ExecuteNonQuery();
            if (result > 0) { return result; }
            else { return 0; }
        }

        


    }
}
