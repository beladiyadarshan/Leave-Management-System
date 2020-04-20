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

public partial class Administration_frmAddCity : System.Web.UI.Page
{
    clsCity_Logic objCity = new clsCity_Logic();
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
        DataSet dsStatus = objCity.GetStatus();
        ddlStatus.DataSource = dsStatus.Tables[0];
        ddlStatus.DataTextField = "StatusName";
        ddlStatus.DataValueField = "StatusId";
        ddlStatus.DataBind();
        ddlStatus.Items.Insert(0, "Select");
    }

    void BindCountry()
    {
        DataSet dsCountry = objCity.GetCountry();
        ddlCountryName.DataSource = dsCountry.Tables[0];
        ddlCountryName.DataTextField = "CountryName";
        ddlCountryName.DataValueField = "CountryId";
        ddlCountryName.DataBind();
        ddlCountryName.Items.Insert(0, "Select");


    }
    void BindState()
    {
        DataSet dsState = objCity.GetState();
        ddlStateName.DataSource = dsState.Tables[0];
        ddlStateName.DataTextField = "StateName";
        ddlStateName.DataValueField = "StateId";
        ddlStateName.DataBind();
        ddlStateName.Items.Insert(0, "Select");

    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        if (ddlCountryName.SelectedItem.Text != "Select")
        {
            if (ddlStateName.SelectedItem.Text != "Select")
            {
                if (ddlStatus.SelectedItem.Text != "Select")
                {
                    objCity.pro_CityName = txtCityName.Text.Trim();
                    objCity.pro_CityDescription = txtCityDescription.Text.Trim();
                    objCity.pro_StateName = ddlStateName.SelectedItem.Text;
                    objCity.pro_StateId = Convert.ToInt32(ddlStateName.SelectedItem.Value);
                    objCity.pro_StatusName = ddlStatus.SelectedItem.Text;
                    objCity.pro_StatusId = Convert.ToInt32(ddlStatus.SelectedItem.Value);
                    objCity.pro_CountryName = ddlCountryName.SelectedItem.Text;
                    objCity.pro_CountryId = Convert.ToInt32(ddlCountryName.SelectedItem.Value);
                    objCity.AddCity();
                    Response.Redirect("frmManageCity.aspx");
                }
                lblErrorStatus.Visible = true;
            }
            else
            {
                lblErrorStateName.Visible = true;


            }
        }
        else
        {
            lblErrorCountryName.Visible = true;

        }       
        
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmManageCity.aspx");

    }
    protected void ddlCountryName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlCountryName.SelectedItem.Text!="Select")
        {
            objCity.pro_CountryName = ddlCountryName.SelectedItem.Text;
            objCity.pro_CountryId = Convert.ToInt32(ddlCountryName.SelectedItem.Value);
            BindState();

        
        }
    }
}
