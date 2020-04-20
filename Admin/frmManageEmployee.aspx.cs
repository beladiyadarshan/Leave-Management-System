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

public partial class Admin_frmManageEmp : System.Web.UI.Page
{
    clsEmployee_Logic objEmployee = new clsEmployee_Logic();
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
            BindData();
            string Msg = "Do you want to delete this data?";
            btnDelete.Attributes.Add("onClick", "return confirm('" + Msg + "');");
        }
    }
    void BindData()
    {
        objEmployee.EmpName = txtEmpName.Text.Trim();
        objEmployee.Sort_On = "";
        if (ViewState["Sort_On"] != null)
            objEmployee.Sort_On = ViewState["Sort_On"].ToString() + " " + ViewState["Sort_By"].ToString();
        lblError.Visible = false;
        DataSet dsTemp = objEmployee.GetEmployee();
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
                this.gvEmp.PageSize = System.Convert.ToInt32(this.txtPageSize.Text);
            }
        }
        gvEmp.DataSource = dtTemp;
        gvEmp.DataBind();
        if (dtTemp.Rows.Count == 0)
        {
            this.Lbl_Pageinfo.Visible = false;
        }
        else
        {
            Int16 intTo;
            Int16 intFrom;
            if (gvEmp.PageSize * (gvEmp.PageIndex + 1) < dtTemp.Rows.Count)
            {
                intTo = System.Convert.ToInt16(gvEmp.PageSize * (gvEmp.PageIndex + 1));
            }
            else
            {
                intTo = System.Convert.ToInt16(dtTemp.Rows.Count);
            }
            intFrom = System.Convert.ToInt16((gvEmp.PageSize * gvEmp.PageIndex) + 1);
            this.Lbl_Pageinfo.Text = "Record(s) " + intFrom + " to " + intTo + " of " + dtTemp.Rows.Count;
            this.Lbl_Pageinfo.Visible = true;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        strError = "No data matching with your searching criteria";
        gvEmp.PageIndex = 0;
        BindData(); 
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmAddEmployee.aspx");
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request["Cbx_UserName"] == null)
            {
                lblError.Text = "Please select at least one to delete.";
                lblError.Visible = true;
            }
            else
            {
                objEmployee.DeleteEmpDetails(Request["Cbx_UserName"].ToString());
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
    protected void gvEmp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (ViewState["Sort_On"] != null)
            objEmployee.Sort_On = ViewState["Sort_On"].ToString();
        else
            objEmployee.Sort_On = "";
        gvEmp.PageIndex = e.NewPageIndex;
        BindData();
    }
    protected void gvEmp_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void gvEmp_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvEmp_Sorting(object sender, GridViewSortEventArgs e)
    {
        objEmployee.Sort_On = e.SortExpression;
        ViewState["Sort_On"] = objEmployee.Sort_On;
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
}
