using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using JKTS_Contract_system.BLL;

namespace JKTS_Contract_system
{
    public partial class CUDACreateContract : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            deptLbl.Text = (string)(Session["User_Dept"]);
            string contractDepartment = deptLbl.Text;
            lbl_CreatedBy.Text = (string)(Session["User_Email"]);
            string createdBy = lbl_CreatedBy.Text;
            if (Page.IsPostBack == false)
            {

            }


            string JQueryVer = "1.7.1";
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/Scripts/jquery-" + JQueryVer + ".min.js",
                DebugPath = "~/Scripts/jquery-" + JQueryVer + ".js",
                CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-" + JQueryVer + ".min.js",
                CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-" + JQueryVer + ".js",
                CdnSupportsSecureConnection = true,
                LoadSuccessExpression = "window.jQuery"
            });





        }



        protected void submit_Click(object sender, EventArgs e)
        {

            Boolean createCounterparty = false;
            Boolean verify = false;
            Boolean verifyContract = false;
            string contractDepartment = Convert.ToString(deptLbl.Text);
            string contractType = Convert.ToString(typeOfContractList.Text);
            string contractSubType = Convert.ToString(contractSubTypeList.Text);
            string contractTitle = Convert.ToString(titleOfContactTb.Text);
            string contractExplaination = Convert.ToString(explainationTb.Text);
            string contractNameOfCounterparty = Convert.ToString(nameOfCounterpartyList.Text);
            if (contractNameOfCounterparty == "Others")
            {
                RequiredFieldValidator6.Enabled = true;
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
            string contractCreatedBy = Convert.ToString(lbl_CreatedBy.Text);
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
            else if (verifyContract == true)
            {
                Response.Write("<script>alert('Contract already exist')</script>");
            }
            else
            {
                if (contractType == "---Select---" || contractSubType == "---Select---" || contractNameOfCounterparty == "---Select---" || contractTerm == "---Select---" || contractAutomaticExtension == "---Select---" || contractDecisionMaker == "---Select---" || contractReviewedByLADept == "---Select---")
                {
                    Response.Write("<script>alert('Please fill up all the required fields')</script>");
                }
                else
                {
                    BllContract contract = new BllContract();
                    int result = contract.InsertContractDetails(contractDepartment, contractType, contractSubType, contractTitle, contractExplaination, contractNameOfCounterparty, contractTerm, contractAmount, contractDate, contractStartDate, contractEndDate, contractDuration, contractAutomaticExtension, contractConditionForAutomaticExtension, contractDocumentLocation, contractSignedBy, contractTitleOfSigner, contractPersonInCharge, contractRefNo, contractDecisionMaker, contractReviewedByLADept, contractRemarks, contractStatus, contractCreatedBy);
                    BLLCounterparty counterparty = new BLLCounterparty();
                    if (createCounterparty == true)
                    {
                        counterparty.InsertContractCounterparty(contractNameOfCounterparty);
                    }
                    if (result > 0)
                    {
                        if (result > 0)
                        {
                            Response.Write("<script type=\"text/javascript\">alert('Successfully created');location.href='CUDAViewAllContracts.aspx'</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Failed to Create, please check ur details again')</script>");
                        }
                    }
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
            }
        }




        protected void automaticExtensionList_SelectedIndexChanged1(object sender, EventArgs e)
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

        protected void decisionMakerList_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string Check = decisionMakerList.SelectedItem.Text;
            if (Check != "---Select---")
            {

                decisionMakerList.Items.Remove("---Select---");
            }
        }

        protected void reviewedByLADeptList_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string Check = reviewedByLADeptList.SelectedItem.Text;
            if (Check != "---Select---")
            {

                reviewedByLADeptList.Items.Remove("---Select---");
            }
        }
    }
}

