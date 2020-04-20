<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterMenu.master" AutoEventWireup="true" CodeFile="frmUpdateCountry.aspx.cs" Inherits="Administration_frmUpdateCountry"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border ="0" cellpadding ="0" cellspacing ="0"  width="100%" height="375" class="publicloginTable">
<tr >

<td style="width:100%" valign="top" align="left">

<table width="100%" class="admintablestyle">
<tr>
<td colspan="4" class="LoginTitle">
Update Country
</td>
    
</tr>
<tr>
        <td colspan="4" class="lblerror">
            *- Mandatory fields</td>
    </tr>
<tr>
<td style="width:18%" >
Country Name<span class="lblerror">*</span></td>
<td style="width:2%">:</td>
<td style="width:18%">
    <asp:TextBox ID="txtCountryName" runat="server" Width="160px"></asp:TextBox>
    </td>
    <td>
        <asp:RequiredFieldValidator ID="rfvCountryName" runat="server" ControlToValidate="txtCountryName"
            ErrorMessage="*" Style="position: relative"></asp:RequiredFieldValidator></td>
</tr>

<tr>
<td >
Country Description
</td>
<td>:</td>
<td>
    <asp:TextBox ID="txtCountryDescription" runat="server" TextMode="MultiLine" Width="160px"></asp:TextBox>
    </td>
    <td>
    </td>
</tr>
<tr>
<td >
Status<span class="lblerror">*</span>
</td>
<td>:</td>
<td>
    <asp:DropDownList ID="ddlStatus" runat="server" Width="90px">
        <asp:ListItem>Active</asp:ListItem>
        <asp:ListItem>InActive</asp:ListItem>
    </asp:DropDownList>
    </td>
    <td>
        &nbsp;<asp:RequiredFieldValidator ID="rfvStatus" runat="server" ControlToValidate="ddlStatus"
            CssClass="lblerror" ErrorMessage="*" InitialValue="select" Style="left: -78px;
            position: relative; top: 2px"></asp:RequiredFieldValidator></td>
</tr>
<tr>
<td align="right">

  

</td>
    <td>
    
        
    </td>
    <td colspan="2">
     <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />&nbsp; 
    <input id="Reset1" type="reset" value="Reset" class="btnstyle" />&nbsp;
    <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
    </td>
</tr>
</table>
</td></tr></table>
</asp:Content>

