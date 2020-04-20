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

public partial class Admin_frmManageDept : System.Web.UI.Page
{
    private clsDept_Logic objDept = new clsDept_Logic();
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
            BindData();
        }
        string Msg = "Do you want to delete this data?";
        btnDelete.Attributes.Add("onClick", "return confirm('" + Msg + "');");
    }
    void BindData()
    {
        try
        {
            objDept.pro_DeptName = txtDeptName.Text.Trim();
            objDept.Sort_On = "";
            if (ViewState["Sort_On"] != null)
                objDept.Sort_On = ViewState["Sort_On"].ToString() + " " + ViewState["Sort_By"].ToString();
            lblError.Visible = false;
            DataSet dsTemp = objDept.GetDept();
            DataTable dtTemp = dsTemp.Tables[0];
            if (dtTemp.Rows.Count > 0)
            {
                lblError.Visible = false;
                btnDelete.Visible = true;
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = strError;
                btnDelete.Visible = false;
            }
            if (this.txtPageSize.Text != "")
            {
                if (System.Convert.ToInt32(this.txtPageSize.Text) > 0)
                {
                    this.gvDept.PageSize = System.Convert.ToInt32(this.txtPageSize.Text);
                }
            }
            gvDept.DataSource = dtTemp;
            gvDept.DataBind();
            if (dtTemp.Rows.Count == 0)
            {
                this.Lbl_Pageinfo.Visible = false;
            }
            else
            {
                Int16 intTo;
                Int16 intFrom;
                if (gvDept.PageSize * (gvDept.PageIndex + 1) < dtTemp.Rows.Count)
                {
                    intTo = System.Convert.ToInt16(gvDept.PageSize * (gvDept.PageIndex + 1));
                }
                else
                {
                    intTo = System.Convert.ToInt16(dtTemp.Rows.Count);
                }
                intFrom = System.Convert.ToInt16((gvDept.PageSize * gvDept.PageIndex) + 1);
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
    protected void btnGo_Click(object sender, EventArgs e)
    {
        strError = "No data matching with your searching criteria";
        gvDept.PageIndex = 0;
        BindData();
    }
    protected void btndelete_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request["Cbx_DeptId"] == null)
            {
                lblError.Text = "Please select at least one to delete.";
                lblError.Visible = true;
            }
            else
            {
                objDept.DeleteDept(Request["Cbx_DeptId"].ToString());
                lblError.Visible = false;
                BindData();
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            lblError.Visible = true;
        }
    }
    protected void btnadd_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmAddDept.aspx");
    }
    protected void gvDept_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (ViewState["Sort_On"] != null)
            objDept.Sort_On = ViewState["Sort_On"].ToString();
        else
            objDept.Sort_On = "";
        gvDept.PageIndex = e.NewPageIndex;
        BindData();
    }
    protected void gvDept_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToUpper() == "UPDATE")
        {
            Response.Redirect("frmUpdateDept.aspx?Id=" + e.CommandArgument.ToString());
        }
    }
    protected void gvDept_Sorting(object sender, GridViewSortEventArgs e)
    {
        objDept.Sort_On = e.SortExpression;
        ViewState["Sort_On"] = objDept.Sort_On;
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
