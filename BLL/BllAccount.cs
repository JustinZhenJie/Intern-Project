using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using JKTS_Contract_system.DAL;
using JKTS_Contract_system.AppCode;

namespace JKTS_Contract_system.BLL
{
    public class BllAccount
    {
        // to get method from dalaccount
        DalAccount dataLayerAccount = new DalAccount();
        // to get encryption method from appcode 
        PassEncryp pCrypt = new PassEncryp();

        // get everything when user logs in
        public DataSet GetAccount(string password, string email)
        {
            string encryptID = "";
            DataSet ds = GetEmail(email);
            DataTable dt = ds.Tables[0];
            
            foreach (DataRow row in dt.Rows)
            {
                encryptID = row["EncryptID"].ToString();
            }

            string encryptPassword = pCrypt.Encrypt(encryptID, password);
            return dataLayerAccount.GetAccount(encryptPassword, email);
        }
        //to get the user active(Yes/No) when logging in
        public DataSet GetUserActive(string password, string email)
        {
            string encryptID = "";
            DataSet ds = GetEmail(email);
            DataTable dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                encryptID = row["EncryptID"].ToString();
            }

            string encryptPassword = pCrypt.Encrypt(encryptID, password);
            return dataLayerAccount.GetUserActive(encryptPassword, email);
        }

        public DataSet GetUser()
        {

            dataLayerAccount = new DalAccount();
            return dataLayerAccount.GetUser();
        }
        // to get user's department when logging in
        public DataSet GetDept(string password, string email)
        {
            string encryptID = "";
            DataSet ds = GetEmail(email);
            DataTable dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                encryptID = row["EncryptID"].ToString();
            }

            string encryptPassword = pCrypt.Encrypt(encryptID, password);
            return dataLayerAccount.GetDept(encryptPassword, email);
        }
        // to get name of user when logging in
        public DataSet GetName(string password, string email)
        {
            string encryptID = "";
            DataSet ds = GetEmail(email);
            DataTable dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                encryptID = row["EncryptID"].ToString();
            }

            string encryptPassword = pCrypt.Encrypt(encryptID, password);
            return dataLayerAccount.GetName(encryptPassword, email);
        }

        //get the name of the person who change password or use the forget password function
        // this is so that we can send email with the person name in the Email content
        public DataSet GetNameForEmail(string email)
        {
            dataLayerAccount = new DalAccount();
            return dataLayerAccount.GetNameForEmail(email);
        }

        // to retrieve information for the gridview based on the different department
        public DataSet GetUserByDept(string User_Dept)
        {
            dataLayerAccount = new DalAccount();
            return dataLayerAccount.GetUserByDept(User_Dept);
        }

        public DataSet GetAllUserButSA(string User_Dept)
        {
            dataLayerAccount = new DalAccount();
            return dataLayerAccount.GetAllUserButSA(User_Dept);
        }

        

        // for the search/filter function base on name
        public DataSet GetUserBySearch(string searchquery)
        {

            dataLayerAccount = new DalAccount();
            return dataLayerAccount.GetUserBySearch(searchquery);
        }

        // for the search/ filter function based on department
        public DataSet GetUserBySearchDept(string searchquery, string User_Dept)
        {

            dataLayerAccount = new DalAccount();
            return dataLayerAccount.GetUserBySearchDept(searchquery, User_Dept);
        }

        // to get more in depths details of selected person, displayed in detailsview
        public DataSet GetUserDetails(string id)
        {

            dataLayerAccount = new DalAccount();
            return dataLayerAccount.GetUserDetails(id);
        }
        public DataSet GetUserDetail(string id)
        {

            dataLayerAccount = new DalAccount();
            return dataLayerAccount.GetUserDetail(id);
        }

        //to get details for edit
        public DataSet GetEditDetails(string id)
        {

            dataLayerAccount = new DalAccount();
            return dataLayerAccount.GetEditDetails(id);
        }
        // to get the status based on existing status

        public DataSet GetStatus()
        {
            DalAccount dataLayerAccount;
            dataLayerAccount = new DalAccount();
            return dataLayerAccount.GetStatus();
        }

        // to get department based on existing departments
        public DataSet GetDept()
        {

            dataLayerAccount = new DalAccount();
            return dataLayerAccount.GetDept();
        }
        // To get * based on email 
        public DataSet GetEmail(string email)
        {

            dataLayerAccount = new DalAccount();
            return dataLayerAccount.GetEmail(email);
        }

        // to get user type when user is logging in

        public DataSet GetUserType(string password, string email)
        {
            string encryptID = "";
            DataSet ds = GetEmail(email);
            DataTable dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                encryptID = row["EncryptID"].ToString();
            }
            string encryptPassword = pCrypt.Encrypt(encryptID, password);
            return dataLayerAccount.GetUserType(encryptPassword, email);
        }

        // to update user's information in the database
        public int UpdateUserDetail(string id, string username, string email, string department, string designation, string type, string active, string updated, string updatedby)
        {
            DalAccount datalayerAccount;
            datalayerAccount = new DalAccount();
            return datalayerAccount.UpdateUserDetail(id, username, email, department, designation, type, active, updated, updatedby);
        }

        // to update password of user
        public int UpdatePassword(string password, string email)
        {
            
            DalAccount datalayerAccount;
            string encryptID, encryptPassword;
            encryptID = EncryptionData.GenerateIdentifier(12);
            encryptPassword = pCrypt.Encrypt(encryptID, password);
            datalayerAccount = new DalAccount();
            return datalayerAccount.UpdatePassword(encryptPassword, email, encryptID);
        }
        // to insert new data into database (User Table)
        public int InsertAccDetails(string username, string password, string email, string department, string designation, string type, string active, string creation, string createdby)
        {
            DalAccount datalayerAccount;
            string encryptID, encryptPassword;
            encryptID = EncryptionData.GenerateIdentifier(12);
            encryptPassword = pCrypt.Encrypt(encryptID, password);
            datalayerAccount = new DalAccount();
            return datalayerAccount.InsertAccDetails(username, encryptPassword, email, department, designation, type, active, encryptID, creation , createdby );

        }

        //to delete data from database (User Table)
        public int DeleteUser(string id)
        {
            DalAccount datalayerAccount;
            datalayerAccount = new DalAccount();
            return datalayerAccount.DeleteUser(id);
        }
        //to verify if the account exist by checking the email and password the user input with the data in the database
        // if input does not match with database, user cannot login
        public Boolean VerifyAccount(string password, string email)
        {
            int result;
            Boolean verify;
            DataSet ds;
            DataTable dt;


            result = 0;
            verify = false;

            ds = GetAccount(password, email);
            dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                string pass = row["User_Password"].ToString();
                string mail = row["User_Email"].ToString();
                string encryptID = row["encryptID"].ToString();

                string encryptPassword = pCrypt.Encrypt(encryptID, password);


                if (encryptPassword.Equals(pass) && email.Equals(mail))
                {
                    result = 1;
                }
                else
                {
                    result = 0;
                }
            }

            if (result == 1)
            {
                verify = true;
            }
            else if (result == 0)
            {
                verify = false;
            }

            return verify;
        }
        // to verify if email already exist, so that there will be no duplicate of account created using the same email
        public Boolean VerifyEmail(string email)
        {
            int result;
            Boolean verify;
            DataSet ds;
            DataTable dt;

            result = 0;
            verify = false;

            ds = GetEmail(email);
            dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                string mail = row["User_Email"].ToString();


                if (email.Equals(mail))
                {
                    result = 1;
                }
                else
                {
                    result = 0;
                }
            }

            if (result == 1)
            {
                verify = true;
            }
            else if (result == 0)
            {
                verify = false;
            }

            return verify;
        }
    }
}