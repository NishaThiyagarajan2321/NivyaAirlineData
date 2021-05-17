using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NivyaAirlineData.Interface;
using NivyaAirlineData.Model;

namespace NivyaAirlineData.Repo
{
    public class RegistrationRepo : IRegistration
    {
        string strcon = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
        SqlDataAdapter da;
        public async Task<int> AddUser(Registration item)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(strcon))
            {

                da = new SqlDataAdapter("proc_register", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@uname", item.Username);
                da.SelectCommand.Parameters.AddWithValue("@reg_email", item.Email);
                da.SelectCommand.Parameters.AddWithValue("@reg_mobile", item.MobileNumber);
                da.SelectCommand.Parameters.AddWithValue("@reg_password", item.Password);
            }
            result = da.SelectCommand.ExecuteNonQuery();
            if (result > 0) { return result; }
            else { return 0; }
        }

        public Registration GetRegistrationDetails()
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                SqlDataReader reader = null;
                da = new SqlDataAdapter("proc_get_user", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                con.Open();
                reader = da.SelectCommand.ExecuteReader();
                Registration details = null;
                while (reader.Read())
                {
                    details = new Registration();
                    details.Username = reader.GetValue(0).ToString();
                    details.Email = reader.GetValue(1).ToString();
                    details.MobileNumber = reader.GetValue(2).ToString();
                    details.Password = reader.GetValue(3).ToString();
                }
                return details;
            }
        }
    }
}
