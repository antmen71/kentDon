using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
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
            clearForm();

        }

        public bool checkMail(string mailAddress)
        {
            List<string> emailAdresses = new List<string>();
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["kentDon"].ConnectionString);
            SqlCommand check = new SqlCommand("SELECT eposta FROM kullanici", sqlConn);
            sqlConn.Open();

            SqlDataReader sqlDataReader = check.ExecuteReader();
            while (sqlDataReader.Read())
                emailAdresses.Add(sqlDataReader.GetSqlValue(0).ToString());
            sqlConn.Close();

            if (emailAdresses.Contains(mailAddress))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public string guidSql (string mailAddress)
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["kentDon"].ConnectionString);
            SqlCommand check = new SqlCommand("SELECT guid FROM kullanici WHERE eposta=@email", sqlConn);
            check.Parameters.AddWithValue("@email", mailAddress);
            sqlConn.Open();
            string guidSql = check.ExecuteScalar().ToString();
            return guidSql;
        }

        protected void Unnamed1_Click1(object sender, EventArgs e)
        {

            if (isim.Text == "" || soyisim.Text == "" || email.Text == "" || password.Text == "" || password1.Text == "" || password.Text !=password1.Text)
            {
                isimLbl.Text = "Lütfen kontrol ediniz";
                soyisimLbl.Text = "Lütfen kontrol ediniz";
                emailLbl.Text = "Lütfen kontrol ediniz";
                sifreLbl.Text = "Lütfen kontrol ediniz";
                sifreLbl2.Text = "Lütfen kontrol ediniz";
                return;
            }

            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["kentDon"].ConnectionString);
            SqlCommand insert = new SqlCommand("insert into kullanici(isim,soyad,eposta,sifre,guid) values(@isim,@soyisim,@eposta,@sifre,@guid)", sqlConn);
            insert.Parameters.AddWithValue("@isim", isim.Text);
            insert.Parameters.AddWithValue("@soyisim", soyisim.Text);
            insert.Parameters.AddWithValue("@eposta", email.Text);
            string sifreEnc = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(password.Text));
            insert.Parameters.AddWithValue("@sifre", sifreEnc);
            Guid guid = Guid.NewGuid();
            insert.Parameters.AddWithValue("@guid", guid);
            sqlConn.Open();
            bool epostaKayitlimi = checkMail(email.Text);
            string eposta = email.Text;
            if (epostaKayitlimi == false)
            {
                emailLbl.Text = "bu posta adresi ile daha önce kayıt alınmıştır";

                return;
            }


            else
            {

                try
                {
                    insert.ExecuteNonQuery();
                  

                    SmtpClient client = new SmtpClient("smtp.live.com");
                    
                    client.Port = 587;
                  
                    client.EnableSsl = true;
                    client.Timeout = 10000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential("orkunantmen@hotmail.com", "zenuKar71");

                    MailMessage mm = new MailMessage("orkunantmen@hotmail.com", email.Text);
                    string body1 = "Kentsel dönüşüm platformuna kayıt olduğunuz için teşekkür ederiz. Üyeliğinizin aktif hale getirilmesi için lütfen aşağıdaki linki tıklayınız.";
                    string body2 = "\r\n";
                    string body3 = "http://www.kentseldonusumplatformu.com/uyeonay.aspx?g=";
                    string cliGuid = guidSql(email.Text);
                    mm.Body = body1 + body2 + body3+cliGuid;

                    mm.Subject = "Kentsel Dönüşüm Platformuna hoşgeldiniz!";

                    try
                    {

                        client.Send(mm);
                    }
                    catch (SmtpException smEx)
                    {
                        isimLbl.Text = smEx.ToString();
                    }

                    Response.Redirect("kayitBasarili.aspx");
                }
                catch (SqlException ex)
                {

                    isimLbl.Text = ex.Message.ToString();
                }


                sqlConn.Close();



                clearForm();
            }

        }

        private void clearForm()
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
    }
}