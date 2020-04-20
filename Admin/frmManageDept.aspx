<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterMenu.master" AutoEventWireup="true" CodeFile="frmManageDept.aspx.cs" Inherits="Admin_frmManageDept" Title="Untitled Page" %>
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
                            Manage Dept
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 17%">
                            Dept Name</td>
                        <td style="width: 2%">
                            :</td>
                        <td style="width: 18%">
                            <asp:TextBox ID="txtDeptName" runat="server"></asp:TextBox>
                        </td>
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
                            <asp:Button ID="btnSearch" runat="server" Text="Search" Width="55px" OnClick="btnGo_Click" /></td>
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
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="65px" OnClick="btndelete_Click" /></td> 
                        <td align="right">
                            <asp:Button ID="btnAdd" runat="server" Text="Add" Width="65px" OnClick="btnadd_Click" /></td></tr>
                       <tr><td colspan="2">                       
                           <asp:GridView ID="gvDept" runat="server" AllowPaging="true" AllowSorting="true"  AutoGenerateColumns="False" Width="100%" OnRowCommand="gvDept_RowCommand" OnSorting="gvDept_Sorting" OnPageIndexChanging="gvDept_PageIndexChanging">
                                <Columns> <asp:TemplateField>
                                        <HeaderTemplate>
                                            <input name="Cbx_Toggle" onclick="toggleAllCheckboexs(this.checked)" type="checkbox" />Select
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            
                                            <input name="Cbx_DeptId" type="checkbox" value='<%#Eval("DeptId")%>' />
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Dept Name" SortExpression="DeptName">
                                               <HeaderStyle Width="30%" />
                                                    <ItemTemplate>
                                                      <asp:LinkButton ID="lnkBtnDeptName" Text='<%#Eval("DeptName")%>' runat="server" CommandArgument='<%#Eval("DeptId")%>' CommandName="Update"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Description">
                                                    <ItemTemplate>
                                                        <%#Eval("DeptDescription")%>
                                                    </ItemTemplate>
                                             </asp:TemplateField>
                                 <%--      <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                    <%#Eval("StatusName") %>
                                    </ItemTemplate>
                                    </asp:TemplateField>--%>
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

