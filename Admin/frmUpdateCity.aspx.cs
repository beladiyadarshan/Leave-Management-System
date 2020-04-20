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

public partial class Administration_frmUpdateCity : System.Web.UI.Page
{
    clsCity_Logic objCity = new clsCity_Logic();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["Id"] != null)
        {
            ViewState["Id"] = Request["Id"].ToString();
        }
        else
        {
            Response.Redirect("frmManageCity.aspx");
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
        DataSet dsStatus = objCity.GetStatus();
        ddlStatus.DataSource = dsStatus.Tables[0];
        ddlStatus.DataTextField = "StatusName";
        ddlStatus.DataValueField = "StatusId";
        ddlStatus.DataBind();
        ddlStatus.Items.Insert(0, "select");      
    }

    void BindCountry()
    {
        DataSet dsCountry = objCity.GetCountry();
        ddlCountryName.DataSource = dsCountry.Tables[0];
        ddlCountryName.DataTextField = "CountryName";
        ddlCountryName.DataValueField = "CountryId";
        ddlCountryName.DataBind();
        ddlCountryName.Items.Insert(0, "select");        
    }
    void BindState()
    {
        DataSet dsState= objCity.GetState();
        ddlStateName.DataSource = dsState.Tables[0];
        ddlStateName.DataTextField = "StateName";
        ddlStateName.DataValueField = "StateId";
        ddlStateName.DataBind();
        ddlStateName.Items.Insert(0, "select");  
    }

    void BindDetails()
    {
        objCity.pro_CityId = Convert.ToInt32(ViewState["Id"].ToString());
        objCity.GetCityDetails();
        txtCityName.Text = objCity.pro_CityName;
        txtCityDescription.Text = objCity.pro_CityDescription;
        int Index = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByText(objCity.pro_StatusName));
        if (Index >= 0)
            ddlStatus.Items[Index].Selected = true;

        int Index1 = ddlCountryName.Items.IndexOf(ddlCountryName.Items.FindByText(objCity.pro_CountryName));
        if (Index1 >= 0)
           ddlCountryName.Items[Index1].Selected = true;
       objCity.pro_CountryId = Convert.ToInt32(ddlCountryName.SelectedItem.Value);
       BindState();
        int Index2 = ddlStateName.Items.IndexOf(ddlStateName.Items.FindByText(objCity.pro_StateName));
        if (Index2 >= 0)
           ddlStateName.Items[Index2].Selected = true;


    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        objCity.pro_CityId = Convert.ToInt32(ViewState["Id"].ToString());
        objCity.pro_CityName = txtCityName.Text.Trim();
        objCity.pro_CityDescription = txtCityDescription.Text.Trim();
        objCity.pro_StatusName = ddlStatus.SelectedItem.Text;
        objCity.pro_StatusId = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        objCity.pro_StateName = ddlStateName.SelectedItem.Text;
        objCity.pro_StateId = Convert.ToInt32(ddlStateName.SelectedItem.Value);
        objCity.pro_CountryName = ddlCountryName.SelectedItem.Text;
        objCity.pro_CountryId = Convert.ToInt32(ddlCountryName.SelectedItem.Value);
        objCity.UpdateCity();
        Response.Redirect("frmManageCity.aspx");
        //if (ddlCountryName.SelectedItem.Text != "select")
        //{
        //    if (ddlStateName.SelectedItem.Text != "select")
        //    {
        //        if (ddlStatus.SelectedItem.Text != "select")
        //        {
        //            objCity.pro_StateName = ddlStateName.SelectedItem.Text;
        //            objCity.pro_StateId = Convert.ToInt32(ddlStateName.SelectedItem.Value);
        //            objCity.pro_CountryName = ddlCountryName.SelectedItem.Text;
        //            objCity.pro_CountryId = Convert.ToInt32(ddlCountryName.SelectedItem.Value);
        //            objCity.UpdateCity();
        //            Response.Redirect("frmManageCity.aspx");
        //        }
        //        //lblErrorStatus.Visible = true;
        //    }
        //    else
        //    {
        //        //lblErrorStateName.Visible = true;            
        //    }
        //}
        //else
        //{
        //   // lblErrorCountryName.Visible = true;
        //}       
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmManageCity.aspx");
    }
    protected void ddlCountryName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCountryName.SelectedItem.Text != "select")
        {
            objCity.pro_CountryName = ddlCountryName.SelectedItem.Text;
            objCity.pro_CountryId = Convert.ToInt32(ddlCountryName.SelectedItem.Value);
        }
        BindState();


    }
}
