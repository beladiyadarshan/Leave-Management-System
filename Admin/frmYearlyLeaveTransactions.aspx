<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterMenu.master" AutoEventWireup="true" CodeFile="frmYearlyLeaveTransactions.aspx.cs" Inherits="Admin_frmYearlyLeaveTransactions" Title="Untitled Page" %>

<%@ Register Assembly="GMDatePicker" Namespace="GrayMatterSoft" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript" language="javascript">
function toggleAllCheckboexs(toggle)
{
				n = document.forms[0].length;
				var frm = document.forms[0];
				for(i=0;i<frm.length;i++)
				
					if(frm.elements[i].type=="checkbox")
						if (frm.elements[i].name.indexOf('Cbx')==0)
							frm.elements[i].checked=toggle;
			}
				function onlyNumbers(evt)
{
    var e = event || evt;
    var charCode = e.which || e.keyCode;
	if ((charCode > 47 && charCode < 58))
    return true;		             
    else
    return false ;		                            
}
</script>
    <table width="100%" height="373" class="publicloginTable">
        <tr>
            <td valign="top" align="left">
                <table width="100%" class="admintablestyle">
                    <tr>
                        <td colspan="6" class="LoginTitle">
                            Yearly Leave Transactions
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 17%">
                            User Name</td>
                        <td style="width: 2%">
                            :</td>
                        <td style="width: 18%">
                            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                        </td>
                        <td colspan="3">
                        </td>
                    </tr>
                    <tr><td>StartingYear</td><td>:</td><td>
                        <cc1:gmdatepicker id="GMStart" runat="server" CalendarOffsetX="-127px" InitialValueMode="Null"></cc1:gmdatepicker>
                        </td><td style="width: 18%">EndingYear</td><td style="width: 2%">:</td><td>
                            <cc1:gmdatepicker id="GMEnd" runat="server" CalendarOffsetX="-127px" InitialValueMode="Null"></cc1:gmdatepicker>
                        </td></tr>
                        
                       
                    <tr>
                        <td style="height: 26px">
                            Page Size</td>
                        <td style="height: 26px">
                            :</td>
                        <td style="height: 26px">
                            <asp:TextBox ID="txtPageSize" OnKeypress="return onlyNumbers(event)" runat="server" Width="50px"></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtPageSize"
                                CssClass="lblerror" ErrorMessage="Invalid Number" MaximumValue="999" MinimumValue="1"
                                 Type="Integer"></asp:RangeValidator>
                        </td>
                        <td colspan="3">
                            </td>
                    </tr>
                    <tr>
                        <td style="height: 26px">
                        </td>
                        <td style="height: 26px">
                        </td>
                        <td style="height: 26px">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" Width="55px" OnClick="btnSearch_Click" /></td>
                            <td colspan="3" style="height: 26px">
                            </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            &nbsp;
                        </td>
                        <td colspan="3">
                         </td>   
                    </tr>
                    <tr>
                        <td colspan="6">
                        <table border="0" width="50%" ><tr>
                        <td align="left" style="width: 321px">
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="65px" Visible="False" /></td> 
                        <td align="right">
                            <asp:Button ID="btnAdd" runat="server" Text="Add" Width="65px"  Visible="False" /></td></tr>
                       <tr><td colspan="2">                       
                           <asp:GridView ID="gvYear" runat="server" AllowPaging="true" AllowSorting="true"  AutoGenerateColumns="False" Width="100%"  OnSorting="gvYear_Sorting" OnPageIndexChanging="gvYear_PageIndexChanging">
                                <Columns><%-- <asp:TemplateField>
                                        <HeaderTemplate>
                                            <input name="Cbx_Toggle" onclick="toggleAllCheckboexs(this.checked)" type="checkbox" />Select
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            
                                            <input name="Cbx_CountryId" type="checkbox" value='<%#Eval("CountryId")%>' />
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                     <asp:TemplateField HeaderText="ApplicationNo">
                                                    <ItemTemplate>
                                                        <%#Eval("ApplicationNo")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                    <asp:TemplateField HeaderText="User Name" SortExpression="UserName">
                                               <HeaderStyle Width="30%" />
                                                    <ItemTemplate>
                                                     <%#Eval("UserName")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                    <asp:TemplateField HeaderText="LeaveType">
                                                    <ItemTemplate>
                                                        <%#Eval("LeaveTypeName")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                    <asp:TemplateField HeaderText="StartingDate">
                                    <ItemTemplate>
                                    <%#Eval("StartingDate") %>
                                    </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView> </td></tr>
                            
                        
                   
                    <tr>
                        <td width="50%">
                            <asp:Label ID="lblError" CssClass="lblerror" Visible="false"  runat="server" Text=""></asp:Label></td>
                       <td align="right">
                           <asp:Label ID="Lbl_Pageinfo" runat="server" Text=""></asp:Label></td> 
                        </tr> 
                    
                </table>
                 </td></tr>
                 </table>
    
    
    
    </td>
    </tr>
    </table>

</asp:Content>

