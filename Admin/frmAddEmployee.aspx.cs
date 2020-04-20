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

public partial class Admin_frmAddEmployee : System.Web.UI.Page
{
    clsEmployee_Logic objEmployee = new clsEmployee_Logic();
    clsCommon_Logic objCommon = new clsCommon_Logic();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDept();
            BindCountry();
            //BindStatus();
            BindState();
            BindCity();
            BindDesignation();
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
    //void BindStatus()
    //{
    //    DataSet dsStatus = objCommon.GetStatusName();
    //    ddlStatus.DataSource = dsStatus.Tables[0];
    //    ddlStatus.DataTextField = "StatusName";
    //    ddlStatus.DataValueField = "StatusId";
    //    ddlStatus.DataBind();
    //    ddlStatus.Items.Insert(0, "Select");
    //}
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
        ddlDesig.DataValueField = "DesigId";
        ddlDesig.DataBind();
        ddlDesig.Items.Insert(0, "Select");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {        
            objEmployee.EmpName = txtEmpName.Text.Trim();
            objEmployee.Address = txtAddress.Text.Trim();
            objEmployee.CountryId = Convert.ToInt32(ddlCountryName.SelectedItem.Value);
            objEmployee.StateId = Convert.ToInt32(ddlStateName.SelectedItem.Value);
            objEmployee.CityId = Convert.ToInt32(ddlCityName.SelectedItem.Value);
            objEmployee.ContactNo = txtContactNo.Text.Trim();
            objEmployee.DeptId = Convert.ToInt32(ddlDept.SelectedItem.Value);
            objEmployee.EmailId = txtEmailId.Text.Trim();
            objEmployee.UserName = txtUserName.Text;
            objEmployee.Password = txtPassword.Text.Trim();
            objEmployee.Designation = ddlDesig.SelectedItem.Text;
            objEmployee.Role = "Employee";
            int i=objEmployee.AddEmployeeDetails();
            
            if (i == 1)
            {
                Response.Redirect("frmManageEmployee.aspx");
            }
            if (i == -2)
            {
                lblError.Visible = true;
                lblError.Text = "Sorry This user name is already existing please choose another username";
            }  
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmManageEmployee.aspx");
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
}
