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

public partial class Admin_frmNextDayEmpList : System.Web.UI.Page
{
    clsEmployee_Logic objNext = new clsEmployee_Logic();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds = objNext.GetNextDayEmpList();
            gvNextday.DataSource = ds.Tables[0];
            gvNextday.DataBind();
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmAdminHome.aspx");

    }
}
