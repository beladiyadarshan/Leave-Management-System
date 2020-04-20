<%@ Page Language="C#" MasterPageFile="~/Employee/SimpleEmployeeMasterPage.master" AutoEventWireup="true" CodeFile="frmEmployeeLogin.aspx.cs" Inherits="Employee_frmEmployeeLogin" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" style="height:300Px"><tr><td valign="middle" align="center">
<table bgcolor="#939393" style="width: 32%">

<tr>
                        <td colspan="3" class="LoginTitle">
                            Employee Login
                        </td>
                    </tr>
<tr>
<td colspan="3" align="center">
    <asp:Label ID="lblError" runat="server" Text="Invalid LoginId and Password" CssClass="lblerror"  Visible="false"></asp:Label>
</td>
</tr>
<tr>
<td align="left">
    <b>Login ID</b></td>
<td><b>:</b></td>
<td align="left">
    <asp:TextBox ID="txtLoginId" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLoginId"
        ErrorMessage="*"></asp:RequiredFieldValidator></td>
</tr>
<tr>
<td align="left"><b>Password</b></td>
<td><b>:</b></td>
<td align="left">
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="148px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
        ErrorMessage="*"></asp:RequiredFieldValidator></td>
</tr>
<tr>
<td></td>
<td></td>
<td></td>
</tr>
    <tr>
        <td style="height: 26px">
        </td>
        <td style="height: 26px">
            
        </td>
        <td align="left" style="height: 26px"><asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="btnstyle" />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Back" CssClass="btnstyle" CausesValidation="False" /></td>
    </tr>

</table>
</td></tr></table>
</asp:Content>

