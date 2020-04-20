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

public partial class Administration_frmAddCountry : System.Web.UI.Page
{
    clsCountry_Logic objCountry = new clsCountry_Logic();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindStatus();
        }

    }
    void BindStatus()
    {
        DataSet dsStatus = objCountry.GetStatusName();
        ddlStatus.DataSource = dsStatus.Tables[0];
        ddlStatus.DataTextField = "StatusName";
        ddlStatus.DataValueField = "StatusId";
        ddlStatus.DataBind();
        ddlStatus.Items.Insert(0, "Select");
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        objCountry.pro_CountryName = txtCountryName.Text.Trim();
        objCountry.pro_CountryDescription = txtCountryDescription.Text.Trim();
        objCountry.pro_StatusName = ddlStatus.SelectedValue;
        objCountry.pro_StatusId =Convert.ToInt32(ddlStatus.SelectedItem.Value);
        objCountry.AddCountry();
        Response.Redirect("frmManageCountry.aspx");
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmManageCountry.aspx");
    }
}
