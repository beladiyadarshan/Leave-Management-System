<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmployeeWebUserControl.ascx.cs" Inherits="Employee_EmployeeWebUserControl" %>
<table border="0" cellpadding="0" cellspacing="0" width="100%" align="center" >
<tr><td>
    <asp:Menu ID="Menu1" runat="server" BackColor="#B5C7DE" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="11pt" ForeColor="#284E98" Orientation="Horizontal" StaticSubMenuIndent="10px" Width="100%" Font-Bold="True">
        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <DynamicHoverStyle BackColor="#284E98" ForeColor="White" />
        <DynamicMenuStyle BackColor="#B5C7DE" />
        <StaticSelectedStyle BackColor="#507CD1" />
        <DynamicSelectedStyle BackColor="#507CD1" />
        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <Items>
            <asp:MenuItem NavigateUrl="~/Employee/frmEmpChangePassword.aspx" Text="Chage PassWord"
                Value="Chage PassWord"></asp:MenuItem>
            <asp:MenuItem Text="Check Details" Value="Manage User">
                <asp:MenuItem Text="Check Own Details" Value="Check Own Details" NavigateUrl="~/Employee/frmUpdateEmployeeDetails.aspx"></asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Employee/frmLeaveApplication.aspx" Text="Leave Application"
                Value="Leave Application"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Employee/frmApllicationStatus.aspx" Text="Application Status"
                Value="Application Status"></asp:MenuItem>
            <asp:MenuItem Text="Logout" Value="Logout" NavigateUrl="~/Employee/frmEmployeeLogOutSuccessful.aspx"></asp:MenuItem>
        </Items>
        <StaticHoverStyle BackColor="#284E98" ForeColor="White" />
    </asp:Menu>
</td></tr>
</table>