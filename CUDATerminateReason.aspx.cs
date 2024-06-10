using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using JKTS_Contract_system.BLL;

namespace JKTS_Contract_system.scripts
{
    public partial class CUDATerminateReason : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_ContractID.Text = (string)(Session["contractID"]);
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("CUDAViewAllContracts.aspx");
        }

        protected void confirmBtn_Click(object sender, EventArgs e)
        {
            lbl_ContractID.Text = (string)(Session["contractID"]);
            string contractID = lbl_ContractID.Text;
            string termination = Convert.ToString(terminationTB.Text);
            BllContract contract = new BllContract();
            int result = contract.UpdateContractTerminationReason(contractID, termination);
            if (result > 0)
            {
                if (result > 0)
                {
                    Response.Write("<script type=\"text/javascript\">alert('Successfully Terminated');location.href='CUDAViewAllContracts.aspx'</script>");
                }
                else
                {
                    Response.Write("<script>alert('Failed to Terminate, please check ur details again')</script>");
                }
            }

        }
    }
}