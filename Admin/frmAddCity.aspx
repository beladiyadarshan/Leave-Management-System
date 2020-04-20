<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterMenu.master" AutoEventWireup="true" CodeFile="frmAddCity.aspx.cs" Inherits="Administration_frmAddCity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border ="0" cellpadding ="0" cellspacing ="0"  width="100%" height="375" class="publicloginTable">
<tr >

<td style="width:100%" valign="top" align="left">
<table width="100%" class="admintablestyle">
<tr>
<td colspan="4" class="LoginTitle">
Add City
</td>
    
</tr>
    <tr>
        <td align="center" class="lblerror" colspan="4">
            <asp:Label ID="lblError" runat="server" Visible="false" Text=""></asp:Label>
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
    <td>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCityName"
        ErrorMessage="Please Enter CityName" >*</asp:RequiredFieldValidator>
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
        <td>
            Country Name<span class="lblerror">*</span></td>
        <td>
            :</td>
        <td>
            <asp:DropDownList ID="ddlCountryName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCountryName_SelectedIndexChanged" Width="90px">
            </asp:DropDownList>
        </td>
        <td><asp:Label id="lblErrorCountryName" runat="server" Text="Select Country Name" CssClass="lblerror" Visible="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            State Name<span class="lblerror">*</span></td>
        <td>
            :</td>
        <td>
            <asp:DropDownList ID="ddlStateName" runat="server" Width="90px">
                
            </asp:DropDownList>
        </td>
        <td><asp:Label id="lblErrorStateName" runat="server" Text="Select State Name" CssClass="lblerror" Visible="False"></asp:Label>
        </td>
    </tr>
<tr>
<td >
Status<span class="lblerror">*</span>
</td>
<td>:</td>
<td>
    <asp:DropDownList ID="ddlStatus" runat="server" Width="90px">
    <asp:ListItem>Select</asp:ListItem>
        <asp:ListItem>Active</asp:ListItem>
        <asp:ListItem>InActive</asp:ListItem>
    </asp:DropDownList>
    </td>
    <td><asp:Label id="lblErrorStatus" runat="server" Text="Select Status Name" CssClass="lblerror" Visible="False"></asp:Label>
    </td>
</tr>
<tr>
<td colspan="2" style="height: 26px">

    

</td>
    <td colspan="2" style="height: 26px">
    
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" Width="65px" />&nbsp;
    <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CausesValidation="False" Width="65px" />
    </td>
</tr>
</table></td></tr></table>
</asp:Content>

