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
    public class DalDept
    {
        private String errMsg;
        // to get method from DalConn  // to connect to database
        DalConn dbConn = new DalConn();
        
        // to get everything from department table
        public DataSet GetDept()
        {
            StringBuilder sql;
            SqlDataAdapter dal;
            DataSet deptData;

            SqlConnection conn = dbConn.GetConnection();
            deptData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT DeptID, User_Dept, Dept_Head, Dept_GM");
            sql.AppendLine("FROM Dept");

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
        // to get everything from department table filtered by the user's department
        public DataSet GetAllByDept(string dept)
        {
            StringBuilder sql;
            SqlDataAdapter da;
            DataSet deptData;

            SqlConnection conn = dbConn.GetConnection();
            deptData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT *");
            sql.AppendLine(" ");
            sql.AppendLine("FROM Dept");
            sql.AppendLine(" ");
            sql.AppendLine("WHERE User_Dept = @User_Dept");
            conn.Open();

            try
            {
                da = new SqlDataAdapter(sql.ToString(), conn);
                da.SelectCommand.Parameters.AddWithValue("User_Dept", dept);
                da.Fill(deptData);
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
        // to insert new department/department head/department GM
        public int InsertDept(string User_Dept, string Dept_Head, string Dept_GM)
        {
            StringBuilder sql;
            SqlCommand sqlCmd;
            int result = 0;


            sql = new StringBuilder();

            sql.AppendLine("INSERT INTO Dept (User_Dept, Dept_Head, Dept_GM)");
            sql.AppendLine("VALUES (@User_Dept, @Dept_Head, @Dept_GM)");
            sql.AppendLine(" ");

            SqlConnection conn = dbConn.GetConnection();
            conn.Open();
            try
            {
                sqlCmd = new SqlCommand(sql.ToString(), conn);
                sqlCmd.Parameters.AddWithValue("@User_Dept", User_Dept);
                sqlCmd.Parameters.AddWithValue("@Dept_Head", Dept_Head);
                sqlCmd.Parameters.AddWithValue("@Dept_GM", Dept_GM);

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
        // to update department/department head/department GM
        public int UpdateDeptDetails(string DeptID, string User_Dept, string Dept_Head, string Dept_GM)
        {
            StringBuilder sql;
            SqlCommand sqlCmd;
            int result;

            result = 0;

            sql = new StringBuilder();
            sql.AppendLine("UPDATE Dept");
            sql.AppendLine("SET User_Dept=@User_Dept, Dept_Head=@Dept_Head, Dept_GM=@Dept_GM");
            sql.AppendLine("WHERE DeptID = @DeptID");
            SqlConnection conn = dbConn.GetConnection();
            try
            {
                sqlCmd = new SqlCommand(sql.ToString(), conn);
                sqlCmd.Parameters.AddWithValue("@DeptID", DeptID);
                sqlCmd.Parameters.AddWithValue("@User_Dept", User_Dept);
                sqlCmd.Parameters.AddWithValue("@Dept_Head", Dept_Head);
                sqlCmd.Parameters.AddWithValue("@Dept_GM", Dept_GM);

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
        // to Delete existing department from database
        public int DeleteDept(string DeptID)
        {
            StringBuilder sql;
            SqlCommand sqlCmd;
            int result;

            result = 0;

            sql = new StringBuilder();
            sql.AppendLine("DELETE FROM Dept");
            sql.AppendLine(" ");
            sql.AppendLine("WHERE DeptID = @DeptID");
            SqlConnection conn = dbConn.GetConnection();
            try
            {
                sqlCmd = new SqlCommand(sql.ToString(), conn);
                sqlCmd.Parameters.AddWithValue("@DeptID", DeptID);
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