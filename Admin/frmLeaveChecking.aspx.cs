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

public partial class Admin_frmLeaveChecking : System.Web.UI.Page
{
    clsLeave_Logic objLeave = new clsLeave_Logic();
    clsApplication_Logic objApp = new clsApplication_Logic();
    private string strError = "No Data Available";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminId"] == null)
        {
            Response.Redirect("frmAdminLogin.aspx");
        }
        else
        {

        }
        if (!Page.IsPostBack)
        {
            this.txtPageSize.Text = "10";
            BindLeavetype();
            BindData();
        }
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
    void BindData()
    {
        try
        {
            
            objApp.Sort_On = "";
            if (ViewState["Sort_On"] != null)
                objApp.Sort_On = ViewState["Sort_On"].ToString() + " " + ViewState["Sort_By"].ToString();
            lblError.Visible = false;
            DataSet dsTemp = objApp.GetApplicationData();
            DataTable dtTemp = dsTemp.Tables[0];
            if (dtTemp.Rows.Count > 0)
            {
                lblError.Visible = false;
                //btnDelete.Visible = true;
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = strError;
               // btnDelete.Visible = false;
            }
            if (this.txtPageSize.Text != "")
            {
                if (System.Convert.ToInt32(this.txtPageSize.Text) > 0)
                {
                    this.gvLeaveCheck.PageSize = System.Convert.ToInt32(this.txtPageSize.Text);
                }
            }
            gvLeaveCheck.DataSource = dtTemp;
            gvLeaveCheck.DataBind();
            if (dtTemp.Rows.Count == 0)
            {
                this.Lbl_Pageinfo.Visible = false;
            }
            else
            {
                Int16 intTo;
                Int16 intFrom;
                if (gvLeaveCheck.PageSize * (gvLeaveCheck.PageIndex + 1) < dtTemp.Rows.Count)
                {
                    intTo = System.Convert.ToInt16(gvLeaveCheck.PageSize * (gvLeaveCheck.PageIndex + 1));
                }
                else
                {
                    intTo = System.Convert.ToInt16(dtTemp.Rows.Count);
                }
                intFrom = System.Convert.ToInt16((gvLeaveCheck.PageSize * gvLeaveCheck.PageIndex) + 1);
                this.Lbl_Pageinfo.Text = "Record(s) " + intFrom + " to " + intTo + " of " + dtTemp.Rows.Count;
                this.Lbl_Pageinfo.Visible = true;
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            lblError.Visible = true;
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string strError;
        
        strError = "No data matching with your searching criteria";
        gvLeaveCheck.PageIndex = 0;
        if (ddlLeaveType.SelectedItem.Text != "Select")
        {
            objApp.LeaveTypeId = Convert.ToInt32(ddlLeaveType.SelectedItem.Value);
        }
        BindData();
    }
    protected void gvLeaveCheck_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (ViewState["Sort_On"] != null)
            objLeave.Sort_On = ViewState["Sort_On"].ToString();
        else
            objLeave.Sort_On = "";
        gvLeaveCheck.PageIndex = e.NewPageIndex;
        BindData();
    }
    protected void gvLeaveCheck_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToUpper() == "UPDATE")
        {
            Response.Redirect("frmLeaveSanction.aspx?Id=" + e.CommandArgument.ToString());
        }
    }
    protected void gvLeaveCheck_Sorting(object sender, GridViewSortEventArgs e)
    {
        objLeave.Sort_On = e.SortExpression;
        ViewState["Sort_On"] = objLeave.Sort_On;
        if (ViewState["Sort_By"] == null)
            ViewState["Sort_By"] = "Asc";
        if (ViewState["Sort_By"].ToString() == "Asc")
        {
            ViewState["Sort_By"] = "Desc";
        }
        else
        {
            ViewState["Sort_By"] = "Asc";
        }

        BindData();
  
    }
}
