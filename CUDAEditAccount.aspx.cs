using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JKTS_Contract_system.BLL;

namespace JKTS_Contract_system
{  // user = person who logged in (Which in this case is the department admin)
    // selected person = person who User wants to edit account information
    public partial class CUDAEditAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // session user's username
            lbl_UpdatedBy.Text = (string)(Session["User_Name"]);

            string updated = lbl_Updated.Text;

            // session selected person's ID
            lbl_UserID.Text = (string)(Session["User_ID"]);

            //first time form load, it does not work when button is clicked.
            if (Page.IsPostBack == false)
            {
                lbl_UpdatedBy.Text = (string)(Session["User_Name"]);
                string updatedby = lbl_UpdatedBy.Text;
                lbl_Updated.Text = DateTime.Now.ToShortDateString();

                BllAccount acc = new BllAccount();
                DataSet ds = new DataSet();
                ds = acc.GetEditDetails(lbl_UserID.Text); // get selected person's information based on his id
                DataTable td = ds.Tables[0];
                for (int i = 0; i < td.Rows.Count; i++)  // get information from gridview
                {
                    tb_Name.Text = td.Rows[i]["User_Name"].ToString();
                    string Name = Convert.ToString(tb_Name.Text);
                    tb_Email.Text = td.Rows[i]["User_Email"].ToString();
                    string Email = Convert.ToString(tb_Email.Text);
                    ddl_dept.Text = td.Rows[i]["User_Dept"].ToString();
                    string Dept = Convert.ToString(ddl_dept.Text);
                    tb_Designation.Text = td.Rows[i]["User_Designation"].ToString();
                    string Designation = Convert.ToString(tb_Designation.Text);
                    ddl_UserType.Text = td.Rows[i]["User_Type"].ToString();
                    string type = Convert.ToString(ddl_UserType.Text);
                    ddl_Active.Text = td.Rows[i]["User_Active"].ToString();
                    string Active = Convert.ToString(ddl_Active.Text);
                }

            }
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("CUDAViewUser.aspx");
        }

        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            string id, username, email, department, designation, type, active, updated, updatedby;
            id = Convert.ToString(lbl_UserID.Text);
            username = Convert.ToString(tb_Name.Text);
            email = Convert.ToString(tb_Email.Text);
            department = Convert.ToString(ddl_dept.Text);
            designation = Convert.ToString(tb_Designation.Text);
            type = Convert.ToString(ddl_UserType.Text);
            active = Convert.ToString(ddl_Active.Text);
            updated = Convert.ToString(lbl_Updated.Text);
            updatedby = Convert.ToString(lbl_UpdatedBy.Text);

            BllAccount myAcc = new BllAccount();
            int result = myAcc.UpdateUserDetail(id, username, email, department, designation, type, active, updated, updatedby);
            // udpate selected person's information in database table (User)

            if (result > 0)
            {
                Response.Write("<script>alert('Successfully Updated')</script>");

            }
            else
            {
                Response.Write("<script>alert('Failed to update')</sciprt>");
            }
        }
    }
    
}