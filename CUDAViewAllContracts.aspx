<%@ Page Title="" Language="C#" MasterPageFile="~/CUDAMasterPage.Master" AutoEventWireup="true" CodeBehind="CUDAViewAllContracts.aspx.cs" Inherits="JKTS_Contract_system.CUDAViewAllContracts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" type="text/css" href="css/custom.css">
    <style type="text/css">
        .auto-style1 {
            margin-left: 150px;
            margin-bottom: 100px;
            margin-top: 50px;
        }

        .auto-style2 {
            margin-left: 10px;
            width: 100px;
        }

        .auto-style3 {
            width: 58px;
        }

        .auto-style4 {
            height: 20px;
            width: 58px;
        }

        .auto-style5 {
            width: 136px;
        }

        .auto-style6 {
            height: 20px;
            width: 136px;
        }

        .auto-style8 {
            width: 200px;
            height: 40px;
        }

        .sidenav {
            width: 130px;
            position: fixed;
            z-index: 1;
            top: 20px;
            left: 10px;
            background: #eee;
            overflow-x: hidden;
            padding: 8px 0;
            float: right;
            clear: left;
        }

            .sidenav a:hover {
                color: #064579;
                float: right;
            }

        @media screen and (max-height: 450px) {
            .sidenav {
                padding-top: 15px;
            }

                .sidenav a {
                    font-size: 18px;
                }
        }

        .auto-style10 {
            width: 130px;
            position: fixed;
            z-index: 1;
            top: 137px;
            left: 817px;
            overflow-x: hidden;
            float: right;
            clear: left;
            padding-left: 0;
            padding-right: 0;
            padding-top: 15px;
            padding-bottom: 8px;
            background: #eee;
        }

        .auto-style11 {
            height: 40px;
        }

        .auto-style12 {
            height: 40px;
            text-align: center;
            width: 126px;
        }

        .auto-style13 {
            height: 40px;
            width: 126px;
        }

        .auto-style14 {
            height: 20px;
            width: 126px;
        }

        .auto-style15 {
            width: 126px;
        }

        .auto-style16 {
            height: 40px;
            width: 58px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>

        <asp:Label ID="lbl_Dept" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lbl_Email" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lbl_ContractParentID" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lbl_ContractID" runat="server" Text="Label" Visible="False"></asp:Label>
    </p>
    <table class="nav-justified">
        <tr>
            <td class="auto-style16">
                <asp:Label ID="Label3" runat="server" Text="Type :"></asp:Label></td>
            <td class="auto-style11">
                <asp:DropDownList ID="ddlcontractType" runat="server" DataSourceID="SqlDataSource2" DataValueField="contractTypeName" AutoPostBack="True" Width="120px" Font-Size="11px" AppendDataBoundItems="True" OnSelectedIndexChanged="ddlcontractType_SelectedIndexChanged" DataTextField="contractTypeName">
                    <asp:ListItem Value="" Text="" Enabled="false" />
                    <asp:ListItem Text="All" Value="%" />

                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT DISTINCT [contractTypeName] FROM [ContractSubType]"></asp:SqlDataSource>

            </td>
            <td class="auto-style16">
                <asp:Label ID="Label4" runat="server" Text="Sub Type :"></asp:Label>
            <td class="auto-style11">
                <asp:DropDownList ID="ddlcontractSubType" EnableViewState="false" AppendDataBoundItems="true" runat="server" AutoPostBack="True" Width="120px" Font-Size="11px" DataSourceID="SqlDataSource1" DataTextField="contractSubTypeName" DataValueField="contractSubTypeName" OnSelectedIndexChanged="ddlcontractSubType_SelectedIndexChanged">
                    <asp:ListItem Value="" Text="" Enabled="false" />
                    <asp:ListItem Text="All" Value="%" />
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Project %>" SelectCommand="SELECT [contractSubTypeName] FROM [ContractSubType] WHERE ([contractTypeName] = @contractTypeName)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlcontractType" Name="contractTypeName" PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>

        </tr>
        <tr>
            <td class="auto-style16">
                <asp:Label ID="Label2" runat="server" Text="Title :"></asp:Label></td>
            <td class="auto-style8">
                <asp:TextBox ID="titleTB" runat="server" CssClass="col-xs-offset-0"></asp:TextBox>
            </td>
            <td class="auto-style8">
                <asp:Button ID="searchBtn" runat="server" OnClick="searchBtn_Click" Text="Search" />

            </td>
            <td class="auto-style13"></td>
            <td class="auto-style11"></td>
        </tr>
        <tr>
            <td class="auto-style8">
                <asp:Button ID="createContract" runat="server" Text="Create New Contract" OnClick="createContract_Click" Width="150px" />

            </td>
            <td class="auto-style8">
                <asp:Button ID="viewAllContracts" runat="server" OnClick="viewAllContracts_Click" Text="View All Contracts" Width="150px" />

            </td>

            <td class="auto-style8">
                <asp:Button ID="exportToExcelbtn" runat="server" Text="Export To Excel" OnClick="exportToExcelbtn_Click" Width="150px" />
            </td>

            <td class="auto-style8">
                <asp:Button ID="contractHistoryBtn" runat="server" Text="Contract History" OnClick="contractHistoryBtn_Click" Width="150px" />
            </td>

        </tr>
        <tr>
            <td class="auto-style4"></td>
            <td class="auto-style6"></td>
            <td class="auto-style14"></td>
            <td class="auto-style2"></td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style15">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>

    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   
    <asp:GridView ID="contractGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="contractID" OnSelectedIndexChanged="contractGridView_SelectedIndexChanged" OnRowDeleting="contractGridView_RowDeleting" OnRowCommand="contractGridView_RowCommand" OnRowDataBound="contractGridView_RowDataBound" CssClass="GridView">

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
            <asp:CommandField ShowSelectButton="True" HeaderText="Details" SelectText="View" ItemStyle-ForeColor="#66FF66" />
            <asp:BoundField DataField="contractParentID" HeaderText="contractParentID" />
            <asp:BoundField DataField="contractRemainingDays" HeaderText="contractRemainingDays" />

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

</asp:Content>
