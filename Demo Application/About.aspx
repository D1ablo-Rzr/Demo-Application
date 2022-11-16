<%@ Page Title="Place Order" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Demo_Application.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <table class="nav-justified" style="height: 170px">
        <tr>
            <td style="width: 255px; height: 32px">Select Product</td>
            <td style="height: 32px; width: 410px;">
    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="ProductName" DataValueField="ProductID" Height="20px" Width="100px">
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>" SelectCommand="SELECT [ProductName], [ProductID] FROM [Products]"></asp:SqlDataSource>
            </td>
            <td style="height: 32px"></td>
            <td style="height: 32px"></td>
        </tr>
        <tr>
            <td style="width: 255px">Enter Quantity</td>
            <td style="width: 410px">
                <asp:TextBox ID="TextBox1" runat="server" Width="100px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 255px; height: 20px">Enter Customer ID</td>
            <td style="height: 20px; width: 410px;">
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 255px; height: 20px">Enter Employee ID</td>
            <td style="height: 20px; width: 410px;">
                <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource3" DataTextField="EmployeeID" DataValueField="EmployeeID" Width="100px">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>" SelectCommand="SELECT [EmployeeID] FROM [Employees]"></asp:SqlDataSource>
            </td>
            <td style="height: 20px"></td>
            <td style="height: 20px"></td>
        </tr>
        <tr>
            <td style="width: 255px">&nbsp;</td>
            <td style="width: 410px">&nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Place Order" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
