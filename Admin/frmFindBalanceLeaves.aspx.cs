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

public partial class Admin_frmFindBalanceLeaves : System.Web.UI.Page
{
    clsLeave_Logic objLeave = new clsLeave_Logic();
    clsEmployee_Logic objEmp = new clsEmployee_Logic();
    private string strError = "No Data Available";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    void BindData()
    {
        try
        {

            objEmp.Sort_On = "";
            if (ViewState["Sort_On"] != null)
                objEmp.Sort_On = ViewState["Sort_On"].ToString() + " " + ViewState["Sort_By"].ToString();
            lblError.Visible = false;
            DataSet dsTemp = objEmp.GetEmployee();
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
                //btnDelete.Visible = false;
            }
            if (this.txtPageSize.Text != "")
            {
                if (System.Convert.ToInt32(this.txtPageSize.Text) > 0)
                {
                    this.gvLeave.PageSize = System.Convert.ToInt32(this.txtPageSize.Text);
                }
            }
            gvLeave.DataSource = dtTemp;
            gvLeave.DataBind();
            if (dtTemp.Rows.Count == 0)
            {
                this.Lbl_Pageinfo.Visible = false;
            }
            else
            {
                Int16 intTo;
                Int16 intFrom;
                if (gvLeave.PageSize * (gvLeave.PageIndex + 1) < dtTemp.Rows.Count)
                {
                    intTo = System.Convert.ToInt16(gvLeave.PageSize * (gvLeave.PageIndex + 1));
                }
                else
                {
                    intTo = System.Convert.ToInt16(dtTemp.Rows.Count);
                }
                intFrom = System.Convert.ToInt16((gvLeave.PageSize * gvLeave.PageIndex) + 1);
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
        strError = "No data matching with your searching criteria";
        gvLeave.PageIndex = 0;
        objEmp.UserName = txtUserName.Text.Trim();
        BindData();
    }
    protected void gvLeave_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (ViewState["Sort_On"] != null)
            objEmp.Sort_On = ViewState["Sort_On"].ToString();
        else
            objEmp.Sort_On = "";
        gvLeave.PageIndex = e.NewPageIndex;
        BindData();
    }
    protected void gvLeave_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToUpper() == "UPDATE")
        {
            Response.Redirect("frmEmpBalanceLeaveDetails.aspx?Id=" + e.CommandArgument.ToString());
        }
   }
    protected void gvLeave_Sorting(object sender, GridViewSortEventArgs e)
    {
        objEmp.Sort_On = e.SortExpression;
        ViewState["Sort_On"] = objEmp.Sort_On;
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
