
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using JKTS_Contract_system.BLL;
using System.Data;
using System.Configuration;
using System.Net.Mail;
using System.IO;
using System.Drawing;


namespace JKTS_Contract_system
{
    public partial class CUDAViewAllContracts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_Dept.Text = (string)(Session)["User_Dept"];
            lbl_Email.Text = (string)(Session)["User_Email"];

            if (!IsPostBack)
                BindGridView();
        }

        private void BindGridView()
        {
            BllContract contract = new BllContract();
            DataSet DS;
            DS = contract.GetContractGridView(lbl_Dept.Text.ToString());
            contractGridView.DataSource = DS;
            contractGridView.DataBind();
        }
        protected void createContract_Click(object sender, EventArgs e)
        {
            Response.Redirect("CUDACreateContract.aspx");
        }

        protected void contractGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

            string contractID = contractGridView.SelectedRow.Cells[0].Text;
            Session["contractID"] = contractID;
            string contractStatus = contractGridView.SelectedRow.Cells[10].Text;
            if (contractStatus == "Active")
            {
                Response.Redirect("CUDAContractDetailsActive.aspx");
            }

            if (contractStatus == "Expiring")
            {
                Response.Redirect("CUDAContractDetailsExpiring.aspx");
            }

            if (contractStatus == "Expired")
            {
                Response.Redirect("CUDAContractDetailsExpired.aspx");
            }
        }

        protected void contractGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            BllContract contract = new BllContract();
            string contractID = contractGridView.DataKeys[e.RowIndex].Value.ToString();
            result = contract.DeleteContract(contractID);

            if (result > 0)
            {
                Response.Write("<script>alert('Successfully Delete')</script>");
                BindGridView();
            }
            else
            {
                Response.Write("<script>alert('Failed to Delete, please try again')</script>");
            }



        }

        protected void contractGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {

            }

            else if (e.CommandName == "edit")
            {

            }
        }



        protected void contractGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string contractID = contractGridView.Rows[e.NewEditIndex].Cells[0].Text;
            Session["contractID"] = contractID;
            Response.Redirect("CUDAContractEdit.aspx");

        }

        //filters
        protected void ddlcontractSubType_SelectedIndexChanged(object sender, EventArgs e)
        {

            string strcon = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;

            SqlConnection con = new SqlConnection(strcon);

            con.Open();

            if (titleTB.Text == "")
            {
                if ((ddlcontractSubType.SelectedItem.Text == "All" || ddlcontractSubType.SelectedItem.Text == "") && ddlcontractType.SelectedItem.Text == "All")
                {
                    string strquery = "select * from Contract where contractDepartment ='" + lbl_Dept.Text + "'" + " and contractHistory = 0";

                    SqlCommand cmd = new SqlCommand(strquery, con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    contractGridView.DataSource = ds;

                    contractGridView.DataBind();

                    con.Close();

                }
                else if (ddlcontractSubType.SelectedItem.Text != "All" || ddlcontractType.SelectedItem.Text != "All")

                {

                    string strquery = "";

                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text == "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + "and contractDepartment = '" + lbl_Dept.Text + "'" + " and contractHistory = 0";
                    }

                    if (ddlcontractSubType.SelectedItem.Text == "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractType='" + ddlcontractType.SelectedItem.Text + "'" + "and contractDepartment = '" + lbl_Dept.Text + "'" + " and contractHistory = 0";
                    }
                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + "and contractDepartment ='" + lbl_Dept.Text + "'" + "and contractType ='" + ddlcontractType.SelectedItem.Text + "'" + " and contractHistory = 0";
                    }
                    SqlCommand cmd = new SqlCommand(strquery, con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    contractGridView.DataSource = ds;

                    contractGridView.DataBind();

                    con.Close();
                }
            }
            else
            {
                if ((ddlcontractSubType.SelectedItem.Text == "All" || ddlcontractSubType.SelectedItem.Text == "") && ddlcontractType.SelectedItem.Text == "All")
                {

                    string strquery = "select * from Contract where contractDepartment ='" + lbl_Dept.Text + "'" + " and contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";

                    SqlCommand cmd = new SqlCommand(strquery, con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    contractGridView.DataSource = ds;

                    contractGridView.DataBind();

                    con.Close();

                }
                else if (ddlcontractSubType.SelectedItem.Text != "All" || ddlcontractType.SelectedItem.Text != "All")

                {

                    string strquery = "";

                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text == "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + "and contractDepartment = '" + lbl_Dept.Text + "'" + " and contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";
                    }

                    if (ddlcontractSubType.SelectedItem.Text == "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractType='" + ddlcontractType.SelectedItem.Text + "'" + "and contractDepartment = '" + lbl_Dept.Text + "'" + " and contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";
                    }
                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + "and contractDepartment ='" + lbl_Dept.Text + "'" + "and contractType ='" + ddlcontractType.SelectedItem.Text + "'" + " and contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";
                    }
                    SqlCommand cmd = new SqlCommand(strquery, con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    contractGridView.DataSource = ds;

                    contractGridView.DataBind();

                    con.Close();
                }
            }

        }

        protected void ddlcontractType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strcon = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;

            SqlConnection con = new SqlConnection(strcon);

            con.Open();

            if (titleTB.Text == "")
            {
                if ((ddlcontractSubType.SelectedItem.Text == "All" || ddlcontractSubType.SelectedItem.Text == "") && ddlcontractType.SelectedItem.Text == "All")
                {

                    string strquery = "select * from Contract where contractDepartment ='" + lbl_Dept.Text + "'" + " and contractHistory = 0";

                    SqlCommand cmd = new SqlCommand(strquery, con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    contractGridView.DataSource = ds;

                    contractGridView.DataBind();

                    con.Close();

                }
                else if (ddlcontractSubType.SelectedItem.Text != "All" || ddlcontractType.SelectedItem.Text != "All")

                {

                    string strquery = "";

                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text == "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + "and contractDepartment = '" + lbl_Dept.Text + "'" + " and contractHistory = 0";
                    }

                    if (ddlcontractSubType.SelectedItem.Text == "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractType='" + ddlcontractType.SelectedItem.Text + "'" + "and contractDepartment = '" + lbl_Dept.Text + "'" + " and contractHistory = 0";
                    }
                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + "and contractDepartment ='" + lbl_Dept.Text + "'" + "and contractType ='" + ddlcontractType.SelectedItem.Text + "'" + " and contractHistory = 0";
                    }
                    SqlCommand cmd = new SqlCommand(strquery, con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    contractGridView.DataSource = ds;

                    contractGridView.DataBind();

                    con.Close();
                }
            }
            else
            {
                if ((ddlcontractSubType.SelectedItem.Text == "All" || ddlcontractSubType.SelectedItem.Text == "") && ddlcontractType.SelectedItem.Text == "All")
                {

                    string strquery = "select * from Contract where contractDepartment ='" + lbl_Dept.Text + "'" + " and contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";

                    SqlCommand cmd = new SqlCommand(strquery, con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    contractGridView.DataSource = ds;

                    contractGridView.DataBind();

                    con.Close();

                }
                else if (ddlcontractSubType.SelectedItem.Text != "All" || ddlcontractType.SelectedItem.Text != "All")

                {

                    string strquery = "";

                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text == "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + "and contractDepartment = '" + lbl_Dept.Text + "'" + " and contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";
                    }

                    if (ddlcontractSubType.SelectedItem.Text == "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractType='" + ddlcontractType.SelectedItem.Text + "'" + "and contractDepartment = '" + lbl_Dept.Text + "'" + " and contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";
                    }
                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + "and contractDepartment ='" + lbl_Dept.Text + "'" + "and contractType ='" + ddlcontractType.SelectedItem.Text + "'" + " and contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";
                    }
                    SqlCommand cmd = new SqlCommand(strquery, con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    contractGridView.DataSource = ds;

                    contractGridView.DataBind();

                    con.Close();
                }
            }
        }

        protected void viewAllContracts_Click(object sender, EventArgs e)
        {
            Response.Redirect("CUDAViewAllContracts.aspx");
        }
        protected void contractGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            e.Row.Cells[0].Visible = false;
            e.Row.Cells[12].Visible = false;
            e.Row.Cells[13].Visible = false;

        }
        protected void exportToExcelbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("CUDAExportContract.aspx");
        }

        protected void contractHistoryBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("CUDAContractHistory.aspx");
        }
        protected void searchBtn_Click(object sender, EventArgs e)
        {

            string strcon = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;

            SqlConnection con = new SqlConnection(strcon);

            con.Open();

            if (titleTB.Text == "")
            {
                if ((ddlcontractSubType.SelectedItem.Text == "All" || ddlcontractSubType.SelectedItem.Text == "") && ddlcontractType.SelectedItem.Text == "All")
                {

                    string strquery = "select * from Contract where contractDepartment ='" + lbl_Dept.Text + "'" + " and contractHistory = 0";

                    SqlCommand cmd = new SqlCommand(strquery, con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    contractGridView.DataSource = ds;

                    contractGridView.DataBind();

                    con.Close();

                }
                else if (ddlcontractSubType.SelectedItem.Text != "All" || ddlcontractType.SelectedItem.Text != "All")

                {

                    string strquery = "";

                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text == "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + "and contractDepartment = '" + lbl_Dept.Text + "'" + " and contractHistory = 0";
                    }

                    if (ddlcontractSubType.SelectedItem.Text == "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractType='" + ddlcontractType.SelectedItem.Text + "'" + "and contractDepartment = '" + lbl_Dept.Text + "'" + " and contractHistory = 0";
                    }
                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + "and contractDepartment ='" + lbl_Dept.Text + "'" + "and contractType ='" + ddlcontractType.SelectedItem.Text + "'" + " and contractHistory = 0";
                    }
                    SqlCommand cmd = new SqlCommand(strquery, con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    contractGridView.DataSource = ds;

                    contractGridView.DataBind();

                    con.Close();
                }
            }
            else
            {
                if ((ddlcontractSubType.SelectedItem.Text == "All" || ddlcontractSubType.SelectedItem.Text == "") && ddlcontractType.SelectedItem.Text == "All")
                {

                    string strquery = "select * from Contract where contractDepartment ='" + lbl_Dept.Text + "'" + " and contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";

                    SqlCommand cmd = new SqlCommand(strquery, con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    contractGridView.DataSource = ds;

                    contractGridView.DataBind();

                    con.Close();

                }
                else if (ddlcontractSubType.SelectedItem.Text != "All" || ddlcontractType.SelectedItem.Text != "All")

                {

                    string strquery = "";

                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text == "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + "and contractDepartment = '" + lbl_Dept.Text + "'" + " and contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";
                    }

                    if (ddlcontractSubType.SelectedItem.Text == "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractType='" + ddlcontractType.SelectedItem.Text + "'" + "and contractDepartment = '" + lbl_Dept.Text + "'" + " and contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";
                    }
                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + "and contractDepartment ='" + lbl_Dept.Text + "'" + "and contractType ='" + ddlcontractType.SelectedItem.Text + "'" + " and contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";
                    }
                    SqlCommand cmd = new SqlCommand(strquery, con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    contractGridView.DataSource = ds;

                    contractGridView.DataBind();

                    con.Close();
                }
            }
        }

    }
}