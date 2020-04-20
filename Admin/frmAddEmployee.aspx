<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterMenu.master" AutoEventWireup="true" CodeFile="frmAddEmployee.aspx.cs" Inherits="Admin_frmAddEmployee" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border ="0" cellpadding ="0" cellspacing ="0"  width="100%" height="375" class="publicloginTable">
<tr >

<td style="width:100%" valign="top" align="left">
<table width="100%" class="admintablestyle">
<tr>
<td colspan="4" class="LoginTitle">
Add Employee 
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
    User Name<span class="lblerror">*</span>
</td>
<td style="width:2%">:</td>
<td style="width:169px">
    <asp:TextBox ID="txtUserName" runat="server" Width="160px"></asp:TextBox>
    </td>
    <td>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName"
        ErrorMessage="Please Enter EmployeeName" >*</asp:RequiredFieldValidator>
        (Must Be Unique)</td>
</tr>
   <tr><td>Password</td><td>:</td><td style="width: 169px">
    <asp:TextBox ID="txtPassword" runat="server" Width="160px"></asp:TextBox></td><td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
            ErrorMessage="Please Enter Password">*</asp:RequiredFieldValidator></td></tr>
<tr>
<td style="width:18%" >
    Emplyee Name<span class="lblerror">*</span>
</td>
<td style="width:2%">:</td>
<td style="width:169px">
    <asp:TextBox ID="txtEmpName" runat="server" Width="160px"></asp:TextBox>
    </td>
    <td>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmpName"
        ErrorMessage="Please Enter EmployeeName" >*</asp:RequiredFieldValidator>
        </td>
</tr>
<tr>
<td style="height: 40px" >
Address
</td>
<td style="height: 40px">:</td>
<td style="width: 169px; height: 40px;">
    <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Width="160px"></asp:TextBox>
    </td>
    <td style="height: 40px">
    </td>
</tr>
    <tr>
        <td>
            Country Name<span class="lblerror">*</span></td>
        <td>
            :</td>
        <td style="width: 169px">
            <asp:DropDownList ID="ddlCountryName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCountryName_SelectedIndexChanged" Width="90px">
            </asp:DropDownList>
        </td>
        <td><asp:Label id="lblErrorCountryName" runat="server" Text="Select Country Name" CssClass="lblerror" Visible="False"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlCountryName"
                ErrorMessage="Please Enter EmployeeName" InitialValue="Select">*</asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td>
            State Name<span class="lblerror">*</span></td>
        <td>
            :</td>
        <td style="width: 169px">
            <asp:DropDownList ID="ddlStateName" runat="server" Width="90px" OnSelectedIndexChanged="ddlStateName_SelectedIndexChanged" AutoPostBack="True">
                
            </asp:DropDownList>
        </td>
        <td><asp:Label id="lblErrorStateName" runat="server" Text="Select State Name" CssClass="lblerror" Visible="False"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlStateName"
                ErrorMessage="Please Enter EmployeeName" InitialValue="Select">*</asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td>
            City Name<span class="lblerror">*</span></td>
        <td>
            :</td>
        <td style="width: 169px">
            <asp:DropDownList ID="ddlCityName" runat="server" Width="90px" OnSelectedIndexChanged="ddlCityName_SelectedIndexChanged" >
                
            </asp:DropDownList>
        </td>
        <td><asp:Label id="lblErrorCityName" runat="server" Text="Select City Name" CssClass="lblerror" Visible="False"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlCityName"
                ErrorMessage="Please Enter EmployeeName" InitialValue="Select">*</asp:RequiredFieldValidator></td>
    </tr>
<%--<tr>
<td >
Status<span class="lblerror">*</span><asp:DropDownList runat="server"></asp:DropDownList>
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
</tr>--%>
<tr><td>EmailId</td><td>:</td><td style="width: 180px">
    <asp:TextBox ID="txtEmailId" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtEmailId"
        ErrorMessage="Please Enter EmployeeName">*</asp:RequiredFieldValidator></td></tr>
    
    <tr><td>ContactNo</td><td>:</td><td style="width: 169px">
        <asp:TextBox ID="txtContactNo" OnKeypress="return onlyNumbers(event)" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtContactNo"
            ErrorMessage="Please Enter EmployeeName">*</asp:RequiredFieldValidator></td></tr>
        <tr><td>Dept Name</td><td>:</td><td style="width: 169px">
            <asp:DropDownList ID="ddlDept" runat="server">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlDept"
                ErrorMessage="Please Enter EmployeeName" InitialValue="Select">*</asp:RequiredFieldValidator></td></tr>
            <tr><td>Designation</td><td>:</td><td>
                <asp:DropDownList ID="ddlDesig" runat="server">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlDesig"
                    ErrorMessage="Please Enter EmployeeName" InitialValue="Select">*</asp:RequiredFieldValidator></td></tr>
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

