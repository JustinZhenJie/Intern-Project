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
    public partial class CUDAExportContract : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_dept.Text = (string)(Session["User_Dept"]);
            string contractDepartment = lbl_dept.Text;
            BindGridView();




            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                contractGridView.AllowPaging = false;
                this.BindGridView();

                contractGridView.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in contractGridView.HeaderRow.Cells)
                {
                    cell.BackColor = contractGridView.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in contractGridView.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = contractGridView.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = contractGridView.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                contractGridView.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
                Response.Redirect("CUDAViewAllContracts.aspx");
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        private void BindGridView()
        {
            BllContract contract = new BllContract();
            DataSet DS;
            DS = contract.GetContractExport(lbl_dept.Text);
            contractGridView.DataSource = DS;
            contractGridView.DataBind();
        }


    }
}