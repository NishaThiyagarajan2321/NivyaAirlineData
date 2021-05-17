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
    public class PassengerDetailsRepo : IPassengerDetails
    {
        string strcon = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
        SqlDataAdapter da;
        public async Task<int> AddPassenger(PassengerDetails item)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(strcon))
            {

                da = new SqlDataAdapter("proc_add_passenger", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@flightno", item.FlightNo);
                da.SelectCommand.Parameters.AddWithValue("@pname", item.PassengerName);
                da.SelectCommand.Parameters.AddWithValue("@age", item.Age);
                da.SelectCommand.Parameters.AddWithValue("@gender", item.Gender);
                da.SelectCommand.Parameters.AddWithValue("@email", item.Email);
            }
            result = da.SelectCommand.ExecuteNonQuery();
            if (result > 0) { return result; }
            else { return 0; }
        }



        public PassengerDetails GetPassengerDetails()
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                SqlDataReader reader = null;
                da = new SqlDataAdapter("proc_get_Passenger", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                con.Open();
                reader = da.SelectCommand.ExecuteReader();
                PassengerDetails obj = null;
                while (reader.Read())
                {
                    obj = new PassengerDetails();
                    obj.FlightNo = Convert.ToInt32(reader.GetValue(0));
                    obj.PassengerName = reader.GetValue(1).ToString();
                    obj.Age = Convert.ToInt32(reader.GetValue(2));
                    obj.Gender = reader.GetValue(3).ToString();
                    obj.Email= reader.GetValue(4).ToString();
                }
                return obj;
            }


        }
    }
}
