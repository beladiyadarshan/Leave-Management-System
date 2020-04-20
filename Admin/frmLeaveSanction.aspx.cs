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

public partial class Admin_frmLeaveSanction : System.Web.UI.Page
{
    int LeaveTypeId, BalanceLeave;
    clsApplication_Logic objSanction = new clsApplication_Logic();
    clsCommon_Logic objCommon = new clsCommon_Logic();
    clsLeave_Logic objLeave = new clsLeave_Logic();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["Id"] == null)
            Response.Redirect("frmLeaveChecking.aspx");
        else
            ViewState["AppNo"] = Request["Id"].ToString();
        if (!IsPostBack)
        {
            BindStatus();
            Binddata();           
        }
        GMAppDate.Attributes.Add("readOnly", "readOnly()");
        GMStartDate.Attributes.Add("readOnly", "readOnly()");
    }


    void Binddata()
    {
        objSanction.ApplicationNo = Convert.ToInt32(ViewState["AppNo"].ToString());
       DataSet ds= objSanction.GetApplicationLeaveDetails();
       DataRowCollection drc = ds.Tables[0].Rows;
       if (drc.Count > 0)
       {
           txtAppNo.Text = drc[0]["ApplicationNo"].ToString();
           GMAppDate.DateString = drc[0]["ApplyingDate"].ToString();
           txtUserName.Text = (drc[0]["UserName"].ToString());
           txtDays.Text = (drc[0]["NoOfDays"].ToString());
           txtLeaveType.Text = drc[0]["LeaveTypeName"].ToString();
           //ddlLeaveType.SelectedItem.Text = drc[0]["LeaveTypeName"].ToString();
           txtPurpose.Text = drc[0]["LeavePurpose"].ToString();
           GMStartDate.DateString = drc[0]["StartingDate"].ToString();
           //ddlStatus.SelectedItem.Text = drc[0]["StatusName"].ToString();

           int Index = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByText(drc[0]["StatusName"].ToString()));
        if (Index >= 0)
            ddlStatus.Items[Index].Selected = true;

        ViewState["LeaveTypeId"] = drc[0]["LeaveTypeId"].ToString();
        //UsedLeaves = Convert.ToInt32(drc[0]["UsedLeaves"].ToString());
        //BalanceLeave = Convert.ToInt32(drc[0]["BalanceLeave"].ToString());

       }

    }
    void BindStatus()
    {
        DataSet dsStatus = objCommon.GetStatusName();
        ddlStatus.DataSource = dsStatus.Tables[0];
        ddlStatus.DataTextField = "StatusName";
        ddlStatus.DataValueField = "StatusId";
        ddlStatus.DataBind();
        ddlStatus.Items.Insert(0, "Select");      
    
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        objLeave.ApplicationNo = Convert.ToInt32(ViewState["AppNo"].ToString());
        if (objLeave.CheckAppNoInLeaveDetails())
        {            
            if (ddlStatus.SelectedItem.Text != "Select")
            {
                objSanction.ApplicationNo = Convert.ToInt32(ViewState["AppNo"].ToString());
                objSanction.AppStatusId = Convert.ToInt32(ddlStatus.SelectedItem.Value);

                objSanction.UpdateApplicationData();
                if (ddlStatus.SelectedItem.Text == "Accepted")
                {
                    objLeave.ApplicationNo = Convert.ToInt32(ViewState["AppNo"].ToString());
                    objLeave.AppStatusId = Convert.ToInt32(ddlStatus.SelectedItem.Value);
                    objLeave.UserName = txtUserName.Text;
                    objLeave.LeaveTypeId =Convert.ToInt32(ViewState["LeaveTypeId"]);
                    BalanceLeave = objLeave.GetBalanceDays() - Convert.ToInt32(txtDays.Text);
                    objLeave.BalanceLeaves = BalanceLeave;
                    objLeave.AddLeaveDetails();
                    Response.Redirect("frmLeaveChecking.aspx");
                }
            }
        }
        else
        {
            lblError.Visible = true;
            lblError.Text = "Sorry you already given status as Accepted";
        }

    }
}
