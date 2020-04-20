<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterMenu.master" AutoEventWireup="true" CodeFile="frmUpdateCity.aspx.cs" Inherits="Administration_frmUpdateCity"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border ="0" cellpadding ="0" cellspacing ="0"  width="100%" height="375" class="publicloginTable">
<tr >

<td style="width:100%" valign="top" align="left">
<table width="100%" class="admintablestyle">
<tr>
<td colspan="4" class="LoginTitle" style="height: 19px">
Update City
</td>
    
</tr>

<tr>
        <td colspan="4" class="lblerror">
            *- Mandatory fields</td>
    </tr>
<tr>
<td style="width:18%" >
City Name<span class="lblerror">*</span>
</td>
<td style="width:2%">:</td>
<td style="width:18%">
    <asp:TextBox ID="txtCityName" runat="server" Width="160px"></asp:TextBox>
    </td>
    <td><asp:RequiredFieldValidator ID="rfvCityName" runat="server" ControlToValidate="txtCityName"
            ErrorMessage="*" Style="position: relative"></asp:RequiredFieldValidator>
    </td>
</tr>

<tr>
<td >
City Description
</td>
<td>:</td>
<td>
    <asp:TextBox ID="txtCityDescription" runat="server" TextMode="MultiLine" Width="160px"></asp:TextBox>
    </td>
    <td>
    </td>
</tr>


 <tr>
        <td style="height: 24px">
            Country Name<span class="lblerror">*</span></td>
        <td style="height: 24px">
            :</td>
        <td style="height: 24px">
            <asp:DropDownList ID="ddlCountryName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCountryName_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
        <td style="height: 24px">
            <asp:RequiredFieldValidator ID="rfvCountryName" runat="server" ControlToValidate="ddlCountryName"
                CssClass="lblerror" ErrorMessage="*" InitialValue="select" Style="position: relative"></asp:RequiredFieldValidator></td>
    </tr>

 <tr>
        <td style="height: 24px">
            State Name<span class="lblerror">*</span></td>
        <td style="height: 24px">
            :</td>
        <td style="height: 24px">
            <asp:DropDownList ID="ddlStateName" runat="server">
                <asp:ListItem>select</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td style="height: 24px">
            <asp:RequiredFieldValidator ID="rfvStateName" runat="server" ControlToValidate="ddlStateName"
                ErrorMessage="*" InitialValue="select" Style="position: relative" CssClass="lblerror"></asp:RequiredFieldValidator></td>
    </tr>
<tr>
<td style="height: 24px" >
Status<span class="lblerror">*</span>
</td>
<td style="height: 24px">:</td>
<td style="height: 24px">
    <asp:DropDownList ID="ddlStatus" runat="server" Width="90px">
        <asp:ListItem>Active</asp:ListItem>
        <asp:ListItem>InActive</asp:ListItem>
    </asp:DropDownList>
    </td>
    <td style="height: 24px">
        <asp:RequiredFieldValidator ID="rfvStatus" runat="server" ControlToValidate="ddlStatus"
            ErrorMessage="*" InitialValue="select" Style="position: relative" CssClass="lblerror"></asp:RequiredFieldValidator></td>
</tr>
   
<tr>
<td align="right">

   

</td>
    <td>
    
        
    </td>
    <td colspan="2">
    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" Width="65px" />&nbsp; 
    <input id="Reset1" type="reset" value="Reset" class="btnstyle" />&nbsp;
    <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" Width="65px" />
    </td>
</tr>
</table>
</td></tr></table>
</asp:Content>

