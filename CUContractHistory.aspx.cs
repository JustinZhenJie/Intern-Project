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


namespace JKTS_Contract_system
{
    public partial class CUContractHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
                BindGridView();
        }
        private void BindGridView()
        {
            BllContract contract = new BllContract();
            DataSet DS;
            DS = contract.GetContractHistoryGridView();
            contractHistoryGridView.DataSource = DS;
            contractHistoryGridView.DataBind();
        }
        protected void contractHistoryGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            BllContract contract = new BllContract();
            //string contractID = contractGridView.SelectedRow.Cells[0].Text;
            string contractID = contractHistoryGridView.DataKeys[e.RowIndex].Value.ToString();
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

        protected void contractHistoryGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {

            }

            else if (e.CommandName == "edit")
            {

            }
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("CUViewAllContracts.aspx");
        }


        protected void contractHistoryGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            string contractID = contractHistoryGridView.SelectedRow.Cells[0].Text;
            Session["contractID"] = contractID;
            Response.Redirect("CUContractDetails.aspx");
        }

        protected void contractHistoryGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
        }
    }
}