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
    public class BLLCounterparty
    {
        DALCounterParty datalayerCounterparty = new DALCounterParty();

        public DataSet GetAllByCounterparty(string contractCounterparty)
        {

            datalayerCounterparty = new DALCounterParty();
            return datalayerCounterparty.GetAllByCounterparty(contractCounterparty);
        }
        public DataSet GetContractCounterpartyGridView()
        {
            DALCounterParty datalayerCounterparty;
            datalayerCounterparty = new DALCounterParty();
            return datalayerCounterparty.GetContractCounterpartyGridView();
        }

        //Deleting
        public int DeleteCounterParty(string nameOfCounterPartyID)
        {
            DALCounterParty datalayerCounterparty;
            datalayerCounterparty = new DALCounterParty();
            return datalayerCounterparty.DeleteCounterparty(nameOfCounterPartyID);
        }
        // Verify that there will not be a duplicat during creation phase
        public Boolean VerifyCounterparty(string contractCounterparty)
        {
            int result;
            Boolean verify;
            DataSet ds;
            DataTable dt;

            result = 0;
            verify = false;

            ds = GetAllByCounterparty(contractCounterparty);
            dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                string counterParty = row["nameOfCounterParty"].ToString();
                counterParty = counterParty.ToUpper();
                contractCounterparty = contractCounterparty.ToUpper();

                if (contractCounterparty.Equals(counterParty))
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
        public int InsertContractCounterparty(string contractCounterParty)
        {
            DALCounterParty datalayerCounterParty;
            datalayerCounterParty = new DALCounterParty();
            return datalayerCounterParty.InsertContractCounterparty(contractCounterParty);
        }
    }
}