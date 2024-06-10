//Basically we include services which communicate to database directly
//This layer is responsible for all database interaction. No outside method is allowed to communicate with database.

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
    public class DALSubType
    {
        private String errMsg;
        DalConn dbConn = new DalConn();

        // Retrieve all subtypes in accordance to their type from the database
        public DataSet GetAllByType(string contractTypeName, string contractSubTypeName)
        {
            StringBuilder sql;
            SqlDataAdapter da;
            DataSet typeData;

            SqlConnection conn = dbConn.GetConnection();
            typeData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT *");
            sql.AppendLine(" ");
            sql.AppendLine("FROM ContractSubType");
            sql.AppendLine(" ");
            sql.AppendLine("WHERE contractTypeName = @contractTypeName and contractSubTypeName = @contractSubTypeName");
            conn.Open();

            try
            {
                da = new SqlDataAdapter(sql.ToString(), conn);
                da.SelectCommand.Parameters.AddWithValue("contractTypeName", contractTypeName);
                da.SelectCommand.Parameters.AddWithValue("contractSubTypeName", contractSubTypeName);
                da.Fill(typeData);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return typeData;
        }
        //Delete

        public int DeleteSubType(string contractSubTypeID)
        {
            StringBuilder sql;
            SqlCommand sqlCmd;
            int result = 0;

            sql = new StringBuilder();

            sql.AppendLine("DELETE from ContractSubType");
            sql.AppendLine("WHERE contractSubTypeID = @contractSubTypeID");

            SqlConnection conn = dbConn.GetConnection();


            try
            {

                sqlCmd = new SqlCommand(sql.ToString(), conn);
                sqlCmd.Parameters.AddWithValue("@contractSubTypeID", contractSubTypeID);
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
        // Create a new subtype
        public int InsertContractSubType(string contractTypeName, string contractSubTypeName)
        {
            StringBuilder sql;
            SqlCommand sqlCmd;
            int result = 0;

            sql = new StringBuilder();

            sql.AppendLine("INSERT INTO ContractSubType (contractTypeName , contractSubTypeName )");
            sql.AppendLine("VALUES (@contractTypeName, @contractSubTypeName)");
            sql.AppendLine(" ");

            SqlConnection conn = dbConn.GetConnection();
            conn.Open();
            try
            {

                sqlCmd = new SqlCommand(sql.ToString(), conn);
                sqlCmd.Parameters.AddWithValue("@contractTypeName", contractTypeName);
                sqlCmd.Parameters.AddWithValue("@contractSubTypeName", contractSubTypeName);

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

        // Retrieve a gridview of the database table subtype with their id, type and subtype
        public DataSet GetContractSubTypeGridView()
        {
            StringBuilder sql;
            SqlDataAdapter dal;
            DataSet contractData;

            SqlConnection conn = dbConn.GetConnection();
            contractData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT  contractSubTypeID, contractTypeName, contractSubTypeName");
            sql.AppendLine("FROM ContractSubType");

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