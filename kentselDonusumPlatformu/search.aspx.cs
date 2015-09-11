using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kentselDonusumPlatformu
{
    public partial class search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                iller ille = new kentselDonusumPlatformu.iller();
                List<string> iller = new List<string>();
                iller = ille.getIller();
                DropDownList drpiller = (DropDownList)FindControl("iller");
                drpiller.DataSource = iller;
                drpiller.DataBind();
                DropDownList drpilceler = (DropDownList)FindControl("ilceler");
                drpilceler.DataSource = ille.getIlceler(drpiller.SelectedValue);
                drpilceler.DataBind();
            }
        }
        protected void iller_SelectedIndexChanged(object sender, EventArgs e)
        {

           
                DropDownList drpiller = (DropDownList)FindControl("iller");
                DropDownList drpilceler = (DropDownList)FindControl("ilceler");


                string il = drpiller.SelectedItem.ToString();
                drpilceler.Items.Clear();
                iller ilceler = new iller();
                List<string> ilcelers = ilceler.getIlceler(il);
                drpilceler.DataSource = ilcelers;
                drpilceler.DataBind();
            
        }
    }
}