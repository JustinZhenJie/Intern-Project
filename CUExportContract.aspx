<%@ Page Title="" Language="C#" MasterPageFile="~/CUMasterpage.Master" AutoEventWireup="true" CodeBehind="CUExportContract.aspx.cs" Inherits="JKTS_Contract_system.CUExportContract" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="contractGridView" runat="server" Height="450px" Width="950px" AutoGenerateColumns="False" CssClass="auto-style1" DataKeyNames="contractID">

        <Columns>
            <asp:BoundField DataField="contractID" HeaderText="contractID"></asp:BoundField>
            <asp:BoundField DataField="contractDepartment" HeaderText="Department" />
            <asp:BoundField DataField="contractType" HeaderText="Type" />
            <asp:BoundField DataField="contractSubType" HeaderText="SubType" />
            <asp:BoundField DataField="contractTitle" HeaderText="Title" />
            <asp:BoundField DataField="contractExplaination" HeaderText="Explaination" />
            <asp:BoundField DataField="contractNameOfCounterparty" HeaderText="Name of Counterparty" />
            <asp:BoundField DataField="contractTerm" HeaderText="Transactional Term" />
            <asp:BoundField DataField="contractAmount" HeaderText="Transactional Amount" DataFormatString="${0:#,0}" />
            <asp:BoundField DataField="contractDate" HeaderText="Date" />
            <asp:BoundField DataField="contractStartDate" HeaderText="Starting Date" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="contractEndDate" HeaderText="Ending Date " DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="contractDuration" HeaderText="Duration" />
            <asp:BoundField DataField="contractAutomaticExtension" HeaderText="Automatic Extension" />
            <asp:BoundField DataField="contractConditionForAutomaticExtension" HeaderText="Condition for Automatic Extension" />
            <asp:BoundField DataField="contractDocumentLocation" HeaderText="Document Location" />
            <asp:BoundField DataField="contractSignedBy" HeaderText="Signed By" />
            <asp:BoundField DataField="contractTitleOfSigner" HeaderText="Title of Signer" />
            <asp:BoundField DataField="contractPersonInCharge" HeaderText="Person In Charge" />
            <asp:BoundField DataField="contractRefNo" HeaderText="Form A Reference No" />
            <asp:BoundField DataField="contractDecisionMaker" HeaderText="Decision Maker" />
            <asp:BoundField DataField="contractReviewedByLADept" HeaderText="Reviewed By Legal Affaris Department" />
            <asp:BoundField DataField="contractRemarks" HeaderText="Remarks" />
            <asp:BoundField DataField="contractStatus" HeaderText="Status" />
            <asp:BoundField DataField="contractRemainingDays" HeaderText="contractRemainingDays" />
            <asp:BoundField DataField="contractCreatedBy" HeaderText="Created By" />
        </Columns>
    </asp:GridView>
</asp:Content>
