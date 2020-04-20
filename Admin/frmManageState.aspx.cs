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

public partial class Administration_frmManageState : System.Web.UI.Page
{
    private clsState_Logic objState = new clsState_Logic();
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
            BindDataToDDL();
            BindData();
            
        }
        string Msg = "Do you want to delete this data?";
        btnDelete.Attributes.Add("onClick", "return confirm('" + Msg + "');");
    }

    private void BindData()
    {
        objState.pro_StateName = txtStateName.Text.Trim();
        
        objState.Sort_On = "";
        if (ViewState["Sort_On"] != null)
            objState.Sort_On = ViewState["Sort_On"].ToString() + " " + ViewState["Sort_By"].ToString();
        lblError.Visible = false;
        DataSet dsTemp = objState.GetState();
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
                this.gvState.PageSize = System.Convert.ToInt32(this.txtPageSize.Text);
            }
        }
        gvState.DataSource = dtTemp;
        gvState.DataBind();
        if (dtTemp.Rows.Count == 0)
        {
            this.Lbl_Pageinfo.Visible = false;
        }
        else
        {
            Int16 intTo;
            Int16 intFrom;
            if (gvState.PageSize * (gvState.PageIndex + 1) < dtTemp.Rows.Count)
            {
                intTo = System.Convert.ToInt16(gvState.PageSize * (gvState.PageIndex + 1));
            }
            else
            {
                intTo = System.Convert.ToInt16(dtTemp.Rows.Count);
            }
            intFrom = System.Convert.ToInt16((gvState.PageSize * gvState.PageIndex) + 1);
            this.Lbl_Pageinfo.Text = "Record(s) " + intFrom + " to " + intTo + " of " + dtTemp.Rows.Count;
            this.Lbl_Pageinfo.Visible = true;
        }
    }
    void BindDataToDDL()
    {
        DataSet dsCountryName = objState.GetCountryName();
        ddlCountryName.DataSource = dsCountryName.Tables[0];
        ddlCountryName.DataTextField = "CountryName";
        ddlCountryName.DataValueField = "CountryId";
        ddlCountryName.DataBind();
        ddlCountryName.Items.Insert(0, "select");
    
    }   
   
    
    protected void gvState_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void gvState_Sorting1(object sender, GridViewSortEventArgs e)
    {
        objState.Sort_On = e.SortExpression;
        ViewState["Sort_On"] = objState.Sort_On;
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
    protected void gvState_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {
        if (ViewState["Sort_On"] != null)
            objState.Sort_On = ViewState["Sort_On"].ToString();
        else
            objState.Sort_On = "";
        gvState.PageIndex = e.NewPageIndex;
        BindData();
    }
    protected void btnSearch_Click1(object sender, EventArgs e)
    {
        
        strError = "No data matching with your searching criteria";
        if (ddlCountryName.SelectedItem.Text != "select")
        {
            objState.pro_CountryName = ddlCountryName.SelectedItem.Text;
            objState.pro_CountryId = Convert.ToInt32(ddlCountryName.SelectedItem.Value);
        }

        gvState.PageIndex = 0;
        BindData();
    }
    protected void btnDelete_Click1(object sender, EventArgs e)
    {
        try{
        if (Request["Cbx_StateId"] == null)
        {
            lblError.Text = "Please select at least one to delete.";
            lblError.Visible = true;
        }
        else
        {
            objState.DeleteState(Request["Cbx_StateId"].ToString());
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
    protected void btnAdd_Click1(object sender, EventArgs e)
    {
        Response.Redirect("frmAddState.aspx");
    }
    //protected void gvState_RowUpdating(object sender, GridViewUpdateEventArgs e)
    //{

    //}
    protected void gvState_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToUpper() == "UPDATE")
        {
            Response.Redirect("frmUpdateState.aspx?Id=" + e.CommandArgument.ToString());
        }

    }
}
