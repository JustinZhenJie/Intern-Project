<%@ Page Title="" Language="C#" MasterPageFile="~/CUMasterPage.Master" AutoEventWireup="true" CodeBehind="CUContractHistory.aspx.cs" Inherits="JKTS_Contract_system.CUContractHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="contractHistoryGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="contractID" OnRowDeleting="contractHistoryGridView_RowDeleting" OnRowCommand="contractHistoryGridView_RowCommand" OnSelectedIndexChanged="contractHistoryGridView_SelectedIndexChanged" OnRowDataBound="contractHistoryGridView_RowDataBound">

        <Columns>
            <asp:BoundField DataField="contractID" HeaderText="contractID" />
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
            <asp:BoundField DataField="contractAmount" HeaderText="Amount" DataFormatString="${0:#,0}" />
            <asp:BoundField DataField="contractStartDate" HeaderText="Starting Date" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="contractEndDate" HeaderText="Ending Date" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="contractStatus" HeaderText="Status" />
            <asp:CommandField ShowSelectButton="True" HeaderText="Details" SelectText="View" ItemStyle-ForeColor="#66FF66" />
            <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("contractID") %>' CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete?');" Text="Delete" />
                </ItemTemplate>
            </asp:TemplateField>
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
    <asp:Button ID="backBtn" runat="server" Text="Back" OnClick="backBtn_Click" />

</asp:Content>
