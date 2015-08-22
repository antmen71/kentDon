using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kentselDonusumPlatformu
{
    public partial class loggeddef : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            string email = Request.QueryString["e"];
            byte[] encodedByte = Convert.FromBase64String(email);
            string base64Encoded = Encoding.UTF8.GetString(encodedByte);
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["kentDon"].ConnectionString);
            SqlCommand check = new SqlCommand("SELECT isim,soyad, eposta, sifre FROM kullanici WHERE eposta=@email", sqlConn);
            check.Parameters.AddWithValue("@email", base64Encoded);
            sqlConn.Open();
            SqlDataReader reader = check.ExecuteReader();
            while (reader.Read())
            {
                Label lbl = (Label)FindControl("Label1");
                lbl.Text = "Sayın " + reader.GetString(0) + " " + reader.GetString(1) + " sitemize hoşgeldiniz.";

            }

        }
    }
}