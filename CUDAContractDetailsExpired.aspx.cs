﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using JKTS_Contract_system.BLL;
using System.Data;
using System.Configuration;
using System.Text;

namespace JKTS_Contract_system
{
    public partial class CUDAContractDetailsExpired : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_ContractID.Text = (string)(Session["contractID"]);
            if (Page.IsPostBack == false)
            {
                BindDetailsView();
                BindGridView();
            }

        }
        private void BindDetailsView()
        {
            BllContract contract = new BllContract();
            DataSet DS;
            DS = contract.GetContractView(lbl_ContractID.Text);
            DetailsView1.DataSource = DS;
            DetailsView1.DataBind();

        }

        private void BindGridView()
        {
            string retrieveParentID = DetailsView1.Rows[23].Cells[1].Text.ToString();
            int parentID = Convert.ToInt32(retrieveParentID);
            BllContract contract = new BllContract();
            DataSet DS;
            DS = contract.GetContractParentIDGridView(parentID);
            contractGridView.DataSource = DS;
            contractGridView.DataBind();



        }

        protected void contractGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[12].Visible = false;
        }

        protected void contractGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            // session variables over
            string contractID = contractGridView.SelectedRow.Cells[0].Text;
            Session["contractID"] = contractID;
            Response.Redirect("CUDAContractPIDDetailsView.aspx");
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("CUDAViewAllContracts.aspx");
        }


        protected void renewBtn_Click(object sender, EventArgs e)
        {
            // session variables over
            string contractID = lbl_ContractID.Text;
            Session["contractID"] = contractID;
            string contractParentID = DetailsView1.Rows[23].Cells[1].Text.ToString();
            Session["contractParentID"] = contractParentID;
            Response.Redirect("CUDARenewContract.aspx");

        }

        protected void closeBtn_Click(object sender, EventArgs e)
        {
            string contractID = lbl_ContractID.Text;

            BllContract close = new BllContract();
            int result = close.CloseContract(contractID);
            if (result > 0)
            {
                Response.Write("<script type=\"text/javascript\">alert('Successfully Closed');location.href='CUDAViewAllContracts.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('Failed to Create, please check ur details again')</script>");
            }
        }

        protected void DetailsView1_DataBound(object sender, EventArgs e)
        {
            DetailsView1.Rows[23].Cells[1].Visible = false;
            DetailsView1.Rows[23].Cells[0].Visible = false;
        }
    }
}