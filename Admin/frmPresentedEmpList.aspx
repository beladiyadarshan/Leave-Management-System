<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterMenu.master" AutoEventWireup="true" CodeFile="frmPresentedEmpList.aspx.cs" Inherits="Admin_frmPresentedEmpList" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" height="373" class="publicloginTable">
    <tr>
    <td valign="top" align="left">
       <table width="100%" class="admintablestyle">                    
        <tr>
        <td class="LoginTitle">
            List of Employees Present Today</td>
        </tr>
        <%--<tr>
        <td>
        Select Your ClientId:
        <asp:DropDownList ID="ddlClientId" runat ="server" AutoPostBack ="true" OnSelectedIndexChanged="ddlClientId_SelectedIndexChanged" ></asp:DropDownList>
        </td>
        </tr>--%>
        <tr><td></td></tr>
        <tr>
        <td>
          <asp:GridView ID="gvPresent" AutoGenerateColumns="false" runat="server">
          <Columns >
           <asp:TemplateField HeaderText ="EmpId" >
          <ItemTemplate >
          <%#Eval("EmpId")%>
          </ItemTemplate>
          </asp:TemplateField>
          
          <asp:TemplateField HeaderText ="EmpName" >
          <ItemTemplate >
          <%#Eval("EmpName")%>
          </ItemTemplate>
          </asp:TemplateField>
          
          <asp:TemplateField HeaderText ="EmpDesigName" >
          <ItemTemplate >
          <%#Eval("EmpDesigName")%>
          </ItemTemplate>
          </asp:TemplateField>
                
          
           <asp:TemplateField HeaderText ="EmailId" >
          <ItemTemplate >
          <%#Eval("EmailId")%>
          </ItemTemplate>
          </asp:TemplateField>
            <asp:TemplateField HeaderText ="ContactNo" >
          <ItemTemplate >
          <%#Eval("ContactNo")%>
          </ItemTemplate>
          </asp:TemplateField>
          
          
          
             <asp:TemplateField HeaderText ="Address" >
          <ItemTemplate >
          <%#Eval("Address")%>
          </ItemTemplate>
          </asp:TemplateField>
          
           
            
          
          
          
          
          </Columns>
    </asp:GridView>
        </td>
        </tr>
           <tr>
               <td>
                   &nbsp;<asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" /></td>
           </tr>
        </table>
        </td>
        </tr>
    </table>

</asp:Content>

