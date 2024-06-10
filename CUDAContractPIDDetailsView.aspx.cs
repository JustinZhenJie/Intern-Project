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
    public partial class CUDAContractPIDDetailsView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_ContractID.Text = (string)(Session["contractID"]);
            lbl_ContractParentID.Text = (string)(Session["contractParentID"]);
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
            string contractID = lbl_ContractID.Text.ToString();
            BllContract contract = new BllContract();
            DataSet DS;
            DS = contract.GetContractRelatedGridView(contractID, parentID);
            contractGridView.DataSource = DS;
            contractGridView.DataBind();

        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("CUDAViewAllContracts.aspx");
        }



        protected void contractGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[12].Visible = false;
        }

        protected void contractGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            string contractID = contractGridView.SelectedRow.Cells[0].Text;
            Session["contractID"] = contractID;
            Response.Redirect("CUDAContractPIDDetailsView.aspx");
        }

        protected void DetailsView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {
            DetailsView1.Rows[23].Cells[1].Visible = false;
            DetailsView1.Rows[23].Cells[0].Visible = false;
        }
        protected void DetailsView1_DataBound(object sender, EventArgs e)
        {
            DetailsView1.Rows[23].Cells[1].Visible = false;
            DetailsView1.Rows[23].Cells[0].Visible = false;
        }
    }
}