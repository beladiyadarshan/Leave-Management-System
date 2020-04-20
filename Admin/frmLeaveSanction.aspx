<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterMenu.master" AutoEventWireup="true" CodeFile="frmLeaveSanction.aspx.cs" Inherits="Admin_frmLeaveSanction" Title="Untitled Page" %>

<%@ Register Assembly="GMDatePicker" Namespace="GrayMatterSoft" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table width="100%" height="373" class="publicloginTable">
        <tr>
            <td valign="top" align="left">
                <table width="100%" class="admintablestyle">
                    <tr>
                        <td colspan="4" class="LoginTitle">
                            Leave Sanction (you can change only Status)</td>
                    </tr>
                    <tr>
                        <td style="width: 17%">
                            Application No</td>
                        <td style="width: 2%">
                            :</td>
                        <td style="width: 161px">
                            <asp:TextBox ID="txtAppNo" runat="server" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 57px">
                            Application Date</td>
                        <td style="height: 57px">
                            :</td>
                        <td style="height: 57px; width: 161px;">
                            <cc1:GMDatePicker ID="GMAppDate" runat="server" CalendarOffsetX="-127px" InitialValueMode="Null">
                            </cc1:GMDatePicker></td>
                           <td style="height: 57px"> &nbsp;</td>
                        </tr><tr><td>UserName</td><td>:</td><td style="width: 161px">
                            <asp:TextBox ID="txtUserName" runat="server" ReadOnly="True"></asp:TextBox></td><td></td></tr>
                            <tr><td>Leave in Days</td><td>:</td><td style="width: 161px">
                                <asp:TextBox ID="txtDays" runat="server" ReadOnly="True"></asp:TextBox></td><td></td></tr>
                            
                            <tr><td>LeaveType</td><td>:</td><td style="width: 161px">
                                <asp:TextBox ID="txtLeaveType" runat="server" ReadOnly="True"></asp:TextBox></td><td></td></tr>
                                <tr><td>Leave Purpose</td><td>:</td><td style="width: 161px">
                                    <asp:TextBox ID="txtPurpose"  TextMode="MultiLine" runat="server" Height="52px" ReadOnly="True"></asp:TextBox></td><td></td></tr>
                            <tr><td>Starting Date</td><td>:</td><td style="width: 161px">
                                <cc1:GMDatePicker ID="GMStartDate" runat="server" CalendarOffsetX="-127px" InitialValueMode="Null">
                                </cc1:GMDatePicker>
                            </td><td></td></tr>
                            <tr><td>Status</td><td>:</td><td style="width: 161px">
                                <asp:DropDownList ID="ddlStatus" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlStatus"
                                    ErrorMessage="Please Select One" InitialValue="Select"></asp:RequiredFieldValidator></td><td></td></tr>
                           <tr><td colspan="4"><h3>
                               <asp:Label ID="lblError" runat="server" Text="" Visible="false"></asp:Label></h3></td></tr>
                           <tr><td colspan="2"></td><td style="width: 161px">
                               <asp:Button ID="btnSubmit" runat="server" Text="SubmitStatus" OnClick="btnSubmit_Click" />&nbsp;
                           </td></tr>
                           </table></td>
                            
                    </tr>
                   
                   
                 </table>
    
  
</asp:Content>

