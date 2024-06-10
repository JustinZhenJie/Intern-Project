<%@ Page Title="" Language="C#" MasterPageFile="~/CUDAMasterPage.Master" AutoEventWireup="true" CodeBehind="CUDAExport.aspx.cs" Inherits="JKTS_Contract_system.CUDAExport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <h1> User Management</h1>
    <div class="auto-style10">
    </div>
    <p> 
      <asp:Label ID="lbl_Dept" runat="server"></asp:Label>
     </p>
        <div class="text-center">
        <asp:GridView ID="gv_User" runat="server" AutoGenerateColumns="False" DataKeyNames="User_ID" Height="223px" Width="793px" OnRowDataBound="gv_User_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="No.">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                    <asp:Label ID ="Label" runat ="server"></asp:Label>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="User_ID" HeaderText="ID"  />
                <asp:BoundField DataField="User_Name" HeaderText="Name" />
                <asp:BoundField DataField="User_Email" HeaderText="Email" />
                <asp:BoundField DataField="User_Dept" HeaderText="Department" />
                <asp:BoundField DataField="User_Designation" HeaderText="Designation" />
                <asp:BoundField DataField="User_Type" HeaderText="Type" />
                <asp:BoundField DataField="User_Active" HeaderText="Active" />
            </Columns>
        </asp:GridView>
     </div>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="Btn_Back" runat="server" OnClick="Btn_Back_Click1" Text="Back" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
    <p> 
        </p>
    <p> 
        &nbsp;</p>
    <table class="auto-style1">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
