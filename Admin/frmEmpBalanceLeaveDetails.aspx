<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterMenu.master" AutoEventWireup="true" CodeFile="frmEmpBalanceLeaveDetails.aspx.cs" Inherits="Admin_frmEmpLeaveDetails" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table width="100%" height="373" class="publicloginTable">
        <tr>
            <td valign="top" align="left">
                <table width="100%" class="admintablestyle">
                    <tr>
                        <td colspan="4" class="LoginTitle">
                            Employee Balance Leave Details
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 17%">
                            User Name</td>
                        <td style="width: 2%">
                            :</td>
                        <td style="width: 161px">
                            <asp:TextBox ID="txtUserName" runat="server" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr> 
                    <tr>
                        <td style="width: 17%">
                            Contact No</td>
                        <td style="width: 2%">
                            :</td>
                        <td style="width: 161px">
                            <asp:TextBox ID="txtContactNo" runat="server" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                     <tr>
                        <td style="width: 17%">
                            Email Id</td>
                        <td style="width: 2%">
                            :</td>
                        <td style="width: 161px">
                            <asp:TextBox ID="txtEmailId" runat="server" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                     
                     <tr>
                        <td style="width: 17%">
                            Address</td>
                        <td style="width: 2%">
                            :</td>
                        <td style="width: 161px">
                            <asp:TextBox ID="txtAddress" TextMode="MultiLine" runat="server" ReadOnly="True" Width="150px" Height="49px"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr><td>Designation</td><td>:</td><td style="width: 161px">
                            <asp:TextBox ID="txtDesig" runat="server" ReadOnly="True"></asp:TextBox></td><td></td></tr>
                            <tr><td>CL Bal</td><td>:</td><td style="width: 161px">
                                <asp:TextBox ID="txtCLBal" runat="server" ReadOnly="True"></asp:TextBox></td><td></td></tr>
                            
                            <tr><td>ML Bal</td><td>:</td><td style="width: 161px">
                                <asp:TextBox ID="txtMLBal" runat="server" ReadOnly="True"></asp:TextBox></td><td></td></tr>
                                <tr><td>EL Bal</td><td>:</td><td style="width: 161px">
                                    <asp:TextBox ID="txtEL"   runat="server" Height="17px" ReadOnly="True"></asp:TextBox></td><td></td></tr>
                            <tr><td>HPL Bal</td><td>:</td><td style="width: 161px">
                                <asp:TextBox ID="txtHPLBal" runat="server" ReadOnly="True"></asp:TextBox>
                            </td><td></td></tr>
                           <tr><td colspan="4"></td></tr>
                           <tr><td colspan="2"></td><td style="width: 161px">
                               &nbsp;<asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" /></td></tr>
                           </table></td>
                            
                    </tr>
                   
                   
                 </table>

</asp:Content>

