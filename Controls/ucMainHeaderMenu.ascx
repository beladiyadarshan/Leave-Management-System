<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucMainHeaderMenu.ascx.cs" Inherits="Admin_Controls_ucHeaderMenu" %>
<table border="0" cellpadding="0" cellspacing="0" width="100%" align="center" >
<tr style="text-align:center"><td >
    <asp:Menu ID="Menu1" runat="server" BackColor="#B5C7DE" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="11pt" ForeColor="#284E98" Orientation="Horizontal" StaticSubMenuIndent="10px" Width="100%" Font-Bold="True">
        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <DynamicHoverStyle BackColor="#284E98" ForeColor="White" />
        <DynamicMenuStyle BackColor="#B5C7DE" />
        <StaticSelectedStyle BackColor="#507CD1" />
        <DynamicSelectedStyle BackColor="#507CD1" />
        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <Items>
            <asp:MenuItem Text="||" Value="||"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Admin/Default.aspx" Text="$Admin$" Value="Manage Leave">
            </asp:MenuItem>
            
            <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Employee/frmEmployeeLogin.aspx" Text="Employee"
                Value="Manage Employee"></asp:MenuItem>
            
            
          
            <asp:MenuItem Text="||" Value="||"></asp:MenuItem>
        </Items>
        <StaticHoverStyle BackColor="#284E98" ForeColor="White" />
    </asp:Menu>
</td></tr>
</table>
