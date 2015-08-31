﻿using System;
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
                kull.pass = reader.GetString(4);
            }

            sqlConn.Close();
            return kull;

        }
        
        public void insertUser(string name, string surname, string email, string password)
        {

        }

        public void insertUserDetails(string email, int kullaniciTipi, string cepTel, string evTel, string isTel, string il, string ilce)
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
                SqlCommand sqlInsertUserDetails = new SqlCommand("INSERT INTO kullaniciDetay(userId, kullaniciTipi,cepTel,evTel,isTel,timeStamp,il,ilce) values(@userId,@kullaniciTipi,@cepTel,@evTel,@isTel,@timeStamp,@il,@ilce)", sqlConn1);
                sqlInsertUserDetails.Parameters.AddWithValue("@userId", kull.id);
                sqlInsertUserDetails.Parameters.AddWithValue("@kullaniciTipi", kullaniciTipi);
                sqlInsertUserDetails.Parameters.AddWithValue("cepTel", cepTel);
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
            SqlCommand sql = new SqlCommand("SELECT k.id, k.isim, k.soyad, k.eposta, k.sifre,kd.cepTel,kd.evTel,kd.isTel, kd.kullaniciTipi,kd.il,kd.ilce FROM kullanici k JOIN kullaniciDetay kd ON k.id=kd.userId WHERE eposta = @email", sqlConn);
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
                kull.cellPhone = reader.GetString(5);
                kull.homePhone = reader.GetString(6);
                kull.workPhone = reader.GetString(7);
                kull.userType = reader.GetInt32(8);
                kull.city = reader.GetString(9);
                kull.district = reader.GetString(10);
            }

            return kull;
        }





    }
}

