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
/// Summary description for ClsBLAdminLogin
/// </summary>
public class clsAdminLogin_Logic 
{
	public clsAdminLogin_Logic()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    string _AdminLoginId, _Password,_OldPassword;

    public string Password
    {
        get { return _Password; }
        set { _Password = value; }
    }

    public string AdminLoginId
    {
        get { return _AdminLoginId; }
        set { _AdminLoginId = value; }
    }

    public string OldPassword
    {
        get { return _OldPassword; }
        set { _OldPassword = value; }
    }

    public DataSet GetAdminLoginDetails()
    {
        SqlParameter[] p = new SqlParameter[2];
        p[0] = new SqlParameter("@AdminLoginId", SqlDbType.VarChar);
        p[0].Value = _AdminLoginId;
        p[1] = new SqlParameter("@Password", SqlDbType.VarChar);
        p[1].Value = _Password;
        DataSet tempds = SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.StoredProcedure, "spAdminLogin", p);
        return tempds;
    }

    public bool CheckAdminOldPassword()
    {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@AdminLoginId", SqlDbType.VarChar);
            p[0].Value = _AdminLoginId;
            p[1] = new SqlParameter("@Password", SqlDbType.VarChar);
            p[1].Value = _OldPassword;
            DataSet tempds = SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.StoredProcedure, "spCheckAdminOldPassword", p);
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

    public int AdminChangeOldPassword()
    {
        SqlParameter[] p = new SqlParameter[2];
        p[0] = new SqlParameter("@AdminLoginId", SqlDbType.VarChar);
        p[0].Value = _AdminLoginId;
        p[1] = new SqlParameter("@Password", SqlDbType.VarChar);
        p[1].Value = _Password;
        int i = SqlHelper.ExecuteNonQuery(ClsConnectionString.getConnectionString(), CommandType.StoredProcedure, "spAdminChangePassword", p);
        return i;
    }

}
