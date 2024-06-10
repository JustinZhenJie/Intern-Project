
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
    public partial class CUViewAllContracts : System.Web.UI.Page
    {
        public int index { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {



            if (Page.IsPostBack == false)
                BindGridView();
        }

        private void BindGridView()
        {
            BllContract contract = new BllContract();
            DataSet DS;
            DS = contract.GetContractGridView();
            contractGridView.DataSource = DS;
            contractGridView.DataBind();
        }


        protected void contractGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

            string contractID = contractGridView.SelectedRow.Cells[0].Text;
            Session["contractID"] = contractID;
            string contractStatus = contractGridView.SelectedRow.Cells[10].Text;

            Response.Redirect("CUContractDetails.aspx");

        }

        protected void contractGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            BllContract contract = new BllContract();
            //string contractID = contractGridView.SelectedRow.Cells[0].Text;
            string contractID = contractGridView.DataKeys[e.RowIndex].Value.ToString();
            result = contract.DeleteContract(contractID);

            if (result > 0)
            {
                Response.Write("<script>alert('Sucessfully Delete')</script>");
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





        protected void ddlcontractSubType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strcon = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;

            SqlConnection con = new SqlConnection(strcon);

            con.Open();

            if (titleTB.Text == "")
            {
                if ((ddlcontractSubType.SelectedItem.Text == "All" || ddlcontractSubType.SelectedItem.Text == "") && ddlcontractDepartment.SelectedItem.Text == "All" && ddlcontractType.SelectedItem.Text == "All")
                {

                    string strquery = "select * from Contract where contractHistory = 0";

                    SqlCommand cmd = new SqlCommand(strquery, con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    contractGridView.DataSource = ds;

                    contractGridView.DataBind();

                    con.Close();

                }
                else if (ddlcontractSubType.SelectedItem.Text != "All" || ddlcontractDepartment.SelectedItem.Text != "All" || ddlcontractType.SelectedItem.Text != "All")

                {

                    string strquery = "";

                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractDepartment.SelectedItem.Text == "All" && ddlcontractType.SelectedItem.Text == "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + " and contractHistory = 0";
                    }
                    if (ddlcontractSubType.SelectedItem.Text == "All" && ddlcontractDepartment.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text == "All")
                    {
                        strquery = "select * from Contract where contractDepartment='" + ddlcontractDepartment.SelectedItem.Text + "'" + " and contractHistory = 0";
                    }
                    if (ddlcontractSubType.SelectedItem.Text == "All" && ddlcontractDepartment.SelectedItem.Text == "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractType='" + ddlcontractType.SelectedItem.Text + "'" + " and contractHistory = 0";
                    }
                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractDepartment.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text == "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + "and contractDepartment ='" + ddlcontractDepartment.SelectedItem.Text + "'" + " and contractHistory = 0";
                    }
                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractDepartment.SelectedItem.Text == "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + "and contractType ='" + ddlcontractType.SelectedItem.Text + "'" + " and contractHistory = 0";
                    }
                    if (ddlcontractSubType.SelectedItem.Text == "All" && ddlcontractDepartment.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractDepartment='" + ddlcontractDepartment.SelectedItem.Text + "'" + "and contractType ='" + ddlcontractType.SelectedItem.Text + "'" + " and contractHistory = 0";
                    }
                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractDepartment.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + "and contractDepartment ='" + ddlcontractDepartment.SelectedItem.Text + "'" + "and contractType ='" + ddlcontractType.SelectedItem.Text + "'" + " and contractHistory = 0";
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
                if ((ddlcontractSubType.SelectedItem.Text == "All" || ddlcontractSubType.SelectedItem.Text == "") && ddlcontractDepartment.SelectedItem.Text == "All" && ddlcontractType.SelectedItem.Text == "All")
                {

                    string strquery = "select * from Contract where contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";

                    SqlCommand cmd = new SqlCommand(strquery, con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    contractGridView.DataSource = ds;

                    contractGridView.DataBind();

                    con.Close();

                }
                else if (ddlcontractSubType.SelectedItem.Text != "All" || ddlcontractDepartment.SelectedItem.Text != "All" || ddlcontractType.SelectedItem.Text != "All")

                {

                    string strquery = "";

                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractDepartment.SelectedItem.Text == "All" && ddlcontractType.SelectedItem.Text == "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + " and contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";
                    }
                    if (ddlcontractSubType.SelectedItem.Text == "All" && ddlcontractDepartment.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text == "All")
                    {
                        strquery = "select * from Contract where contractDepartment='" + ddlcontractDepartment.SelectedItem.Text + "'" + " and contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";
                    }
                    if (ddlcontractSubType.SelectedItem.Text == "All" && ddlcontractDepartment.SelectedItem.Text == "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractType='" + ddlcontractType.SelectedItem.Text + "'" + " and contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";
                    }
                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractDepartment.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text == "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + "and contractDepartment ='" + ddlcontractDepartment.SelectedItem.Text + "'" + " and contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";
                    }
                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractDepartment.SelectedItem.Text == "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + "and contractType ='" + ddlcontractType.SelectedItem.Text + "'" + " and contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";
                    }
                    if (ddlcontractSubType.SelectedItem.Text == "All" && ddlcontractDepartment.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractDepartment='" + ddlcontractDepartment.SelectedItem.Text + "'" + "and contractType ='" + ddlcontractType.SelectedItem.Text + "'" + " and contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";
                    }
                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractDepartment.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + "and contractDepartment ='" + ddlcontractDepartment.SelectedItem.Text + "'" + "and contractType ='" + ddlcontractType.SelectedItem.Text + "'" + " and contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";
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

        protected void ddlcontractDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

            string strcon = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;

            SqlConnection con = new SqlConnection(strcon);

            con.Open();

            if (titleTB.Text == "")
            {
                if ((ddlcontractSubType.SelectedItem.Text == "All" || ddlcontractSubType.SelectedItem.Text == "") && ddlcontractDepartment.SelectedItem.Text == "All" && ddlcontractType.SelectedItem.Text == "All")
                {

                    string strquery = "select * from Contract where contractHistory = 0";

                    SqlCommand cmd = new SqlCommand(strquery, con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    contractGridView.DataSource = ds;

                    contractGridView.DataBind();

                    con.Close();

                }
                else if (ddlcontractSubType.SelectedItem.Text != "All" || ddlcontractDepartment.SelectedItem.Text != "All" || ddlcontractType.SelectedItem.Text != "All")

                {

                    string strquery = "";

                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractDepartment.SelectedItem.Text == "All" && ddlcontractType.SelectedItem.Text == "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + " and contractHistory = 0";
                    }
                    if (ddlcontractSubType.SelectedItem.Text == "All" && ddlcontractDepartment.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text == "All")
                    {
                        strquery = "select * from Contract where contractDepartment='" + ddlcontractDepartment.SelectedItem.Text + "'" + " and contractHistory = 0";
                    }
                    if (ddlcontractSubType.SelectedItem.Text == "All" && ddlcontractDepartment.SelectedItem.Text == "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractType='" + ddlcontractType.SelectedItem.Text + "'" + " and contractHistory = 0";
                    }
                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractDepartment.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text == "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + "and contractDepartment ='" + ddlcontractDepartment.SelectedItem.Text + "'" + " and contractHistory = 0";
                    }
                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractDepartment.SelectedItem.Text == "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + "and contractType ='" + ddlcontractType.SelectedItem.Text + "'" + " and contractHistory = 0";
                    }
                    if (ddlcontractSubType.SelectedItem.Text == "All" && ddlcontractDepartment.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractDepartment='" + ddlcontractDepartment.SelectedItem.Text + "'" + "and contractType ='" + ddlcontractType.SelectedItem.Text + "'" + " and contractHistory = 0";
                    }
                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractDepartment.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + "and contractDepartment ='" + ddlcontractDepartment.SelectedItem.Text + "'" + "and contractType ='" + ddlcontractType.SelectedItem.Text + "'" + " and contractHistory = 0";
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
                if ((ddlcontractSubType.SelectedItem.Text == "All" || ddlcontractSubType.SelectedItem.Text == "") && ddlcontractDepartment.SelectedItem.Text == "All" && ddlcontractType.SelectedItem.Text == "All")
                {

                    string strquery = "select * from Contract where contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";

                    SqlCommand cmd = new SqlCommand(strquery, con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    contractGridView.DataSource = ds;

                    contractGridView.DataBind();

                    con.Close();

                }
                else if (ddlcontractSubType.SelectedItem.Text != "All" || ddlcontractDepartment.SelectedItem.Text != "All" || ddlcontractType.SelectedItem.Text != "All")

                {

                    string strquery = "";

                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractDepartment.SelectedItem.Text == "All" && ddlcontractType.SelectedItem.Text == "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + " and contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";
                    }
                    if (ddlcontractSubType.SelectedItem.Text == "All" && ddlcontractDepartment.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text == "All")
                    {
                        strquery = "select * from Contract where contractDepartment='" + ddlcontractDepartment.SelectedItem.Text + "'" + " and contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";
                    }
                    if (ddlcontractSubType.SelectedItem.Text == "All" && ddlcontractDepartment.SelectedItem.Text == "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractType='" + ddlcontractType.SelectedItem.Text + "'" + " and contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";
                    }
                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractDepartment.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text == "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + "and contractDepartment ='" + ddlcontractDepartment.SelectedItem.Text + "'" + " and contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";
                    }
                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractDepartment.SelectedItem.Text == "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + "and contractType ='" + ddlcontractType.SelectedItem.Text + "'" + " and contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";
                    }
                    if (ddlcontractSubType.SelectedItem.Text == "All" && ddlcontractDepartment.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractDepartment='" + ddlcontractDepartment.SelectedItem.Text + "'" + "and contractType ='" + ddlcontractType.SelectedItem.Text + "'" + " and contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";
                    }
                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractDepartment.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + "and contractDepartment ='" + ddlcontractDepartment.SelectedItem.Text + "'" + "and contractType ='" + ddlcontractType.SelectedItem.Text + "'" + " and contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";
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
                if ((ddlcontractSubType.SelectedItem.Text == "All" || ddlcontractSubType.SelectedItem.Text == "") && ddlcontractDepartment.SelectedItem.Text == "All" && ddlcontractType.SelectedItem.Text == "All")
                {

                    string strquery = "select * from Contract where contractHistory = 0";

                    SqlCommand cmd = new SqlCommand(strquery, con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    contractGridView.DataSource = ds;

                    contractGridView.DataBind();

                    con.Close();

                }
                else if (ddlcontractSubType.SelectedItem.Text != "All" || ddlcontractDepartment.SelectedItem.Text != "All" || ddlcontractType.SelectedItem.Text != "All")

                {

                    string strquery = "";

                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractDepartment.SelectedItem.Text == "All" && ddlcontractType.SelectedItem.Text == "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + " and contractHistory = 0";
                    }
                    if (ddlcontractSubType.SelectedItem.Text == "All" && ddlcontractDepartment.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text == "All")
                    {
                        strquery = "select * from Contract where contractDepartment='" + ddlcontractDepartment.SelectedItem.Text + "'" + " and contractHistory = 0";
                    }
                    if (ddlcontractSubType.SelectedItem.Text == "All" && ddlcontractDepartment.SelectedItem.Text == "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractType='" + ddlcontractType.SelectedItem.Text + "'" + " and contractHistory = 0";
                    }
                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractDepartment.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text == "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + "and contractDepartment ='" + ddlcontractDepartment.SelectedItem.Text + "'" + " and contractHistory = 0";
                    }
                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractDepartment.SelectedItem.Text == "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + "and contractType ='" + ddlcontractType.SelectedItem.Text + "'" + " and contractHistory = 0";
                    }
                    if (ddlcontractSubType.SelectedItem.Text == "All" && ddlcontractDepartment.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractDepartment='" + ddlcontractDepartment.SelectedItem.Text + "'" + "and contractType ='" + ddlcontractType.SelectedItem.Text + "'" + " and contractHistory = 0";
                    }
                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractDepartment.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + "and contractDepartment ='" + ddlcontractDepartment.SelectedItem.Text + "'" + "and contractType ='" + ddlcontractType.SelectedItem.Text + "'" + " and contractHistory = 0";
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
                if ((ddlcontractSubType.SelectedItem.Text == "All" || ddlcontractSubType.SelectedItem.Text == "") && ddlcontractDepartment.SelectedItem.Text == "All" && ddlcontractType.SelectedItem.Text == "All")
                {

                    string strquery = "select * from Contract where contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";

                    SqlCommand cmd = new SqlCommand(strquery, con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    contractGridView.DataSource = ds;

                    contractGridView.DataBind();

                    con.Close();

                }
                else if (ddlcontractSubType.SelectedItem.Text != "All" || ddlcontractDepartment.SelectedItem.Text != "All" || ddlcontractType.SelectedItem.Text != "All")

                {

                    string strquery = "";

                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractDepartment.SelectedItem.Text == "All" && ddlcontractType.SelectedItem.Text == "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + " and contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";
                    }
                    if (ddlcontractSubType.SelectedItem.Text == "All" && ddlcontractDepartment.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text == "All")
                    {
                        strquery = "select * from Contract where contractDepartment='" + ddlcontractDepartment.SelectedItem.Text + "'" + " and contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";
                    }
                    if (ddlcontractSubType.SelectedItem.Text == "All" && ddlcontractDepartment.SelectedItem.Text == "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractType='" + ddlcontractType.SelectedItem.Text + "'" + " and contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";
                    }
                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractDepartment.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text == "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + "and contractDepartment ='" + ddlcontractDepartment.SelectedItem.Text + "'" + " and contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";
                    }
                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractDepartment.SelectedItem.Text == "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + "and contractType ='" + ddlcontractType.SelectedItem.Text + "'" + " and contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";
                    }
                    if (ddlcontractSubType.SelectedItem.Text == "All" && ddlcontractDepartment.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractDepartment='" + ddlcontractDepartment.SelectedItem.Text + "'" + "and contractType ='" + ddlcontractType.SelectedItem.Text + "'" + " and contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";
                    }
                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractDepartment.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + "and contractDepartment ='" + ddlcontractDepartment.SelectedItem.Text + "'" + "and contractType ='" + ddlcontractType.SelectedItem.Text + "'" + " and contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";
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


        protected void searchBtn_Click(object sender, EventArgs e)
        {
            string strcon = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;

            SqlConnection con = new SqlConnection(strcon);

            con.Open();

            if (titleTB.Text == "")
            {
                if ((ddlcontractSubType.SelectedItem.Text == "All" || ddlcontractSubType.SelectedItem.Text == "") && ddlcontractDepartment.SelectedItem.Text == "All" && ddlcontractType.SelectedItem.Text == "All")
                {

                    string strquery = "select * from Contract where contractHistory = 0";

                    SqlCommand cmd = new SqlCommand(strquery, con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    contractGridView.DataSource = ds;

                    contractGridView.DataBind();

                    con.Close();

                }
                else if (ddlcontractSubType.SelectedItem.Text != "All" || ddlcontractDepartment.SelectedItem.Text != "All" || ddlcontractType.SelectedItem.Text != "All")

                {

                    string strquery = "";

                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractDepartment.SelectedItem.Text == "All" && ddlcontractType.SelectedItem.Text == "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + " and contractHistory = 0";
                    }
                    if (ddlcontractSubType.SelectedItem.Text == "All" && ddlcontractDepartment.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text == "All")
                    {
                        strquery = "select * from Contract where contractDepartment='" + ddlcontractDepartment.SelectedItem.Text + "'" + " and contractHistory = 0";
                    }
                    if (ddlcontractSubType.SelectedItem.Text == "All" && ddlcontractDepartment.SelectedItem.Text == "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractType='" + ddlcontractType.SelectedItem.Text + "'" + " and contractHistory = 0";
                    }
                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractDepartment.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text == "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + "and contractDepartment ='" + ddlcontractDepartment.SelectedItem.Text + "'" + " and contractHistory = 0";
                    }
                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractDepartment.SelectedItem.Text == "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + "and contractType ='" + ddlcontractType.SelectedItem.Text + "'" + " and contractHistory = 0";
                    }
                    if (ddlcontractSubType.SelectedItem.Text == "All" && ddlcontractDepartment.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractDepartment='" + ddlcontractDepartment.SelectedItem.Text + "'" + "and contractType ='" + ddlcontractType.SelectedItem.Text + "'" + " and contractHistory = 0";
                    }
                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractDepartment.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + "and contractDepartment ='" + ddlcontractDepartment.SelectedItem.Text + "'" + "and contractType ='" + ddlcontractType.SelectedItem.Text + "'" + " and contractHistory = 0";
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
                if ((ddlcontractSubType.SelectedItem.Text == "All" || ddlcontractSubType.SelectedItem.Text == "") && ddlcontractDepartment.SelectedItem.Text == "All" && ddlcontractType.SelectedItem.Text == "All")
                {

                    string strquery = "select * from Contract where contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";

                    SqlCommand cmd = new SqlCommand(strquery, con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    contractGridView.DataSource = ds;

                    contractGridView.DataBind();

                    con.Close();

                }
                else if (ddlcontractSubType.SelectedItem.Text != "All" || ddlcontractDepartment.SelectedItem.Text != "All" || ddlcontractType.SelectedItem.Text != "All")

                {

                    string strquery = "";

                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractDepartment.SelectedItem.Text == "All" && ddlcontractType.SelectedItem.Text == "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + " and contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";
                    }
                    if (ddlcontractSubType.SelectedItem.Text == "All" && ddlcontractDepartment.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text == "All")
                    {
                        strquery = "select * from Contract where contractDepartment='" + ddlcontractDepartment.SelectedItem.Text + "'" + " and contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";
                    }
                    if (ddlcontractSubType.SelectedItem.Text == "All" && ddlcontractDepartment.SelectedItem.Text == "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractType='" + ddlcontractType.SelectedItem.Text + "'" + " and contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";
                    }
                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractDepartment.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text == "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + "and contractDepartment ='" + ddlcontractDepartment.SelectedItem.Text + "'" + " and contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";
                    }
                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractDepartment.SelectedItem.Text == "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + "and contractType ='" + ddlcontractType.SelectedItem.Text + "'" + " and contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";
                    }
                    if (ddlcontractSubType.SelectedItem.Text == "All" && ddlcontractDepartment.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractDepartment='" + ddlcontractDepartment.SelectedItem.Text + "'" + "and contractType ='" + ddlcontractType.SelectedItem.Text + "'" + " and contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";
                    }
                    if (ddlcontractSubType.SelectedItem.Text != "All" && ddlcontractDepartment.SelectedItem.Text != "All" && ddlcontractType.SelectedItem.Text != "All")
                    {
                        strquery = "select * from Contract where contractSubType='" + ddlcontractSubType.SelectedItem.Text + "'" + "and contractDepartment ='" + ddlcontractDepartment.SelectedItem.Text + "'" + "and contractType ='" + ddlcontractType.SelectedItem.Text + "'" + " and contractHistory = 0 and contractTitle LIKE '%" + titleTB.Text + "%'";
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
            Response.Redirect("CUViewAllContracts.aspx");
        }

        protected void contractGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            e.Row.Cells[0].Visible = false;
            e.Row.Cells[12].Visible = false;
            e.Row.Cells[13].Visible = false;

        }

        protected void remainingDaysGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].Visible = false;
        }

        protected void exportToExcelbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("CUExportContract.aspx");
        }

        protected void EmailDeptHead_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[6].Visible = false;

        }

        protected void EmailDeptGM_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[6].Visible = false;
        }

        protected void contractHistoryBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("CUContractHistory.aspx");
        }


    }
}