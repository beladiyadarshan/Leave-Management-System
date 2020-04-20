<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterMenu.master" AutoEventWireup="true" CodeFile="frmManageState.aspx.cs" Inherits="Administration_frmManageState" %>
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
    <td  valign="top" align="left">
    <table width="100%" class="admintablestyle">
    <tr>
    <td colspan="6" class="LoginTitle">
    Manage State
    </td>
    </tr>
    <tr>
    <td style="width:14%">State Name</td>
    <td style="width:2%">:</td>
    <td style="width:18%">
        <asp:TextBox ID="txtStateName" OnKeypress="return onlyNumbers(event)" runat="server" Width="160px"></asp:TextBox>
        </td>
        <td align="right" width="14%" >Country Name</td>
        <td width="2%" align="center">:</td>
        <td>
        <asp:DropDownList ID=
        "ddlCountryName" runat="server" Width="90px" ></asp:DropDownList>
        </td>
        
        
    </tr>
    <tr>
    <td>Page Size</td>
    <td>:</td>
    <td>
        <asp:TextBox ID="txtPageSize"  OnKeypress="return onlyNumbers(event)" runat="server" Width="55px"></asp:TextBox>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtPageSize"
            CssClass="lblerror" ErrorMessage="Invalid Number" MaximumValue="999" MinimumValue="1"
            Style="position: relative" Type="Integer"></asp:RangeValidator></td>
        <td style="width: 166px">
            </td>
    </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td><asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click1" Width="55px" />
            </td>
            <td style="width: 166px">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td style="width: 166px">
            </td>
        </tr>
    <tr>
    <td colspan="6">
    <table border="0" width="65%" ><tr>
                        <td align="left" style="width: 321px">
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="65px" OnClick="btnDelete_Click1"  /></td> 
                        <td align="right">
                            <asp:Button ID="btnAdd" runat="server" Text="Add" Width="65px" OnClick="btnAdd_Click1"/></td></tr>
                       <tr><td colspan="2">                       
                           <asp:GridView ID="gvState" runat="server" AllowPaging="true" AllowSorting="true"
                               AutoGenerateColumns="False" Width="100%" OnPageIndexChanging="gvState_PageIndexChanging1" OnSorting="gvState_Sorting1" OnRowCommand="gvState_RowCommand1">
                               <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <input name="Cbx_Toggle" onclick="toggleAllCheckboexs(this.checked)" type="checkbox" />Select
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            
                                            <input name="Cbx_StateId" type="checkbox" value='<%#Eval("StateId")%>' />
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   <asp:TemplateField HeaderText="State Name" SortExpression="StateName">
                                       <HeaderStyle Width="30%" />
                                       <ItemTemplate>
                                           <asp:LinkButton ID="lnkBtnStateName" Text='<%#Eval("StateName")%>' runat="server"
                                               CommandArgument='<%#Eval("StateId")%>' CommandName="Update"></asp:LinkButton>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Description">
                                       <ItemTemplate>
                                           <%#Eval("StateDescription")%>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Country Name">
                                       <ItemTemplate>
                                           <%#Eval("CountryName") %>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Status">
                                       <ItemTemplate>
                                           <%#Eval("StatusName") %>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                               </Columns>
                           </asp:GridView>
                       </td>
                       </tr>
        <tr>
                        <td width="50%">
                            <asp:Label ID="lblError" CssClass="lblerror" Visible="false"  runat="server" Text=""></asp:Label></td>
                       <td align="right" >
                           <asp:Label ID="Lbl_Pageinfo" runat="server" Text=""></asp:Label></td> 
                        </tr> 
                    
                </table>
                </td> 
                </tr> 
                </table>  
                 
                 
    
    
    </td>
    </tr>
    </table>

</asp:Content>

