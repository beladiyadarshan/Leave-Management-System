<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterMenu.master" AutoEventWireup="true" CodeFile="frmAddStatus.aspx.cs" Inherits="Administration_frmAddStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border ="0" cellpadding ="0" cellspacing ="0"  width="100%" height="375">
<tr >

<td style="width:100%" valign="top" align="left">
<table width="100%">
<tr>
<td colspan="4" class="LoginTitle">
Add Status
</td>
    
</tr>
    <tr>
        <td colspan="4" class="lblerror">
            *- Mandatory fields</td>
    </tr>
<tr>
<td style="width:14%" >
Status Name<span class="lblerror">*</span></td>
<td style="width:2%">:</td>
<td style="width:18%">
    <asp:TextBox ID="txtStatusName" runat="server" Width="160px"></asp:TextBox>
    </td>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtStatusName"
            CssClass="lblerror" ErrorMessage="Please Enter StatusName" Style="position: relative">*</asp:RequiredFieldValidator></td>
</tr>

<tr>
<td >
Status Description
</td>
<td>:</td>
<td>
    <asp:TextBox ID="txtStatusDescription" runat="server" TextMode="MultiLine" Height="50px" Width="160px"></asp:TextBox>
    </td>
    <td>
    </td>
</tr>
    <tr>
        <td colspan="2">
        </td>
        <td colspan="2">
        </td>
    </tr>
<tr>
<td colspan="2" style="height: 26px">

    

</td>
    <td colspan="2" style="height: 26px">
    
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" Width="65px" />
        <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnAdd_Click" CausesValidation="False" Width="65px" /></td>
</tr>
</table>
</td></tr></table>

</asp:Content>

