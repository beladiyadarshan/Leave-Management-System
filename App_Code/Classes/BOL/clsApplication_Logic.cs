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
/// Summary description for clsApplication_Logic
/// </summary>
public class clsApplication_Logic
{
    string _UserName, _StartingDate, _EndingDate, _ApplaiyingDate, _LeavePurpose;
    int _LeaveTypeId, _NoOfDays, _AppStatusId, _ApplicationNo;
    public string Sort_On;
	public clsApplication_Logic()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string UserName
    {
        get { return _UserName; }
        set { _UserName = value; }
    }
    public string StartingDate
    {
        get { return _StartingDate; }
        set { _StartingDate = value; }
    }
    public string EndingDate
    {
        get { return _EndingDate; }
        set { _EndingDate = value; }
    }
    public string ApplaiyingDate
    {
        get { return _ApplaiyingDate; }
        set { _ApplaiyingDate = value; }
    }
    public string LeavePurpose
    {
        get { return _LeavePurpose; }
        set { _LeavePurpose = value; }
    }

    public int NoOfDays
    {
        get { return _NoOfDays; }
        set { _NoOfDays = value; }
    }

    public int LeaveTypeId
    {
        get { return _LeaveTypeId; }
        set { _LeaveTypeId = value; }
    }
    public int AppStatusId
    {
        get { return _AppStatusId; }
        set { _AppStatusId = value; }
    }

    public int ApplicationNo
    {
        get { return _ApplicationNo; }
        set { _ApplicationNo = value; }
    }
    public void AddLeaveApplication()
    {
        SqlParameter[] p = new SqlParameter[8];
        p[0] = new SqlParameter("@LeaveTypeId", SqlDbType.Int);
        p[0].Value = _LeaveTypeId;
        p[1] = new SqlParameter("@UserName", SqlDbType.VarChar);
        p[1].Value = _UserName;
        p[2] = new SqlParameter("@StartingDate", SqlDbType.DateTime);
        p[2].Value = Convert.ToDateTime(_StartingDate);
        p[3] = new SqlParameter("@EndingDate", SqlDbType.DateTime);
        p[3].Value = Convert.ToDateTime(_EndingDate);
        p[4] = new SqlParameter("@ApplyingDate", SqlDbType.DateTime);
        p[4].Value =Convert.ToDateTime( _ApplaiyingDate);
        p[5] = new SqlParameter("@NoOfDays", SqlDbType.Int);
        p[5].Value = _NoOfDays;
        p[6] = new SqlParameter("@LeavePurpose", SqlDbType.VarChar);
        p[6].Value = _LeavePurpose;
        p[7] = new SqlParameter("@StatusId", SqlDbType.Int);
        p[7].Value = 3;
        SqlHelper.ExecuteNonQuery(ClsConnectionString.getConnectionString(),CommandType.StoredProcedure,"spAddLeaveApplication",p);        
    }

    public void UpdateApplicationData()
    {
        SqlParameter[] p = new SqlParameter[2];
        p[0] = new SqlParameter("@StausId", SqlDbType.Int);
        p[0].Value = _AppStatusId;
        p[1] = new SqlParameter("@ApplicationNo", SqlDbType.Int);
        p[1].Value = _ApplicationNo;
        SqlHelper.ExecuteNonQuery(ClsConnectionString.getConnectionString(), CommandType.StoredProcedure, "spUpdateApplicationData", p);
    }

    public DataSet GetApplicationStatus()
    {
        SqlParameter[] p = new SqlParameter[1];
        p[0] = new SqlParameter("@UserName", SqlDbType.VarChar);
        p[0].Value = _UserName;
        return SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.StoredProcedure, "spGetApplicationStatus",p);        
    }

    public DataSet GetApplicationLeaveDetails()
    {
        SqlParameter[] p = new SqlParameter[1];
        p[0] = new SqlParameter("@ApplicationNo", SqlDbType.Int);
        p[0].Value = _ApplicationNo;
        return SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.StoredProcedure, "spGetApplicationLeave", p);
    }
    //jan 04
    public DataSet GetApplicationData()
    {
        string strSql = string.Empty;
        strSql = "select * from tbl_ApplicationData a,tbl_Status s,tbl_LeaveType l where a.ApplicationStatusId=s.StatusId and a.LeaveTypeId=l.LeaveTypeId ";
        if (!string.IsNullOrEmpty(_UserName))
            strSql += " and a.UserName like '%" + _UserName + "%'";
        if (_LeaveTypeId!=0)
            strSql += " and a.LeaveTypeId=" + _LeaveTypeId;
        if (!string.IsNullOrEmpty(Sort_On))
        {
            strSql = strSql + " ORDER BY " + Sort_On;
        }
        else
        {
            strSql = strSql + " Order By a.UserName";
        }
        DataSet dsTemp;
        dsTemp = SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.Text, strSql);
        return dsTemp;
    }
}
