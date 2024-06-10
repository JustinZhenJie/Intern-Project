using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JKTS_Contract_system
{
    public partial class CUMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_Email"] == null)
            {
                Response.Redirect("LoginHome.aspx");
            }
            else if (Session["User_Dept"] == null)
            {
                Response.Redirect("LoginHome.aspx");
            }
            else if (Session["User_Name"] == null)
            {
                Response.Redirect("LoginHome.aspx");
            }
        }

        protected void lb_ChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CUChangePassword.aspx");
        }

        protected void lb_Logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("LoginHome.aspx");
        }

        protected void Rb_CU_CheckedChanged(object sender, EventArgs e)
        {
            Response.Redirect("CUHomePage.aspx");
        }

        protected void Rb_DA_CheckedChanged1(object sender, EventArgs e)
        {
            Response.Redirect("CUDAHomePage.aspx");
        }
    }
}