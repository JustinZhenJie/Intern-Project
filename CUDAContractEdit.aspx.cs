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


namespace JKTS_Contract_system
{
    public partial class CUDAContractEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_ContractID.Text = (string)(Session["contractID"]);
            string contractID = lbl_ContractID.Text;
            lbl_ContractParentID.Text = (string)(Session["contractParentID"]);
            string contractParentID = lbl_ContractParentID.Text;

            if (Page.IsPostBack == false)
            {
                BllContract contract = new BllContract();

                DataSet DS = new DataSet();
                DS = contract.GetContractEditView(contractID);
                DataTable td = DS.Tables[0];
                for (int i = 0; i < td.Rows.Count; i++)
                //retrieve contract information with sessioned contractid
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
                    contractDateTB.Text = td.Rows[i]["contractDate"].ToString();
                    DateTime contractDate = Convert.ToDateTime(contractDateTB.Text);
                    startDateTb.Text = td.Rows[i]["contractStartDate"].ToString();
                    DateTime contractStartDate = Convert.ToDateTime(startDateTb.Text);
                    endDateTb.Text = td.Rows[i]["contractEndDate"].ToString();
                    DateTime contractEndDate = Convert.ToDateTime(endDateTb.Text);
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

        //update/edit
        protected void btnEdit_onClick(object sender, EventArgs e)
        {
            lbl_ContractID.Text = (string)(Session["contractID"]);
            string contractID = lbl_ContractID.Text;
            lbl_ContractParentID.Text = (string)(Session["contractParentID"]);
            string contractParentID = lbl_ContractParentID.Text;
            Boolean createCounterparty = false;
            Boolean verify = false;
            Boolean verifyContract = false;




            string contractDepartment = Convert.ToString(deptLbl.Text);
            string typeOfContract = Convert.ToString(typeOfContractList.Text);
            string contractSubType = Convert.ToString(contractSubTypeList.Text);
            string titleOfContact = Convert.ToString(titleOfContactTb.Text);
            string explaination = Convert.ToString(explainationTb.Text);
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
            int duration = Convert.ToInt32(durationTb.Text);
            string automaticExtension = Convert.ToString(automaticExtensionList.Text);
            string conditionForExtension = Convert.ToString(conditionForExtensionTb.Text);
            string documentLocation = Convert.ToString(documentLocationTb.Text);
            string signedby = Convert.ToString(signedbyTb.Text);
            string title = Convert.ToString(titleTb.Text);
            string personInCharge = Convert.ToString(personInChargeTb.Text);
            string formRefNo = Convert.ToString(formRefNoTb.Text);
            string decisionMaker = Convert.ToString(decisionMakerList.Text);
            string reviewedByLADept = Convert.ToString(reviewedByLADeptList.Text);
            string remarks = Convert.ToString(remarksTb.Text);
            BllContract verify2 = new BllContract();
            verifyContract = verify2.VerifyContract(titleOfContact, typeOfContract, contractSubType, contractDepartment);

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
                BllContract update = new BllContract();
                int result = update.UpdateContractDetails(contractID, contractDepartment, typeOfContract, contractSubType, titleOfContact, explaination, contractNameOfCounterparty, contractTerm, contractAmount, contractDate, contractStartDate, contractEndDate, duration, automaticExtension, conditionForExtension, documentLocation, signedby, title, personInCharge, formRefNo, decisionMaker, reviewedByLADept, remarks);
                if (result > 0)
                {
                    Response.Write("<script type=\"text/javascript\">alert('Successfully updated');location.href='CUDAViewAllContracts.aspx'</script>");

                }
                else
                {
                    Response.Write("<script>alert('Failed to update, please check ur details again')</script>");
                }
            }
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

        protected void automaticExtensionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Check = automaticExtensionList.SelectedItem.Text;
            if (Check != "---Select---")
            {

                automaticExtensionList.Items.Remove("---Select---");
            }

            if (Check == "Yes")
            {
                conditionForExtensionTb.Text = "";
                conditionForExtensionTb.Enabled = true;
            }

            if (Check == "No")
            {
                conditionForExtensionTb.Text = "Nil";
                conditionForExtensionTb.Enabled = false;
            }
        }
    }
}