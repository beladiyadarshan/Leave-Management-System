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

public partial class Administration_frmUpdateCountry : System.Web.UI.Page
{
    clsCountry_Logic objCountry = new clsCountry_Logic();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["Id"] != null)
        {
            ViewState["Id"] = Request["Id"].ToString();
        }
        if (!Page.IsPostBack)
        {
            BindStatus();
            BindDetails();
        }
    }
    void BindStatus()
    {
        DataSet dsStatus = objCountry.GetStatusName();
        ddlStatus.DataSource = dsStatus.Tables[0];
        ddlStatus.DataTextField = "StatusName";
        ddlStatus.DataValueField = "StatusId";
        ddlStatus.DataBind();
    }
    void BindDetails()
    {
        objCountry.pro_CountryId = Convert.ToInt32(ViewState["Id"].ToString());
        objCountry.GetCountryDetails();
        txtCountryName.Text = objCountry.pro_CountryName;
        txtCountryDescription.Text = objCountry.pro_CountryDescription;
        int Index = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByText(objCountry.pro_StatusName));
        if (Index >= 0)
            ddlStatus.Items[Index].Selected = true;

    
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        objCountry.pro_CountryId = Convert.ToInt32(ViewState["Id"].ToString());
        objCountry.pro_CountryName = txtCountryName.Text.Trim();
        objCountry.pro_CountryDescription = txtCountryDescription.Text.Trim();
        objCountry.pro_StatusName = ddlStatus.SelectedItem.Text;
        objCountry.pro_StatusId =Convert.ToInt32(ddlStatus.SelectedItem.Value);
        objCountry.UpdateCountry();
        Response.Redirect("frmManageCountry.aspx");
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmManageCountry.aspx");
    }
}
