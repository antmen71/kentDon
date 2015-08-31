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
    public partial class updateUserDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["e"] == null)
            { Response.Redirect("loggeddef.aspx"); }

            illerDrpDwn.Items.Clear();
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["kentDon"].ConnectionString);
            sqlConn.Open();
            SqlCommand getIller = new SqlCommand("SELECT DISTINCT(ILADI) FROM iller ORDER BY ILADI", sqlConn);
            SqlDataReader reader = getIller.ExecuteReader();
            while (reader.Read())
            { illerDrpDwn.Items.Add(reader.GetString(0)); }

            sqlConn.Close();

            string email = Request.QueryString["e"];

            byte[] encodedByte = Convert.FromBase64String(email);
            string base64Encoded = Encoding.UTF8.GetString(encodedByte);


            kullanici kull = new kullanici();
            kull = kull.getUser(base64Encoded);

            TextBox1.Text = kull.name;
            TextBox2.Text = kull.surName;
            TextBox3.Text = kull.email;


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
            CheckBox evsahibi = (CheckBox)FindControl("evsahibi");
            CheckBox muteahhit = (CheckBox)FindControl("muteahhit");

            int kullaniciTipi = 3;

            if (evsahibi.Checked)
            { kullaniciTipi = 0; }
            else if (muteahhit.Checked)
            { kullaniciTipi = 1; }
            else if (evsahibi.Checked && muteahhit.Checked)
            { kullaniciTipi = 2; }
            else { }

            string cepTel = TextBox4.Text;
            string evTel = TextBox5.Text;
            string isTel = TextBox6.Text;
            string il = illerDrpDwn.SelectedValue.ToString();
            string ilce = ilcelerDrpDwn.SelectedValue.ToString();
            kullanici kull = new kullanici();
            kull = kull.getUser(TextBox3.Text);
            kull.insertUserDetails(kull.email, kullaniciTipi, cepTel, evTel, isTel, il, ilce);
            string txt1Enc = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(kull.email));
            Response.Redirect("loggeddef.aspx?e=" + txt1Enc);
        }
    }
}