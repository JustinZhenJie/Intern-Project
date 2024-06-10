using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JKTS_Contract_system.BLL;

namespace JKTS_Contract_system
{
    public partial class CUDAChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
                lbl_Email.Text = (string)(Session["User_Email"]);
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            string password, email, newpassword;
            Boolean result;

            password = tb_CurPass.Text;
            email = lbl_Email.Text;
            newpassword = tb_ConPass.Text;

            BllAccount myAcc = new BllAccount();
            result = myAcc.VerifyAccount(password, email); // verify password entered by user

            if (result == true)  // if user input is verified
            {
                BllAccount Name = new BllAccount();
                DataSet dss;
                dss = Name.GetNameForEmail(email); // get User_Name of user based on user's email 
                if (dss.Tables.Count > 0) // if database is not empty
                {
                    if (dss.Tables[0].Rows.Count > 0) //if database row based on user's input exist
                    {
                        string name = dss.Tables[0].Rows[0]["User_Name"].ToString();
                        if (name != null || name != String.Empty) // if username is stored inside local variable name
                        {

                            BllSetting mySet = new BllSetting();
                            DataSet ds;
                            ds = mySet.GetSystemAdmin(); // get the email of the system admin
                            if (ds.Tables.Count > 0) // if database is not empty
                            {
                                if (ds.Tables[0].Rows.Count > 0) //if database row is not empty
                                {
                                    string SAdmin = ds.Tables[0].Rows[0]["SystemAdmin"].ToString();
                                    BllAccount acc = new BllAccount();
                                    acc.UpdatePassword(newpassword, email); // update password in database table (User_Password)

                                    try
                                    {
                                        // send Email to user to notify user that password is changed
                                        MailMessage mail = new MailMessage();
                                        mail.To.Add(email);
                                        mail.From = new MailAddress("webmaster@jkts.jvckenwood.com");
                                        mail.Subject = "Contract Management System Account Password reset";
                                        mail.Body =
                                                                "<p>Hi " + name + ", </p> " +

                                                                 "Your Password have just been changed, " + "<br>" +
                                                                 "If it was not you who changed your password, please contact the <a href = " + SAdmin + "> system administrator </a> " + " <br> " +

                                                                 "<p>To Login, Click <a href = 'http://10.230.4.120/CMS/'> Here </a> <p> " +
                                                                 "<p>Thank you </p>" +

                                                                 "Regards," + "<br>" +
                                                                 "CMS Admin" + "<br>" +

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
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    Response.Write("<script>alert('Password successfully changed')</script>");

                                    Session.Abandon();
                                }
                                else
                                {
                                    Response.Write("<script>alert('Failed to change password')</script>");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
    
