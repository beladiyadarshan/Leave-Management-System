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

public partial class Administration_frmManageCity : System.Web.UI.Page
{

    private clsCity_Logic objCity = new clsCity_Logic();
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
            BindCountry();
            BindState();
            BindData();

        }
        string Msg = "Do you want to delete this data?";
        btnDelete.Attributes.Add("onClick", "return confirm('" + Msg + "');");

    }
    void BindCountry()
    {
        DataSet dsCountry = objCity.GetCountry();
        ddlCountryName.DataSource = dsCountry.Tables[0];
        ddlCountryName.DataTextField = "CountryName";
        ddlCountryName.DataValueField="CountryId";
        ddlCountryName.DataBind();
        ddlCountryName.Items.Insert(0,"select");    
    }
    void BindState()
    {
        DataSet dsState = objCity.GetState();
        ddlStateName.DataSource = dsState.Tables[0];
        ddlStateName.DataTextField = "StateName";
        ddlStateName.DataValueField = "StateId";
        ddlStateName.DataBind();
        ddlStateName.Items.Insert(0, "select");    
    }

    void BindData()
    {
        objCity.pro_CityName = txtCityName.Text.Trim();
        objCity.Sort_On = "";
        if (ViewState["Sort_On"] != null)
            objCity.Sort_On = ViewState["Sort_On"].ToString() + " " + ViewState["Sort_By"].ToString();
        lblError.Visible = false;
        DataSet dsTemp = objCity.GetCity();
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
                this.gvCity.PageSize = System.Convert.ToInt32(this.txtPageSize.Text);
            }
        }
        gvCity.DataSource = dtTemp;
        gvCity.DataBind();
        if (dtTemp.Rows.Count == 0)
        {
            this.Lbl_Pageinfo.Visible = false;
        }
        else
        {
            Int16 intTo;
            Int16 intFrom;
            if (gvCity.PageSize * (gvCity.PageIndex + 1) < dtTemp.Rows.Count)
            {
                intTo = System.Convert.ToInt16(gvCity.PageSize * (gvCity.PageIndex + 1));
            }
            else
            {
                intTo = System.Convert.ToInt16(dtTemp.Rows.Count);
            }
            intFrom = System.Convert.ToInt16((gvCity.PageSize * gvCity.PageIndex) + 1);
            this.Lbl_Pageinfo.Text = "Record(s) " + intFrom + " to " + intTo + " of " + dtTemp.Rows.Count;
            this.Lbl_Pageinfo.Visible = true;
        }
    } 

    protected void gvCity_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToUpper() == "UPDATE")
        Response.Redirect("frmUpdateCity.aspx?Id=" + e.CommandArgument.ToString());
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try{
        if (Request["Cbx_CityId"] == null)
        {
            lblError.Text = "Please select at least one to delete.";
            lblError.Visible = true;
        }
        else
        {
            objCity.DeleteCity(Request["Cbx_CityId"].ToString());
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
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmAddCity.aspx");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        strError = "No data matching with your searching criteria";
        gvCity.PageIndex = 0;
        objCity.pro_CountryName = ddlCountryName.SelectedItem.Text;
        objCity.pro_StateName = ddlStateName.SelectedItem.Text;
        BindData();

    }
    protected void gvCity_Sorting(object sender, GridViewSortEventArgs e)
    {
        objCity.Sort_On = e.SortExpression;
        ViewState["Sort_On"] = objCity.Sort_On;
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
    protected void gvCity_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToUpper() == "UPDATE")
        {
            Response.Redirect("frmUpdateCity.aspx?Id=" + e.CommandArgument.ToString());
        }

    }
    protected void gvCity_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (ViewState["Sort_On"] != null)
            objCity.Sort_On = ViewState["Sort_On"].ToString();
        else
            objCity.Sort_On = "";
        gvCity.PageIndex = e.NewPageIndex;
        BindData();

    }
}
