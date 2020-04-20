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

public partial class Administration_frmAddStatus : System.Web.UI.Page
{
    clsStatus_Logic objStatus = new clsStatus_Logic();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        objStatus.pro_StatusName = txtStatusName.Text.Trim();
        objStatus.pro_StatusDescription = txtStatusDescription.Text.Trim();
        objStatus.AddStatus();
        Response.Redirect("frmManageStatus.aspx");
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmManageStatus.aspx");
    }
}
