using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kentselDonusumPlatformu
{
    public class kullanici
    {
        private int _id;
        private string _name;
        private string _surname;
        private string _email;
        private string _pass;
        private string _cellPhone;
        private string _homePhone;
        private string _workPhone;
        private int _userType;
        private string _city;
        private string _district;
        private string _guid;

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
        public string pass
        {
            get { return _pass; }
            set { _pass = value; }
        }
        public string cellPhone
        {
            get { return _cellPhone; }
            set { _cellPhone = value; }
        }

        public string homePhone
        {
            get { return _homePhone; }
            set { _homePhone = value; }
        }

        public string workPhone
        {
            get { return _workPhone; }
            set { _workPhone = value; }
        }

        public int userType
        {
            get { return _userType; }
            set { _userType = value; }
        }

        public string city
        {
            get { return _city; }
            set { _city = value; }
        }

        public string district
        {
            get { return _district; }
            set { _district = value; }
        }

        public string guid
        {
            get { return _guid; }
            set { _guid = value; }
        }


        public kullanici getUser(string email)
        {
            kullanici kull = new kullanici();
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["kentDon"].ConnectionString);
            SqlCommand sql = new SqlCommand("SELECT id, isim, soyad, eposta, sifre,guid FROM kullanici WHERE eposta = @email", sqlConn);
            sql.Parameters.AddWithValue("@email", email);
            sqlConn.Open();


            SqlDataReader reader = sql.ExecuteReader();

            while (reader.Read())
            {
                kull.id = reader.GetInt32(0);
                kull.name = reader.GetString(1);
                kull.surName = reader.GetString(2);
                kull.email = reader.GetString(3);
                kull.pass = reader.GetString(4);
                kull.guid = reader.GetString(5);
            }

            sqlConn.Close();
            return kull;

        }
        
        public void insertUser(string name, string surname, string email, string password)
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["kentDon"].ConnectionString);
            SqlCommand insert = new SqlCommand("insert into kullanici(isim,soyad,eposta,sifre,guid,cepTel,evTel,isTel, kullaniciTipi,il,ilce) values(@isim,@soyisim,@eposta,@sifre,@guid,@cepTel,@evTel,@isTel,@kullaniciTipi,@il,@ilce)", sqlConn);
            insert.Parameters.AddWithValue("@isim", name);
            insert.Parameters.AddWithValue("@soyisim", surname);
            insert.Parameters.AddWithValue("@eposta", email);
            string sifreEnc = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(password));
            insert.Parameters.AddWithValue("@sifre", sifreEnc);
            Guid guid = Guid.NewGuid();
            insert.Parameters.AddWithValue("@guid", guid);
            insert.Parameters.AddWithValue("@cepTel", DBNull.Value);
            insert.Parameters.AddWithValue("@evTel", DBNull.Value);
            insert.Parameters.AddWithValue("@isTel", DBNull.Value);
            insert.Parameters.AddWithValue("@kullaniciTipi", 3);
            insert.Parameters.AddWithValue("@il", DBNull.Value);
            insert.Parameters.AddWithValue("@ilce", DBNull.Value);

            sqlConn.Open();
            insert.ExecuteNonQuery();
            sqlConn.Close();
        }

        public void updateUserDetails(int id, string isim, string soyad, string eposta,  int kullaniciTipi, string cepTel, string evTel, string isTel, string il, string ilce)
        {
            kullanici kull = new kullanici();

            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["kentDon"].ConnectionString);

            SqlCommand sql = new SqlCommand("SELECT id FROM kullanici WHERE eposta = @email", sqlConn);
            sql.Parameters.AddWithValue("@email", email);
            sqlConn.Open();
            kull.id = Convert.ToInt32(sql.ExecuteScalar());
            sqlConn.Close();

            if (kull.id == 0)
            { }
            else
            {
                SqlConnection sqlConn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["kentDon"].ConnectionString);
                SqlCommand sqlInsertUserDetails = 
                    new SqlCommand("UPDATE kullanici SET isim=@name,soyad=@surname,kullaniciTipi=@kullaniciTipi,cepTel=@cepTel,evTel=@evTel,isTel=@isTel,timeStamp=@timeStamp,il=@il,ilce=@ilce WHERE id=@id" , sqlConn1);
                sqlInsertUserDetails.Parameters.AddWithValue("@id", id);

                sqlInsertUserDetails.Parameters.AddWithValue("@name", isim);
                    sqlInsertUserDetails.Parameters.AddWithValue("@surname", surName);

                sqlInsertUserDetails.Parameters.AddWithValue("@kullaniciTipi", kullaniciTipi);
                sqlInsertUserDetails.Parameters.AddWithValue("@cepTel", cepTel);
                sqlInsertUserDetails.Parameters.AddWithValue("@evTel", evTel);
                sqlInsertUserDetails.Parameters.AddWithValue("@isTel", isTel);
                sqlInsertUserDetails.Parameters.AddWithValue("@timeStamp", DateTime.Now);
                sqlInsertUserDetails.Parameters.AddWithValue("@il", il);
                sqlInsertUserDetails.Parameters.AddWithValue("@ilce", ilce);
                sqlConn1.Open();
                sqlInsertUserDetails.ExecuteNonQuery();
            }
        }

        public kullanici getUserDetails(string email)
        {
            kullanici kull = new kullanici();
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["kentDon"].ConnectionString);
            SqlCommand sql = new SqlCommand("SELECT id, isim, soyad, eposta, sifre,cepTel,evTel,isTel, kullaniciTipi,il,ilce FROM kullanici WHERE eposta = @email", sqlConn);
            sql.Parameters.AddWithValue("@email", email);
            sqlConn.Open();
            SqlDataReader reader = sql.ExecuteReader();
            while (reader.Read())
            {
                kull.id = reader.GetInt32(0);
                kull.name = reader.GetString(1);
                kull.surName = reader.GetString(2);
                kull.email = reader.GetString(3);
                kull.pass = reader.GetString(4);
                if (reader.IsDBNull(5))
                {
                    kull.cellPhone = "";
                }
                else
                {
                    kull.cellPhone = reader.GetString(5);
                }
                if (reader.IsDBNull(6))
                {
                    kull.homePhone = "";
                }
                else
                {
                    kull.homePhone = reader.GetString(6);
                }
                if (reader.IsDBNull(7))
                {
                    kull.workPhone = "";
                }
                else
                {
                    kull.workPhone = reader.GetString(7);
                }
                if (reader.IsDBNull(8))
                {
                    kull.userType = 3;
                }
                else
                {
                    kull.userType = reader.GetInt32(8);
                }
                if (reader.IsDBNull(9))
                {
                    kull.city = "";
                }
                else
                {
                    kull.city = reader.GetString(9);
                }
                if (reader.IsDBNull(10))
                {
                    kull.district = "";
                }
                else
                {
                    kull.district = reader.GetString(10);
                }
            }

            return kull;
        }





    }
}

