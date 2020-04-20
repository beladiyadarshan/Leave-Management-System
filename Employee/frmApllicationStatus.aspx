<%@ Page Language="C#" MasterPageFile="~/Employee/EmployeeMasterPage.master" AutoEventWireup="true" CodeFile="frmApllicationStatus.aspx.cs" Inherits="Employee_frmApllicationStatus" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" height="373" class="publicloginTable">
        <tr>
            <td valign="top" align="left">

<table width="100%" >
<tr align ="center" >
<td>
    <asp:GridView ID="gvAppStatus" AutoGenerateColumns="false" runat="server">
    <Columns>
    <asp:BoundField HeaderText="Application Number" DataField="ApplicationNo" />
    <asp:BoundField HeaderText="User Name" DataField="UserName" />
    <asp:BoundField HeaderText="Leave Type Name" DataField="LeaveTypeName" />
    <asp:BoundField HeaderText="Starting Date" DataField="StartingDate" />
    <asp:BoundField HeaderText="Ending date" DataField="EndingDate" />
    <asp:BoundField HeaderText="Applying Date" DataField="ApplyingDate" />
    <asp:BoundField HeaderText="NoOf Days" DataField="NoOfDays" />
     <asp:BoundField HeaderText="Leave Purpose" DataField="LeavePurpose" />
      <asp:BoundField HeaderText="Status Name" DataField="StatusName" />    
    </Columns>
    </asp:GridView>
</td>
</tr>
</table>
</td>
</tr>
</table>
</asp:Content>

