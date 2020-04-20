<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterMenu.master" AutoEventWireup="true" CodeFile="frmUpdateState.aspx.cs" Inherits="Administration_frmUpdateState" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border ="0" cellpadding ="0" cellspacing ="0"  width="100%" height="375" class="publicloginTable">
<tr >

<td style="width:100%" valign="top" align="left">
<table width="100%" class="admintablestyle">
<tr>
<td colspan="4" class="LoginTitle">
Update State
</td>
    
</tr>

<tr>
        <td colspan="4" class="lblerror">
            *- Mandatory fields</td>
    </tr>
<tr>
<td style="width:18%" >
State Name<span class="lblerror">*</span>
</td>
<td style="width:2%">:</td>
<td style="width:18%">
    <asp:TextBox ID="txtStateName" runat="server" Width="160px"></asp:TextBox>
    </td>
    <td>
    <asp:RequiredFieldValidator ID="rfvStateName" runat="server" ControlToValidate="txtStateName"
            ErrorMessage="*" Style="position: relative" CssClass="lblerror"></asp:RequiredFieldValidator>
    </td>
</tr>

<tr>
<td >
State Description
</td>
<td>:</td>
<td>
    <asp:TextBox ID="txtStateDescription" runat="server" TextMode="MultiLine" Width="160px"></asp:TextBox>
    </td>
    <td>
    </td>
</tr>
<tr>
        <td>
            Country Name<span class="lblerror">*</span></td>
        <td>
            :</td>
        <td>
            <asp:DropDownList ID="ddlCountryName" runat="server">
            </asp:DropDownList>
        </td>
        <td>
            &nbsp;</td>
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
        &nbsp;</td>
</tr>
    
<tr>
<td align="right" style="height: 26px">
    &nbsp;</td>
    <td style="height: 26px">
    
        
    </td>
    <td colspan="2" style="height: 26px">
       <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />&nbsp; 
    <input id="Reset1" type="reset" value="Reset" class="btnstyle" />&nbsp;
    <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
    </td>
</tr>
</table>
</td></tr></table>
</asp:Content>

