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
    public class DALCounterParty
    {
        private String errMsg;
        DalConn dbConn = new DalConn();

        // Retrieve all counterparties from database with specified name
        public DataSet GetAllByCounterparty(string nameOfCounterParty)
        {
            StringBuilder sql;
            SqlDataAdapter da;
            DataSet counterpartyData;

            SqlConnection conn = dbConn.GetConnection();
            counterpartyData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT *");
            sql.AppendLine(" ");
            sql.AppendLine("FROM ContractNameOfCounterParty");
            sql.AppendLine(" ");
            sql.AppendLine("WHERE nameOfCounterParty = @nameOfCounterParty");
            conn.Open();

            try
            {
                da = new SqlDataAdapter(sql.ToString(), conn);
                da.SelectCommand.Parameters.AddWithValue("nameOfCounterParty", nameOfCounterParty);
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
        // Create a new counterparty
        public int InsertContractCounterparty(string nameOfCounterParty)
        {
            StringBuilder sql;
            SqlCommand sqlCmd;
            int result = 0;

            sql = new StringBuilder();

            sql.AppendLine("INSERT INTO ContractNameOfCounterParty (nameOfCounterParty)");
            sql.AppendLine("VALUES (@nameOfCounterParty)");
            sql.AppendLine(" ");

            SqlConnection conn = dbConn.GetConnection();
            conn.Open();
            try
            {

                sqlCmd = new SqlCommand(sql.ToString(), conn);
                sqlCmd.Parameters.AddWithValue("@nameOfCounterParty", nameOfCounterParty);

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

        //Delete
        public int DeleteCounterparty(string nameOfCounterPartyID)
        {
            StringBuilder sql;
            SqlCommand sqlCmd;
            int result = 0;

            sql = new StringBuilder();

            sql.AppendLine("DELETE from ContractNameOfCounterParty");
            sql.AppendLine("WHERE nameOfCounterPartyID = @nameOfCounterPartyID");

            SqlConnection conn = dbConn.GetConnection();


            try
            {

                sqlCmd = new SqlCommand(sql.ToString(), conn);
                sqlCmd.Parameters.AddWithValue("@nameOfCounterPartyID", nameOfCounterPartyID);
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

        //Get a gridview of all the counterparties
        public DataSet GetContractCounterpartyGridView()
        {
            StringBuilder sql;
            SqlDataAdapter dal;
            DataSet contractData;

            SqlConnection conn = dbConn.GetConnection();
            contractData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT  nameOfCounterPartyID, nameOfCounterParty");
            sql.AppendLine("FROM ContractNameOfCounterParty");

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