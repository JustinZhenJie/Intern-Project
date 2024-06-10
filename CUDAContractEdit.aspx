<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="~/CUDAMasterPage.Master" AutoEventWireup="true" CodeBehind="CUDAContractEdit.aspx.cs" Inherits="JKTS_Contract_system.CUDAContractEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1 {
            width: 100px;
        }

        .style2 {
            margin-top: 20px;
            margin-left: 300px;
        }

        .auto-style3 {
            width: 90%;
            margin-left: 20%;
            vertical-align: top;
        }

        .auto-style4 {
            width: 50%;
            vertical-align: top;
            padding-bottom: 1%;
        }

        .auto-style6 {
            height: 10px;
            width: 40%;
            vertical-align: top;
            padding-left: 13%;
        }

        .auto-style7 {
            width: 50%;
            vertical-align: top;
            padding-bottom: 1%;
            height: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Edit Contract</h1>
    <table class="auto-style3">
        <tr>
            <td class="auto-style6">
                <asp:Label ID="departmentLbl" runat="server" Text="Department :"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:Label ID="deptLbl" runat="server" Height="16px">
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Label ID="typeOfContractLbl" runat="server" Text="Type Of Contract :"></asp:Label>
            </td>
            <td class="auto-style7">
                <asp:DropDownList ID="typeOfContractList" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2" DataTextField="contractTypeName" DataValueField="contractTypeName">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT DISTINCT [contractTypeName] FROM [ContractSubType]"></asp:SqlDataSource>
                <asp:DropDownList ID="contractSubTypeList" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource3" DataTextField="contractSubTypeName" DataValueField="contractSubTypeName">
                    <asp:ListItem>Others</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT [contractSubTypeName] FROM [ContractSubType] WHERE ([contractTypeName] = @contractTypeName)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="typeOfContractList" Name="contractTypeName" PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>

            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="typeOfContractList" ErrorMessage="Please choose type of contract" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="contractSubTypeList" ErrorMessage="Please choose sub type of contract" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>


            </td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Label ID="titleOfContactLbl" runat="server" Text="Title Of Contract :"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="titleOfContactTb" runat="server" autocomplete="off"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="titleOfContactTb" ErrorMessage="Please enter title of contract" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>


            </td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Label ID="explainationLbl" runat="server" Text="Explaination Of Contract :"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="explainationTb" runat="server" TextMode="MultiLine" ValidateRequestMode="Enabled" autocomplete="off" Height="120px" Width="370px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="explainationTb" ErrorMessage="Please enter explaination of contract" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>


            </td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Label ID="nameOfCounterpartyLbl" runat="server" Text="FullName Of Counterparty :"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:DropDownList ID="nameOfCounterpartyList" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource4" DataTextField="nameOfCounterParty" DataValueField="nameOfCounterParty" OnSelectedIndexChanged="nameOfCounterpartyList_SelectedIndexChanged" AppendDataBoundItems="True">
                    <asp:ListItem>Others</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="counterPartyTb" runat="server" Visible="False"></asp:TextBox>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT DISTINCT [nameOfCounterParty] FROM [ContractNameOfCounterParty]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="nameOfCounterPartyList" ErrorMessage="Please enter name of counterparty" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>


            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="counterpartyTb" ErrorMessage="Please enter name of counterparty" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>


            </td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Label ID="contractTermLbl" runat="server" Text="Contract Payment Term :"></asp:Label>
            </td>
            <td class="auto-style7">
                <asp:DropDownList ID="contractTermList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="contractTermList_SelectedIndexChanged">
                    <asp:ListItem>Nil</asp:ListItem>
                    <asp:ListItem>One Time Payment</asp:ListItem>
                    <asp:ListItem>Monthly</asp:ListItem>
                    <asp:ListItem>Yearly</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="contractTermList" ErrorMessage="Please select contract payment term" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>


            </td>
        </tr>

        <tr>
            <td class="auto-style6">
                <asp:Label ID="contractAmountLbl" runat="server" Text="Contract Amount :"></asp:Label>
            </td>
            <td class="auto-style7">
                <asp:TextBox ID="contractAmountTb" runat="server" TextMode="Number" ValidateRequestMode="Enabled" autocomplete="off"></asp:TextBox>
            </td>

        </tr>
        <tr>
            <td></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="contractAmountTb" ErrorMessage="Please enter contract amount" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>

            </td>

        </tr>
        <tr>
            <td></td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please enter only numbers" ControlToValidate="contractAmountTb" ValidationExpression="^\d+?$" Font-Bold="True" ForeColor="Red"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Label ID="contractDateLbl" runat="server" Text="Contract Date :"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="contractDateTB" runat="server" dataformatstring="{0:dd/MM/yyyy}" TextMode="Date"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="contractDateTB" ErrorMessage="Please enter contract date" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>


            </td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Label ID="startDateLbl" runat="server" Text="Contract Starting Date :"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="startDateTb" runat="server" dataformatstring="{0:dd/MM/yyyy}" TextMode="Date"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="startDateTb" ErrorMessage="Please enter contract start date" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>


            </td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Label ID="endDateLbl" runat="server" Text="Contract Ending Date :"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="endDateTb" runat="server" dataformatstring="{0:dd/MM/yyyy}" TextMode="Date"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="endDateTb" ErrorMessage="Please enter contract end date" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>


            </td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Label ID="durationLbl" runat="server" Text="Duration of Contract (in months) :"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="durationTb" runat="server" autocomplete="off" TextMode="Number"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="durationTb" ErrorMessage="Please enter duration of contract" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>


            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Please enter only numbers" ControlToValidate="durationTb" ValidationExpression="^\d+?$" Font-Bold="True" ForeColor="Red"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Label ID="automaticExtensionLbl" runat="server" Text="Automatic Extension :"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:DropDownList ID="automaticExtensionList" runat="server" OnSelectedIndexChanged="automaticExtensionList_SelectedIndexChanged">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="automaticExtensionList" ErrorMessage="Please select if contract is valid for automatic extension" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>


            </td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Label ID="conditionForExtensionLbl" runat="server" Text="Condition For Extension :"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="conditionForExtensionTb" runat="server" TextMode="MultiLine" ValidateRequestMode="Enabled" autocomplete="off" Height="120px" Width="370px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="conditionForExtensionTb" ErrorMessage="Please enter condition for extension" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>


            </td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Label ID="documentLocationLbl" runat="server" Text="Document Location :"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="documentLocationTb" runat="server" autocomplete="off"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="documentLocationTb" ErrorMessage="Please enter document location" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>


            </td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Label ID="signedByLbl" runat="server" Text="Signed By :"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="signedbyTb" runat="server" autocomplete="off"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="signedbyTb" ErrorMessage="Please enter name of signer" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>


            </td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Label ID="titleLbl" runat="server" Text="Job Title :"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="titleTb" runat="server" TextMode="SingleLine" ValidateRequestMode="Enabled" autocomplete="off"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="titleTb" ErrorMessage="Please enter job title of signer" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>


            </td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Label ID="personInChargeLbl" runat="server" Text="Person in Charge of Contract :"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="personInChargeTb" runat="server" autocomplete="off"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="personInChargeTb" ErrorMessage="Please enter person in charge of contract" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>


            </td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Label ID="formRefNoLbl" runat="server" Text="Form A Reference Number :"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="formRefNoTb" runat="server" autocomplete="off"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="formRefNoTb" ErrorMessage="Please enter form A reference number" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>


            </td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Label ID="decisionMakerLbl" runat="server" Text="Decision Maker Of Contract :"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:DropDownList ID="decisionMakerList" runat="server" DataSourceID="SqlDataSource1" DataTextField="ContractDecisionMakerName" DataValueField="ContractDecisionMakerName">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT DISTINCT [ContractDecisionMakerName] FROM [ContractDecisionMaker]"></asp:SqlDataSource>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="decisionMakerList" ErrorMessage="Please select the decision maker of contract" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>


            </td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Label ID="reviewedByLALbl" runat="server" Text="Reviewed by Legal Affairs Department :"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:DropDownList ID="reviewedByLADeptList" runat="server">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="reviewedByLADeptList" ErrorMessage="Please select if contract is reviewed by legal affairs department" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>


            </td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Label ID="remarksLbl" runat="server" Text="Remarks :"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="remarksTb" runat="server" TextMode="MultiLine" autocomplete="off" Height="120px" Width="370px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style6"></td>
            <td class="auto-style4">&nbsp;</td>
        </tr>
    </table>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>


    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbl_ContractID" runat="server" Visible="False"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbl_ContractParentID" runat="server" Visible="False"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnBack" runat="server" Text="Back to Contract Grid View" OnClick="btnBack_OnClick" CausesValidation="False" />
    &nbsp;&nbsp;&nbsp;
        
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnEdit" runat="server" Text="Update" OnClick="btnEdit_onClick" />
</asp:Content>
