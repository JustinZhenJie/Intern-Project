﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JKTS_Contract_system
{
    public partial class CUHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_UserName.Text = (string)(Session)["User_Name"];
            lbl_Dept.Text = (string)(Session)["User_Dept"];
            lbl_Email.Text = (string)(Session)["User_Email"];
            if (!IsPostBack)
            {
                DataTable dtActive = new DataTable();
                string conStr = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;
                using (SqlConnection cn = new SqlConnection(conStr))
                {
                    string sql = "select * from Contract where contractHistory =0";
                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dtActive);
                        }

                    }
                }
                Chart1.ChartAreas["ChartActive"].AxisX.Interval = 1;
                Chart1.ChartAreas["ChartActive"].AxisY.Title = "Remaining Days";

                Chart1.ChartAreas["ChartActive"].AxisX.Title = "Contract Title";


                Chart1.DataSource = dtActive;
                Chart1.DataBind();


            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDepartment.SelectedItem.Text == "All" && ddlStatus.SelectedItem.Text == "All")
            {
                DataTable dtActive = new DataTable();
                string conStr = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;
                using (SqlConnection cn = new SqlConnection(conStr))
                {
                    string sql = "select * from Contract where contractHistory =0"; ;
                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dtActive);
                        }

                    }
                }

                Chart1.ChartAreas["ChartActive"].AxisX.Interval = 1;
                Chart1.ChartAreas["ChartActive"].AxisY.Title = "Remaining Days";

                Chart1.ChartAreas["ChartActive"].AxisX.Title = "Contract Title";


                Chart1.DataSource = dtActive;
                Chart1.DataBind();
            }
            else if (ddlDepartment.SelectedItem.Text != "All" || ddlStatus.SelectedItem.Text != "All")
            {
                DataTable dtActive = new DataTable();
                string conStr = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;
                using (SqlConnection cn = new SqlConnection(conStr))
                {
                    string sql = "select * from Contract where contractHistory =0";

                    if (ddlDepartment.SelectedItem.Text != "All" && ddlStatus.SelectedItem.Text == "All")
                    {
                        sql = "select * from Contract where contractDepartment ='" + ddlDepartment.SelectedItem.Text + "'" + " and contractHistory = 0";
                    }
                    if (ddlDepartment.SelectedItem.Text == "All" && ddlStatus.SelectedItem.Text != "All")
                    {
                        sql = "select * from Contract where contractStatus = '" + ddlStatus.SelectedItem.Text + "'" + " and contractHistory = 0";
                    }
                    if (ddlDepartment.SelectedItem.Text != "All" && ddlStatus.SelectedItem.Text != "All")
                    {
                        sql = "select * from Contract where contractDepartment ='" + ddlDepartment.SelectedItem.Text + "'" + "and contractStatus = '" + ddlStatus.SelectedItem.Text + "'" + " and contractHistory = 0";
                    }

                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dtActive);
                        }

                    }
                }

                Chart1.ChartAreas["ChartActive"].AxisX.Interval = 1;
                Chart1.ChartAreas["ChartActive"].AxisY.Title = "Remaining Days";

                Chart1.ChartAreas["ChartActive"].AxisX.Title = "Contract Title";


                Chart1.DataSource = dtActive;
                Chart1.DataBind();
            }


        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDepartment.SelectedItem.Text == "All" && ddlStatus.SelectedItem.Text == "All")
            {
                DataTable dtActive = new DataTable();
                string conStr = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;
                using (SqlConnection cn = new SqlConnection(conStr))
                {
                    string sql = "select * from Contract where contractHistory =0";
                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dtActive);
                        }

                    }
                }

                Chart1.ChartAreas["ChartActive"].AxisX.Interval = 1;
                Chart1.ChartAreas["ChartActive"].AxisY.Title = "Remaining Days";

                Chart1.ChartAreas["ChartActive"].AxisX.Title = "Contract Title";


                Chart1.DataSource = dtActive;
                Chart1.DataBind();
            }
            else if (ddlDepartment.SelectedItem.Text != "All" || ddlStatus.SelectedItem.Text != "All")
            {
                DataTable dtActive = new DataTable();
                string conStr = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;
                using (SqlConnection cn = new SqlConnection(conStr))
                {
                    string sql = "select * from Contract where contractHistory =0";

                    if (ddlDepartment.SelectedItem.Text != "All" && ddlStatus.SelectedItem.Text == "All")
                    {
                        sql = "select * from Contract where contractDepartment ='" + ddlDepartment.SelectedItem.Text + "'" + " and contractHistory = 0";
                    }
                    if (ddlDepartment.SelectedItem.Text == "All" && ddlStatus.SelectedItem.Text != "All")
                    {
                        sql = "select * from Contract where contractStatus = '" + ddlStatus.SelectedItem.Text + "'" + " and contractHistory = 0";
                    }
                    if (ddlDepartment.SelectedItem.Text != "All" && ddlStatus.SelectedItem.Text != "All")
                    {
                        sql = "select * from Contract where contractDepartment ='" + ddlDepartment.SelectedItem.Text + "'" + "and contractStatus = '" + ddlStatus.SelectedItem.Text + "'" + " and contractHistory = 0";
                    }

                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dtActive);
                        }

                    }
                }

                Chart1.ChartAreas["ChartActive"].AxisX.Interval = 1;
                Chart1.ChartAreas["ChartActive"].AxisY.Title = "Remaining Days";

                Chart1.ChartAreas["ChartActive"].AxisX.Title = "Contract Title";


                Chart1.DataSource = dtActive;
                Chart1.DataBind();
            }
        }
    }
}