//DA View for Contract details that are currently expiring

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
using System.Text;

namespace JKTS_Contract_system
{
    public partial class DAContractDetailsExpiring : System.Web.UI.Page
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
        // retrieve details view of the selected contract
        private void BindDetailsView()
        {
            BllContract contract = new BllContract();
            DataSet DS;
            DS = contract.GetContractView(lbl_ContractID.Text);
            DetailsView1.DataSource = DS;
            DetailsView1.DataBind();

        }

        // retrieve details of contracts with the same parent ID

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
            string contractID = contractGridView.SelectedRow.Cells[0].Text;
            Session["contractID"] = contractID;
            Response.Redirect("DAContractPIDDetailsView.aspx");
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("DAViewAllContracts.aspx");
        }


        protected void renewBtn_Click(object sender, EventArgs e)
        {

            string contractID = lbl_ContractID.Text;
            Session["contractID"] = contractID;
            string contractParentID = DetailsView1.Rows[23].Cells[1].Text.ToString();
            Session["contractParentID"] = contractParentID;
            Response.Redirect("DARenewContract.aspx");

        }

        protected void terminateBtn_Click(object sender, EventArgs e)
        {

            string contractID = lbl_ContractID.Text;
            Session["contractID"] = contractID;
            Response.Redirect("DATerminateReason.aspx");
        }

        protected void DetailsView1_DataBound(object sender, EventArgs e)
        {
            DetailsView1.Rows[23].Cells[1].Visible = false;
            DetailsView1.Rows[23].Cells[0].Visible = false;
        }
    }
}