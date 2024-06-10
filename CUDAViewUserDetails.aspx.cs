using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JKTS_Contract_system.BLL;

namespace JKTS_Contract_system
{
    public partial class CUDAViewUserDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //session selected person's user id
            lbl_UserID.Text = (string)(Session["User_ID"]);
            Bind();
        }
        public void Bind()
        {
            BllAccount myAcc = new BllAccount();
            DataSet ds;
            ds = myAcc.GetUserDetail(lbl_UserID.Text); // get infromation of selected person based on id
            DetailsView1.DataSource = ds;
            DetailsView1.DataBind();

        }
        protected void Btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("CUDAViewUser.aspx");
        }
    }
}