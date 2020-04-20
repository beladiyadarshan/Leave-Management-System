<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterMenu.master" AutoEventWireup="true" CodeFile="frmManageStatus.aspx.cs"
    Inherits="Administration_frmManageStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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
        <td colspan="4" class="LoginTitle">Manage Status</td>
        </tr>
                    
        <tr>
        <td style="width: 13%">Status Name</td>
        <td align ="center"  style="width: 2%">:</td>
        <td style="width: 18%"><asp:TextBox ID="txtStatusName" runat="server"></asp:TextBox></td>
        <td></td>
        </tr>
                    
        <tr>
        <td>Page Size</td>
        <td align ="center" >:</td>
        <td><asp:TextBox ID="txtPageSize" OnKeypress="return onlyNumbers(event)" runat="server" Width="50px"></asp:TextBox>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtPageSize"
        CssClass="lblerror" ErrorMessage="Invalid Number" MaximumValue="999" MinimumValue="1"
        Style="position: relative" Type="Integer"></asp:RangeValidator></td>
        <td></td>
        </tr>
                    
        <tr>
        <td></td>
        <td></td>
        <td><asp:Button ID="btnSearch" runat="server" Text="Search" Width="55px" Style="position: relative" OnClick="btnSearch_Click" /></td>
        <td></td>
        </tr>
                    
        <tr>
        <td colspan="4"></td>
        </tr>
        <tr>
        <td colspan="4">
        <table width="50%" border="0" cellpadding="0" cellspacing="0">
        <tr>
        <td width="50%">
        <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="65px" Style="position: relative" CausesValidation="False" OnClick="btnDelete_Click" /></td>
        <td align="right">
        <asp:Button ID="btnAdd" runat="server" Text="Add" Width="65px" Style="position: relative" OnClick="btnAdd_Click" CausesValidation="False" /></td>
        </tr>
        
        <tr>
        <td colspan="2">
        <asp:GridView ID="gvStatus" runat="server" AutoGenerateColumns="False" Width="100%"
        Style="position: relative" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="gvStatus_PageIndexChanging" OnSorting="gvStatus_Sorting" OnRowCommand="gvStatus_RowCommand" OnSelectedIndexChanged="gvStatus_SelectedIndexChanged">
        <Columns>
        <asp:TemplateField>
          <HeaderTemplate>              
        <input name="Cbx_Toggle" onclick="toggleAllCheckboexs(this.checked)" type="checkbox" />Select
          </HeaderTemplate>
        <ItemTemplate>
        <input name="Cbx_StatusId" type="checkbox" value='<%#Eval("StatusId")%>' />
        </ItemTemplate>
        <HeaderStyle Width="5%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status Name" SortExpression="StatusName">
                                                
        <HeaderStyle Width="30%" />
        <ItemTemplate>
        <asp:LinkButton ID="lnkBtnStatusName" Text='<%#Eval("StatusName")%>' runat="server" CommandArgument='<%#Eval("StatusId")%>' CommandName="Update"></asp:LinkButton>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description">
        <ItemTemplate>
        <%#Eval("StatusDescription")%>
        </ItemTemplate>
        </asp:TemplateField>
        </Columns>
        </asp:GridView>
        </td>
        </tr>
                               
        <tr>
        <td width="45%">
        <asp:Label ID="lblError" runat="server"  Visible="false" CssClass="lblerror"></asp:Label></td>
        <td align="right" >
        <asp:Label ID="Lbl_Pageinfo" runat="server" Style="position: relative"></asp:Label></td>
        </tr>
        </table>
        </td>
        </tr>
        
        <tr>
        <td colspan="4"></td>
        </tr>
        </table>
        </td>
        </tr>
    </table>
</asp:Content>
