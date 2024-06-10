using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JKTS_Contract_system.BLL;
using System.Configuration;
using System.Data.SqlClient;

namespace JKTS_Contract_system
{
    public partial class CUDAViewUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // session user's department
            lbl_Dept.Text = (string)(Session)["User_Dept"];

            if (Page.IsPostBack == false) //first time form load, it does not work when button is clicked
            {
                BindGridView();
            }
        }
        private void BindGridView()
        {
            BllAccount myAcc = new BllAccount();
            DataSet ds;
            ds = myAcc.GetAllUserButSA(lbl_Dept.Text); // get information of all the people in user's department              
            gv_User.DataSource = ds;                // displayed in gridview
            gv_User.DataBind();
        }

        protected void btn_Create_Click(object sender, EventArgs e)
        {
            Response.Redirect("CUDACreateAccount.aspx");
        }

        protected void btn_Export_Click(object sender, EventArgs e)
        {
            Response.Redirect("CuDAExport.aspx");
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            string strcon = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;

            SqlConnection con = new SqlConnection(strcon);

            con.Open();

            if (tb_Name.Text == "")
            {
                if (ddl_Active.SelectedItem.Text == "All")
                {

                    string strquery = "select * from [User] where User_Type NOT LIKE 'Setting%'" + " and User_Dept = '" + lbl_Dept.Text + "'";
                    SqlCommand cmd = new SqlCommand(strquery, con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    gv_User.DataSource = ds;

                    gv_User.DataBind();

                    con.Close();

                    Button2.Visible = true;
                }
                else if (ddl_Active.SelectedItem.Text != "All")

                {

                    string strquery = "";

                    if (ddl_Active.SelectedItem.Text != "All")
                    {
                        strquery = "select * from [User] where User_Type NOT LIKE 'Setting%'" + " and User_Active ='" + ddl_Active.SelectedItem.Text + "'" + " and User_Dept ='" + lbl_Dept.Text + "'";
                    }

                    SqlCommand cmd = new SqlCommand(strquery, con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    gv_User.DataSource = ds;

                    gv_User.DataBind();

                    con.Close();
                }
                Button2.Visible = true;
            }
            else
            {
                if (ddl_Active.SelectedItem.Text == "All")
                {

                    string strquery = "select * from [User] where User_Type NOT LIKE 'Setting%'" + " and User_Name LIKE '%" + tb_Name.Text + "%'" + " and User_Dept = '" + lbl_Dept.Text + "'";

                    SqlCommand cmd = new SqlCommand(strquery, con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    gv_User.DataSource = ds;

                    gv_User.DataBind();

                    con.Close();

                    Button2.Visible = true;

                }
                else if (ddl_Active.SelectedItem.Text != "All")

                {

                    string strquery = "";

                    if (ddl_Active.SelectedItem.Text != "All")
                    {
                        strquery = "select * from [User] where User_Type NOT LIKE 'Setting%'" + " and User_Active ='" + ddl_Active.SelectedItem.Text + "'" + " and User_Dept ='" + lbl_Dept.Text + "'" + " and User_Name LIKE '%" + tb_Name.Text + "%'";
                    }

                    SqlCommand cmd = new SqlCommand(strquery, con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    gv_User.DataSource = ds;

                    gv_User.DataBind();

                    con.Close();
                }
                Button2.Visible = true;
            }
        }

        protected void ddl_Active_SelectedIndexChanged(object sender, EventArgs e)
        {
            // to connect to database
            string strcon = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;

            SqlConnection con = new SqlConnection(strcon);

            con.Open();

            if (tb_Name.Text == "")
            {
                if (ddl_Active.SelectedItem.Text == "All")
                {

                    string strquery = "select * from [User] where User_Type NOT LIKE 'Setting%'" + " and User_Dept = '" + lbl_Dept.Text + "'";
                    SqlCommand cmd = new SqlCommand(strquery, con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    gv_User.DataSource = ds;

                    gv_User.DataBind();

                    con.Close();

                    Button2.Visible = true;
                }
                else if (ddl_Active.SelectedItem.Text != "All")

                {

                    string strquery = "";

                    if (ddl_Active.SelectedItem.Text != "All")
                    {
                        strquery = "select * from [User] where User_Type NOT LIKE 'Setting%'" + " and User_Active ='" + ddl_Active.SelectedItem.Text + "'" + " and User_Dept ='" + lbl_Dept.Text + "'";
                    }

                    SqlCommand cmd = new SqlCommand(strquery, con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    gv_User.DataSource = ds;

                    gv_User.DataBind();

                    con.Close();
                }
                Button2.Visible = true;
            }
            else
            {
                if (ddl_Active.SelectedItem.Text == "All")
                {

                    string strquery = "select * from [User] where User_Type NOT LIKE 'Setting%'" + " and User_Name LIKE '%" + tb_Name.Text + "%'" + " and User_Dept = '" + lbl_Dept.Text + "'";

                    SqlCommand cmd = new SqlCommand(strquery, con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    gv_User.DataSource = ds;

                    gv_User.DataBind();

                    con.Close();

                    Button2.Visible = true;

                }
                else if (ddl_Active.SelectedItem.Text != "All")

                {

                    string strquery = "";

                    if (ddl_Active.SelectedItem.Text != "All")
                    {
                        strquery = "select * from [User] where User_Type NOT LIKE 'Setting%'" + " and User_Active ='" + ddl_Active.SelectedItem.Text + "'" + " and User_Dept ='" + lbl_Dept.Text + "'" + " and User_Name LIKE '%" + tb_Name.Text + "%'";
                    }

                    SqlCommand cmd = new SqlCommand(strquery, con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    gv_User.DataSource = ds;

                    gv_User.DataBind();

                    con.Close();
                }
                Button2.Visible = true;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("CUDAViewUser.aspx");
        }

        protected void gv_User_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false; //Hide User_ID
            e.Row.Cells[3].Visible = false; //Hide User_Email
            e.Row.Cells[5].Visible = false; //Hide User_Designation
            e.Row.Cells[8].Visible = false; // Hide Created Date
            e.Row.Cells[9].Visible = false; // Hide Created By
            e.Row.Cells[10].Visible = false; // Hide Updated Date
            e.Row.Cells[11].Visible = false; // Hide Updated By
        }

        protected void gv_User_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "select")
            {

            }
            if (e.CommandName == "Edit")
            {

            }
            if (e.CommandName == "Delete")
            {

            }
        }

        protected void gv_User_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            BllAccount myAcc = new BllAccount();
            string User_ID = gv_User.DataKeys[e.RowIndex].Value.ToString();
            result = myAcc.DeleteUser(User_ID); //delete user from database table (User)

            if (result > 0) //if yes button is clicked
            {
                Response.Write("<script>alert('Account Deleted successfully');</script>");
                BindGridView();
            }
            else  // if no button is clicked
            {
                Response.Write("<script>alert('Failed to Delete Account');</script>");
            }
        }

        protected void gv_User_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // session the user's user id
            string User_ID = gv_User.Rows[e.NewEditIndex].Cells[1].Text;
            Session["User_ID"] = User_ID;
            Response.Redirect("CUDAEditAccount.aspx");
        }

        protected void gv_User_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            BindGridView();
        }

        protected void gv_User_SelectedIndexChanged(object sender, EventArgs e)
        {
            string User_ID = gv_User.SelectedRow.Cells[1].Text;
            Session["User_ID"] = User_ID;


            Response.Redirect("CUDAViewUserDetails.aspx");
        }
    }
}