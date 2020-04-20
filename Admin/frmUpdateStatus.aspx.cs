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

public partial class Administration_frmUpdateStatus : System.Web.UI.Page
{
    private clsStatus_Logic objStatus = new clsStatus_Logic();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["Id"] != null)
        {
            ViewState["Id"] = Request["Id"].ToString();
        }
        if (!Page.IsPostBack)
        {
            BindDetails();
        }
    }
    private void BindDetails()
    {
        objStatus.pro_StatusId = Convert.ToInt32(ViewState["Id"].ToString());
        objStatus.GetStatusDetails();
        txtStatusName.Text = objStatus.pro_StatusName;
        txtStatusDescription.Text = objStatus.pro_StatusDescription;
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        objStatus.pro_StatusId = Convert.ToInt32(ViewState["Id"].ToString());
        objStatus.pro_StatusName = txtStatusName.Text.Trim();
        objStatus.pro_StatusDescription = txtStatusDescription.Text.Trim();
        objStatus.UpdateStatus();
        Response.Redirect("frmManageStatus.aspx");
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmManageStatus.aspx");
    }
}
