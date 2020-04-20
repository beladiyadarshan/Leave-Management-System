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

public partial class Employee_frmEditEmployeeDetails : System.Web.UI.Page
{
    clsEmployee_Logic EmpObj = new clsEmployee_Logic();
    clsCommon_Logic objCommon = new clsCommon_Logic();
   // clsUsers_Logic objUser = new clsUsers_Logic();
    protected void Page_Load(object sender, EventArgs e)
    {



        if (!IsPostBack)
        {
            BindDept();
            BindCountry();
           // BindStatus();
            BindState();
            BindCity();
            BindDesignation();
            BindData();
        }

    }
    void BindCountry()
    {
        DataSet dsCountry = objCommon.GetCountryName();
        ddlCountryName.DataSource = dsCountry.Tables[0];
        ddlCountryName.DataTextField = "CountryName";
        ddlCountryName.DataValueField = "CountryId";
        ddlCountryName.DataBind();
        ddlCountryName.Items.Insert(0, "Select");
    }
    void BindState()
    {
        DataSet dsState = objCommon.GetStateName();
        ddlStateName.DataSource = dsState.Tables[0];
        ddlStateName.DataTextField = "StateName";
        ddlStateName.DataValueField = "StateId";
        ddlStateName.DataBind();
        ddlStateName.Items.Insert(0, "Select");

    }
    void BindCity()
    {
        DataSet dsCity = objCommon.GetCityName();
        ddlCityName.DataSource = dsCity.Tables[0];
        ddlCityName.DataTextField = "CityName";
        ddlCityName.DataValueField = "CityId";
        ddlCityName.DataBind();
        ddlCityName.Items.Insert(0, "Select");
    }   
    void BindDept()
    {
        DataSet dsDept = objCommon.GetDeptName();
        ddlDept.DataSource = dsDept.Tables[0];
        ddlDept.DataTextField = "DeptName";
        ddlDept.DataValueField = "DeptId";
        ddlDept.DataBind();
        ddlDept.Items.Insert(0, "Select");
    }
    void BindDesignation()
    {
        DataSet dsDesgn = objCommon.GetDesignation();
        ddlDesig.DataSource = dsDesgn.Tables[0];
        ddlDesig.DataTextField = "DesigType";
       // ddlDesig.DataValueField = "DesigId";
        ddlDesig.DataBind();
        ddlDesig.Items.Insert(0, "Select");
    }

   
    public void BindData()
    {
        EmpObj.UserName = Session["UserName"].ToString();
        EmpObj.GetEmployeeDetails();
        txtUserName.Text = Session["UserName"].ToString();
        txtEmpName.Text = EmpObj.EmpName;
        //txtPassword.Text = EmpObj.Password;
        txtAddress.Text = EmpObj.Address;
        txtEmailId.Text = EmpObj.EmailId;
        txtContactNo.Text = EmpObj.ContactNo;
        //Modifications
        int DeptIndex = ddlDept.Items.IndexOf(ddlDept.Items.FindByValue(EmpObj.DeptId.ToString()));
        if (DeptIndex >= 0)
            ddlDept.Items[DeptIndex].Selected = true;

        int CountryIndex = ddlCountryName.Items.IndexOf(ddlCountryName.Items.FindByValue(EmpObj.CountryId.ToString()));
        if (CountryIndex >= 0)
            ddlCountryName.Items[CountryIndex].Selected = true;

        int StateIndex = ddlStateName.Items.IndexOf(ddlStateName.Items.FindByValue(EmpObj.StateId.ToString()));
        if (StateIndex >= 0)
            ddlStateName.Items[StateIndex].Selected = true;

        int CityIndex = ddlCityName.Items.IndexOf(ddlCityName.Items.FindByValue(EmpObj.CityId.ToString()));
        if (CityIndex >= 0)
            ddlCityName.Items[CityIndex].Selected = true;

        int DesigIndex = ddlDesig.Items.IndexOf(ddlDesig.Items.FindByText(EmpObj.Designation.ToString()));
        if (DesigIndex >= 0)
            ddlDesig.Items[DesigIndex].Selected = true;
    }
    
    
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmEmployeeHome.aspx");
    }
    protected void ddlCountryName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCountryName.SelectedItem.Text != "Select")
        {
            objCommon.pro_CountryId = Convert.ToInt32(ddlCountryName.SelectedItem.Value);
            BindState();
        }
    }
    protected void ddlStateName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStateName.SelectedItem.Text != "Select")
        {
            objCommon.pro_StateId = Convert.ToInt32(ddlStateName.SelectedItem.Value);
            BindCity();
        }
    }
    protected void ddlCityName_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        EmpObj.UserName = Session["UserName"].ToString();
        //EmpObj.EmpId =Convert.ToInt32(Session["EmpId"].ToString());
        EmpObj.EmpName = txtEmpName.Text.Trim();
        EmpObj.Address = txtAddress.Text.Trim();
        EmpObj.Designation = ddlDesig.SelectedItem.Text;
        EmpObj.CountryId = Convert.ToInt32(ddlCountryName.SelectedItem.Value);
        EmpObj.StateId = Convert.ToInt32(ddlStateName.SelectedItem.Value);
        EmpObj.CityId = Convert.ToInt32(ddlCityName.SelectedItem.Value);
        EmpObj.ContactNo = txtContactNo.Text.Trim();
        EmpObj.DeptId = Convert.ToInt32(ddlDept.SelectedItem.Value);
        EmpObj.EmailId = txtEmailId.Text.Trim();
       // EmpObj.StatusId = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        EmpObj.UpdateEmployeeDetails();
    }
}
