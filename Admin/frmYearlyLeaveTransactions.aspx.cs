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

public partial class Admin_frmYearlyLeaveTransactions : System.Web.UI.Page
{
    clsLeave_Logic objYear = new clsLeave_Logic();
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
        GMStart.Attributes.Add("readonly","readonly()");
        GMEnd.Attributes.Add("readonly","readonly()");
    }
    void BindData()
    {
        try
        {
            objYear.Sort_On = "";
            if (ViewState["Sort_On"] != null)
                objYear.Sort_On = ViewState["Sort_On"].ToString() + " " + ViewState["Sort_By"].ToString();
            lblError.Visible = false;
            DataSet dsTemp = objYear.GetMonthlyLeavetransactions();
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
                    this.gvYear.PageSize = System.Convert.ToInt32(this.txtPageSize.Text);
                }
            }
            gvYear.DataSource = dtTemp;
            gvYear.DataBind();
            if (dtTemp.Rows.Count == 0)
            {
                this.Lbl_Pageinfo.Visible = false;
            }
            else
            {
                Int16 intTo;
                Int16 intFrom;
                if (gvYear.PageSize * (gvYear.PageIndex + 1) < dtTemp.Rows.Count)
                {
                    intTo = System.Convert.ToInt16(gvYear.PageSize * (gvYear.PageIndex + 1));
                }
                else
                {
                    intTo = System.Convert.ToInt16(dtTemp.Rows.Count);
                }
                intFrom = System.Convert.ToInt16((gvYear.PageSize * gvYear.PageIndex) + 1);
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
    protected void gvYear_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (ViewState["Sort_On"] != null)
            objYear.Sort_On = ViewState["Sort_On"].ToString();
        else
            objYear.Sort_On = "";
        gvYear.PageIndex = e.NewPageIndex;
        BindData();
    }
    protected void gvYear_Sorting(object sender, GridViewSortEventArgs e)
    {
        objYear.Sort_On = e.SortExpression;
        ViewState["Sort_On"] = objYear.Sort_On;
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string strError;
        objYear.UserName = txtUserName.Text.Trim();
        objYear.StartingDate = GMStart.DateString;
        objYear.EndingDate = GMEnd.DateString;
        strError = "No data matching with your searching criteria";
        gvYear.PageIndex = 0;
        BindData();
    }
}
