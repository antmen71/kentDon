using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kentselDonusumPlatformu
{
    class kullanici
    {
        private int _id;
        private string _name;
        private string _surname;
        private string _email;
        //private string _phone;
        //private string _type;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string surName
        {
            get { return _surname; }
            set { _surname = value; }
        }

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string email
        {
            get { return _email; }
            set { _email = value; }
        }

        public kullanici getUser(string email)
        {
            kullanici kull = new kullanici();
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["kentDon"].ConnectionString);
            SqlCommand sql = new SqlCommand("SELECT id, isim, soyad, eposta, sifre FROM kullanici WHERE eposta = @email", sqlConn);
            sql.Parameters.AddWithValue("@email", email);
            sqlConn.Open();

           
                SqlDataReader reader = sql.ExecuteReader();

                while (reader.Read())
                {
                    kull.id = reader.GetInt32(0);
                    kull.name = reader.GetString(1);
                    kull.surName = reader.GetString(2);
                    kull.email = reader.GetString(3);
                }
   
            sqlConn.Close();
            return kull;
            
        }

        public void insertUserDetails(string email)
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["kentDon"].ConnectionString);
            //SqlCommand sqlCom = new SqlCommand ("INSERT INTO kullaiciDetay(")
        }
    }
}
