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

public partial class Administration_frmManageStatus : System.Web.UI.Page
{
    private clsStatus_Logic objStatus = new clsStatus_Logic();
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

    private void BindData()
    {
        objStatus.pro_StatusName = txtStatusName.Text.Trim();
        objStatus.Sort_On = "";
        if (ViewState["Sort_On"] != null)
            objStatus.Sort_On = ViewState["Sort_On"].ToString() + " " + ViewState["Sort_By"].ToString();
        lblError.Visible = false;
        DataSet dsTemp = objStatus.GetStatus();
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
                this.gvStatus.PageSize = System.Convert.ToInt32(this.txtPageSize.Text);
            }
        }
        gvStatus.DataSource = dtTemp;
        gvStatus.DataBind();
        if (dtTemp.Rows.Count == 0)
        {
            this.Lbl_Pageinfo.Visible = false;
        }
        else
        {
            Int16 intTo;
            Int16 intFrom;
            if (gvStatus.PageSize * (gvStatus.PageIndex + 1) < dtTemp.Rows.Count)
            {
                intTo = System.Convert.ToInt16(gvStatus.PageSize * (gvStatus.PageIndex + 1));
            }
            else
            {
                intTo = System.Convert.ToInt16(dtTemp.Rows.Count);
            }
            intFrom = System.Convert.ToInt16((gvStatus.PageSize * gvStatus.PageIndex) + 1);
            this.Lbl_Pageinfo.Text = "Record(s) " + intFrom + " to " + intTo + " of " + dtTemp.Rows.Count;
            this.Lbl_Pageinfo.Visible = true;
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmAddStatus.aspx");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        strError = "No data matching with your searching criteria";
        gvStatus.PageIndex = 0;
        BindData(); 
    }
    protected void gvStatus_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (ViewState["Sort_On"] != null)
            objStatus.Sort_On = ViewState["Sort_On"].ToString();
        else
            objStatus.Sort_On = "";
        gvStatus.PageIndex = e.NewPageIndex;
        BindData();
    }
    protected void gvStatus_Sorting(object sender, GridViewSortEventArgs e)
    {
        objStatus.Sort_On = e.SortExpression;
        ViewState["Sort_On"] = objStatus.Sort_On;
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
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try{
        if (Request["Cbx_StatusId"] == null)
        {
            lblError.Text = "Please select at least one to delete.";
            lblError.Visible = true;
        }
        else
        {
             objStatus.DeleteStatus(Request["Cbx_StatusId"].ToString());
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
    protected void gvStatus_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToUpper() == "UPDATE")
        {
            Response.Redirect("frmUpdateStatus.aspx?Id=" + e.CommandArgument.ToString());
        }
    }
    protected void gvStatus_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
