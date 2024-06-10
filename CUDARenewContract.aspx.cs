using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using JKTS_Contract_system.BLL;
using System.Globalization;
using System.Configuration;


namespace JKTS_Contract_system
{
    public partial class CUDARenewContract : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_ContractID.Text = (string)(Session["contractID"]);
            string contractID = lbl_ContractID.Text;
            lbl_ContractParentID.Text = (string)(Session["contractParentID"]);
            string contractParentID = lbl_ContractParentID.Text;
            lbl_CreatedBy.Text = (string)(Session["User_Email"]);
            string createdBy = lbl_CreatedBy.Text;

            if (Page.IsPostBack == false)
            {
                BllContract contract = new BllContract();

                //retrieve contract information with sessioned contractid
                DataSet DS = new DataSet();
                DS = contract.GetContractEditView(contractID);
                DataTable td = DS.Tables[0];
                for (int i = 0; i < td.Rows.Count; i++)
                {
                    deptLbl.Text = td.Rows[i]["contractDepartment"].ToString();
                    string contractDepartment = Convert.ToString(deptLbl.Text);
                    typeOfContractList.Text = td.Rows[i]["contractType"].ToString();
                    string typeOfContract = Convert.ToString(typeOfContractList.Text);
                    contractSubTypeList.Text = td.Rows[i]["contractSubType"].ToString();
                    string contractSubType = Convert.ToString(contractSubTypeList.Text);
                    titleOfContactTb.Text = td.Rows[i]["contractTitle"].ToString();
                    string titleOfContact = Convert.ToString(titleOfContactTb.Text);
                    explainationTb.Text = td.Rows[i]["contractExplaination"].ToString();
                    string explaination = Convert.ToString(explainationTb.Text);
                    nameOfCounterpartyList.Text = td.Rows[i]["contractNameOfCounterparty"].ToString();
                    string nameOfCounterparty = Convert.ToString(nameOfCounterpartyList.Text);
                    contractTermList.Text = td.Rows[i]["contractTerm"].ToString();
                    string contractTerm = Convert.ToString(contractTermList.Text);
                    contractAmountTb.Text = td.Rows[i]["contractAmount"].ToString();
                    int contractAmount = Convert.ToInt32(contractAmountTb.Text);
                    DateTime date = DateTime.Parse(td.Rows[i]["contractDate"].ToString());
                    contractDateTB.Text = date.ToShortDateString();
                    string contractDate = Convert.ToString(contractDateTB.Text);
                    DateTime startDate = DateTime.Parse(td.Rows[i]["contractStartDate"].ToString());
                    startDateTb.Text = startDate.ToShortDateString();
                    string contractStartDate = Convert.ToString(startDateTb.Text);
                    DateTime endDate = DateTime.Parse(td.Rows[i]["contractEndDate"].ToString());
                    endDateTb.Text = endDate.ToShortDateString();
                    string contractEndDate = Convert.ToString(endDateTb.Text);
                    durationTb.Text = td.Rows[i]["contractDuration"].ToString();
                    int duration = Convert.ToInt32(durationTb.Text);
                    automaticExtensionList.Text = td.Rows[i]["contractAutomaticExtension"].ToString();
                    string automaticExtension = Convert.ToString(automaticExtensionList.Text);
                    conditionForExtensionTb.Text = td.Rows[i]["contractConditionForAutomaticExtension"].ToString();
                    string conditionForExtension = Convert.ToString(conditionForExtensionTb.Text);
                    documentLocationTb.Text = td.Rows[i]["contractDocumentLocation"].ToString();
                    string documentLocation = Convert.ToString(documentLocationTb.Text);
                    signedbyTb.Text = td.Rows[i]["contractSignedBy"].ToString();
                    string signedby = Convert.ToString(signedbyTb.Text);
                    titleTb.Text = td.Rows[i]["contractTitleOfSigner"].ToString();
                    string title = Convert.ToString(titleTb.Text);
                    personInChargeTb.Text = td.Rows[i]["contractPersonInCharge"].ToString();
                    string personInCharge = Convert.ToString(personInChargeTb.Text);
                    formRefNoTb.Text = td.Rows[i]["contractRefNo"].ToString();
                    string formRefNo = Convert.ToString(formRefNoTb.Text);
                    decisionMakerList.Text = td.Rows[i]["contractDecisionMaker"].ToString();
                    string decisionMaker = Convert.ToString(decisionMakerList.Text);
                    reviewedByLADeptList.Text = td.Rows[i]["contractReviewedByLADept"].ToString();
                    string reviewedByLADept = Convert.ToString(reviewedByLADeptList.Text);
                    remarksTb.Text = td.Rows[i]["contractRemarks"].ToString();
                    string remarks = Convert.ToString(remarksTb.Text);
                }

            }
        }

        protected void btnBack_OnClick(object sender, EventArgs e)
        {


            Response.Redirect("CUDAViewAllContracts.aspx");


        }


        protected void contractTermList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Check = contractTermList.SelectedItem.Text;
            if (Check != "---Select---")
            {

                contractTermList.Items.Remove("---Select---");
            }
            if (Check == "Nil")
            {
                contractAmountLbl.Text = "";
                contractAmountTb.Text = "0";
                contractAmountTb.Enabled = false;
            }
            if (Check == "One Time Payment")
            {
                contractAmountTb.Enabled = true;
                contractAmountLbl.Text = "Contract Payment for Transaction";
            }
            if (Check == "Monthly")
            {
                contractAmountTb.Enabled = true;
                contractAmountLbl.Text = "Contract Payment per Month";
            }
            if (Check == "Yearly")
            {
                contractAmountTb.Enabled = true;
                contractAmountLbl.Text = "Contract Payment per Year";
            }
        }

        protected void renewBtn_Click(object sender, EventArgs e)
        {

            string contractParentID = lbl_ContractParentID.Text;
            int parentID = Convert.ToInt32(contractParentID);
            Boolean createCounterparty = false;
            Boolean verify = false;
            Boolean verifyContract = false;
            string contractID = lbl_ContractID.Text;
            if (contractParentID == "0")
            {
                int highestContractParentID = 0;
                string conStr = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;
                // if not renewed before, create a new contractpaerntid
                using (SqlConnection cnz = new SqlConnection(conStr))
                {
                    SqlCommand cmdzs = new SqlCommand("SELECT MAX(contractParentID) AS result from Contract ", cnz);
                    cmdzs.CommandType = CommandType.Text;
                    cnz.Open();
                    highestContractParentID = Convert.ToInt32(cmdzs.ExecuteScalar().ToString());
                    highestContractParentID++;
                }
                lbl_ContractParentID.Text = highestContractParentID.ToString();
                lbl_HighestParentID.Text = highestContractParentID.ToString();
                BllContract updateOldContract = new BllContract();
                int test = updateOldContract.RenewContract(contractID, highestContractParentID);
                parentID = highestContractParentID;

            }
            else
            {
                BllContract updateOldContract = new BllContract();
                int test = updateOldContract.RenewContract(contractID, parentID);
            }
            string contractDepartment = Convert.ToString(deptLbl.Text);
            string contractType = Convert.ToString(typeOfContractList.Text);
            string contractSubType = Convert.ToString(contractSubTypeList.Text);
            string contractTitle = Convert.ToString(titleOfContactTb.Text);
            string contractExplaination = Convert.ToString(explainationTb.Text);
            string contractNameOfCounterparty = Convert.ToString(nameOfCounterpartyList.Text);
            if (contractNameOfCounterparty == "Others")
            {
                contractNameOfCounterparty = Convert.ToString(counterPartyTb.Text);
                createCounterparty = true;
                contractNameOfCounterparty = contractNameOfCounterparty.ToUpper();
                BLLCounterparty myCounterParty = new BLLCounterparty();
                verify = myCounterParty.VerifyCounterparty(contractNameOfCounterparty);


            }
            string contractTerm = Convert.ToString(contractTermList.Text);
            int contractAmount = Convert.ToInt32(contractAmountTb.Text);
            string contractDate = Convert.ToString(contractDateTB.Text);
            string contractStartDate = Convert.ToString(startDateTb.Text);
            string contractEndDate = Convert.ToString(endDateTb.Text);
            int contractDuration = Convert.ToInt32(durationTb.Text);
            string contractAutomaticExtension = Convert.ToString(automaticExtensionList.Text);
            string contractConditionForAutomaticExtension = Convert.ToString(conditionForExtensionTb.Text);
            string contractDocumentLocation = Convert.ToString(documentLocationTb.Text);
            string contractSignedBy = Convert.ToString(signedbyTb.Text);
            string contractTitleOfSigner = Convert.ToString(titleOfContactTb.Text);
            string contractPersonInCharge = Convert.ToString(personInChargeTb.Text);
            string contractRefNo = Convert.ToString(formRefNoTb.Text);
            string contractDecisionMaker = Convert.ToString(decisionMakerList.Text);
            string contractReviewedByLADept = Convert.ToString(reviewedByLADeptList.Text);
            string contractRemarks = Convert.ToString(remarksTb.Text);
            string contractStatus = "Active";
            string created = Convert.ToString(lbl_CreatedBy);
            BllContract verify2 = new BllContract();
            verifyContract = verify2.VerifyContract(contractTitle, contractType, contractSubType, contractDepartment);

            DateTime start = Convert.ToDateTime(contractStartDate);
            DateTime end = Convert.ToDateTime(contractEndDate);
            if (verify == true)
            {
                Response.Write("<script>alert('Counterparty already exist, please select from drop down list')</script>");

            }
            else if (end.Date < start.Date)
            {
                Response.Write("<script>alert('Contract start date has to be lower than its end date')</script>");
            }

            else
            {
                BLLCounterparty counterparty = new BLLCounterparty();
                if (createCounterparty == true)
                {
                    counterparty.InsertContractCounterparty(contractNameOfCounterparty);
                }
                BllContract contract = new BllContract();
                int result = contract.RenewContractDetails(contractDepartment, contractType, contractSubType, contractTitle, contractExplaination, contractNameOfCounterparty, contractTerm, contractAmount, contractDate, contractStartDate, contractEndDate, contractDuration, contractAutomaticExtension, contractConditionForAutomaticExtension, contractDocumentLocation, contractSignedBy, contractTitleOfSigner, contractPersonInCharge, contractRefNo, contractDecisionMaker, contractReviewedByLADept, contractRemarks, contractStatus, parentID, created);


                if (result > 0)
                {
                    if (result > 0)
                    {
                        Response.Write("<script type=\"text/javascript\">alert('Successfully renewed');location.href='CUDAViewAllContracts.aspx'</script>");

                    }
                    else
                    {
                        Response.Write("<script>alert('Failed to Renew, please check ur details again')</script>");
                    }
                }


            }

        }

        protected void nameOfCounterpartyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Check = nameOfCounterpartyList.SelectedItem.Text;
            if (Check != "---Select---")
            {
                nameOfCounterpartyList.Items.Remove("---Select---");
            }
            if (Check == "Others")
            {
                counterPartyTb.Visible = true;
            }
            if (Check != "Others")
            {
                counterPartyTb.Visible = false;
                counterPartyTb.Text = " ";
            }
        }
    }

}
