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
/// Summary description for clsEmployeeLogin_Logic
/// </summary>
public class clsEmployeeLogin_Logic
{
	public clsEmployeeLogin_Logic()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    string _UserName, _Password, _OldPassword;

    public string Password
    {
        get { return _Password; }
        set { _Password = value; }
    }

    public string UserName
    {
        get { return _UserName; }
        set { _UserName = value; }
    }

    public string OldPassword
    {
        get { return _OldPassword; }
        set { _OldPassword = value; }
    }

    public DataSet GetEmpLoginDetails()
    {
        SqlParameter[] p = new SqlParameter[2];
        p[0] = new SqlParameter("@UserName", SqlDbType.VarChar);
        p[0].Value = _UserName;
        p[1] = new SqlParameter("@Password", SqlDbType.VarChar);
        p[1].Value = _Password;
        DataSet tempds = SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.StoredProcedure, "spEmpLogin", p);
        return tempds;
    }


    public int EmpChangeOldPassword()
    {
        SqlParameter[] p = new SqlParameter[2];
        p[0] = new SqlParameter("@UserName", SqlDbType.VarChar);
        p[0].Value = _UserName;
        p[1] = new SqlParameter("@Password", SqlDbType.VarChar);
        p[1].Value = _Password;
        int i = SqlHelper.ExecuteNonQuery(ClsConnectionString.getConnectionString(), CommandType.StoredProcedure, "spEmpChangePassword", p);
        return i;
    }

    public bool CheckEmpOldPassword()
    {
        SqlParameter[] p = new SqlParameter[2];
        p[0] = new SqlParameter("@UserName", SqlDbType.VarChar);
        p[0].Value = _UserName;
        p[1] = new SqlParameter("@Password", SqlDbType.VarChar);
        p[1].Value = _OldPassword;
        DataSet tempds = SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.StoredProcedure, "spCheckEmpOldPassword", p);
        DataRowCollection drc = tempds.Tables[0].Rows;
        if (drc.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
