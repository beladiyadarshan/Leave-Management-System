<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucAdminHeaderMenu.ascx.cs" Inherits="Admin_Controls_ucHeaderMenu" %>
<table border="0" cellpadding="0" cellspacing="0" width="100%" align="center" >
<tr><td>
    <asp:Menu ID="Menu1" runat="server" BackColor="#B5C7DE" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="X-Small" ForeColor="#284E98" Orientation="Horizontal" StaticSubMenuIndent="10px" Width="100%" Font-Bold="True" StaticEnableDefaultPopOutImage="False">
        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <DynamicHoverStyle BackColor="#284E98" ForeColor="White" />
        <DynamicMenuStyle BackColor="#B5C7DE" />
        <StaticSelectedStyle BackColor="#507CD1" />
        <DynamicSelectedStyle BackColor="#507CD1" />
        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <Items>
            <asp:MenuItem Text="||" Value="||"></asp:MenuItem>
            <asp:MenuItem Text="Administration" Value="Administration">
                <asp:MenuItem Text="Change Password" Value="Change Password" NavigateUrl="../frmChangePassword.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Manage Department" Value="Manage Document Category" NavigateUrl="~/Admin/frmManageDept.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Manage Country" Value="Manage Country" NavigateUrl="../frmManageCountry.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Manage State" Value="Manage State" NavigateUrl="../frmManageState.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Manage City" Value="Manage City" NavigateUrl="~/Admin/frmManageCity.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Manage Status" Value="Manage Status" NavigateUrl="../frmManageStatus.aspx"></asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Admin/frmFindBalanceLeaves.aspx" Text="Manage Leave" Value="Manage Leave">
            </asp:MenuItem>
            <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Admin/frmManageEmployee.aspx" Text="Manage Employee"
                Value="Manage Employee"></asp:MenuItem>
            <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Admin/frmLeaveChecking.aspx" Text="Manage Leave Sanction"
                Value="Manage Leave Sanction"></asp:MenuItem>
            <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
            <asp:MenuItem Text="Reports" Value="Reports">
                <asp:MenuItem NavigateUrl="~/Admin/frmMonthlyLeaveTransactions.aspx" Text="Monthly Leave"
                    Value="Monthly Leave"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/Admin/frmYearlyLeaveTransactions.aspx" Text="Yearly Leave"
                    Value="Yearly Leave"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/Admin/frmPresentedEmpList.aspx" Text="PresentEmployeesList"
                    Value="PresentEmployeesList"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/Admin/frmNextDayEmpList.aspx" Text="NextdayEmployeesList"
                    Value="NextdayEmployeesList"></asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
            <asp:MenuItem Text="Logout" Value="Logout" NavigateUrl="~/Admin/frmSingOutSuccessFul.aspx"></asp:MenuItem>
            <asp:MenuItem Text="||" Value="||"></asp:MenuItem>
        </Items>
        <StaticHoverStyle BackColor="#284E98" ForeColor="White" />
    </asp:Menu>
</td></tr>
</table>
