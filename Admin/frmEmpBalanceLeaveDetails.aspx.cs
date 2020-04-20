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

public partial class Admin_frmEmpLeaveDetails : System.Web.UI.Page
{
    clsEmployee_Logic objEmployee = new clsEmployee_Logic();
    clsLeave_Logic objLeave = new clsLeave_Logic();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["id"] == null)
        {
            Response.Redirect("frmFindBalanceLeaves.aspx");
        }
        if (!IsPostBack)
        {
            BindData();
        }

    }
    void BindData()
    {
        objEmployee.UserName = Request["id"].ToString();
        objEmployee.GetEmployeeDetails();
        txtUserName.Text = Request["id"].ToString();
        txtContactNo.Text = objEmployee.ContactNo;
        txtAddress.Text = objEmployee.Address;
        txtEmailId.Text = objEmployee.EmailId;
        txtDesig.Text = objEmployee.Designation;
        objLeave.UserName = Request["id"].ToString();
        objLeave.GetTotalBalanceDays();
        txtCLBal.Text = objLeave.CasualBalanceLeaves.ToString();
        txtMLBal.Text = objLeave.MedicalBalanceLeaves.ToString();
        txtEL.Text = objLeave.EarnBalanceLeaves.ToString();
        txtHPLBal.Text = objLeave.HalfPaidBalanceLeaves.ToString();
       

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

    }
    protected void btnBack_Click(object sender, EventArgs e)
    {

    }
}
