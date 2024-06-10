<%@ Page Title="" Language="C#" MasterPageFile="~/CUDAMasterPage.Master" AutoEventWireup="true" CodeBehind="CUDACreateAccount.aspx.cs" Inherits="JKTS_Contract_system.CUDACreateAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <style type="text/css">
        .auto-style1 {
            height: 20px;
        }
        .auto-style3 {
            height: 20px;
            width: 124px;
        }
        .auto-style6 {
            height: 20px;
            width: 161px;
        }
        .auto-style7 {
            width: 124px
        }
        .auto-style11 {
            width: 161px
        }
        .auto-style15 {
            width: 124px;
            height: 35px;
            text-align: center;
        }
        .auto-style16 {
            width: 161px;
            height: 35px;
            text-align: center;
        }
        .auto-style17 {
            height: 35px;
        }
        .auto-style18 {
            width: 161px;
            text-align: center;
        }
        .auto-style19 {
            width: 124px;
            text-align: center;
        }
        .auto-style20 {
            height: 20px;
            width: 124px;
            text-align: center;
        }
         .auto-style21 {
             text-align: center;
             height: 40px;
         }
         .auto-style22 {
             height: 40px;
         }
         .auto-style23 {
             text-align: center;
             height: 38px;
         }
         .auto-style24 {
             height: 38px;
         }
      </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1> Create Account</h1>
    <p> </p>
    <table class="nav-justified">
        <tr>
            <td class="auto-style15">Name:</td>
            <td class="auto-style16">
                <asp:TextBox ID="tb_UserName" placeholder="Full Name" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style17">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tb_UserName" ErrorMessage="Please enter a name" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style15">Email:</td>
            <td class="auto-style16">
                <asp:TextBox ID="tb_Email" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style17">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tb_Email" ErrorMessage="Please enter email" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tb_Email" ErrorMessage="Invalid Email" Font-Bold="True" ForeColor="Red" ValidationExpression="(?:[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+)*|&quot;(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*&quot;)@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style15">Department</td>
            <td class="auto-style16">
                <asp:Label ID="lbl_Dept" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="auto-style17">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style15">Designation:</td>
            <td class="auto-style16">
                <asp:TextBox ID="tb_Designation" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style17">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tb_Designation" ErrorMessage="Please enter designation" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style15">User Type</td>
            <td class="auto-style16">
                <asp:DropDownList ID="ddl_UserType" runat="server">
                    <asp:ListItem>User</asp:ListItem>
                    <asp:ListItem>Admin</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style17">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddl_UserType" ErrorMessage="Please choose user type" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style15">&nbsp;</td>
            <td class="auto-style16">
                <asp:Label ID="lbl_Active" runat="server" Text="Yes" Visible="False"></asp:Label>
            </td>
            <td class="auto-style17"></td>
        </tr>
        <tr>
            <td class="auto-style21">
                &nbsp;</td>
            <td class="auto-style21">
                <asp:Label ID="lbl_Creation" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
            <td class="auto-style22"></td>
        </tr>
        <tr>
            <td class="auto-style23">
                &nbsp;</td>
            <td class="auto-style23">
                <asp:Label ID="lbl_CreatedBy" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
            <td class="auto-style24"></td>
        </tr>
        <tr>
            <td class="auto-style3">
                &nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style20">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
            <td class="auto-style6"></td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td class="auto-style19">
                <asp:Button ID="Btn_Back" runat="server"  Text="Back" OnClick="Btn_Back_Click1" CausesValidation="False" />
            </td>
            <td class="auto-style18">
                <asp:Button ID="Btn_Create" runat="server" Text="Create" OnClick="Btn_Create_Click1" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style11">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
