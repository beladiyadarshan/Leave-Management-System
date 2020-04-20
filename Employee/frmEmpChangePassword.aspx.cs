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

public partial class Employee_frmEmpChangePassword : System.Web.UI.Page
{
    clsEmployeeLogin_Logic LoginObj = new clsEmployeeLogin_Logic();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
         Page.Validate();
        if (Page.IsValid)
        {
           LoginObj .UserName = Session["UserName"].ToString();
            LoginObj.OldPassword = txtOldPassword.Text.Trim();
            if (LoginObj.CheckEmpOldPassword() == true)
            {
                if (txtNewPassword.Text.Trim() == txtOldPassword.Text.Trim())
                {
                    lblError.Text = "New Password should not be same as Old Password";
                    lblError.Visible = true;
                    lblSuccess.Visible = false;
                }
                else
                {
                    LoginObj .Password = txtNewPassword.Text.Trim();
                    LoginObj.EmpChangeOldPassword ();
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

