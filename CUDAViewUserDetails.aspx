<%@ Page Title="" Language="C#" MasterPageFile="~/CUDAMasterPage.Master" AutoEventWireup="true" CodeBehind="CUDAViewUserDetails.aspx.cs" Inherits="JKTS_Contract_system.CUDAViewUserDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link rel="stylesheet" type="text/css" href="css/custom.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1> User Details</h1>
    <p> 
        <asp:Label ID="lbl_UserID" runat="server" Visible="False"></asp:Label>
    </p>
    <p class="text-center"> 
        <asp:DetailsView ID="DetailsView1" runat="server" CssClass="DetailsView" AutoGenerateRows="False" DataKeyNames="User_ID">
            <Fields>
                <asp:BoundField DataField="User_ID" HeaderText="User ID" >
                <HeaderStyle Font-Bold="true" />
                </asp:BoundField >
                <asp:BoundField DataField="User_Name" HeaderText="Name" >
                <HeaderStyle Font-Bold="true" />
                </asp:BoundField >
                <asp:BoundField DataField="User_Email" HeaderText="Email" >
                <HeaderStyle Font-Bold="true" />
                </asp:BoundField >
                <asp:BoundField DataField="User_Dept" HeaderText="Department" >
                <HeaderStyle Font-Bold="true" />
                </asp:BoundField >
                <asp:BoundField DataField="User_Designation" HeaderText="Designation" >
                <HeaderStyle Font-Bold="true" />
                </asp:BoundField >
                <asp:BoundField DataField="User_Type" HeaderText="User Type" >
                <HeaderStyle Font-Bold="true" />
                </asp:BoundField >
                <asp:BoundField DataField="User_Active" HeaderText="Active" >
                <HeaderStyle Font-Bold="true" />
                </asp:BoundField >
                <asp:BoundField DataField="User_Creation" HeaderText="Date Created">
                <HeaderStyle Font-Bold="true" />
                </asp:BoundField>
                <asp:BoundField DataField="User_CreatedBy" HeaderText="Created By" >
                <HeaderStyle Font-Bold="true" />
                </asp:BoundField>
                <asp:BoundField DataField="User_Updated" HeaderText="Latest Update" >
                <HeaderStyle Font-Bold="true" />
                </asp:BoundField>
                <asp:BoundField DataField="User_UpdatedBy" HeaderText="Updated By" >
                <HeaderStyle Font-Bold="true" />
                </asp:BoundField>
            </Fields>

            <FooterStyle BackColor="White" ForeColor="#333333" />
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" Font-Size ="120%" />
            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:DetailsView>
    </p>
    <p> &nbsp;</p>
    <asp:Button ID="Btn_Back" runat="server" OnClick="Btn_Back_Click" Text="Back" Height="32px" Width="57px" />
  
</asp:Content>
