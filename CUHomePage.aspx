<%@ Page Title="" Language="C#" MasterPageFile="~/CUMasterPage.Master" AutoEventWireup="true" CodeBehind="CUHomePage.aspx.cs" Inherits="JKTS_Contract_system.CUHomePage" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Welcome
        <asp:Label ID="lbl_UserName" runat="server" Text="Label"></asp:Label></h1>
    <p>&nbsp;</p>
    <p>
        <asp:Label ID="lbl_Dept" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="lbl_Email" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="departmentlbl" runat="server" Text="Department :"></asp:Label>
        <asp:DropDownList ID="ddlDepartment" runat="server" DataSourceID="SqlDataSource1" DataTextField="User_Dept" DataValueField="User_Dept" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AppendDataBoundItems="true" AutoPostBack="true">
            <asp:ListItem Value="" Text="" Enabled="false" />
            <asp:ListItem Text="All" Value="%" />
        </asp:DropDownList>
        <asp:Label ID="statuslbl" runat="server" Text="Status"></asp:Label>
        <asp:DropDownList ID="ddlStatus" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AppendDataBoundItems="true" AutoPostBack="true">
            <asp:ListItem Value="" Text="" Enabled="false" />
            <asp:ListItem>All</asp:ListItem>
            <asp:ListItem>Active</asp:ListItem>
            <asp:ListItem>Expiring</asp:ListItem>
            <asp:ListItem>Expired</asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT DISTINCT [User_Dept] FROM [Dept]"></asp:SqlDataSource>
    </p>
    <asp:Chart ID="Chart1" runat="server" Palette="EarthTones" Height="700px" Width="1000px">
        <Series>
            <asp:Series Name="Series1" ChartType="Bar" XValueMember="contractTitle" YValueMembers="contractRemainingDays" Color="Green">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartActive">
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
</asp:Content>
