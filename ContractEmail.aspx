<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContractEmail.aspx.cs" Inherits="JKTS_Contract_system.ContractEmail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>

                <asp:Label ID="lbl_Dept" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="lbl_Email" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="lbl_ContractParentID" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="lbl_ContractID" runat="server" Text="Label" Visible="False"></asp:Label>
            </p>

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   

    <asp:GridView ID="contractGridView" runat="server" Height="47px" Width="169px" AutoGenerateColumns="False" DataKeyNames="contractID" OnRowDataBound="contractGridView_RowDataBound">

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
            <asp:CommandField ShowSelectButton="True" HeaderText="Details" SelectText="View" />
            <asp:BoundField DataField="contractParentID" HeaderText="contractParentID" />
            <asp:BoundField DataField="contractRemainingDays" HeaderText="contractRemainingDays" />

        </Columns>

        <FooterStyle BackColor="White" ForeColor="#333333" Height="100px" Width="100px" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" Height="35px" Width="100px" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#333333" HorizontalAlign="Center" VerticalAlign="Middle" Height="50px" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#487575" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#275353" />
    </asp:GridView>

            <table>
                <tr>
                    <td>
                        <asp:GridView ID="EmailDeptHead" runat="server" Height="47px" Width="169px" AutoGenerateColumns="False" DataKeyNames="User_Name" OnRowDataBound="EmailDeptHead_RowDataBound">

                            <Columns>
                                <asp:BoundField DataField="User_Email" HeaderText="email"></asp:BoundField>
                                <asp:BoundField DataField="contractTitle" HeaderText="contractTitle"></asp:BoundField>
                                <asp:BoundField DataField="User_Name" HeaderText="name" />
                                <asp:BoundField DataField="contractCreatedBy" HeaderText="Creator" />
                                <asp:BoundField DataField="contractStartDate" HeaderText="Starting Date (dd/mm/yyyy)" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField DataField="contractEndDate" HeaderText="Ending Date (dd/mm/yyyy)" DataFormatString="{0:dd/MM/yyyy}" />

                                <asp:BoundField DataField="contractRemainingDays" HeaderText="contractRemainingDays" />
                                <asp:BoundField DataField="contractNameOfCounterparty" HeaderText="contractNameOfCounterparty" />
                                <asp:BoundField DataField="contractStatus" HeaderText="contractStatus" />


                            </Columns>
                        </asp:GridView>
                    </td>
                    <td>
                        <asp:GridView ID="EmailDeptGM" runat="server" Height="47px" Width="169px" AutoGenerateColumns="False" DataKeyNames="User_Name" OnRowDataBound="EmailDeptGM_RowDataBound">

                            <Columns>
                                <asp:BoundField DataField="User_Email" HeaderText="email"></asp:BoundField>
                                <asp:BoundField DataField="contractTitle" HeaderText="contractTitle"></asp:BoundField>
                                <asp:BoundField DataField="User_Name" HeaderText="name" />
                                <asp:BoundField DataField="contractCreatedBy" HeaderText="Creator" />
                                <asp:BoundField DataField="contractStartDate" HeaderText="Starting Date (dd/mm/yyyy)" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField DataField="contractEndDate" HeaderText="Ending Date (dd/mm/yyyy)" DataFormatString="{0:dd/MM/yyyy}" />

                                <asp:BoundField DataField="contractRemainingDays" HeaderText="contractRemainingDays" />
                                <asp:BoundField DataField="contractNameOfCounterparty" HeaderText="contractNameOfCounterparty" />
                                <asp:BoundField DataField="contractStatus" HeaderText="contractStatus" />

                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>

            </table>
            <asp:GridView ID="remainingDaysGridView" runat="server" Height="47px" Width="169px" AutoGenerateColumns="False" CssClass="auto-style1" DataKeyNames="contractID" OnRowDataBound="remainingDaysGridView_RowDataBound">

                <Columns>
                    <asp:BoundField DataField="contractID" HeaderText="contractID"></asp:BoundField>
                    <asp:BoundField DataField="contractRemainingDays" HeaderText="contractRemainingDays" />

                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
