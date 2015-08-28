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
    public partial class userDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["e"] == null)
            { Response.Redirect("Default.aspx"); }
            else
            {
                string email = Request.QueryString["e"];

                byte[] encodedByte = Convert.FromBase64String(email);
                string base64Encoded = Encoding.UTF8.GetString(encodedByte);

                kullanici kull = new kullanici();
                kull = kull.getUser(base64Encoded);
                TextBox1.Text = kull.name;
                TextBox2.Text = kull.surName;
                TextBox3.Text = kull.email;


                SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["kentDon"].ConnectionString);
                //SqlCommand getUserDetails = new SqlCommand("SELECT * FROM kullanici k JOIN kullaniciDetay kd ON k.id = kd.userId WHERE eposta=@email", sqlConn);
                //getUserDetails.Parameters.AddWithValue("@email", base64Encoded);
                //sqlConn.Open();
                //SqlDataReader userDetailsReader = getUserDetails.ExecuteReader();
                //while (userDetailsReader.Read())
                //{
                //    TextBox1.Text = userDetailsReader.GetString(1);
                //    TextBox2.Text = userDetailsReader.GetString(2);
                //    TextBox3.Text = userDetailsReader.GetString(3);
                //}
                //sqlConn.Close();
                sqlConn.Open();
                SqlCommand check = new SqlCommand("SELECT DISTINCT(ILADI) FROM iller", sqlConn);
                SqlDataReader reader = check.ExecuteReader();

                illerDrpDwn.Items.Add("Lütfen seçiniz");
                while (reader.Read())
                {
                    illerDrpDwn.Items.Add(reader.GetString(0));
                }

                sqlConn.Close();
            }
        }
        protected void illerDrpDwn_SelectedIndexChanged(object sender, EventArgs e)
        {
            ilcelerDrpDwn.Items.Clear();
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["kentDon"].ConnectionString);
            sqlConn.Open();
            SqlCommand check = new SqlCommand("SELECT ILCEADI FROM iller WHERE ILADI=@il ORDER BY ILCEADI", sqlConn);
            check.Parameters.AddWithValue("@il", illerDrpDwn.SelectedValue.ToString());
            SqlDataReader reader = check.ExecuteReader();
            while (reader.Read())
            { ilcelerDrpDwn.Items.Add(reader.GetString(0)); }
            
            sqlConn.Close();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            kullanici kull = new kullanici();
            kull.getUser(TextBox3.Text);

        }
    }
}