using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kentselDonusumPlatformu
{
   public class iller
    {
        public List<string> getIller()
        {
            List<string> iller = new List<string>();

            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["kentDon"].ConnectionString);
            sqlConn.Open();
            SqlCommand getIller = new SqlCommand("SELECT DISTINCT(ILADI) FROM iller ORDER BY ILADI", sqlConn);
            SqlDataReader reader = getIller.ExecuteReader();
            while (reader.Read())
                iller.Add(reader.GetString(0));

            sqlConn.Close();
            return iller;
        }


        public List<string> getIlceler(string il)
        {
            List<string> ilceler = new List<string>();
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["kentDon"].ConnectionString);
            sqlConn.Open();
            SqlCommand check = new SqlCommand("SELECT ILCEADI FROM iller WHERE ILADI=@il ORDER BY ILCEADI", sqlConn);
            check.Parameters.AddWithValue("@il", il);
            SqlDataReader reader = check.ExecuteReader();
            while (reader.Read())
            {
                ilceler.Add(reader.GetString(0));
            }
            sqlConn.Close();
            return ilceler;
        }
    }
}
