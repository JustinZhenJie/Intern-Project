// BLL Layer Here we include all business logic serving services. 
//This is nothing but seperation of business logic into classes which can be reused in entire application.

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using JKTS_Contract_system.DAL;

namespace JKTS_Contract_system.BLL
{
    public class BLLSubType
    {

        DALSubType datalayerType = new DALSubType();

        public DataSet GetAllByType(string type, string subType)
        {

            datalayerType = new DALSubType();
            return datalayerType.GetAllByType(type, subType);
        }
        public DataSet GetContractSubTypeGridView()
        {
            DALSubType datalayerType;
            datalayerType = new DALSubType();
            return datalayerType.GetContractSubTypeGridView();
        }
        //Delte
        public int DeleteSubType(string contractSubTypeID)
        {

            DALSubType datalayerType;
            datalayerType = new DALSubType();
            return datalayerType.DeleteSubType(contractSubTypeID);
        }

        // Verify that there will not be a duplicat during creation phase
        public Boolean VerifyType(string contractType, string contractSubType)
        {
            int result;
            Boolean verify;
            DataSet ds;
            DataTable dt;

            result = 0;
            verify = false;

            ds = GetAllByType(contractType, contractSubType);
            dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                string type = row["contractTypeName"].ToString();
                string subType = row["contractSubTypeName"].ToString();

                type = type.ToUpper();
                subType = subType.ToUpper();
                contractType = contractType.ToUpper();
                contractSubType = contractSubType.ToUpper();
                if (contractType.Equals(type) && contractSubType.Equals(subType))
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
        public int InsertContractSubType(string contractTypeName, string contractSubTypeName)
        {
            DALSubType datalayerSubType;
            datalayerSubType = new DALSubType();
            return datalayerSubType.InsertContractSubType(contractTypeName, contractSubTypeName);
        }
    }
}