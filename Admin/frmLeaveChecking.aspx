<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterMenu.master" AutoEventWireup="true" CodeFile="frmLeaveChecking.aspx.cs" Inherits="Admin_frmLeaveChecking" Title="Untitled Page" %>
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
                        <td colspan="4" class="LoginTitle">
                            Leave Checking
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 17%">
                            Leave Type</td>
                        <td style="width: 2%">
                            :</td>
                        <td style="width: 18%">
                            <asp:DropDownList ID="ddlLeaveType" runat="server">
                            </asp:DropDownList></td>
                        <td>
                        </td>
                    </tr>
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
                        <td style="height: 26px">
                            </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnSearch" runat="server" Text="Search" Width="55px" OnClick="btnSearch_Click" /></td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            &nbsp;
                        </td>
                        <td>
                         </td>   
                    </tr>
                    <tr>
                        <td colspan="4">
                        <table border="0" width="50%" ><tr>
                        <td align="left" style="width: 321px">
                            &nbsp;</td> 
                        <td align="right">
                            </td></tr>
                       <tr><td colspan="2">                       
                           <asp:GridView ID="gvLeaveCheck" runat="server" AllowPaging="true" AllowSorting="true"  AutoGenerateColumns="False" Width="100%" OnRowCommand="gvLeaveCheck_RowCommand" OnSorting="gvLeaveCheck_Sorting" OnPageIndexChanging="gvLeaveCheck_PageIndexChanging">
                                <Columns> <%--<asp:TemplateField>
                                        <HeaderTemplate>
                                            <input name="Cbx_Toggle" onclick="toggleAllCheckboexs(this.checked)" type="checkbox" />Select
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            
                                            <input name="Cbx_CountryId" type="checkbox" value='<%#Eval("CountryId")%>' />
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="User Name" SortExpression="UserName">
                                               <HeaderStyle Width="30%" />
                                                    <ItemTemplate>
                                                      <asp:LinkButton ID="lnkBtnUserName" Text='<%#Eval("UserName")%>' runat="server" CommandArgument='<%#Eval("ApplicationNo")%>' CommandName="Update"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                    <asp:TemplateField HeaderText="StartingDate">
                                                    <ItemTemplate>
                                                        <%#Eval("StartingDate")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                    <asp:TemplateField HeaderText="NoOfDays">
                                    <ItemTemplate>
                                    <%#Eval("NoOfDays")%>
                                    </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                    <%#Eval("ApplicationStatusId")%>
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

