using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace kentselDonusumPlatformu
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        



        protected void Unnamed1_Click(object sender, EventArgs e)
        {

            TextBox txt = (TextBox)FindControl("TextBox1");
            TextBox txt1 = (TextBox)FindControl("TextBox2");
            string txtEnc = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(txt.Text));
            string txt2Enc = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(txt1.Text));

            Response.Redirect("kaydol.aspx?k=" + txtEnc+"&p="+txt2Enc);

        }
    }
}