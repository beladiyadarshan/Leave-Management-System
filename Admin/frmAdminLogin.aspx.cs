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

public partial class Admin_frmAdminLogin : System.Web.UI.Page
{
    clsAdminLogin_Logic objAmin = new clsAdminLogin_Logic();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            objAmin.AdminLoginId = txtLoginId.Text.Trim();
            objAmin.Password = txtPassword.Text.Trim();
            DataSet dsAdminLoginDetail = objAmin.GetAdminLoginDetails();
            DataRowCollection drc = dsAdminLoginDetail.Tables[0].Rows;
            if (drc.Count > 0)
            {
                lblError.Visible = false;
                DataRow dr = drc[0];
                Session["AdminId"] = dr["AdminLoginId"].ToString();
                Response.Redirect("frmAdminHome.aspx");
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Invalid Login ID/Password";
            }
        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message.ToString();
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }
}
