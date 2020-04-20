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

public partial class Employee_frmApllicationStatus : System.Web.UI.Page
{
    clsApplication_Logic objApplication = new clsApplication_Logic();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            objApplication.UserName = Session["UserName"].ToString();
            DataSet ds=objApplication.GetApplicationStatus();
            gvAppStatus.DataSource = ds.Tables[0];
            gvAppStatus.DataBind();
        }
    }
}
