﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kentselDonusumPlatformu
{
    public partial class kayitBasarili : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)FindControl("TextBox1");
            TextBox txt1 = (TextBox)FindControl("TextBox2");

            if (txt.Text == "" || txt1.Text == "")
            {
                Label lblWarning = (Label)FindControl("Label1");
                lblWarning.ForeColor = System.Drawing.Color.Red;
                lblWarning.Text = "Eposta ve/veya şifre alanlarını boş bıraktınız.";
                return;
            }

            string email = txt.Text;
            string txt1Enc = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(txt1.Text));


            kullanici kull = new kullanici();
            kull = kull.getUser(email);


            //            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["kentDon"].ConnectionString);
            //            SqlCommand check = new SqlCommand("SELECT eposta, sifre FROM kullanici WHERE eposta=@email", sqlConn);
            //            check.Parameters.AddWithValue("@email", email);

            //            sqlConn.Open();
            //            SqlDataReader reader = check.ExecuteReader();
            //reader.Read() && 
            if (kull.pass == txt1Enc)
            {

                string emailEnc = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(kull.email));
                Response.Redirect("loggeddef.aspx?e=" + emailEnc);

            }

            else
            {

                Label lblWarning = (Label)FindControl("Label1");
                lblWarning.ForeColor = System.Drawing.Color.Red;
                lblWarning.Text = "Eposta veya şifreniz hatalıdır lütfen tekrar deneyiniz.";
            }

        }
    }
    }
