using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using JKTS_Contract_system.DAL;

namespace JKTS_Contract_system.BLL
{
    public class BllDept
    {
        // to get method from DalDept
        DalDept datalayerDept = new DalDept();

        // to get everything from department table
        public DataSet GetDept()
        { 
            datalayerDept = new DalDept();
            return datalayerDept.GetDept();
        }
        // to get everything from department table filtered by the user's department
        public DataSet GetAllByDept(string dept)
        {

            datalayerDept = new DalDept();
            return datalayerDept.GetAllByDept(dept);
        }

        // to verify if the department name already exist when user input/create new department. 
        // if department name already exist, user cannot create the same department/cannot create department with the same name
        public Boolean VerifyDept(string dept)
        {
            int result;
            Boolean verify;
            DataSet ds;
            DataTable dt;

            result = 0;
            verify = false;

            ds = GetAllByDept(dept);
            dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                string Dept = row["User_Dept"].ToString();


                if (dept.Equals(Dept))
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

        // to insert new department/department head/department GM in database (Dept)
        public int InsertDept(string User_Dept, string Dept_Head, string Dept_GM)
        {

            datalayerDept = new DalDept();
            return datalayerDept.InsertDept(User_Dept, Dept_Head, Dept_GM);
        }

        // to update department/department head/department GM in database (Dept)

        public int UpdateDeptDetails(string DeptID, string User_Dept, string Dept_Head, string Dept_GM)
        {
            datalayerDept = new DalDept();
            return datalayerDept.UpdateDeptDetails(DeptID, User_Dept, Dept_Head, Dept_GM);
        }


        // to Delete existing department from database (Dept)
        public int DeleteDept(string DeptID)
        {
            datalayerDept = new DalDept();
            return datalayerDept.DeleteDept(DeptID);
        }
    }
}