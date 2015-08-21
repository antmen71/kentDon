using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace kentselDonusumPlatformu
{
    public partial class uyeOl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            
           

        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            isim.Text = "";
            soyisim.Text = "";
            email.Text = "";
            password.Text = "";
            password1.Text = "";
            isimLbl.Text = "*";
            soyisimLbl.Text = "*";
            emailLbl.Text = "*";
            sifreLbl.Text = "*";
            sifreLbl2.Text = "*";

        }

      

        protected void Unnamed1_Click1(object sender, EventArgs e)
        {

            if (isim.Text == "" || soyisim.Text == "" || email.Text == "" || password.Text == "" || password1.Text == "")
            {
                isimLbl.Text = "Lütfen kontrol ediniz";
                soyisimLbl.Text = "Lütfen kontrol ediniz";
                emailLbl.Text = "Lütfen kontrol ediniz";
                sifreLbl.Text = "Lütfen kontrol ediniz";
                sifreLbl2.Text = "Lütfen kontrol ediniz";
                return;
            }

            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["kentDon"].ConnectionString);
            SqlCommand insert = new SqlCommand("insert into kullanici(isim,soyad,eposta,sifre) values(@isim,@soyisim,@eposta,@sifre)", sqlConn);
            insert.Parameters.AddWithValue("@isim", isim.Text);
            insert.Parameters.AddWithValue("@soyisim", soyisim.Text);
            insert.Parameters.AddWithValue("@eposta", email.Text);
            string sifreEnc = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(password.Text));
            insert.Parameters.AddWithValue("@sifre", sifreEnc);

            sqlConn.Open();
            //insert.ExecuteNonQuery();
            try { insert.ExecuteNonQuery(); }
            catch (SqlException ex){ 

               isimLbl.Text= ex.Message.ToString();
            }


                sqlConn.Close();
            
            //    Response.Redirect("default.aspx");
            //else
            //    isimLbl.Text = "başarılı değil";

            isim.Text = "";
            soyisim.Text = "";
            email.Text = "";
            password.Text = "";
            password1.Text = "";


        }
    }
}