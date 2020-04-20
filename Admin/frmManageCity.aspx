<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterMenu.master" AutoEventWireup="true" CodeFile="frmManageCity.aspx.cs" Inherits="Administration_frmManageCity" %>
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
                        <td colspan="9" class="LoginTitle">
                            Manage City
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 17%">
                            City Name</td>
                        <td style="width: 2%">
                            :</td>
                        <td style="width: 18%">
                            <asp:TextBox ID="txtCityName" runat="server" Width="160px"></asp:TextBox>
                        </td>
                        <td style="width:15%;">Country Name
                        </td>
                        <td>:</td>
                        <td>
                            <asp:DropDownList ID="ddlCountryName" runat="server">
                            </asp:DropDownList></td>
                            <td style="width:15%;">State Name
                        </td>
                        <td>:</td>
                        <td>
                            <asp:DropDownList ID="ddlStateName" runat="server">
                            </asp:DropDownList></td>
                            
                    </tr>
                    <tr>
                        <td>
                            Page Size</td>
                        <td>
                            :</td>
                        <td>
                            <asp:TextBox ID="txtPageSize" OnKeypress="return onlyNumbers(event)" runat="server" Width="55px"></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtPageSize"
                                CssClass="lblerror" ErrorMessage="Invalid Number" MaximumValue="999" MinimumValue="1"
                                Style="position: relative" Type="Integer"></asp:RangeValidator></td>
                        <td colspan="6">
                            </td>
                    </tr>
                    <tr>
                        <td style="height: 26px">
                        </td>
                        <td style="height: 26px">
                        </td>
                        <td colspan="7" style="height: 26px">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" Width="55px" OnClick="btnSearch_Click"/></td>
                    </tr>
                    <tr>
                        <td colspan="9" style="height: 16px">
                            &nbsp;
                        </td>
                          
                    </tr>
                    <tr>
                        <td colspan="9">
                        <table border="0" width="70%" ><tr>
                        <td align="left" style="width: 321px">
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="65px" OnClick="btnDelete_Click"  /></td> 
                        <td align="right">
                            <asp:Button ID="btnAdd" runat="server" Text="Add" Width="65px" OnClick="btnAdd_Click"  /></td></tr>
                       <tr><td colspan="2">                       
                           <asp:GridView ID="gvCity" runat="server" AllowPaging="true" AllowSorting="true"  AutoGenerateColumns="False" Width="100%" OnPageIndexChanging="gvCity_PageIndexChanging" OnRowCommand="gvCity_RowCommand1" OnSorting="gvCity_Sorting">
                                <Columns> <asp:TemplateField>
                                        <HeaderTemplate>
                                            <input name="Cbx_Toggle" onclick="toggleAllCheckboexs(this.checked)" type="checkbox" />Select
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            
                                            <input name="Cbx_CityId" type="checkbox" value='<%#Eval("CityId")%>' />
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="City Name" SortExpression="CityName">
                                                   
                                                    <ItemTemplate>
                                                      <asp:LinkButton ID="lnkBtnCityName" Text='<%#Eval("CityName")%>' runat="server" CommandArgument='<%#Eval("CityId")%>' CommandName="Update"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Description">
                                                    <ItemTemplate>
                                                        <%#Eval("CityDescription")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="State Name">
                                                <ItemTemplate>
                                                <%#Eval("StateName") %>                                                
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
                            </asp:GridView> </td></tr>
                            
                        
                   
                    <tr>
                        <td style="width: 189px; height: 14px">
                            <asp:Label ID="lblError" CssClass="lblerror" Visible="false"  runat="server" Text=""></asp:Label></td>
                       <td align="right" style="height: 14px">
                           <asp:Label ID="Lbl_Pageinfo" runat="server" Text=""></asp:Label></td> 
                        </tr> 
                    
                </table>
                 </td></tr>
                 </table>
    
    
    
    </td>
    </tr>
    </table>

</asp:Content>

