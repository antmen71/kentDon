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

        public int ID;
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Request.QueryString["e"] == null)
            { Response.Redirect("Default.aspx"); }
            else
            {
                string email = Request.QueryString["e"];

                byte[] encodedByte = Convert.FromBase64String(email);
                string base64Encoded = Encoding.UTF8.GetString(encodedByte);
                SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["kentDon"].ConnectionString);
                sqlConn.Open();
                SqlCommand check = new SqlCommand("SELECT id,isim,soyad, eposta, sifre FROM kullanici WHERE eposta=@email", sqlConn);
                check.Parameters.AddWithValue("@email", base64Encoded);
                
                SqlDataReader reader = check.ExecuteReader();
                while (reader.Read())
                {
                    Repeater1.DataSource = reader;
                    Repeater1.DataBind();
                    
                }
                reader.Close();

                sqlConn.Close();


            }

        }

        protected void goToDetails()
        {
            

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            string email = Request.QueryString["e"];
            Response.Redirect("userDetails.aspx?e=" + email);
        }
    }
}