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
    public partial class CUDAExport : System.Web.UI.Page
    {   // everything in this Page_Load is for exporting gridview to excel
        protected void Page_Load(object sender, EventArgs e)
        {
            // session user's department
            lbl_Dept.Text = (string)(Session)["User_Dept"];
            BindGridView();

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=User List.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                gv_User.AllowPaging = false;
                this.BindGridView();

                gv_User.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in gv_User.HeaderRow.Cells)
                {
                    cell.BackColor = gv_User.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in gv_User.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gv_User.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gv_User.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                gv_User.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
                Response.Redirect("CuDAViewUser.aspx");
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        private void BindGridView()
        {
            BllAccount myAcc = new BllAccount();
            DataSet ds;
            ds = myAcc.GetUserByDept(lbl_Dept.Text); // get information of all the people in user's department 
            gv_User.DataSource = ds;                // displayed in gridview
            gv_User.DataBind();
        }

        protected void Btn_Back_Click1(object sender, EventArgs e)
        {
            Response.Redirect("CUDAViewUser.aspx");
        }

        protected void gv_User_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false; //hide column [1] in gridview (User_ID)
        }
    }
}