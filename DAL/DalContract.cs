﻿//Basically we include services which communicate to database directly
//This layer is responsible for all database interaction. No outside method is allowed to communicate with database.

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Configuration;

namespace JKTS_Contract_system.DAL
{
    public class DalContract
    {
        private String errMsg;
        DalConn dbConn = new DalConn();


        //Get a contract grid view of all contracts in the database
        public DataSet GetContractGridView()
        {
            StringBuilder sql;
            SqlDataAdapter dal;
            DataSet contractData;

            SqlConnection conn = dbConn.GetConnection();
            contractData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT  contractID, contractDepartment, contractType, contractSubType, contractTitle , contractTerm, contractAmount , contractStartDate, contractEndDate , contractStatus,  contractParentID, contractRemainingDays");
            sql.AppendLine("FROM Contract");
            sql.AppendLine("WHERE contractHistory = '0'");

            try
            {
                dal = new SqlDataAdapter(sql.ToString(), conn);
                dal.Fill(contractData);

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return contractData;
        }

        //get all contract by specified name and type
        public DataSet GetAllByTitleAndType(string contractTitle, string contractType, string contractSubType, string contractDepartment)
        {
            StringBuilder sql;
            SqlDataAdapter da;
            DataSet counterpartyData;

            SqlConnection conn = dbConn.GetConnection();
            counterpartyData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT *");
            sql.AppendLine(" ");
            sql.AppendLine("FROM Contract");
            sql.AppendLine(" ");
            sql.AppendLine("WHERE contractTitle = @contractTitle and contractType = @contractType and contractSubType = @contractSubType and contractDepartment = @contractDepartment");
            conn.Open();

            try
            {
                da = new SqlDataAdapter(sql.ToString(), conn);
                da.SelectCommand.Parameters.AddWithValue("contractTitle", contractTitle);
                da.SelectCommand.Parameters.AddWithValue("contractType", contractType);
                da.SelectCommand.Parameters.AddWithValue("contractSubType", contractSubType);
                da.SelectCommand.Parameters.AddWithValue("contractDepartment", contractDepartment);
                da.Fill(counterpartyData);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return counterpartyData;
        }

        // Get contract gridview of all contracts in database within the specified department
        public DataSet GetContractGridView(string contractDepartment)
        {
            StringBuilder sql;
            SqlDataAdapter dal;
            DataSet contractData;

            SqlConnection conn = dbConn.GetConnection();
            contractData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT  contractID, contractDepartment, contractType, contractSubType, contractTitle , contractTerm, contractAmount , contractStartDate, contractEndDate , contractStatus,  contractParentID, contractRemainingDays");
            sql.AppendLine("FROM Contract");
            sql.AppendLine("WHERE contractHistory = '0' and contractDepartment = @contractDepartment");

            try
            {
                dal = new SqlDataAdapter(sql.ToString(), conn);
                dal.SelectCommand.Parameters.AddWithValue("@contractDepartment", contractDepartment);
                dal.Fill(contractData);

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return contractData;
        }

        // Select data to to place into a gridview for exporting into a excel in accordance to department specified

        public DataSet GetContractExport(string contractDepartment)
        {
            StringBuilder sql;
            SqlDataAdapter dal;
            DataSet contractData;

            SqlConnection conn = dbConn.GetConnection();
            contractData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT  contractID, contractDepartment, contractType, contractSubType, contractTitle , contractExplaination , contractNameOfCounterparty , contractTerm, contractAmount ,contractDate , contractStartDate, contractEndDate ,contractDuration , contractAutomaticExtension , contractConditionForAutomaticExtension, contractDocumentLocation , contractSignedBy , contractTitleOfSigner, contractPersonInCharge ,contractRefNo ,  contractDecisionMaker , contractReviewedByLADept , contractRemarks , contractStatus, contractHistory ,  contractReasonForTermination , contractRemainingDays , contractCreatedBy");
            sql.AppendLine("FROM Contract");
            sql.AppendLine("WHERE contractHistory = '0'and contractDepartment = @contractDepartment");

            try
            {
                dal = new SqlDataAdapter(sql.ToString(), conn);
                dal.SelectCommand.Parameters.AddWithValue("@contractDepartment", contractDepartment);
                dal.Fill(contractData);

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return contractData;
        }

        // Retrieve all data to to place into a gridview for exporting into a excel

        public DataSet GetContractExport()
        {
            StringBuilder sql;
            SqlDataAdapter dal;
            DataSet contractData;

            SqlConnection conn = dbConn.GetConnection();
            contractData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT  contractID, contractDepartment, contractType, contractSubType, contractTitle , contractExplaination , contractNameOfCounterparty , contractTerm, contractAmount ,contractDate , contractStartDate, contractEndDate ,contractDuration , contractAutomaticExtension , contractConditionForAutomaticExtension, contractDocumentLocation , contractSignedBy , contractTitleOfSigner, contractPersonInCharge ,contractRefNo ,  contractDecisionMaker , contractReviewedByLADept , contractRemarks , contractStatus, contractHistory ,  contractReasonForTermination , contractRemainingDays , contractCreatedBy");
            sql.AppendLine("FROM Contract");
            sql.AppendLine("WHERE contractHistory = '0'");

            try
            {
                dal = new SqlDataAdapter(sql.ToString(), conn);
                dal.Fill(contractData);

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return contractData;
        }

        // Get a gridview of the remaining days of all contracts

        public DataSet GetRemainingDaysGridView()
        {
            StringBuilder sql;
            SqlDataAdapter dal;
            DataSet contractData;

            SqlConnection conn = dbConn.GetConnection();
            contractData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT  contractID, contractRemainingDays");
            sql.AppendLine("FROM Contract");
            sql.AppendLine("WHERE contractHistory = '0'");

            try
            {
                dal = new SqlDataAdapter(sql.ToString(), conn);
                dal.Fill(contractData);

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return contractData;
        }

        // Retrieve gridview of contracts that have the same parent ID (Contracts that have been renewed share the same parent ID)
        public DataSet GetContractParentIDGridView(int contractParentID)
        {
            StringBuilder sql;
            SqlDataAdapter dal;
            DataSet contractData;

            SqlConnection conn = dbConn.GetConnection();
            contractData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT  contractID, contractDepartment, contractType, contractSubType, contractTitle , contractTerm, contractAmount , contractStartDate, contractEndDate , contractStatus,  contractParentID");
            sql.AppendLine("FROM Contract");
            sql.AppendLine("WHERE contractParentID = @contractParentID and contractParentID != '0' and contractHistory = 1");

            try
            {
                dal = new SqlDataAdapter(sql.ToString(), conn);
                dal.SelectCommand.Parameters.AddWithValue("@contractParentID", contractParentID);
                dal.Fill(contractData);

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return contractData;
        }

        // Retrieve gridview of contracts that have the same parent ID (Contracts that have been renewed share the same parent ID) without the current contract specified

        public DataSet GetContractRelatedGridView(string contractID, int contractParentID)
        {
            StringBuilder sql;
            SqlDataAdapter dal;
            DataSet contractData;

            SqlConnection conn = dbConn.GetConnection();
            contractData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT  contractID, contractDepartment, contractType, contractSubType, contractTitle , contractTerm, contractAmount , contractStartDate, contractEndDate , contractStatus,  contractParentID");
            sql.AppendLine("FROM Contract");
            sql.AppendLine("WHERE contractParentID = @contractParentID and contractParentID != '0' and contractID != @contractID");

            try
            {
                dal = new SqlDataAdapter(sql.ToString(), conn);
                dal.SelectCommand.Parameters.AddWithValue("@contractParentID", contractParentID);
                dal.SelectCommand.Parameters.AddWithValue("@contractID", contractID);
                dal.Fill(contractData);

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return contractData;
        }

        // Retrieves the contracts that have been terminated or closed and data of a contract that has been renewed

        public DataSet GetContractHistoryGridView()
        {
            StringBuilder sql;
            SqlDataAdapter dal;
            DataSet contractData;

            SqlConnection conn = dbConn.GetConnection();
            contractData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT  contractID, contractDepartment, contractType, contractSubType, contractTitle , contractAmount , contractStartDate, contractEndDate , contractStatus");
            sql.AppendLine("FROM Contract");
            sql.AppendLine("WHERE contractHistory = 1");

            try
            {
                dal = new SqlDataAdapter(sql.ToString(), conn);
                dal.Fill(contractData);

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return contractData;
        }

        //// Retrieves the contracts that have been terminated or closed and data of a contract that has been renewed in accordance to department

        public DataSet GetContractHistoryGridView(string contractDepartment)
        {
            StringBuilder sql;
            SqlDataAdapter dal;
            DataSet contractData;

            SqlConnection conn = dbConn.GetConnection();
            contractData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT  contractID, contractDepartment, contractType, contractSubType, contractTitle , contractAmount , contractStartDate, contractEndDate , contractStatus");
            sql.AppendLine("FROM Contract");
            sql.AppendLine("WHERE contractHistory = 1 and contractDepartment = @contractDepartment");

            try
            {
                dal = new SqlDataAdapter(sql.ToString(), conn);
                dal.SelectCommand.Parameters.AddWithValue("@contractDepartment", contractDepartment);
                dal.Fill(contractData);

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return contractData;
        }

        //Gets the email of the department head

        public DataSet GetEmailDeptHead()
        {
            StringBuilder sql;
            SqlDataAdapter dal;
            DataSet contractData;

            SqlConnection conn = dbConn.GetConnection();
            contractData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT  [User].User_Email , [User].User_Name , [Contract].contractCreatedBy , [Contract].contractTitle , [Contract].contractStartDate , [Contract].contractEndDate , [Contract].contractRemainingDays , [Contract].contractNameOfCounterparty , [Contract].contractStatus");
            sql.AppendLine("FROM [User]");
            sql.AppendLine("INNER JOIN Dept ON [User].User_Name = Dept.Dept_Head");
            sql.AppendLine("INNER JOIN Contract ON Dept.User_Dept = Contract.contractDepartment");
            sql.AppendLine("Where (Contract.contractStatus = 'Expiring' OR Contract.contractStatus = 'Expired') AND Contract.contractHistory = '0'");

            try
            {
                dal = new SqlDataAdapter(sql.ToString(), conn);
                dal.Fill(contractData);

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return contractData;
        }
        //Gets the email of the department GM
        public DataSet GetEmailDeptGM()
        {
            StringBuilder sql;
            SqlDataAdapter dal;
            DataSet contractData;

            SqlConnection conn = dbConn.GetConnection();
            contractData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT  [User].User_Email , [User].User_Name , [Contract].contractCreatedBy , [Contract].contractTitle , [Contract].contractStartDate , [Contract].contractEndDate , [Contract].contractRemainingDays , [Contract].contractNameOfCounterparty , [Contract].contractStatus");
            sql.AppendLine("FROM [User]");
            sql.AppendLine("INNER JOIN Dept ON [User].User_Name = Dept.Dept_GM");
            sql.AppendLine("INNER JOIN Contract ON Dept.User_Dept = Contract.contractDepartment");
            sql.AppendLine("Where (Contract.contractStatus = 'Expiring' OR Contract.contractStatus = 'Expired') AND Contract.contractHistory = '0'");

            try
            {
                dal = new SqlDataAdapter(sql.ToString(), conn);
                dal.Fill(contractData);

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return contractData;
        }

        public DataSet GetEmailHeadAndGM()
        {
            StringBuilder sql;
            SqlDataAdapter dal;
            DataSet contractData;

            SqlConnection conn = dbConn.GetConnection();
            contractData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT  [User].User_Email , [User].User_Name , [Contract].contractCreatedBy , [Contract].contractTitle , [Contract].contractStartDate , [Contract].contractEndDate , [Contract].contractRemainingDays , [Dept].Dept_Head , [Dept].Dept_GM");
            sql.AppendLine("FROM [User]");
            sql.AppendLine("INNER JOIN Dept ON  ([User].User_Name = Dept.Dept_Head OR [User].User_Name = Dept.Dept_GM)");
            sql.AppendLine("INNER JOIN Contract ON Dept.User_Dept = Contract.contractDepartment");
            sql.AppendLine(" Where ([User].User_Name = Dept.Dept_Head OR [User].User_Name = Dept.Dept_GM) AND [User].User_Dept = Contract.contractDepartment");

            try
            {
                dal = new SqlDataAdapter(sql.ToString(), conn);
                dal.Fill(contractData);

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return contractData;
        }

        //Retrieves an entire line of data in accordance to the ID

        public DataSet GetContractView(String contractID)
        {
            StringBuilder sql;
            SqlDataAdapter dal;
            DataSet contractData;

            SqlConnection conn = dbConn.GetConnection();
            contractData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT * ");
            sql.AppendLine("FROM Contract");
            sql.AppendLine("WHERE contractID = @contractID");


            conn.Open();
            try
            {
                dal = new SqlDataAdapter(sql.ToString(), conn);
                dal.SelectCommand.Parameters.AddWithValue("@contractID", contractID);
                dal.Fill(contractData);

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return contractData;
        }

        //Retrieves contract to be placed into different textboxes for updating

        public DataSet GetContractEditView(String contractID)
        {
            StringBuilder sql;
            SqlDataAdapter dal;
            DataSet contractData;

            SqlConnection conn = dbConn.GetConnection();
            contractData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT contractID, contractDepartment , contractType, contractSubType, contractTitle , contractExplaination , contractNameOfCounterparty , contractTerm , contractAmount , contractDate , contractStartDate, contractEndDate ,contractDuration, contractAutomaticExtension, contractConditionForAutomaticExtension, contractDocumentLocation, contractSignedBy , contractTitleOfSigner, contractPersonInCharge , contractRefNo , contractDecisionMaker, contractReviewedByLADept , contractRemarks ,contractStatus");
            sql.AppendLine("FROM Contract");
            sql.AppendLine("WHERE contractID = @contractID");


            conn.Open();
            try
            {
                dal = new SqlDataAdapter(sql.ToString(), conn);
                dal.SelectCommand.Parameters.AddWithValue("@contractID", contractID);
                dal.Fill(contractData);

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return contractData;
        }

        //Creation of a new contract

        public int InsertContractDetails(string contractDepartment, string contractType, string contractSubType, string contractTitle, string contractExplaination, string contractNameOfCounterparty, string contractTerm, int contractAmount, string contractDate, string contractStartDate, string contractEndDate, int contractDuration, string contractAutomaticExtension, string contractConditionForAutomaticExtension, string contractDocumentLocation, string contractSignedBy, string contractTitleOfSigner, string contractPersonInCharge, string contractRefNo, string contractDecisionMaker, string contractReviewedByLADept, string contractRemarks, string contractStatus, string contractCreatedBy)
        {
            StringBuilder sql;
            SqlCommand sqlCmd;
            int result = 0;

            sql = new StringBuilder();

            sql.AppendLine("INSERT INTO Contract (contractDepartment , contractType, contractSubType, contractTitle , contractExplaination , contractNameOfCounterparty , contractTerm , contractAmount , contractDate , contractStartDate, contractEndDate ,contractDuration, contractAutomaticExtension, contractConditionForAutomaticExtension, contractDocumentLocation, contractSignedBy , contractTitleOfSigner, contractPersonInCharge , contractRefNo , contractDecisionMaker, contractReviewedByLADept , contractRemarks ,contractStatus , contractCreatedBy)");
            sql.AppendLine("VALUES (@contractDepartment, @contractType, @contractSubType, @contractTitle, @contractExplaination, @contractNameOfCounterparty, @contractTerm, @contractAmount, @contractDate, @contractStartDate , @contractEndDate , @contractDuration , @contractAutomaticExtension , @contractConditionForAutomaticExtension , @contractDocumentLocation , @contractSignedBy , @contractTitleOfSigner , @contractPersonInCharge , @contractRefNo , @contractDecisionMaker , @contractReviewedByLADept , @contractRemarks , @contractStatus , @contractCreatedBy)");
            sql.AppendLine(" ");

            SqlConnection conn = dbConn.GetConnection();
            conn.Open();
            try
            {

                sqlCmd = new SqlCommand(sql.ToString(), conn);
                sqlCmd.Parameters.AddWithValue("@contractDepartment", contractDepartment);
                sqlCmd.Parameters.AddWithValue("@contractType", contractType);
                sqlCmd.Parameters.AddWithValue("@contractSubType", contractSubType);
                sqlCmd.Parameters.AddWithValue("@contractTitle", contractTitle);
                sqlCmd.Parameters.AddWithValue("@contractExplaination", contractExplaination);
                sqlCmd.Parameters.AddWithValue("@contractNameOfCounterparty", contractNameOfCounterparty);
                sqlCmd.Parameters.AddWithValue("@contractTerm", contractTerm);
                sqlCmd.Parameters.AddWithValue("@contractAmount", contractAmount);
                sqlCmd.Parameters.AddWithValue("@contractDate", contractDate);
                sqlCmd.Parameters.AddWithValue("@contractStartDate", contractStartDate);
                sqlCmd.Parameters.AddWithValue("@contractEndDate", contractEndDate);
                sqlCmd.Parameters.AddWithValue("@contractDuration", contractDuration);
                sqlCmd.Parameters.AddWithValue("@contractAutomaticExtension", contractAutomaticExtension);
                sqlCmd.Parameters.AddWithValue("@contractConditionForAutomaticExtension", contractConditionForAutomaticExtension);
                sqlCmd.Parameters.AddWithValue("@contractDocumentLocation", contractDocumentLocation);
                sqlCmd.Parameters.AddWithValue("@contractSignedBy", contractSignedBy);
                sqlCmd.Parameters.AddWithValue("@contractTitleOfSigner", contractTitleOfSigner);
                sqlCmd.Parameters.AddWithValue("@contractPersonInCharge", contractPersonInCharge);
                sqlCmd.Parameters.AddWithValue("@contractRefNo", contractRefNo);
                sqlCmd.Parameters.AddWithValue("@contractDecisionMaker", contractDecisionMaker);
                sqlCmd.Parameters.AddWithValue("@contractReviewedByLADept", contractReviewedByLADept);
                sqlCmd.Parameters.AddWithValue("@contractRemarks", contractRemarks);
                sqlCmd.Parameters.AddWithValue("@contractStatus", contractStatus);
                sqlCmd.Parameters.AddWithValue("@contractCreatedBy", contractCreatedBy);

                result = sqlCmd.ExecuteNonQuery();
                conn.Close();
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


        //Renewing a contract (Creating) but with the same parentID as the current contract

        public int RenewContractDetails(string contractDepartment, string contractType, string contractSubType, string contractTitle, string contractExplaination, string contractNameOfCounterparty, string contractTerm, int contractAmount, string contractDate, string contractStartDate, string contractEndDate, int contractDuration, string contractAutomaticExtension, string contractConditionForAutomaticExtension, string contractDocumentLocation, string contractSignedBy, string contractTitleOfSigner, string contractPersonInCharge, string contractRefNo, string contractDecisionMaker, string contractReviewedByLADept, string contractRemarks, string contractStatus, int contractParentID, string contractCreatedBy)
        {
            StringBuilder sql;
            SqlCommand sqlCmd;
            int result = 0;

            sql = new StringBuilder();

            sql.AppendLine("INSERT INTO Contract (contractDepartment , contractType, contractSubType, contractTitle , contractExplaination , contractNameOfCounterparty , contractTerm , contractAmount , contractDate , contractStartDate, contractEndDate ,contractDuration, contractAutomaticExtension, contractConditionForAutomaticExtension, contractDocumentLocation, contractSignedBy , contractTitleOfSigner, contractPersonInCharge , contractRefNo , contractDecisionMaker, contractReviewedByLADept , contractRemarks ,contractStatus , contractParentID , contractCreatedBy)");
            sql.AppendLine("VALUES (@contractDepartment, @contractType, @contractSubType, @contractTitle, @contractExplaination, @contractNameOfCounterparty, @contractTerm, @contractAmount, @contractDate, @contractStartDate , @contractEndDate , @contractDuration , @contractAutomaticExtension , @contractConditionForAutomaticExtension , @contractDocumentLocation , @contractSignedBy , @contractTitleOfSigner , @contractPersonInCharge , @contractRefNo , @contractDecisionMaker , @contractReviewedByLADept , @contractRemarks , @contractStatus , @contractParentID , @contractCreatedBy)");
            sql.AppendLine(" ");

            SqlConnection conn = dbConn.GetConnection();
            conn.Open();
            try
            {

                sqlCmd = new SqlCommand(sql.ToString(), conn);
                sqlCmd.Parameters.AddWithValue("@contractDepartment", contractDepartment);
                sqlCmd.Parameters.AddWithValue("@contractType", contractType);
                sqlCmd.Parameters.AddWithValue("@contractSubType", contractSubType);
                sqlCmd.Parameters.AddWithValue("@contractTitle", contractTitle);
                sqlCmd.Parameters.AddWithValue("@contractExplaination", contractExplaination);
                sqlCmd.Parameters.AddWithValue("@contractNameOfCounterparty", contractNameOfCounterparty);
                sqlCmd.Parameters.AddWithValue("@contractTerm", contractTerm);
                sqlCmd.Parameters.AddWithValue("@contractAmount", contractAmount);
                sqlCmd.Parameters.AddWithValue("@contractDate", contractDate);
                sqlCmd.Parameters.AddWithValue("@contractStartDate", contractStartDate);
                sqlCmd.Parameters.AddWithValue("@contractEndDate", contractEndDate);
                sqlCmd.Parameters.AddWithValue("@contractDuration", contractDuration);
                sqlCmd.Parameters.AddWithValue("@contractAutomaticExtension", contractAutomaticExtension);
                sqlCmd.Parameters.AddWithValue("@contractConditionForAutomaticExtension", contractConditionForAutomaticExtension);
                sqlCmd.Parameters.AddWithValue("@contractDocumentLocation", contractDocumentLocation);
                sqlCmd.Parameters.AddWithValue("@contractSignedBy", contractSignedBy);
                sqlCmd.Parameters.AddWithValue("@contractTitleOfSigner", contractTitleOfSigner);
                sqlCmd.Parameters.AddWithValue("@contractPersonInCharge", contractPersonInCharge);
                sqlCmd.Parameters.AddWithValue("@contractRefNo", contractRefNo);
                sqlCmd.Parameters.AddWithValue("@contractDecisionMaker", contractDecisionMaker);
                sqlCmd.Parameters.AddWithValue("@contractReviewedByLADept", contractReviewedByLADept);
                sqlCmd.Parameters.AddWithValue("@contractRemarks", contractRemarks);
                sqlCmd.Parameters.AddWithValue("@contractStatus", contractStatus);
                sqlCmd.Parameters.AddWithValue("@contractParentID", contractParentID);
                sqlCmd.Parameters.AddWithValue("@contractCreatedBy", contractCreatedBy);
                result = sqlCmd.ExecuteNonQuery();
                conn.Close();
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
        public int RenewContract(string contractID, int contractParentID)
        {
            StringBuilder sql;
            SqlCommand sqlCmd;
            int result = 0;

            sql = new StringBuilder();

            sql.AppendLine("Update Contract");
            sql.AppendLine("Set contractHistory = '1' , contractParentID=@contractParentID");
            sql.AppendLine("Where contractID = @contractID");

            SqlConnection conn = dbConn.GetConnection();
            conn.Open();
            try
            {

                sqlCmd = new SqlCommand(sql.ToString(), conn);
                sqlCmd.Parameters.AddWithValue("@contractID", contractID);
                sqlCmd.Parameters.AddWithValue("@contractParentID", contractParentID);

                result = sqlCmd.ExecuteNonQuery();
                conn.Close();
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

        // Deleting contract

        public int DeleteContract(string contractID)
        {
            StringBuilder sql;
            SqlCommand sqlCmd;
            int result = 0;

            sql = new StringBuilder();

            sql.AppendLine("DELETE from Contract");
            sql.AppendLine("WHERE contractID = @contractID");

            SqlConnection conn = dbConn.GetConnection();


            try
            {

                sqlCmd = new SqlCommand(sql.ToString(), conn);
                sqlCmd.Parameters.AddWithValue("@contractID", contractID);
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

        // Update contract
        public int UpdateContractDetails(string contractID, string contractDepartment, string contractType, string contractSubType, string contractTitle, string contractExplaination, string contractNameOfCounterparty, string contractTerm, int contractAmount, string contractDate, string contractStartDate, string contractEndDate, int contractDuration, string contractAutomaticExtension, string contractConditionForAutomaticExtension, string contractDocumentLocation, string contractSignedBy, string contractTitleOfSigner, string contractPersonInCharge, string contractRefNo, string contractDecisionMaker, string contractReviewedByLADept, string contractRemarks)
        {
            StringBuilder sql;
            SqlCommand sqlCmd;
            int result = 0;
            DateTime contractDate1 = Convert.ToDateTime(contractDate);
            DateTime contractDate2 = Convert.ToDateTime(contractStartDate);
            DateTime contractDate3 = Convert.ToDateTime(contractEndDate);

            sql = new StringBuilder();
            sql.AppendLine("UPDATE Contract");
            sql.AppendLine("SET contractDepartment = @contractDepartment , contractType = @contractType , contractSubType = @contractSubType , contractTitle = @contractTitle , contractExplaination = @contractExplaination , contractNameOfCounterparty = @contractNameOfCounterparty , contractTerm = @contractTerm , contractAmount = @contractAmount , contractDate = @contractDate , contractStartDate = @contractStartDate , contractEndDate = @contractEndDate , contractDuration = @contractDuration , contractAutomaticExtension = @contractAutomaticExtension , contractConditionForAutomaticExtension = @contractConditionForAutomaticExtension , contractDocumentLocation = @contractDocumentLocation , contractSignedBy = @contractSignedBy , contractTitleOfSigner = @contractTitleOfSigner , contractPersonInCharge = @contractPersonInCharge , contractRefNo=@contractRefNo , contractDecisionMaker = @contractDecisionMaker , contractReviewedByLADept = @contractReviewedByLADept , contractRemarks = @contractRemarks ");
            sql.AppendLine("WHERE contractID = @contractID");



            SqlConnection conn = dbConn.GetConnection();

            try
            {

                sqlCmd = new SqlCommand(sql.ToString(), conn);
                sqlCmd.Parameters.AddWithValue("@contractID", contractID);
                sqlCmd.Parameters.AddWithValue("@contractDepartment", contractDepartment);
                sqlCmd.Parameters.AddWithValue("@contractType", contractType);
                sqlCmd.Parameters.AddWithValue("@contractSubType", contractSubType);
                sqlCmd.Parameters.AddWithValue("@contractTitle", contractTitle);
                sqlCmd.Parameters.AddWithValue("@contractExplaination", contractExplaination);
                sqlCmd.Parameters.AddWithValue("@contractNameOfCounterparty", contractNameOfCounterparty);
                sqlCmd.Parameters.AddWithValue("@contractTerm", contractTerm);
                sqlCmd.Parameters.AddWithValue("@contractAmount", contractAmount);
                sqlCmd.Parameters.AddWithValue("@contractDate", contractDate1);
                sqlCmd.Parameters.AddWithValue("@contractStartDate", contractDate2);
                sqlCmd.Parameters.AddWithValue("@contractEndDate", contractDate3);
                sqlCmd.Parameters.AddWithValue("@contractDuration", contractDuration);
                sqlCmd.Parameters.AddWithValue("@contractAutomaticExtension", contractAutomaticExtension);
                sqlCmd.Parameters.AddWithValue("@contractConditionForAutomaticExtension", contractConditionForAutomaticExtension);
                sqlCmd.Parameters.AddWithValue("@contractDocumentLocation", contractDocumentLocation);
                sqlCmd.Parameters.AddWithValue("@contractSignedBy", contractSignedBy);
                sqlCmd.Parameters.AddWithValue("@contractTitleOfSigner", contractTitleOfSigner);
                sqlCmd.Parameters.AddWithValue("@contractPersonInCharge", contractPersonInCharge);
                sqlCmd.Parameters.AddWithValue("@contractRefNo", contractRefNo);
                sqlCmd.Parameters.AddWithValue("@contractDecisionMaker", contractDecisionMaker);
                sqlCmd.Parameters.AddWithValue("@contractReviewedByLADept", contractReviewedByLADept);
                sqlCmd.Parameters.AddWithValue("@contractRemarks", contractRemarks);

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

        //Updating a contract's termination reason
        public int UpdateContractTerminationReason(string contractID, string contractReasonForTermination)
        {
            StringBuilder sql;
            SqlCommand sqlCmd;
            int result = 0;

            sql = new StringBuilder();
            sql.AppendLine("UPDATE Contract");
            sql.AppendLine("SET contractReasonForTermination = @contractReasonForTermination , contractStatus = 'Terminated' , contractHistory = '1'");
            sql.AppendLine("WHERE contractID = @contractID");



            SqlConnection conn = dbConn.GetConnection();

            try
            {

                sqlCmd = new SqlCommand(sql.ToString(), conn);
                sqlCmd.Parameters.AddWithValue("@contractID", contractID);
                sqlCmd.Parameters.AddWithValue("@contractReasonForTermination", contractReasonForTermination);

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

        // Updates the current date of all contract

        public int UpdateCurrentDate(DateTime currentDate)
        {
            StringBuilder sql;
            SqlCommand sqlCmd;
            int result = 0;

            sql = new StringBuilder();
            sql.AppendLine("UPDATE Contract");
            sql.AppendLine("SET contractCurrentDate = @currentDate");



            SqlConnection conn = dbConn.GetConnection();

            try
            {

                sqlCmd = new SqlCommand(sql.ToString(), conn);
                sqlCmd.Parameters.AddWithValue("@currentDate", currentDate);

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

        // Updating contract so it shows in contract history

        public int CloseContract(string contractID)
        {
            StringBuilder sql;
            SqlCommand sqlCmd;
            int result = 0;

            sql = new StringBuilder();
            sql.AppendLine("UPDATE Contract");
            sql.AppendLine("SET contractHistory = '1'");
            sql.AppendLine("WHERE contractID = @contractID");



            SqlConnection conn = dbConn.GetConnection();

            try
            {

                sqlCmd = new SqlCommand(sql.ToString(), conn);
                sqlCmd.Parameters.AddWithValue("@contractID", contractID);

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

        //Update the status of contract in accordance to its remaining days

        public int UpdateStatus(string contractID, int remainingDays)
        {
            StringBuilder sql;
            SqlCommand sqlCmd;
            int result = 0;

            sql = new StringBuilder();
            if (remainingDays <= 60)
            {
                if (remainingDays <= 0)
                {
                    sql.AppendLine("UPDATE Contract");
                    sql.AppendLine("SET contractStatus = 'Expired'");
                    sql.AppendLine("WHERE contractID = @contractID");
                }
                else
                {
                    sql.AppendLine("UPDATE Contract");
                    sql.AppendLine("SET contractStatus = 'Expiring'");
                    sql.AppendLine("WHERE contractID = @contractID");
                }

            }
            else
            {
                sql.AppendLine("UPDATE Contract");
                sql.AppendLine("SET contractStatus = 'Active'");
                sql.AppendLine("WHERE contractID = @contractID");
            }

            SqlConnection conn = dbConn.GetConnection();

            try
            {

                sqlCmd = new SqlCommand(sql.ToString(), conn);
                sqlCmd.Parameters.AddWithValue("@contractID", contractID);

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

        // Retrieves parentID in accordance to contractID

        public DataSet GetParentID(string contractID)
        {
            StringBuilder sql;
            SqlDataAdapter dal;
            DataSet contractData; ;

            SqlConnection conn = dbConn.GetConnection();
            contractData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("Select  contractParentID from Contract");
            sql.AppendLine("WHERE contractID = @contractID");




            try
            {

                dal = new SqlDataAdapter(sql.ToString(), conn);
                dal.Fill(contractData);

            }

            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return contractData;
        }

    }
}