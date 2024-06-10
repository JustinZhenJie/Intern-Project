<%@ Page Title="" Language="C#" MasterPageFile="~/CUDAMasterPage.Master" AutoEventWireup="true" CodeBehind="CUDAEditAccount.aspx.cs" Inherits="JKTS_Contract_system.CUDAEditAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .auto-style1 {
            height: 20px;
        }
        .auto-style2 {
            height: 20px;
            width: 311px;
            text-align: center;
        }
        .auto-style3 {
            width: 311px;
        }
        .auto-style4 {
            height: 30px;
            width: 311px;
            text-align: center;
        }
        .auto-style5 {
            height: 30px;
        }
        .auto-style6 {
            width: 311px;
            text-align: center;
        }
        .auto-style9 {
            height: 30px;
            text-align: left;
            width: 194px;
        }
        .auto-style10 {
            text-align: left;
            width: 194px;
        }
        .auto-style11 {
            height: 20px;
            text-align: left;
            width: 194px;
        }
        .auto-style12 {
            width: 194px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <h1> Edit Account</h1>
    <p> &nbsp;</p>
    <table class="nav-justified">
        <tr>
            <td class="auto-style4">Name:</td>
            <td class="auto-style9">
                <asp:TextBox ID="tb_Name" placeholder="Full Name" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style5">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tb_Name" ErrorMessage="Please enter a name" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Email</td>
            <td class="auto-style9">
                <asp:TextBox ID="tb_Email" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style5">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tb_Email" ErrorMessage="Please enter email" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tb_Email" ErrorMessage="Invalid Email" Font-Bold="True" ForeColor="Red" ValidationExpression="(?:[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+)*|&quot;(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*&quot;)@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])"></asp:RegularExpressionValidator>
                </td>
        </tr>
        <tr>
            <td class="auto-style4">Department</td>
            <td class="auto-style9">
                <asp:DropDownList ID="ddl_dept" runat="server" DataSourceID="SqlDataSource1" DataTextField="User_Dept" DataValueField="User_Dept">
                    <asp:ListItem>IT</asp:ListItem>
                    <asp:ListItem>HR</asp:ListItem>
                    <asp:ListItem>Software</asp:ListItem>
                    <asp:ListItem>Electrical</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT DISTINCT [User_Dept] FROM [Dept]"></asp:SqlDataSource>
            </td>
            <td class="auto-style5">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddl_dept" ErrorMessage="Please choose a department" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Designation</td>
            <td class="auto-style9">
                <asp:TextBox ID="tb_Designation" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style5">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tb_Designation" ErrorMessage="Please enter designation " Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">User Type</td>
            <td class="auto-style9">
                <asp:DropDownList ID="ddl_UserType" runat="server" DataTextField="User_Type" DataValueField="User_Type">
                    <asp:ListItem>Admin</asp:ListItem>
                    <asp:ListItem>User</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style5">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddl_UserType" ErrorMessage="Please choose user type" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Active</td>
            <td class="auto-style9">
                <asp:DropDownList ID="ddl_Active" runat="server" DataSourceID="SqlDataSource2" DataTextField="User_Active" DataValueField="User_Active">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT DISTINCT [User_Active] FROM [Status]"></asp:SqlDataSource>
            </td>
            <td class="auto-style5">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddl_Active" ErrorMessage="Please choose user status" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style16"></td>
            <td class="auto-style17">
                <asp:Label ID="lbl_Updated" runat="server" Visible="False"></asp:Label>
            </td>
            <td class="auto-style18"></td>
        </tr>
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style1">
                <asp:Label ID="lbl_UpdatedBy" runat="server" Visible="False"></asp:Label>
            </td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="lbl_UserID" runat="server" Visible="False"></asp:Label>
            </td>
            <td class="auto-style11"></td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td class="auto-style2">
                &nbsp;</td>
            <td class="auto-style11">&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Button ID="btn_Back" runat="server" Text="Back" OnClick="btn_Back_Click" CausesValidation="False" />
            </td>
            <td class="auto-style10">
                &nbsp;&nbsp;<asp:Button ID="Btn_Update" runat="server" Text="Update" OnClick="Btn_Update_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style12">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <br />
</asp:Content>
