<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterMenu.master" AutoEventWireup="true" CodeFile="frmAddDept.aspx.cs" Inherits="Admin_frmAddDept" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border ="0" cellpadding ="0" cellspacing ="0"  width="100%" height="375" class="publicloginTable">
<tr >

<td style="width:100%" valign="top" align="left">
<table width="100%" class="admintablestyle">
<tr>
<td colspan="4" class="LoginTitle">
Add Dept
</td>
    
</tr>
 <tr>
        <td colspan="4" class="lblerror">
            *- Mandatory fields</td>
    </tr>
<tr>
<td style="width:18%" >
Dept Name<span class="lblerror">*</span></td>
<td style="width:2%">:</td>
<td style="width:18%">
    <asp:TextBox ID="txtDeptName" runat="server" Width="160px"></asp:TextBox>
   </td>
    <td>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDeptName"
        ErrorMessage="Please Enter DeptName" >*</asp:RequiredFieldValidator>
    </td>
</tr>

<tr>
<td >
Dept Description
</td>
<td>:</td>
<td>
    <asp:TextBox ID="txtDeptDescription" runat="server" TextMode="MultiLine" Width="160px"></asp:TextBox>
    </td>
    <td>
    </td>
</tr>
<tr>
<td colspan="2">

    

</td>
    <td colspan="2">
    
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" Width="65px" />&nbsp;&nbsp;
        <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CausesValidation="False" Width="65px" />
    </td>
</tr>
</table>
</td></tr></table>

</asp:Content>

