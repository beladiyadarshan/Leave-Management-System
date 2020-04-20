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

public partial class Admin_frmMonthlyLeaveTransactions : System.Web.UI.Page
{
    clsLeave_Logic objMonth = new clsLeave_Logic();
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

            BindData();
        }
    }
    void BindData()
    {
        try
        {
            
            objMonth.Sort_On = "";
            if (ViewState["Sort_On"] != null)
                objMonth.Sort_On = ViewState["Sort_On"].ToString() + " " + ViewState["Sort_By"].ToString();
            lblError.Visible = false;
            DataSet dsTemp = objMonth.GetMonthlyLeavetransactions();
            DataTable dtTemp = dsTemp.Tables[0];
            //if (dtTemp.Rows.Count > 0)
            //{
            //    lblError.Visible = false;
            //    btnDelete.Visible = true;
            //}
            //else
            //{
            //    lblError.Visible = true;
            //    lblError.Text = strError;
            //    btnDelete.Visible = false;
            //}
            if (this.txtPageSize.Text != "")
            {
                if (System.Convert.ToInt32(this.txtPageSize.Text) > 0)
                {
                    this.gvMonth.PageSize = System.Convert.ToInt32(this.txtPageSize.Text);
                }
            }
            gvMonth.DataSource = dtTemp;
            gvMonth.DataBind();
            if (dtTemp.Rows.Count == 0)
            {
                this.Lbl_Pageinfo.Visible = false;
            }
            else
            {
                Int16 intTo;
                Int16 intFrom;
                if (gvMonth.PageSize * (gvMonth.PageIndex + 1) < dtTemp.Rows.Count)
                {
                    intTo = System.Convert.ToInt16(gvMonth.PageSize * (gvMonth.PageIndex + 1));
                }
                else
                {
                    intTo = System.Convert.ToInt16(dtTemp.Rows.Count);
                }
                intFrom = System.Convert.ToInt16((gvMonth.PageSize * gvMonth.PageIndex) + 1);
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
        objMonth.UserName = txtUserName.Text.Trim();
        if(ddlStart.SelectedItem.Text!="Select")
        objMonth.StartingMonth = ddlStart.SelectedItem.Value;
    if (ddlEnd.SelectedItem.Text != "Select")
        objMonth.EndingMonth = ddlEnd.SelectedItem.Value;
        strError = "No data matching with your searching criteria";
        gvMonth.PageIndex = 0;
        BindData();
    }
    protected void gvMonth_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (ViewState["Sort_On"] != null)
            objMonth.Sort_On = ViewState["Sort_On"].ToString();
        else
            objMonth.Sort_On = "";
        gvMonth.PageIndex = e.NewPageIndex;
        BindData();
    }
    protected void gvMonth_Sorting(object sender, GridViewSortEventArgs e)
    {
        objMonth.Sort_On = e.SortExpression;
        ViewState["Sort_On"] = objMonth.Sort_On;
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
