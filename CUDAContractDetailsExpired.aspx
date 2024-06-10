<%@ Page Title="" Language="C#" MasterPageFile="~/CUDAMasterPage.Master" AutoEventWireup="true" CodeBehind="CUDAContractDetailsExpired.aspx.cs" Inherits="JKTS_Contract_system.CUDAContractDetailsExpired" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" type="text/css" href="css/custom.css">
    <style type="text/css">
        .auto-style1 {
            margin-left: 150px;
            margin-bottom: 100px;
            margin-top: 50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Contract Details</h1>
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="contractID" OnDataBound="DetailsView1_DataBound" CssClass="DetailsView">
        <Fields>
            <asp:BoundField DataField="contractTitle" HeaderText="Title Of Contract">
                <HeaderStyle Font-Bold="true" />
            </asp:BoundField>
            <asp:BoundField DataField="contractDepartment" HeaderText="Contract Department">
                <HeaderStyle Font-Bold="true" />
            </asp:BoundField>
            <asp:BoundField DataField="contractType" HeaderText="Contract Type">
                <HeaderStyle Font-Bold="true" />
            </asp:BoundField>
            <asp:BoundField DataField="contractSubType" HeaderText="Contract Sub Type">
                <HeaderStyle Font-Bold="true" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Contract Explaination">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" Text='<%# Bind("contractExplaination") %>' ReadOnly="True" Enabled="False"></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle Font-Bold="True" />
            </asp:TemplateField>
            <asp:BoundField DataField="contractNameOfCounterparty" HeaderText="Name of Counterparty">
                <HeaderStyle Font-Bold="true" />
            </asp:BoundField>
            <asp:BoundField DataField="contractAmount" HeaderText="Contract Amount per Transactional Term" DataFormatString="${0:#,0}">
                <HeaderStyle Font-Bold="true" />
            </asp:BoundField>
            <asp:BoundField DataField="contractTerm" HeaderText="Transactional Term">
                <HeaderStyle Font-Bold="true" />
            </asp:BoundField>
            <asp:BoundField DataField="contractDate" HeaderText="Contract Date (dd/MM/yyyy)" DataFormatString="{0:dd/MM/yyyy}">
                <HeaderStyle Font-Bold="true" />
            </asp:BoundField>
            <asp:BoundField DataField="contractStartDate" HeaderText="Starting Date (dd/MM/yyyy)" DataFormatString="{0:dd/MM/yyyy}">
                <HeaderStyle Font-Bold="true" />
            </asp:BoundField>
            <asp:BoundField DataField="contractEndDate" HeaderText="Ending Date (dd/MM/yyyy)" DataFormatString="{0:dd/MM/yyyy}">
                <HeaderStyle Font-Bold="true" />
            </asp:BoundField>
            <asp:BoundField DataField="contractDuration" HeaderText="Duration of Contract (in months)">
                <HeaderStyle Font-Bold="true" />
            </asp:BoundField>
            <asp:BoundField DataField="contractAutomaticExtension" HeaderText="Automatic Extension">
                <HeaderStyle Font-Bold="true" />
            </asp:BoundField>
            <asp:BoundField DataField="contractConditionForAutomaticExtension" HeaderText="Condition for Automatic Extension">
                <HeaderStyle Font-Bold="true" />
            </asp:BoundField>
            <asp:BoundField DataField="contractDocumentLocation" HeaderText="Document Location">
                <HeaderStyle Font-Bold="true" />
            </asp:BoundField>
            <asp:BoundField DataField="contractSignedBy" HeaderText="Signed By">
                <HeaderStyle Font-Bold="true" />
            </asp:BoundField>
            <asp:BoundField DataField="contractTitleOfSigner" HeaderText="Title Of Signer">
                <HeaderStyle Font-Bold="true" />
            </asp:BoundField>
            <asp:BoundField DataField="contractPersonInCharge" HeaderText="Person In Charge">
                <HeaderStyle Font-Bold="true" />
            </asp:BoundField>
            <asp:BoundField DataField="contractRefNo" HeaderText="Form A Reference Number">
                <HeaderStyle Font-Bold="true" />
            </asp:BoundField>
            <asp:BoundField HeaderText="Decision Maker" DataField="contractDecisionMaker">
                <HeaderStyle Font-Bold="true" />
            </asp:BoundField>
            <asp:BoundField DataField="contractReviewedByLADept" HeaderText="Reviewed by Legal Affaris Department">
                <HeaderStyle Font-Bold="true" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Remarks">

                <ItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" Text='<%# Bind("contractRemarks") %>' Wrap="true" ReadOnly="True" Enabled="False"></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle Font-Bold="True" />
                <ItemStyle Wrap="True" />
            </asp:TemplateField>
            <asp:BoundField DataField="contractStatus" HeaderText="Status">
                <HeaderStyle Font-Bold="true" />
            </asp:BoundField>
            <asp:BoundField DataField="contractParentID" HeaderText="parentid">
                <HeaderStyle Font-Bold="true" />
            </asp:BoundField>
        </Fields>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" Font-Size="120%" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#333333" HorizontalAlign="Center" VerticalAlign="Middle" />

    </asp:DetailsView>
    <asp:Button ID="backBtn" runat="server" Text="Back" OnClick="backBtn_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="renewBtn" runat="server" OnClick="renewBtn_Click" Text="Renew and keep current contract" />
    <asp:Button ID="closeBtn" runat="server" OnClick="closeBtn_Click" Text="Close and keep current contract" OnClientClick="return confirm('Are you sure you want to delete?');" />
    <p></p>
    <asp:Label ID="lbl_ContractID" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lbl_ContractParentID" runat="server" Visible="true"></asp:Label>

    <asp:GridView ID="contractGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="contractID" OnSelectedIndexChanged="contractGridView_SelectedIndexChanged" OnRowDataBound="contractGridView_RowDataBound" CssClass="GridView">

        <Columns>
            <asp:BoundField DataField="contractID" HeaderText="contractID"></asp:BoundField>
            <asp:TemplateField HeaderText="ID">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="contractTitle" HeaderText="Title" />
            <asp:BoundField DataField="contractDepartment" HeaderText="Department" />
            <asp:BoundField DataField="contractType" HeaderText="Type" />
            <asp:BoundField DataField="contractSubType" HeaderText="Sub-Type" />
            <asp:BoundField DataField="contractTerm" HeaderText="Contract Payment Term" />
            <asp:BoundField DataField="contractAmount" HeaderText="Transactional Amount" DataFormatString="${0:#,0}" />
            <asp:BoundField DataField="contractStartDate" HeaderText="Starting Date (dd/MM/yyyy)" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="contractEndDate" HeaderText="Ending Date (dd/MM/yyyy)" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="contractStatus" HeaderText="Status" />
            <asp:CommandField ShowSelectButton="True" HeaderText="Details" SelectText="View" ItemStyle-ForeColor="#66FF66" />
            <asp:BoundField DataField="contractParentID" HeaderText="contractParentID" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#333333" HorizontalAlign="Center" VerticalAlign="Middle" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#487575" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#275353" />
    </asp:GridView>
</asp:Content>
