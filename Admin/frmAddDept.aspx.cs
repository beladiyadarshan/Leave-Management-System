using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Admin_frmAddDept : System.Web.UI.Page
{
    clsDept_Logic objDept = new clsDept_Logic();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
        }
    }

   
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        objDept.pro_DeptName = txtDeptName.Text.Trim();
        objDept.pro_DeptDescription = txtDeptDescription.Text.Trim();
       // objDept.pro_StatusName = ddlStatus.SelectedItem.Text;
        //objDept.pro_StatusId = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        objDept.AddDept();
        Response.Redirect("frmManageDept.aspx");
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmManageDept.aspx");
    }
}
