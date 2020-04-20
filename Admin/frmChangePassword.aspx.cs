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

public partial class Administration_frmChangePassword : System.Web.UI.Page
{
    clsAdminLogin_Logic objAdminMember = new clsAdminLogin_Logic();
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["UserId"] == null)
        //{
        //    Response.Redirect("frmLogin.aspx");
        //}
        //else
        //{
        //}
        if (!Page.IsPostBack)
        {

        }
       
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            objAdminMember.AdminLoginId = Session["AdminId"].ToString();
            objAdminMember.OldPassword = txtOldPassword.Text.Trim();
            if (objAdminMember.CheckAdminOldPassword() == true)
            {
                if (txtNewPassword.Text.Trim() == txtOldPassword.Text.Trim())
                {
                    lblError.Text = "New Password should not be same as Old Password";
                    lblError.Visible = true;
                    lblSuccess.Visible = false;
                }
                else
                {
                    objAdminMember.Password = txtNewPassword.Text.Trim();
                    objAdminMember.AdminChangeOldPassword();
                    lblSuccess.Visible = true;
                    lblSuccess.Text = "Your Password has been changed successfully!";
                    lblError.Visible = false;

                }
            }
            else
            {
                lblError.Text = "Invalid Old Password";
                lblError.Visible = true;
                lblSuccess.Visible = false;
            }
        }
    }
}
