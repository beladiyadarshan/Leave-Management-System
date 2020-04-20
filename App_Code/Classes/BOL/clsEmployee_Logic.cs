using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

/// <summary>
/// Summary description for clsEmployee_Logic
/// </summary>
public class clsEmployee_Logic
{
    string _Password, _OldPassword, _EmployeeLoginId, _ContactNo, _Address, _EmailId, _EmpName,_Designation,_Role,_UserName;
    int _EmpId, _CityId, _StateId, _CountryId,_DeptId,_projId;
    clsDbConnector objdDbConnector = new clsDbConnector();
    public string Sort_On;


   
    public string Role
    {
        get { return _Role; }
        set { _Role = value; }
    }
    public int ProjId
    {
        get { return _projId;}
        set { _projId = value; }
    }
   
    public string Password
    {
        get { return _Password; }
        set { _Password = value; }
    }

    public int EmpId
    {
        get { return _EmpId; }
        set { _EmpId = value; }
    }
    public string OldPassword
    {
        get { return _OldPassword; }
        set { _OldPassword = value; }
    }
    public string EmployeeLoginId
    {
        get { return _EmployeeLoginId; }
        set { _EmployeeLoginId = value; }
    }
    public string ContactNo
    {
        get { return _ContactNo; }
        set { _ContactNo = value; }
    }
    public string Address
    {
        get { return _Address; }
        set { _Address = value; }
    }
    public string EmailId
    {
        get { return _EmailId; }
        set { _EmailId = value; }
    }

    public string EmpName
    {
        get { return _EmpName; }
        set { _EmpName = value; }
    }
    public string Designation
    {
        get { return _Designation; }
        set { _Designation = value; }
    }
    public string UserName
    {
        get { return _UserName; }
        set { _UserName = value; }
    }
    public int CityId
    {
        get { return _CityId; }
        set { _CityId = value; }
    }

    public int StateId
    {
        get { return _StateId; }
        set { _StateId = value; }
    }
    public int CountryId
    {
        get { return _CountryId; }
        set { _CountryId = value; }
    }

    public int DeptId
    {
        get { return _DeptId; }
        set { _DeptId = value; }
    }

	public clsEmployee_Logic()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public DataSet GetEmployeeLoginDetails()
    {
        SqlParameter[] p = new SqlParameter[2];
        p[0] = new SqlParameter("@UserLoginId", SqlDbType.VarChar);
        p[0].Value = this._EmployeeLoginId;

        p[1] = new SqlParameter("@Password", SqlDbType.VarChar);
        p[1].Value = this.Password;


        DataSet dsEmployeeLoginDetails= SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.StoredProcedure, "spEmployeeLoginDetails", p);
        return dsEmployeeLoginDetails;
    }
    public int EmployeeChangePassword()
    {
        //SqlParameter[] p = new SqlParameter[2];

        //p[0] = new SqlParameter("@UserId", SqlDbType.VarChar);
        //p[0].Value = this._EmployeeLoginId;
        //p[1] = new SqlParameter("@Password", SqlDbType.VarChar);
        //p[1].Value = this._Password;
        int i=0 ;//= SqlHelper.ExecuteNonQuery(ClsConnectionString.getConnectionString(), CommandType.StoredProcedure, "spEmployeeChangePassword", p);
        return i;
    }

    public bool EmployeeCheckPassword()
    {
        //SqlParameter[] p = new SqlParameter[2];

        //p[0] = new SqlParameter("@UserId", SqlDbType.VarChar);
        //p[0].Value = this._EmployeeLoginId;
        //p[1] = new SqlParameter("@Password", SqlDbType.VarChar);
        //p[1].Value = _OldPassword;
        //DataSet ds = SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.StoredProcedure, "spEmployeeCheckPassword", p);
        //DataRowCollection drc = ds.Tables[0].Rows;
        //if (drc.Count > 0)
        //{
        //    return true;
        //}
        //else
           return false;
    }

    public int AddEmployeeDetails()
    {
        
        SqlParameter[] p = new SqlParameter[13];
        
        p[0] = new SqlParameter("@DeptId", this._DeptId);
        p[0].DbType = DbType.Int32;
        p[1] = new SqlParameter("@ContactNo", this._ContactNo);
        p[1].DbType = DbType.String;
        p[2] = new SqlParameter("@Address", this._Address);
        p[2].DbType = DbType.String;
        p[3] = new SqlParameter("@CityId", this._CityId);
        p[3].DbType = DbType.Int32;
        p[4] = new SqlParameter("@StateId", this._StateId);
        p[4].DbType = DbType.Int32;
        p[5] = new SqlParameter("@CountryId", this._CountryId);
        p[5].DbType = DbType.Int32;
        p[6] = new SqlParameter("@EmailId", this._EmailId);
        p[6].DbType = DbType.String;
        p[7] = new SqlParameter("@EmpName", this._EmpName);
        p[7].DbType = DbType.String;
        p[8] = new SqlParameter("@output", SqlDbType.Int);
        p[8].Direction = ParameterDirection.Output;
        p[9] = new SqlParameter("@UserName", this._UserName);
        p[9].DbType = DbType.String;
        p[10] = new SqlParameter("@Password", this._Password);
        p[10].DbType = DbType.String;
        p[11] = new SqlParameter("@DesigName", SqlDbType.VarChar);
        p[11].Value = _Designation;
        p[12] = new SqlParameter("@Role", SqlDbType.VarChar);
        p[12].Value = _Role;
        SqlHelper.ExecuteNonQuery(ClsConnectionString.getConnectionString(), CommandType.StoredProcedure, "spAddEmployee", p);
        return (int)p[8].Value;
         

    }


    public void AddEmployeeOnProject(string EmployeeIds, int ProjectId)
    {
        //int i = 0;
        //string str = EmployeeIds;
        //char[] delimiterChars = { ',' };
        //string[] words = str.Split(delimiterChars);
        //int length = words.Length;
        //string[] sa = new string[length];
        //foreach (string s in words)
        //{
        //    sa[i] = "insert into tbl_EmpOnProj values(" + Convert.ToInt32(s) + "," + ProjectId + ")";
        //    i++;
        //}
        //objdDbConnector.BatchTransaction(sa);

    }

    public DataSet GetEmployeeOnProject()
    {
        SqlParameter[] p = new SqlParameter[1];
        p[0] = new SqlParameter("@ProjectId", SqlDbType.Int);
        p[0].Value = _projId;
        return SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.StoredProcedure, "spGetEmployeeOnProject", p);
    }


    public bool DeleteEmpDetails(string UserName)
    {
        string strSql1, strSql2;
        strSql1 = string.Empty;
        strSql1 += "delete from  tbl_EmpDetails  where UserName in('" + UserName.Replace(",", "','") + "');";
        strSql2 = "delete from tbl_Users where UserName in('" + UserName.Replace(",", "','") + "')";
        string[] strSql ={ strSql1, strSql2 };
        Boolean b = objdDbConnector.BatchTransaction(strSql);
        return b;


        /* string strSql = string.Empty;
         strSql += "delete from tbl_Supplier";
         strSql += " where SupplierId in('" + SupplierId.Replace(",", "','") + "')";
         SqlHelper.ExecuteNonQuery(ClsConnectionString.getConnectionString(), CommandType.Text, strSql);*/
    }

    public void UpdateEmployeeDetails()
    {

        SqlParameter[] p = new SqlParameter[10];
        
        p[0] = new SqlParameter("@DeptId", this._DeptId);
        p[0].DbType = DbType.Int32;
        p[1] = new SqlParameter("@ContactNo", this._ContactNo);
        p[1].DbType = DbType.String;
        p[2] = new SqlParameter("@Address", this._Address);
        p[2].DbType = DbType.String;
        p[3] = new SqlParameter("@CityId", this._CityId);
        p[3].DbType = DbType.Int32;
        p[4] = new SqlParameter("@StateId", this._StateId);
        p[4].DbType = DbType.Int32;
        p[5] = new SqlParameter("@CountryId", this._CountryId);
        p[5].DbType = DbType.Int32;
        p[6] = new SqlParameter("@EmailId", this._EmailId);
        p[6].DbType = DbType.String;
        p[7] = new SqlParameter("@UserName", this._UserName);
        p[7].DbType = DbType.String;
        p[8] = new SqlParameter("@Desig", this._Designation);
        p[8].DbType = DbType.String;
        p[9] = new SqlParameter("@EmpName", this._EmpName);
        p[9].DbType = DbType.String;
       // p[8] = new SqlParameter("@StatusId", this._StatusId);
       // p[8].DbType = DbType.Int32;
       
        //p[9] = new SqlParameter("@output", SqlDbType.Int);
        //p[9].Direction = ParameterDirection.Output;

        SqlHelper.ExecuteNonQuery(ClsConnectionString.getConnectionString(), CommandType.StoredProcedure, "spUpdataEmployee", p);
        
    }

    public DataSet GetEmployee()
    {       

        string strSql = string.Empty;
        strSql = "select * from tbl_EmpDetails e,tbl_Users u  where  u.UserName=e.UserName ";
        if (!string.IsNullOrEmpty(_UserName))
            strSql += " and u.UserName like '%" + _UserName + "%'";
        if (!string.IsNullOrEmpty(Sort_On))
        {
            strSql = strSql + " ORDER BY " + Sort_On;
        }
        else
        {
            strSql = strSql + " Order By u.UserName";
        }
        DataSet dsTemp;
        dsTemp = SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.Text, strSql);
        return dsTemp;         
    }

    public void GetEmployeeDetails()
    {
        ///*
        //string strSql = string.Empty;
        //strSql += "select * from tbl_ClientDetails u,tbl_ClientLoginAccount ul, tbl_Status stat where u.StatusId=stat.StatusId and ul.ClientId=u.ClientId ";
        //strSql += " and u.ClientId=" + _UserId;
        
        SqlParameter[]p=new SqlParameter [1];
        p[0] = new SqlParameter("@UserName", SqlDbType.VarChar);
        p[0].Value=_UserName ;
        DataSet dsTemp;;

        dsTemp = SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.StoredProcedure,"spGetEmpDetails",p);
        DataRowCollection drc = dsTemp.Tables[0].Rows;
        if (drc.Count > 0)
        {
            _UserName = drc[0]["UserName"].ToString();
            _EmpName = drc[0]["EmpName"].ToString();
            _Designation = drc[0]["EmpDesigName"].ToString();
            _ContactNo = drc[0]["ContactNo"].ToString();
            _Address = drc[0]["Address"].ToString();
            _EmailId = drc[0]["EmailId"].ToString();
            _CityId = Convert.ToInt32(drc[0]["CityId"].ToString());
            _StateId = Convert.ToInt32(drc[0]["StateId"].ToString());
            _CountryId = Convert.ToInt32(drc[0]["CountryId"].ToString());
            _DeptId=Convert.ToInt32(drc[0]["DeptId"].ToString());
        }
        else
        {
            _EmpName = "";
            _ContactNo = "";
            _Address = "";
            _EmailId = "";
        }
         
    }


    /*  public bool CheckUserName()
      {
        
          SqlParameter[] p = new SqlParameter[1];
          p[0] = new SqlParameter("@UserName", SqlDbType.VarChar);
          p[0].Value = _UserName;

          DataSet ds = SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.StoredProcedure, "spCheckUserName", p);
          DataTable dtable = ds.Tables[0];
          if (dtable.Rows.Count > 0)
              return true;
          else
         
              return false;
           * * 
      }*/

    public DataSet GetPresentDayEmpList()
    {

        return SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.Text, "spGetPresentDayEmpList");
    }

    public DataSet GetNextDayEmpList()
    {

        return SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.Text, "spGetNextDayEmpList");
    }

}
