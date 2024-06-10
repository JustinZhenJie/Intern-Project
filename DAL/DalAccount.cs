using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace JKTS_Contract_system.DAL
{
    public class DalAccount
    {   // to connnect to the database
        private String errMsg;
        DalConn dbConn = new DalConn();

        String connString = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;
        // get everything when user logs in
        public DataSet GetAccount(string password, string email)
        {
            StringBuilder sql;
            SqlDataAdapter da;
            DataSet accountData;

            SqlConnection conn = dbConn.GetConnection();
            accountData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT *");
            sql.AppendLine(" ");
            sql.AppendLine("FROM [User]");
            sql.AppendLine(" ");
            sql.AppendLine("WHERE User_Password = @User_Password AND User_Email = @User_Email");
            conn.Open();

            try
            {
                da = new SqlDataAdapter(sql.ToString(), conn);
                da.SelectCommand.Parameters.AddWithValue("User_Password", password);
                da.SelectCommand.Parameters.AddWithValue("User_Email", email);
                da.Fill(accountData);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return accountData;
        }
        //to get the user active(Yes/No) when logging in
        public DataSet GetUserActive(string password, string email)
        {
            StringBuilder sql;
            SqlDataAdapter dal;
            DataSet userData;

            SqlConnection conn = dbConn.GetConnection();
            userData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT User_Active");
            sql.AppendLine("FROM [User]");
            sql.AppendLine("WHERE User_Password = @User_Password AND User_Email = @User_Email");
            conn.Open();

            try
            {
                dal = new SqlDataAdapter(sql.ToString(), conn);
                dal.SelectCommand.Parameters.AddWithValue("User_Password", password);
                dal.SelectCommand.Parameters.AddWithValue("User_Email", email);
                dal.Fill(userData);

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return userData;
        }
        public DataSet GetUser()
        {
            StringBuilder sql;
            SqlDataAdapter dal;
            DataSet userData;

            SqlConnection conn = dbConn.GetConnection();
            userData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT User_ID, User_Name, User_Email, User_Dept, User_Designation, User_Type, User_Active, User_Creation, User_CreatedBy, User_Updated, User_UpdatedBy");
            sql.AppendLine("FROM [User]");

            try
            {
                dal = new SqlDataAdapter(sql.ToString(), conn);

                dal.Fill(userData);

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return userData;
        }
        // Getting the user's department when logging in
        public DataSet GetDept(string password, string email)
        {
            StringBuilder sql;
            SqlDataAdapter dal;
            DataSet userData;

            SqlConnection conn = dbConn.GetConnection();
            userData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT User_Dept");
            sql.AppendLine("FROM [User]");
            sql.AppendLine("WHERE User_Password = @User_Password AND User_Email = @User_Email");
            conn.Open();

            try
            {
                dal = new SqlDataAdapter(sql.ToString(), conn);
                dal.SelectCommand.Parameters.AddWithValue("User_Password", password);
                dal.SelectCommand.Parameters.AddWithValue("User_Email", email);
                dal.Fill(userData);

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return userData;
        }
        // getting the user's name when logging in
        public DataSet GetName(string password, string email)
        {
            StringBuilder sql;
            SqlDataAdapter da;
            DataSet accountData;

            SqlConnection conn = dbConn.GetConnection();
            accountData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT User_Name");
            sql.AppendLine(" ");
            sql.AppendLine("FROM [User]");
            sql.AppendLine(" ");
            sql.AppendLine("WHERE User_Password = @User_Password AND User_Email = @User_Email");
            conn.Open();

            try
            {
                da = new SqlDataAdapter(sql.ToString(), conn);
                da.SelectCommand.Parameters.AddWithValue("User_Password", password);
                da.SelectCommand.Parameters.AddWithValue("User_Email", email);
                da.Fill(accountData);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return accountData;
        }
        
        //get the name of the person who change password or use the forget password function
        // this is so that we can send email with the person name in the Email content
        public DataSet GetNameForEmail(string email)
        {
            StringBuilder sql;
            SqlDataAdapter da;
            DataSet accountData;

            SqlConnection conn = dbConn.GetConnection();
            accountData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT User_Name");
            sql.AppendLine(" ");
            sql.AppendLine("From [User]");
            sql.AppendLine(" ");
            sql.AppendLine("WHERE User_Email = @User_Email");
            conn.Open();

            try
            {
                da = new SqlDataAdapter(sql.ToString(), conn);
                da.SelectCommand.Parameters.AddWithValue("User_Email", email);
                da.Fill(accountData);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return accountData;
        }
        // to retrieve information for the gridview based on the different department
        public DataSet GetUserByDept(string User_Dept)
        {
            StringBuilder sql;
            SqlDataAdapter dal;
            DataSet userData;

            SqlConnection conn = dbConn.GetConnection();
            userData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT User_ID, User_Name, User_Email, User_Dept, User_Designation, User_Type, User_Active");
            sql.AppendLine("FROM [User]");
            sql.AppendLine("WHERE User_Dept = @User_Dept");

            try
            {
                dal = new SqlDataAdapter(sql.ToString(), conn);
                dal.SelectCommand.Parameters.AddWithValue("User_Dept", User_Dept);
                dal.Fill(userData);

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return userData;
        }

        public DataSet GetAllUserButSA(string User_Dept )
        {
            StringBuilder sql;
            SqlDataAdapter dal;
            DataSet userData;

            SqlConnection conn = dbConn.GetConnection();
            userData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT User_ID, User_Name, User_Email, User_Dept, User_Designation, User_Type, User_Active, User_Creation, User_CreatedBy, User_Updated, User_UpdatedBy");
            sql.AppendLine("FROM [User]");
            sql.AppendLine("WHERE User_Dept = @User_Dept");
            sql.AppendLine("AND User_Type NOT LIKE 'Setting%'");

            try
            {
                dal = new SqlDataAdapter(sql.ToString(), conn);
                dal.SelectCommand.Parameters.AddWithValue("User_Dept", User_Dept);
                dal.Fill(userData);

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return userData;
        }
        // for the search/filter function base on name
        public DataSet GetUserBySearch(String searchquery)
        {
            StringBuilder sql;
            SqlDataAdapter dal;
            DataSet userData;

            SqlConnection conn = dbConn.GetConnection();
            userData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT User_ID, User_Name, User_Email, User_Dept, User_Designation, User_Type, User_Active");
            sql.AppendLine("FROM [User]");
            sql.AppendLine("WHERE User_Name LIKE @User_Name");

            try
            {
                dal = new SqlDataAdapter(sql.ToString(), conn);
                dal.SelectCommand.Parameters.AddWithValue("@User_Name", "%" + searchquery + "%");
                dal.Fill(userData);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return userData;
        }
        // for the search/ filter function based on department
        public DataSet GetUserBySearchDept(String searchquery, string User_Dept)
        {
            StringBuilder sql;
            SqlDataAdapter dal;
            DataSet userData;

            SqlConnection conn = dbConn.GetConnection();
            userData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT User_ID, User_Name, User_Email, User_Dept, User_Designation, User_Type, User_Active");
            sql.AppendLine("FROM [User]");
            sql.AppendLine("WHERE User_Name LIKE @User_Name AND User_Dept = @User_Dept");

            try
            {
                dal = new SqlDataAdapter(sql.ToString(), conn);
                dal.SelectCommand.Parameters.AddWithValue("@User_Name", "%" + searchquery + "%");
                dal.SelectCommand.Parameters.AddWithValue("User_Dept", User_Dept);
                dal.Fill(userData);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return userData;
        }
      // to get more in depths details of selected person, displayed in detailsview
        public DataSet GetUserDetails(string id)
        {
            StringBuilder sql;
            SqlDataAdapter dal;
            DataSet userData;

            SqlConnection conn = dbConn.GetConnection();
            userData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT User_ID, User_Name, User_Email, User_Dept, User_Designation, User_Type, User_Active FROM [User]");
            sql.AppendLine("WHERE User_ID = @User_ID");


            conn.Open();
            try
            {
                dal = new SqlDataAdapter(sql.ToString(), conn);
                dal.SelectCommand.Parameters.AddWithValue("@User_ID", id);
                dal.Fill(userData);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return userData;
        }
        //to get more in depth details of the selected person, displayed in a detailview
        public DataSet GetUserDetail(string id)
        {
            StringBuilder sql;
            SqlDataAdapter dal;
            DataSet userData;

            SqlConnection conn = dbConn.GetConnection();
            userData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT User_ID, User_Name, User_Email, User_Dept, User_Designation, User_Type, User_Active, User_Creation, User_CreatedBy, User_Updated, User_UpdatedBy FROM [User]");
            sql.AppendLine("WHERE User_ID = @User_ID");


            conn.Open();
            try
            {
                dal = new SqlDataAdapter(sql.ToString(), conn);
                dal.SelectCommand.Parameters.AddWithValue("@User_ID", id);
                dal.Fill(userData);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return userData;
        }
        //to get details for edit
        public DataSet GetEditDetails(string id)
        {
            StringBuilder sql;
            SqlDataAdapter dal;
            DataSet userData;

            SqlConnection conn = dbConn.GetConnection();
            userData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT User_ID, User_Name, User_Email, User_Dept, User_Designation, User_Type, User_Active FROM [User]");
            sql.AppendLine("WHERE User_ID = @USer_ID");

            conn.Open();
            try
            {
                dal = new SqlDataAdapter(sql.ToString(), conn);
                dal.SelectCommand.Parameters.AddWithValue("User_ID", id);
                dal.Fill(userData);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return userData;
        }
        // to get the status based on existing status
        public DataSet GetStatus()
        {
            StringBuilder sql;
            SqlDataAdapter dal;
            DataSet statusData;

            SqlConnection conn = dbConn.GetConnection();
            statusData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT ActiveID, User_Active");
            sql.AppendLine("FROM Status");

            conn.Open();
            try
            {
                dal = new SqlDataAdapter(sql.ToString(), conn);
                dal.Fill(statusData);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return statusData;

        }
        // to get department based on existing departments
        public DataSet GetDept()
        {
            StringBuilder sql;
            SqlDataAdapter dal;
            DataSet deptData;

            SqlConnection conn = dbConn.GetConnection();
            deptData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT DeptID, User_Dept");
            sql.AppendLine("FROM Dept");

            conn.Open();
            try
            {
                dal = new SqlDataAdapter(sql.ToString(), conn);
                dal.Fill(deptData);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return deptData;

        }
        // To get * based on email 
        public DataSet GetEmail(string email)
        {
            StringBuilder sql;
            SqlDataAdapter da;
            DataSet accountData;

            SqlConnection conn = dbConn.GetConnection();
            accountData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT *");
            sql.AppendLine(" ");
            sql.AppendLine("FROM [User]");
            sql.AppendLine(" ");
            sql.AppendLine("WHERE User_Email = @User_Email");
            conn.Open();

            try
            {
                da = new SqlDataAdapter(sql.ToString(), conn);
                da.SelectCommand.Parameters.AddWithValue("User_Email", email);
                da.Fill(accountData);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return accountData;
        }
        // to get user type when user is logging in
        public DataSet GetUserType(string password, string email)
        {
            StringBuilder sql;
            SqlDataAdapter da;
            DataSet accountData;

            SqlConnection conn = dbConn.GetConnection();
            accountData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT User_Type");
            sql.AppendLine(" ");
            sql.AppendLine("FROM [User]");
            sql.AppendLine(" ");
            sql.AppendLine("WHERE User_Password = @User_Password AND User_Email = @User_Email");
            conn.Open();

            try
            {
                da = new SqlDataAdapter(sql.ToString(), conn);
                da.SelectCommand.Parameters.AddWithValue("User_Password", password);
                da.SelectCommand.Parameters.AddWithValue("User_Email", email);
                da.Fill(accountData);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return accountData;
        }
       

        // to update user's information in the database
        public int UpdateUserDetail(string id, string username, string email, string department, string designation, string type, string active, string updated, string updatedby)
        {
            StringBuilder sql;
            SqlCommand sqlCmd;
            int result;

            result = 0;

            sql = new StringBuilder();
            sql.AppendLine("UPDATE [User]");
            sql.AppendLine("SET User_Name=@User_Name, User_Email=@User_Email, User_Dept=@User_Dept, User_Designation=@User_Designation, User_Type=@User_Type, User_Active=@User_Active , User_Updated=@User_Updated, User_UpdatedBy=@User_UpdatedBy");
            sql.AppendLine("WHERE User_ID = @User_ID");
            SqlConnection conn = dbConn.GetConnection();
            try
            {
                sqlCmd = new SqlCommand(sql.ToString(), conn);
                sqlCmd.Parameters.AddWithValue("@User_ID", id);
                sqlCmd.Parameters.AddWithValue("@User_Name", username);
                sqlCmd.Parameters.AddWithValue("@User_Email", email);
                sqlCmd.Parameters.AddWithValue("@User_Dept", department);
                sqlCmd.Parameters.AddWithValue("@User_Designation", designation);
                sqlCmd.Parameters.AddWithValue("@User_Type", type);
                sqlCmd.Parameters.AddWithValue("@User_Active", active);
                sqlCmd.Parameters.AddWithValue("@User_Updated", updated);
                sqlCmd.Parameters.AddWithValue("@User_UpdatedBy", updatedby);

                conn.Open();
                result = sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }
        // to update password of user
        public int UpdatePassword(string password, string email, string encryptID)
        {
            StringBuilder sql;
            SqlCommand sqlCmd;
            int result;

            result = 0;

            sql = new StringBuilder();
            sql.AppendLine("UPDATE [User]");
            sql.AppendLine("SET User_Password=@User_Password, EncryptID=@EncryptID");
            sql.AppendLine("WHERE User_Email = @User_Email");
            SqlConnection conn = dbConn.GetConnection();
            try
            {
                sqlCmd = new SqlCommand(sql.ToString(), conn);
                sqlCmd.Parameters.AddWithValue("@User_Password", password);
                sqlCmd.Parameters.AddWithValue("@User_Email", email);
                sqlCmd.Parameters.AddWithValue("@EncryptID", encryptID);
                conn.Open();
                result = sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        // to insert new data into database (User Table)
        public int InsertAccDetails(string username, string password, string email, string department, string designation, string type, string active, string encryptID, string creation, string createdby)
        {
            StringBuilder sql;
            SqlCommand sqlCmd;
            int result = 0;
            sql = new StringBuilder();

            sql.AppendLine("INSERT INTO [User] (User_Name, User_Password, User_Email, User_Dept, User_Designation, User_Type, User_Active, EncryptID, User_Creation, User_CreatedBy)");
            sql.AppendLine("VALUES (@User_Name, @User_Password, @User_Email, @User_Dept, @User_Designation, @User_Type, @User_Active, @EncryptID, @User_Creation, @User_CreatedBy)");
            sql.AppendLine(" ");

            SqlConnection conn = dbConn.GetConnection();
            conn.Open();
            try
            {
                sqlCmd = new SqlCommand(sql.ToString(), conn);
                sqlCmd.Parameters.AddWithValue("@User_Name", username);
                sqlCmd.Parameters.AddWithValue("@User_Password", password);
                sqlCmd.Parameters.AddWithValue("@User_Email", email);
                sqlCmd.Parameters.AddWithValue("@User_Dept", department);
                sqlCmd.Parameters.AddWithValue("@User_Designation", designation);
                sqlCmd.Parameters.AddWithValue("@User_Type", type);
                sqlCmd.Parameters.AddWithValue("@User_Active", active);
                sqlCmd.Parameters.AddWithValue("@EncryptID", encryptID);
                sqlCmd.Parameters.AddWithValue("@User_Creation", creation);
                sqlCmd.Parameters.AddWithValue("@User_CreatedBy", createdby);

                result = sqlCmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        //to delete data from database (User Table)
        public int DeleteUser (string id)
        {
            StringBuilder sql;
            SqlCommand sqlCmd;
            int result;

            result = 0;

            sql = new StringBuilder();
            sql.AppendLine("DELETE FROM [User]");
            sql.AppendLine(" ");
            sql.AppendLine("WHERE User_ID = @User_ID");
            SqlConnection conn = dbConn.GetConnection();
            try
            {
                sqlCmd = new SqlCommand(sql.ToString(), conn);
                sqlCmd.Parameters.AddWithValue("@User_ID", id);
                conn.Open();
                result = sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }
      
    }

}