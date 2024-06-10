using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JKTS_Contract_system.BLL;

namespace JKTS_Contract_system
{
    public partial class CUDACreateAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // session user's username
            lbl_CreatedBy.Text = (string)(Session["User_Name"]);
            // session user's department
            lbl_Dept.Text = (string)(Session["User_Dept"]);

            Bind();
            GeneratePassword();
        }
        private void Bind()
        {
            string username = tb_UserName.Text;
            string email = tb_Email.Text;
            string department = lbl_Dept.Text;
            string designation = tb_Designation.Text;
            string type = ddl_UserType.SelectedValue;
            string active = lbl_Active.Text;
            lbl_CreatedBy.Text = (string)(Session["User_Name"]);
            string creation = lbl_Creation.Text;
            lbl_Creation.Text = DateTime.Now.ToShortDateString();
        }

        public string GeneratePassword()
        {
            string PasswordLength = "8";  //set password length
            string NewPassword = "";

            string allowedChars = "";  // choose what characters is allowed for the generated password
            allowedChars = "1,2,3,4,5,6,7,8,9,0";
            allowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";
            allowedChars += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";


            char[] sep = {
            ','
        };
            string[] arr = allowedChars.Split(sep);


            string IDString = "";
            string temp = "";

            Random rand = new Random();

            for (int i = 0; i < Convert.ToInt32(PasswordLength); i++)
            {
                temp = arr[rand.Next(0, arr.Length)];
                IDString += temp;
                NewPassword = IDString;

            }
            return NewPassword;
        }
        protected void Btn_Back_Click1(object sender, EventArgs e)
        {
            Response.Redirect("CuDAViewUser.aspx");
        }

        protected void Btn_Create_Click1(object sender, EventArgs e)
        {
            string Email;
            Boolean result;


            Email = tb_Email.Text;


            BllAccount myAcc = new BllAccount();
            result = myAcc.VerifyEmail(Email); // check if email already exist from database table (User_Email)


            if (result == true) // if email exist in database table, account creation fail
            {
                Response.Write("<script>alert('Email already exist, please create another account')</script>");

            }
            else //  if email does not exist in database table
            {

                string strNewPassword = GeneratePassword().ToString();
                string username = Convert.ToString(tb_UserName.Text);
                string email = Convert.ToString(tb_Email.Text);
                string department = Convert.ToString(lbl_Dept.Text);
                string designation = Convert.ToString(tb_Designation.Text);
                string type = Convert.ToString(ddl_UserType.Text);
                string active = Convert.ToString(lbl_Active.Text);
                string creation = Convert.ToString(lbl_Creation.Text);
                string createdby = Convert.ToString(lbl_CreatedBy.Text);

                BllAccount Acc = new BllAccount();

                int insert = Acc.InsertAccDetails(username, strNewPassword, email, department, designation, type, active, creation, createdby);
                // insert account details into database table (User)

                if (insert > 0) // if insert is sucessfully, send email
                {
                    BllSetting mySet = new BllSetting();
                    DataSet ds;
                    ds = mySet.GetSystemAdmin(); // get the email of the system admin
                    if (ds.Tables.Count > 0) // if database is not empty
                    {
                        if (ds.Tables[0].Rows.Count > 0) //if database row is not empty
                        {
                            string SAdmin = ds.Tables[0].Rows[0]["SystemAdmin"].ToString();
                            try
                            {
                                MailMessage mail = new MailMessage();
                                mail.To.Add(email);
                                mail.From = new MailAddress("123@jvckenwood.com");
                                mail.Subject = "Contract Management System Account Password";
                                mail.Body =
                                                "<p>Hi " + username + ", </p> " +

                                                 "Your password is: " + strNewPassword + "<br>" +

                                                 "<p>To Login, Click <a href = 'http://10.230.4.120/CMS/'> Here </a> <p> " +
                                                 "<p>Thank you </p>" +

                                                 "Regards," + "<br>" +
                                                 "CMS Admin" + "<br>" +

                                                 "<p>*** This is a System generated email, Please do not reply *** </p>";

                                mail.IsBodyHtml = true;
                                SmtpClient smtp = new SmtpClient();
                                smtp.Host = "123"; //Your SMTP Server Address
                                smtp.UseDefaultCredentials = false;
                                smtp.Credentials = new System.Net.NetworkCredential
                                     ("123@jvckenwood.com", "123"); // ***use valid credentials***
                                smtp.Port = 25;// Your port number // Usually 587 or 25

                                smtp.EnableSsl = false;
                                smtp.Send(mail);

                                Response.Write("<script>alert('Account successfully created')</script>");
                                Response.Write("<script>alert('Password has been sent to the registered email')</script>");
                            }
                            catch (Exception ex)
                            {
                                Response.Write("<script>alert('Failed to send password to registered email')</script>");
                                Response.Write("<script>alert('Account not created')</script>");
                                Console.WriteLine(ex.Message);
                            }

                        }
                        else
                        {
                            Response.Write("<script>alert('Failed to Create, please check ur details again')</script>");
                        }
                    }
                }
            }
        }
    }
}
