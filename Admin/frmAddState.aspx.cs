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

public partial class Administration_frmAddState : System.Web.UI.Page
{
    clsState_Logic objState = new clsState_Logic();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindStatus();
            BindCountry();
        }
    }
    void BindStatus()
    {
        DataSet dsStatus = objState.GetStatusName();
        ddlStatus.DataSource = dsStatus.Tables[0];
        ddlStatus.DataTextField = "StatusName";
        ddlStatus.DataValueField = "StatusId";
        ddlStatus.DataBind();
        ddlStatus.Items.Insert(0, "Select");
    }
    void BindCountry()
    {
        DataSet dsCountry = objState.GetCountryName();
        ddlCountryName.DataSource = dsCountry.Tables[0];
        ddlCountryName.DataTextField = "CountryName";
        ddlCountryName.DataValueField = "CountryId";
        ddlCountryName.DataBind();
        ddlCountryName.Items.Insert(0, "Select");
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        objState.pro_StateName = txtStateName.Text.Trim();
        objState.pro_StateDescription = txtStateDescription.Text.Trim();
        objState.pro_CountryName = ddlCountryName.SelectedItem.Text;
        objState.pro_CountryId =Convert.ToInt32(ddlCountryName.SelectedItem.Value);
        objState.pro_StatusName = ddlStatus.SelectedValue;
        objState.pro_StatusId = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        objState.AddState();
        Response.Redirect("frmManageState.aspx");
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmManageState.aspx");
    }
}
