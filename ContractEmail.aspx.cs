
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
    public partial class ContractEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            DateTime today = DateTime.Today;
            BllContract updateCurrentDate = new BllContract();
            updateCurrentDate.UpdateCurrentDate(today);
            BindRemainingDaysGridView();
            BindEmailDeptHead();
            BindEmailDeptGM();
            BindGridView();

            //calculate remaining days
            int rows = Convert.ToInt32(remainingDaysGridView.Rows.Count.ToString());
            for (int i = 0; i < rows; i++)
            {
                string contractID = remainingDaysGridView.Rows[i].Cells[0].Text;
                string contractRemainingDays = remainingDaysGridView.Rows[i].Cells[1].Text;
                int remainingDays = Convert.ToInt32(contractRemainingDays);
                Session["contractID"] = contractID;
                if (remainingDays <= 60)
                {
                    BllContract updateStatus = new BllContract();
                    updateStatus.UpdateStatus(contractID, remainingDays);
                }


            }
            //email system

            int rows2 = Convert.ToInt32(EmailDeptHead.Rows.Count.ToString());

            for (int x = 0; x < rows2; x++)
            {
                string contractRemainingDays = EmailDeptHead.Rows[x].Cells[6].Text;
                int remainingDays = Convert.ToInt32(contractRemainingDays);
                string deptHeadEmail = EmailDeptHead.Rows[x].Cells[0].Text;
                string createdBy = EmailDeptHead.Rows[x].Cells[3].Text;
                string deptGMEmail = EmailDeptGM.Rows[x].Cells[0].Text;
                DateTime dtnow = DateTime.Now;
                int hour = dtnow.Hour;
                if (today.DayOfWeek == DayOfWeek.Monday && remainingDays <= 60 && hour == 8)
                {
                    if (createdBy == deptGMEmail)
                    {

                        MailMessage mail = new MailMessage();
                        mail.To.Add(deptHeadEmail);
                        mail.To.Add(createdBy);
                        mail.From = new MailAddress("webmaster@jkts.jvckenwood.com");
                        mail.Subject = "Contract Expiring in 60 or lesser days";
                        mail.Body = "Report generated on: " + dtnow + " " + today.DayOfWeek + "" + "<br>" +
                            "<p>---------------------------------" + "<br>" +
                            "Description: " + EmailDeptGM.Rows[x].Cells[1].Text + "<br>" +
                            "Vendor: " + EmailDeptGM.Rows[x].Cells[7].Text + "<br>" +
                            "Start Date: " + EmailDeptGM.Rows[x].Cells[4].Text + "<br>" +
                            "End Date: " + EmailDeptGM.Rows[x].Cells[5].Text + "<br>" +
                            "Remaining Days: " + EmailDeptGM.Rows[x].Cells[6].Text + "<br>" +
                            "Status: " + EmailDeptGM.Rows[x].Cells[8].Text + "<br>" +
                            "<p><a href = \"http://10.230.4.120/CMS/\"> Login </a>" + "<br>" +

                            "<p>*** This is a System generated email, Please do not reply *** </p>";



                        mail.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "jktsexsv01"; //Your SMTP Server Address
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new System.Net.NetworkCredential
                             ("webmaster@jkts.jvckenwood.com", "webm@ster"); // ***use valid credentials***
                        smtp.Port = 25;// Your port number // Usually 587 or 25

                        smtp.EnableSsl = false;
                        smtp.Send(mail);
                    }
                    else if (createdBy == deptHeadEmail)
                    {
                        MailMessage mail = new MailMessage();

                        mail.To.Add(deptGMEmail);
                        mail.To.Add(createdBy);
                        mail.From = new MailAddress("webmaster@jkts.jvckenwood.com");
                        mail.Subject = "Contract Expiring in 60 or lesser days";
                        mail.Body = "Report generated on: " + dtnow + " " + today.DayOfWeek + "" + "<br>" +
                          "<p>---------------------------------" + "<br>" +
                          "Description: " + EmailDeptHead.Rows[x].Cells[1].Text + "<br>" +
                          "Vendor: " + EmailDeptHead.Rows[x].Cells[7].Text + "<br>" +
                          "Start Date: " + EmailDeptHead.Rows[x].Cells[4].Text + "<br>" +
                          "End Date: " + EmailDeptGM.Rows[x].Cells[5].Text + "<br>" +
                          "Remaining Days: " + EmailDeptHead.Rows[x].Cells[6].Text + "<br>" +
                          "Status: " + EmailDeptHead.Rows[x].Cells[8].Text + "<br>" +
                          "<p><a href = \"http://10.230.4.120/CMS/\"> Login </a>" + "<br>" +

                          "<p>*** This is a System generated email, Please do not reply *** </p>";

                        mail.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "jktsexsv01"; //Your SMTP Server Address
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new System.Net.NetworkCredential
                             ("webmaster@jkts.jvckenwood.com", "webm@ster"); // ***use valid credentials***
                        smtp.Port = 25;// Your port number // Usually 587 or 25
                        smtp.EnableSsl = false;
                        smtp.Send(mail);
                    }
                    else
                    {
                        MailMessage mail = new MailMessage();
                        mail.To.Add(deptGMEmail);
                        mail.To.Add(deptHeadEmail);
                        mail.To.Add(createdBy);
                        mail.From = new MailAddress("webmaster@jkts.jvckenwood.com");
                        mail.Subject = "Contract Expiring in 60 or lesser days";
                        mail.Body = "Report generated on: " + dtnow + " " + today.DayOfWeek + "" + "<br>" +
                        "<p>---------------------------------" + "<br>" +
                        "Description: " + EmailDeptHead.Rows[x].Cells[1].Text + "<br>" +
                        "Vendor: " + EmailDeptHead.Rows[x].Cells[7].Text + "<br>" +
                        "Start Date: " + EmailDeptHead.Rows[x].Cells[4].Text + "<br>" +
                        "End Date: " + EmailDeptGM.Rows[x].Cells[5].Text + "<br>" +
                        "Remaining Days: " + EmailDeptHead.Rows[x].Cells[6].Text + "<br>" +
                        "Status: " + EmailDeptHead.Rows[x].Cells[8].Text + "<br>" +
                        "<p><a href = \"http://10.230.4.120/CMS/\"> Login </a>" + "<br>" +

                        "<p>*** This is a System generated email, Please do not reply *** </p>";


                        mail.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "jktsexsv01"; //Your SMTP Server Address
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new System.Net.NetworkCredential
                             ("webmaster@jkts.jvckenwood.com", "webm@ster"); // ***use valid credentials***
                        smtp.Port = 25;// Your port number // Usually 587 or 25

                        smtp.EnableSsl = false;
                        smtp.Send(mail);
                    }
                }
            }
        }

        private void BindGridView()
        {
            BllContract contract = new BllContract();
            DataSet DS;
            DS = contract.GetContractGridView();
            contractGridView.DataSource = DS;
            contractGridView.DataBind();

        }
        private void BindRemainingDaysGridView()
        {
            BllContract contract = new BllContract();
            DataSet DS;
            DS = contract.GetRemainingDaysGridView();
            remainingDaysGridView.DataSource = DS;
            remainingDaysGridView.DataBind();
        }

        private void BindEmailDeptHead()
        {
            BllContract contract = new BllContract();
            DataSet DS;
            DS = contract.GetEmailDeptHead();
            EmailDeptHead.DataSource = DS;
            EmailDeptHead.DataBind();
        }

        private void BindEmailDeptGM()
        {
            BllContract contract = new BllContract();
            DataSet DS;
            DS = contract.GetEmailDeptGM();
            EmailDeptGM.DataSource = DS;
            EmailDeptGM.DataBind();
        }




        protected void contractGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[10].Visible = false;
            e.Row.Cells[11].Visible = false;
            e.Row.Cells[12].Visible = false;
            e.Row.Cells[13].Visible = false;

        }

        protected void remainingDaysGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].Visible = false;
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
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[8].Visible = false;

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
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[8].Visible = false;
        }






    }
}