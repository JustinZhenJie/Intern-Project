<%@ Page Title="" Language="C#" MasterPageFile="~/CUDAMasterPage.Master" AutoEventWireup="true" CodeBehind="CUDAViewUser.aspx.cs" Inherits="JKTS_Contract_system.CUDAViewUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" type="text/css" href="css/custom.css">
     <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
         .auto-style2 {
             width: 19px;
         }
         .auto-style3 {
             width: 120px;
         }
         .auto-style4 {
             width: 19px;
             height: 40px;
         }
         .auto-style5 {
             width: 120px;
             height: 40px;
         }
         .auto-style6 {
             height: 40px;
         }
         </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1> User Management</h1>

    <table class="nav-justified">
        <tr>
            <td class="auto-style4">Name:&nbsp; </td>
            <td class="auto-style5">
                <asp:TextBox ID="tb_Name" autocomplete="off" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style6">
                &nbsp;
                <asp:Button ID="btn_Search" runat="server" Text="Search" OnClick="btn_Search_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Active:</td>
            <td class="auto-style5">
                <asp:DropDownList ID="ddl_Active" runat="server" DataSourceID="User_Active" DataValueField="User_Active" AppendDataBoundItems="true" AutoPostBack="True" OnSelectedIndexChanged="ddl_Active_SelectedIndexChanged">
                 <asp:ListItem Text="All" Value="%" />
                </asp:DropDownList>
            </td>
            <td class="auto-style6">
            </td>
        </tr>
        <tr>
            <td class="auto-style2"></td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style25">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">
                <asp:Button ID="btn_Create" runat="server" CssClass="auto-style19" OnClick="btn_Create_Click" Text="Create Account" />
            </td>
            <td class="auto-style25">
                <asp:Button ID="btn_Export" runat="server" OnClick="btn_Export_Click" Text="Export to Excel" />
                </td>
        </tr>
        </table>
      <asp:Label ID="lbl_Dept" runat="server" Visible="False"></asp:Label>
    <p> 
        &nbsp;</p>
        <asp:GridView ID="gv_User" runat="server" CssClass="GridView" AutoGenerateColumns="False" DataKeyNames="User_ID" Rowstyle-Height="70px" OnRowCommand="gv_User_RowCommand" OnSelectedIndexChanged="gv_User_SelectedIndexChanged" OnRowEditing="gv_User_RowEditing" OnRowDeleting="gv_User_RowDeleting" OnRowUpdated="gv_User_RowUpdated" OnRowDataBound="gv_User_RowDataBound"  >
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
                <asp:BoundField DataField="User_Creation" HeaderText="Date Created" />
                <asp:BoundField DataField="User_CreatedBy" HeaderText="Created By" />
                <asp:BoundField DataField="User_Updated" HeaderText="Latest Update" />
                <asp:BoundField DataField="User_UpdatedBy" HeaderText="Updated By" />
                <asp:TemplateField HeaderText="View more">
                    <ItemTemplate>
                        <asp:Button ID="btn_Select" runat="server" CommandArgument='<%# Eval("User_ID")%>' CommandName="Select" Text="Select" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Update">
                    <ItemTemplate>
                        <asp:Button ID="Btn_Update" runat="server" CommandArgument='<%# Eval("User_ID")%>' CommandName="Edit" Text="Edit" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
        <ItemTemplate>
                <asp:Button ID="Btn_Delete" runat="server" CommandName="Delete" Text="Delete"
                        OnClientClick="return confirm('Are you sure you want to delete?');" />
        </ItemTemplate>
</asp:TemplateField>
           
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#333333" />
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" Font-Size ="120%" />
            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" HorizontalAlign="Center" VerticalAlign="Middle" />
            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />
        </asp:GridView>
    <p>
    </p>
    <p> 
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Back To View All User" Visible="False" CssClass="center"/>
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
         <asp:SqlDataSource ID="User_Active" runat="server" ConnectionString="<%$ConnectionStrings:Project %>" SelectCommand="Select Distinct User_Active from [User]"></asp:SqlDataSource>
</asp:Content>
