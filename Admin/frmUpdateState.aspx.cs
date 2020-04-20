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

public partial class Administration_frmUpdateState : System.Web.UI.Page
{
    clsState_Logic objState = new clsState_Logic();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["Id"] != null)
        {
            ViewState["Id"] = Request["Id"].ToString();
        }
        if (!Page.IsPostBack)
        {
            BindStatus();
            BindCountry();            
            BindDetails();
        }
        
    }

    void BindStatus()
    {
        DataSet dsStatus = objState.GetStatusName();
        ddlStatus.DataSource = dsStatus.Tables[0];
        ddlStatus.DataTextField = "StatusName";
        ddlStatus.DataValueField = "StatusId";
        ddlStatus.DataBind();
    
    
    }
    void BindCountry()
    { 
        DataSet dsCountryName = objState.GetCountryName();
            ddlCountryName.DataSource = dsCountryName.Tables[0];
            ddlCountryName.DataTextField = "CountryName";
            ddlCountryName.DataValueField = "CountryId";
            ddlCountryName.DataBind();
    
    
    }
    void BindDetails()
    {
        objState.pro_StateId = Convert.ToInt32(ViewState["Id"].ToString());
        objState.GetStateDetails();
        txtStateName.Text = objState.pro_StateName;
        txtStateDescription.Text = objState.pro_StateDescription;
        //ddlStatus.SelectedValue = objState.pro_StatusName;
        //ddlCountryName.SelectedValue = objState.pro_CountryName;
        int Index = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByText(objState.pro_StatusName));
        if (Index >= 0)
            ddlStatus.Items[Index].Selected = true;
        int Index1 = ddlCountryName.Items.IndexOf(ddlCountryName.Items.FindByText(objState.pro_CountryName));
        if (Index1 >= 0)
            ddlCountryName.Items[Index1].Selected = true;

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        objState.pro_StateId = Convert.ToInt32(ViewState["Id"].ToString());
        objState.pro_StateName = txtStateName.Text.Trim();
        objState.pro_StateDescription = txtStateDescription.Text.Trim();
        objState.pro_StatusName = ddlStatus.SelectedItem.Text;
        objState.pro_StatusId = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        objState.pro_CountryName =ddlCountryName.SelectedItem.Text;
        objState.pro_CountryId = Convert.ToInt32(ddlCountryName.SelectedItem.Value);
        objState.UpdateState();
        Response.Redirect("frmManageState.aspx");
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmManageState.aspx");
    }
}
