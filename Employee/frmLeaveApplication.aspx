<%@ Page Language="C#" MasterPageFile="~/Employee/EmployeeMasterPage.master" AutoEventWireup="true" CodeFile="frmLeaveApplication.aspx.cs" Inherits="Employee_frmLeaveApplication" Title="Untitled Page" %>

<%@ Register Assembly="GMDatePicker" Namespace="GrayMatterSoft" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border ="0" cellpadding ="0" cellspacing ="0"  width="100%" height="375" class="publicloginTable">
<tr >

<td style="width:100%" valign="top" align="left">
<table width="100%" class="admintablestyle">
<tr>
<td colspan="4" class="LoginTitle">
Leave Application
</td>
    
</tr>
 <tr>
        <td colspan="4" class="lblerror">
            *- Mandatory fields</td>
    </tr>
    <tr>
        <td class="lblerror" colspan="4">
            <asp:Label ID="lblError" runat="server" Visible="false" Text="lblError"></asp:Label>
        </td>
    </tr>
<tr>
<td style="width:20%" >
User Name<span class="lblerror">*</span></td>
<td style="width:2%">:</td>
<td style="width:18%">
    <asp:TextBox ID="txtUserName" runat="server" Width="160px" ReadOnly="True"></asp:TextBox>
   </td>
    <td>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName"
        ErrorMessage="*" >*</asp:RequiredFieldValidator>
    </td>
</tr>

<tr>
<td >
Leave type
</td>
<td>:</td>
<td>
    <asp:DropDownList ID="ddlLeaveType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLeaveType_SelectedIndexChanged">
        <asp:ListItem>Select</asp:ListItem>
    </asp:DropDownList>
    </td>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlLeaveType"
            ErrorMessage="*" InitialValue="Select">*</asp:RequiredFieldValidator></td>
</tr>
<tr>
<td >
Balance Leave<span class="lblerror">*</span>
</td>
<td>:</td>
<td>
    <asp:TextBox ID="txtBalanceLeave" ReadOnly="true" runat="server"></asp:TextBox>
    </td>
    <td></td>
</tr>



<tr>
<td >
Start Date<span class="lblerror">*</span>
</td>
<td>:</td>
<td>
    <cc1:GMDatePicker ID="GMDStartDate" runat="server" CalendarOffsetX="-127px" DateFormat="dd-MMM-yyyy" InitialValueMode="Null">
    </cc1:GMDatePicker>
    </td>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="GMDStartDate"
            ErrorMessage="*">*</asp:RequiredFieldValidator></td>
</tr>

<tr>
<td >
No Of Days<span class="lblerror">*</span>
</td>
<td>:</td>
<td>
    <asp:TextBox ID="txtNoOfdays" OnKeypress="return onlyNumbers(event)" runat="server"></asp:TextBox>
    </td>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtNoOfdays"
            ErrorMessage="*">*</asp:RequiredFieldValidator></td>
</tr>


<tr>
<td >
Purpose<span class="lblerror">*</span>
</td>
<td>:</td>
<td>
    <asp:TextBox ID="txtPurpose" TextMode="MultiLine" runat="server" Height="54px"></asp:TextBox>
    </td>
    <td></td>
</tr>

<tr>
<td colspan="2">

    

</td>
    <td colspan="2">
    
    <asp:Button ID="btnApplyLeave" runat="server" Text="ApplyLeave" OnClick="btnApplyLeave_Click" Width="86px" />&nbsp;&nbsp;
        <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CausesValidation="False" Width="65px" />
    </td>
</tr>
</table>
</td></tr></table>
</asp:Content>

