using NivyaAirlineData.Interface;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using NivyaAirlineData.Model;
namespace NivyaAirlineData.Repo
{
    public class FlightDetailsRepo : IFlightDetails
    {
        string strcon = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
        SqlDataAdapter da;

        public async Task<int> AddFlight(FlightDetails item)
        {

            int result = 0;
            using (SqlConnection con = new SqlConnection(strcon))
            {

                da = new SqlDataAdapter("proc_add_flight", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@flightno", item.FlightNo);
                da.SelectCommand.Parameters.AddWithValue("@flightname", item.FlightName);
                da.SelectCommand.Parameters.AddWithValue("@source", item.Source);
                da.SelectCommand.Parameters.AddWithValue("@destination", item.Destination);
                da.SelectCommand.Parameters.AddWithValue("@departure", item.Departure);
                da.SelectCommand.Parameters.AddWithValue("@arrival", item.Arrival);
                da.SelectCommand.Parameters.AddWithValue("@date", item.Date);
                da.SelectCommand.Parameters.AddWithValue("@seat_type", item.SeatType);
                da.SelectCommand.Parameters.AddWithValue("@price", item.Price);
                da.SelectCommand.Parameters.AddWithValue("@no_of_seats", item.NoOfSeats);

            }
            result = da.SelectCommand.ExecuteNonQuery();
            if (result > 0) { return result; }
            else { return 0; }
        }

        public FlightDetails GetFlightDetails()
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                SqlDataReader reader = null;
                da = new SqlDataAdapter("proc_get_flight", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                con.Open();
                reader = da.SelectCommand.ExecuteReader();
                FlightDetails details = null;
                while (reader.Read())
                {
                    details = new FlightDetails();
                    details.FlightNo = Convert.ToInt32(reader.GetValue(0));
                    details.FlightName = reader.GetValue(1).ToString();
                    details.Source = reader.GetValue(2).ToString();
                    details.Destination = reader.GetValue(3).ToString();
                    details.Departure = Convert.ToDateTime(reader.GetValue(4));
                    details.Arrival = Convert.ToDateTime(reader.GetValue(5));
                    details.Date = Convert.ToDateTime(reader.GetValue(6));
                    details.SeatType = reader.GetValue(7).ToString();
                    details.Price = Convert.ToInt32(reader.GetValue(8));
                    details.NoOfSeats = Convert.ToInt32(reader.GetValue(9));
                }
                return details;
                
            }
            
        }

        public List<FlightDetails> SearchFlight(string source, string destination)
        {
            List<FlightDetails> flightlist = new List<FlightDetails>();
            SqlDataReader reader;
            using (SqlConnection con = new SqlConnection(strcon))
            {
               
                da = new SqlDataAdapter("searchflight", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                con.Open();
                da.SelectCommand.Parameters.AddWithValue("@source", source);
                da.SelectCommand.Parameters.AddWithValue("@destination", destination);

                reader = da.SelectCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        FlightDetails details = new FlightDetails();
                        details.FlightNo = Convert.ToInt32(reader.GetValue(0));
                        details.FlightName = reader.GetValue(1).ToString();
                        details.Source = reader.GetValue(2).ToString();
                        details.Destination = reader.GetValue(3).ToString();
                        details.Departure = Convert.ToDateTime(reader.GetValue(4));
                        details.Arrival = Convert.ToDateTime(reader.GetValue(5));
                        details.Date = Convert.ToDateTime(reader.GetValue(6));
                        details.SeatType = reader.GetValue(7).ToString();
                        details.Price = Convert.ToInt32(reader.GetValue(8));
                        details.NoOfSeats = Convert.ToInt32(reader.GetValue(9));
                        flightlist.Add(details);
                    }
                }

            }
            return flightlist;
        }
    }
}
