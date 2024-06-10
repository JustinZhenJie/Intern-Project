<%@ Page Title="" Language="C#" MasterPageFile="~/CUDAMasterPage.Master" AutoEventWireup="true" CodeBehind="CUDATerminateReason.aspx.cs" Inherits="JKTS_Contract_system.scripts.CUDATerminateReason" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1 {
            width: 100px;
        }

        .style2 {
            margin-top: 20px;
            margin-left: 300px;
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="nav-justified">
        <tr>
            <td class="auto-style6">
                <asp:Label ID="terminationReasonLbl" runat="server" Text="Reason for Contract Termination :"></asp:Label>

            </td>
            <td class="auto-style4">
                <asp:TextBox ID="terminationTB" runat="server" Height="123px" Width="303px" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="terminationTB" Font-Bold="True" ForeColor="Red" ErrorMessage="Please enter reason for termination"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <asp:Button ID="backBtn" runat="server" Text="Back to Contract Grid View" OnClick="backBtn_Click" CausesValidation="False" />
    <asp:Button ID="confirmBtn" runat="server" Text="Confirm" OnClick="confirmBtn_Click" />
    <asp:Label ID="lbl_ContractID" runat="server" Text="Label" Visible="False"></asp:Label>
</asp:Content>
