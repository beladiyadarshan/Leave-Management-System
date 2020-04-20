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

public partial class Employee_frmEmployeeLogin : System.Web.UI.Page
{
    clsEmployeeLogin_Logic LoginObj=new clsEmployeeLogin_Logic ();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
         try
        {
            LoginObj.UserName  = txtLoginId.Text.Trim();
            LoginObj.Password = txtPassword.Text.Trim();
            DataSet dsEmpLoginDetail = LoginObj.GetEmpLoginDetails ();
            DataRowCollection drc = dsEmpLoginDetail.Tables[0].Rows;
            if (drc.Count > 0)
            {
                lblError.Visible = false;
                DataRow dr = drc[0];
                Session["UserName"] = dr["UserName"].ToString();
                //Session["EmpLoginId"] = dr["EmpLoginId"];
                
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
        Response.Redirect("frmEmployeeHome.aspx");

    }

    protected void LnkNewUser_Click(object sender, EventArgs e)
    {
        //Response.Redirect("frmEmployeeRegistration.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }
}
