<%@ Page Title="" Language="C#" MasterPageFile="~/CUDAMasterPage.Master" AutoEventWireup="true" CodeBehind="CUDAChangePassword.aspx.cs" Inherits="JKTS_Contract_system.CUDAChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <style type="text/css">
        .auto-style1 {
            width: 250px;
            text-align: right;
        }
        .auto-style2 {
            width: 250px;
            height: 40px;
            text-align: center;
        }
        .auto-style3 {
            height: 40px;
            text-align: left;
        }
        .auto-style4 {
            width: 250px;
            height: 41px;
            text-align: center;
        }
        .auto-style5 {
            height: 41px;
            text-align: left;
        }
        .auto-style6 {
            height: 40px;
            width: 156px;
        }
        .auto-style7 {
            height: 41px;
            width: 156px;
        }
        .auto-style8 {
            width: 156px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <h1> Change Password</h1>
    <p> 
        <asp:Label ID="lbl_Email" runat="server" Visible="False"></asp:Label>
    </p>
    <table class="nav-justified">
        <tr>
            <td class="auto-style2">Current Password:</td>
            <td class="auto-style6">
                <asp:TextBox ID="tb_CurPass" type ="password" runat="server"></asp:TextBox>
            &nbsp;</td>
            <td class="auto-style3">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tb_CurPass" ErrorMessage="!!" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">New Password:</td>
            <td class="auto-style7">
                <asp:TextBox ID="tb_NewPass" type ="password" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style5">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tb_NewPass" ErrorMessage="!!" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Confirm New Password:</td>
            <td class="auto-style6">
                <asp:TextBox ID="tb_ConPass" type ="password" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style3">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tb_ConPass" ErrorMessage="!!" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="tb_NewPass" ControlToValidate="tb_ConPass" ErrorMessage="Password not same !!" ForeColor="Red"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
            <td class="text-left">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style8">
                <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click" />
            </td>
            <td class="text-left">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                &nbsp;</td>
            <td class="auto-style8">
                <asp:Label ID="lbl_Msg" runat="server"></asp:Label>
            </td>
            <td class="text-left">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
