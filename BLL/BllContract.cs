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
    public class BllContract
    {
        DalContract datalayerContract = new DalContract();
        public DataSet GetContractGridView()
        {
            DalContract datalayerContract;
            datalayerContract = new DalContract();
            return datalayerContract.GetContractGridView();
        }

        public DataSet GetAllByTitleAndType(string contractTitle, string contractType, string contractSubType, string contractDepartment)
        {

            datalayerContract = new DalContract();
            return datalayerContract.GetAllByTitleAndType(contractTitle, contractType, contractSubType, contractDepartment);
        }

        //Verify contract based on title type and subtype to ensure no duplicates
        public Boolean VerifyContract(string contractTitle, string contractType, string contractSubType, string contractDepartment)
        {
            int result;
            Boolean verify;
            DataSet ds;
            DataTable dt;

            result = 0;
            verify = false;

            ds = GetAllByTitleAndType(contractTitle, contractType, contractSubType, contractDepartment);
            dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                string title = row["contractTitle"].ToString();
                string type = row["contractType"].ToString();
                string subtype = row["contractSubType"].ToString();
                string dept = row["contractDepartment"].ToString();

                if (contractTitle.Equals(title) && contractType.Equals(type) && contractSubType.Equals(subtype) && contractDepartment.Equals(dept))
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

        public DataSet GetContractGridView(string contractDepartment)
        {
            DalContract datalayerContract;
            datalayerContract = new DalContract();
            return datalayerContract.GetContractGridView(contractDepartment);
        }
        public DataSet GetContractExport()
        {
            DalContract datalayerContract;
            datalayerContract = new DalContract();
            return datalayerContract.GetContractExport();

        }
        public DataSet GetContractExport(string contractDepartment)
        {
            DalContract datalayerContract;
            datalayerContract = new DalContract();
            return datalayerContract.GetContractExport(contractDepartment);

        }
        public DataSet GetRemainingDaysGridView()
        {
            DalContract datalayerContract;
            datalayerContract = new DalContract();
            return datalayerContract.GetRemainingDaysGridView();
        }

        public DataSet GetContractParentIDGridView(int contractParentID)
        {
            DalContract datalayerContract;
            datalayerContract = new DalContract();
            return datalayerContract.GetContractParentIDGridView(contractParentID);
        }
        public DataSet GetContractRelatedGridView(string contractID, int contractParentID)
        {
            DalContract datalayerContract;
            datalayerContract = new DalContract();
            return datalayerContract.GetContractRelatedGridView(contractID, contractParentID);
        }





        public DataSet GetContractView(string contractID)
        {
            DalContract datalayerContract;
            datalayerContract = new DalContract();
            return datalayerContract.GetContractView(contractID);
        }
        public DataSet GetEmailDeptHead()
        {
            DalContract datalayerContract;
            datalayerContract = new DalContract();
            return datalayerContract.GetEmailDeptHead();
        }

        public DataSet GetEmailDeptGM()
        {
            DalContract datalayerContract;
            datalayerContract = new DalContract();
            return datalayerContract.GetEmailDeptGM();
        }

        public DataSet GetEmailHeadAndGM()
        {
            DalContract datalayerContract;
            datalayerContract = new DalContract();
            return datalayerContract.GetEmailHeadAndGM();
        }


        public DataSet GetContractHistoryGridView()
        {
            DalContract datalayerContract;
            datalayerContract = new DalContract();
            return datalayerContract.GetContractHistoryGridView();
        }

        public DataSet GetContractHistoryGridView(string contractDepartment)
        {
            DalContract datalayerContract;
            datalayerContract = new DalContract();
            return datalayerContract.GetContractHistoryGridView(contractDepartment);
        }
        public DataSet GetContractEditView(string contractID)
        {
            DalContract datalayerContract;
            datalayerContract = new DalContract();
            return datalayerContract.GetContractEditView(contractID);
        }

        //public DataSet GetDeptFromUserID(string userID)
        //{
        //    DalContract datalayerContract;
        //    datalayerContract = new DalContract();
        //    return datalayerContract.GetDeptFromUserID(userID);
        //}

        public int DeleteContract(string contractID)
        {
            DalContract datalayerContract;
            datalayerContract = new DalContract();
            return datalayerContract.DeleteContract(contractID);
        }



        public int InsertContractDetails(string contractDepartment, string contractType, string contractSubType, string contractTitle, string contractExplaination, string contractNameOfCounterparty, string contractTerm, int contractAmount, string contractDate, string contractStartDate, string contractEndDate, int contractDuration, string contractAutomaticExtension, string contractConditionForAutomaticExtension, string contractDocumentLocation, string contractSignedBy, string contractTitleOfSigner, string contractPersonInCharge, string contractRefNo, string contractDecisionMaker, string contractReviewedByLADept, string contractRemarks, string contractStatus, string contractCreatedBy)
        {
            DalContract datalayerContract;
            datalayerContract = new DalContract();
            return datalayerContract.InsertContractDetails(contractDepartment, contractType, contractSubType, contractTitle, contractExplaination, contractNameOfCounterparty, contractTerm, contractAmount, contractDate, contractStartDate, contractEndDate, contractDuration, contractAutomaticExtension, contractConditionForAutomaticExtension, contractDocumentLocation, contractSignedBy, contractTitleOfSigner, contractPersonInCharge, contractRefNo, contractDecisionMaker, contractReviewedByLADept, contractRemarks, contractStatus, contractCreatedBy);
        }



        public int UpdateStatus(string contractID, int remainingDays)
        {
            DalContract datalayerContract;
            datalayerContract = new DalContract();
            return datalayerContract.UpdateStatus(contractID, remainingDays);

        }


        public int UpdateCurrentDate(DateTime currentDate)
        {
            DalContract datalayerContract;
            datalayerContract = new DalContract();
            return datalayerContract.UpdateCurrentDate(currentDate);
        }

        public int RenewContractDetails(string contractDepartment, string contractType, string contractSubType, string contractTitle, string contractExplaination, string contractNameOfCounterparty, string contractTerm, int contractAmount, string contractDate, string contractStartDate, string contractEndDate, int contractDuration, string contractAutomaticExtension, string contractConditionForAutomaticExtension, string contractDocumentLocation, string contractSignedBy, string contractTitleOfSigner, string contractPersonInCharge, string contractRefNo, string contractDecisionMaker, string contractReviewedByLADept, string contractRemarks, string contractStatus, int contractParentID, string contractCreatedBy)
        {
            DalContract datalayerContract;
            datalayerContract = new DalContract();
            return datalayerContract.RenewContractDetails(contractDepartment, contractType, contractSubType, contractTitle, contractExplaination, contractNameOfCounterparty, contractTerm, contractAmount, contractDate, contractStartDate, contractEndDate, contractDuration, contractAutomaticExtension, contractConditionForAutomaticExtension, contractDocumentLocation, contractSignedBy, contractTitleOfSigner, contractPersonInCharge, contractRefNo, contractDecisionMaker, contractReviewedByLADept, contractRemarks, contractStatus, contractParentID, contractCreatedBy);
        }

        //public DataSet GetParentID(string contractID)
        //{
        //    DalContract datalayerContract;
        //    datalayerContract = new DalContract();
        //    return datalayerContract.GetParentID(contractID);
        //}

        public int UpdateContractDetails(string contractID, string contractDepartment, string contractType, string contractSubType, string contractTitle, string contractExplaination, string contractNameOfCounterparty, string contractTerm, int contractAmount, string contractDate, string contractStartDate, string contractEndDate, int contractDuration, string contractAutomaticExtension, string contractConditionForAutomaticExtension, string contractDocumentLocation, string contractSignedBy, string contractTitleOfSigner, string contractPersonInCharge, string contractRefNo, string contractDecisionMaker, string contractReviewedByLADept, string contractRemarks)
        {
            DalContract datalayerContract;
            datalayerContract = new DalContract();
            return datalayerContract.UpdateContractDetails(contractID, contractDepartment, contractType, contractSubType, contractTitle, contractExplaination, contractNameOfCounterparty, contractTerm, contractAmount, contractDate, contractStartDate, contractEndDate, contractDuration, contractAutomaticExtension, contractConditionForAutomaticExtension, contractDocumentLocation, contractSignedBy, contractTitleOfSigner, contractPersonInCharge, contractRefNo, contractDecisionMaker, contractReviewedByLADept, contractRemarks);

        }
        public int UpdateContractTerminationReason(string contractID, string contractReasonForTermination)
        {
            DalContract datalayerContract;
            datalayerContract = new DalContract();
            return datalayerContract.UpdateContractTerminationReason(contractID, contractReasonForTermination);

        }

        public int RenewContract(string contractID, int parentID)
        {
            DalContract datalayerContract;
            datalayerContract = new DalContract();
            return datalayerContract.RenewContract(contractID, parentID);
        }
        public int CloseContract(string contractID)
        {
            DalContract datalayerContract;
            datalayerContract = new DalContract();
            return datalayerContract.CloseContract(contractID);

        }
    }
}