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

public partial class Employee_frmLeaveApplication : System.Web.UI.Page
{
    clsLeave_Logic objLeave = new clsLeave_Logic();
    clsApplication_Logic objApplicaion = new clsApplication_Logic();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["UserName"] == null)
        {
            Response.Redirect("frmEmployeeLogin.aspx");
        }
        else
            txtUserName.Text = Session["UserName"].ToString();
        if (!IsPostBack)
        {
            BindLeavetype();
            
        }
        GMDStartDate.Attributes.Add("readonly", "readOnly()");
    }

    void BindLeavetype()
    {
        DataSet dsLeavetype = objLeave.GetLeaveType();
        ddlLeaveType.DataSource = dsLeavetype.Tables[0];
        ddlLeaveType.DataTextField = "LeaveTypeName";
        ddlLeaveType.DataValueField = "LeaveTypeId";
        ddlLeaveType.DataBind();
        ddlLeaveType.Items.Insert(0, "Select");
    }

    protected void ddlLeaveType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlLeaveType.SelectedItem.Text != "Select")
        {
            objLeave.UserName = Session["UserName"].ToString();
            objLeave.LeaveTypeId = Convert.ToInt32(ddlLeaveType.SelectedItem.Value);
            int BalaceLeaves = objLeave.GetBalanceDays();
            txtBalanceLeave.Text = BalaceLeaves.ToString();
        }
        else
        txtBalanceLeave.Text = "";
    }
    protected void btnApplyLeave_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(txtNoOfdays.Text) <= Convert.ToInt32(txtBalanceLeave.Text))
        {
            objApplicaion.UserName = Session["UserName"].ToString();
            objApplicaion.LeaveTypeId = Convert.ToInt32(ddlLeaveType.SelectedItem.Value);
            objApplicaion.StartingDate = GMDStartDate.DateString;
            objApplicaion.ApplaiyingDate = System.DateTime.Now.ToString();
            objApplicaion.NoOfDays = Convert.ToInt32(txtNoOfdays.Text);
            //string.Format("{0:yyyy-MM-dd}", System.DateTime.Now.AddDays(1))
            DateTime s = GMDStartDate.Date;
            objApplicaion.EndingDate = (s.AddDays(Convert.ToInt32(txtNoOfdays.Text))).ToString();
            objApplicaion.LeavePurpose = txtPurpose.Text;
            objApplicaion.AddLeaveApplication();
            Response.Redirect("frmLeaveApplicationSuccess.aspx");
        }
        else
        {
            lblError.Visible = true;
            lblError.Text = "No of Days should not be more than Balalnce days";
        }
        }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmEmployeeHome.aspx");
    }
}
