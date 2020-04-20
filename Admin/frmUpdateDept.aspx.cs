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

public partial class Admin_frmUpdateDept1 : System.Web.UI.Page
{
    clsDept_Logic objDept = new clsDept_Logic();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["Id"] != null)
        {
            ViewState["Id"] = Request["Id"].ToString();
        }
        if (!Page.IsPostBack)
        {
            BindStatus();
            BindDetails();
        }
    }
    void BindStatus()
    {
        DataSet dsStatus = objDept.GetStatusName();
        ddlStatus.DataSource = dsStatus.Tables[0];
        ddlStatus.DataTextField = "StatusName";
        ddlStatus.DataValueField = "StatusId";
        ddlStatus.DataBind();
    }
    void BindDetails()
    {
        objDept.pro_DeptId = Convert.ToInt32(ViewState["Id"].ToString());
        objDept.GetDeptDetails();
        txtDeptName.Text = objDept.pro_DeptName;
        txtDeptDescription.Text = objDept.pro_DeptDescription;
        int Index = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByText(objDept.pro_StatusName));
        if (Index >= 0)
            ddlStatus.Items[Index].Selected = true;


    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        objDept.pro_DeptId = Convert.ToInt32(ViewState["Id"].ToString());
        objDept.pro_DeptName = txtDeptName.Text.Trim();
        objDept.pro_DeptDescription = txtDeptDescription.Text.Trim();
        objDept.pro_StatusName = ddlStatus.SelectedItem.Text;
        objDept.pro_StatusId = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        objDept.UpdateDept();
        Response.Redirect("frmManageDept.aspx");
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmManageDept.aspx");
    }
}
