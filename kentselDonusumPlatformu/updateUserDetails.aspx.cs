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
            if (!IsPostBack)
            {
                if (Request.QueryString["e"] == null)
                { Response.Redirect("loggeddef.aspx"); }

                illerDrpDwn.Items.Clear();
                iller iller = new iller();
                List<string> illers = iller.getIller();
                illerDrpDwn.DataSource = illers;
                illerDrpDwn.DataBind();
                illerDrpDwn.Items.Insert(0, "Lütfen seçiniz");

                string email = Request.QueryString["e"];

                byte[] encodedByte = Convert.FromBase64String(email);
                string base64Encoded = Encoding.UTF8.GetString(encodedByte);

                //kullanici kull = new kullanici();
                //kull = kull.getUser(base64Encoded);
                //TextBox1.Text = kull.name;
                //TextBox2.Text = kull.surName;
                //TextBox3.Text = kull.email;
                kullanici kull = new kullanici();
                kullanici kull1 = new kullanici();
                kull = kull.getUser(base64Encoded);
                kull1 = kull1.getUserDetails(base64Encoded);
                TextBox1.Text = kull.name;
                TextBox2.Text = kull.surName;
                TextBox3.Text = kull.email;
                TextBox4.Text = kull1.cellPhone;
                TextBox5.Text = kull1.homePhone;
                TextBox6.Text = kull1.workPhone;
                CheckBox chkEv = (CheckBox)FindControl("evsahibi");
                CheckBox chkMut = (CheckBox)FindControl("muteahhit");
                if (kull1.userType == 0)
                {
                    chkEv.Checked = true;
                    chkMut.Checked = false;
                }
                else if (kull1.userType == 1)
                {
                    chkMut.Checked = true;
                    chkEv.Checked = false;
                }
                else if (kull1.userType == 2)
                {
                    chkEv.Checked = true;
                    chkMut.Checked = true;
                }

                foreach (string il in illers)
                { if (il == kull1.city)
                        illerDrpDwn.SelectedValue = il;
                    
                }
                ilcelerDrpDwn.Items.Clear();
                iller ilceler = new iller();
                List<string> ilcelers = ilceler.getIlceler(kull1.city);
                ilcelerDrpDwn.DataSource = ilcelers;
                ilcelerDrpDwn.DataBind();
                foreach (string ilce in ilcelers)
                {
                    if (ilce == kull1.city)
                        ilcelerDrpDwn.SelectedValue = ilce;
                    return;
                }
            }
        }

        protected void illerDrpDwn_SelectedIndexChanged(object sender, EventArgs e)
        {
            string il = illerDrpDwn.SelectedItem.ToString();
            ilcelerDrpDwn.Items.Clear();
            iller ilceler = new iller();
            List<string> ilcelers = ilceler.getIlceler(il);
            ilcelerDrpDwn.DataSource = ilcelers;
            ilcelerDrpDwn.DataBind();
            
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
            string email = TextBox3.Text;
            string name = TextBox1.Text;
            string surName = TextBox2.Text;
            string cepTel = TextBox4.Text;
            string evTel = TextBox5.Text;
            string isTel = TextBox6.Text;
            string il = illerDrpDwn.SelectedValue.ToString();
            string ilce = ilcelerDrpDwn.SelectedValue.ToString();
            kullanici kull = new kullanici();
            kull = kull.getUser(TextBox3.Text);
            kull.insertUserDetails(kull.id,name, surName, email,  kullaniciTipi, cepTel, evTel, isTel, il, ilce);
            string txt1Enc = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(kull.email));
            Response.Redirect("loggeddef.aspx?e=" + txt1Enc);
        }
    }
}