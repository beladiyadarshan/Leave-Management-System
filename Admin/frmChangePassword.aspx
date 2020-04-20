<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="frmChangePassword.aspx.cs" MasterPageFile="~/Admin/AdminMasterMenu.master" Inherits="Administration_frmChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<center>
<table border ="0" cellpadding ="0" cellspacing ="0"  width="100%" height="370">
<tr >

<td style="width:100%" valign="top" align="left">
 <table width="100%">
    <tr>
        <td colspan="3" class="LoginTitle" ><strong>Change Password</strong> 
        </td>
    </tr>
     <tr>
         <td align="center" colspan="3">
             <asp:Label ID="lblSuccess" runat="server" Visible="False" Font-Size="12pt" ForeColor="Navy"></asp:Label></td>
     </tr>
     <tr>
         <td align="left" colspan="3">
             <asp:Label ID="lblError" runat="server" Visible="False" CssClass="lblerror"></asp:Label></td>
     </tr>
    <tr>
        <td align="left" width="20%" style="height: 26px">Old Password&nbsp;<span class="lblerror">*</span>
        </td>
        <td width="2%" style="height: 26px">
            <strong>:</strong></td>
        <td align="left" style="height: 26px">
            <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password" CssClass="txt"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOldPassword"
                ErrorMessage="Old Password must not be blank">*</asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td align="left">New Password&nbsp;<span class="lblerror">*</span>
        </td>
        <td>
            <strong>:</strong></td>
        <td align="left">
            <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" CssClass="txt"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewPassword"
                ErrorMessage="Give different New Password">*</asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td align="left">Confirm Password&nbsp;<span class="lblerror">*</span>
        </td>
        <td>
            <strong>:</strong></td>
        <td align="left">
            <asp:TextBox ID="txtConformPassword" runat="server" TextMode="Password" CssClass="txt"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtConformPassword"
                ErrorMessage="Conform Password Must Not Blank">*</asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewPassword"
                ControlToValidate="txtConformPassword" ErrorMessage="New Password & Conform Password Must Be The Same"></asp:CompareValidator></td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td style="text-align: center"  >
            &nbsp;</td>
        <td>
        </td>
        <td align="left" >
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" Font-Bold="True" Font-Names="Verdana" Font-Size="10pt" ForeColor="#660033" CssClass="button" style="position: relative" OnClick="btnSubmit_Click" />
            <input id="Reset1" type="reset" value="Reset" class="btnstyle" style="position: relative" /></td>
    </tr>
    <tr>
        <td colspan="3">
        </td>
    </tr>
</table>
</td>
</tr>



</table>
</center>

</asp:Content>