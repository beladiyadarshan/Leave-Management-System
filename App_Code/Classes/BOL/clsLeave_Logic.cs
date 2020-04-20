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
/// Summary description for clsLeave_Logic
/// </summary>
public class clsLeave_Logic
{
    private string _LeaveTypeName,_UserName,_StartingMonth,_EndingMonth,_StartingDate,_EndingDate;
    int _LeaveTypeId, _NoOfLeavesPerYear, _UsedLeaves, _BalanceLeaves, _ApplicationNo, _AppStatusId;
    int _CasualBalanceLeaves, _EarnBalanceLeaves, _HalfPaidBalanceLeaves, _MedicalBalanceLeaves;
    public string Sort_On;
    public clsLeave_Logic()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public string StartingMonth
    {
        get { return _StartingMonth; }
        set { _StartingMonth = value; }
    }
    public string EndingMonth
    {
        get { return _EndingMonth; }
        set { _EndingMonth = value; }
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

    public int ApplicationNo
    {
        get { return _ApplicationNo; }
        set { _ApplicationNo = value; }
    }
    public int AppStatusId
    {
        get { return _AppStatusId; }
        set { _AppStatusId = value; }
    }
    public int CasualBalanceLeaves
    {
        get { return _CasualBalanceLeaves; }
        set { _CasualBalanceLeaves = value; }
    }
    public int EarnBalanceLeaves
    {
        get { return _EarnBalanceLeaves; }
        set { _EarnBalanceLeaves = value; }
    }
    public int HalfPaidBalanceLeaves
    {
        get { return _HalfPaidBalanceLeaves; }
        set { _HalfPaidBalanceLeaves = value; }
    }
    public int MedicalBalanceLeaves
    {
        get { return _MedicalBalanceLeaves; }
        set { _MedicalBalanceLeaves = value; }
    }

    public string UserName
    {
        get { return _UserName; }
        set { _UserName = value; }
    }
    public string LeaveTypeName
    {
        get { return _LeaveTypeName; }
        set { _LeaveTypeName = value; }
    }
    public int LeaveTypeId
    {
        get { return _LeaveTypeId; }
        set { _LeaveTypeId = value; }
    }

    public int NoOfLeavesPerYear
    {
        get { return _NoOfLeavesPerYear; }
        set { _NoOfLeavesPerYear = value; }
    }
    public int UsedLeaves
    {
        get { return _UsedLeaves; }
        set { _UsedLeaves = value; }
    }
    public int BalanceLeaves
    {
        get { return _BalanceLeaves; }
        set { _BalanceLeaves = value; }
    }

    public int GetBalanceDays()
    {
        SqlParameter[] p = new SqlParameter[3];
        p[0] = new SqlParameter("@LeaveTypeId", SqlDbType.Int);
        p[0].Value = _LeaveTypeId;
        p[1] = new SqlParameter("@UserName", SqlDbType.VarChar);
        p[1].Value = _UserName;
        p[2] = new SqlParameter("@Balanceleaves", SqlDbType.Int);
        p[2].Direction = ParameterDirection.Output;
       
        SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.StoredProcedure, "spGetBalanceDays", p);
        //return i;
        return (int)p[2].Value;
    }
    public DataSet GetLeaveType()
    {
        return SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.StoredProcedure, "spGetLeaveType");
    }

    //Jan 04 11.09am
    public void GetTotalBalanceDays()
    {
        SqlParameter[] p = new SqlParameter[5];        
        p[0] = new SqlParameter("@UserName", SqlDbType.VarChar);
        p[0].Value = _UserName;
        p[1] = new SqlParameter("@CasualBalanceLeaves", SqlDbType.Int);
        p[1].Direction = ParameterDirection.Output;
        p[2] = new SqlParameter("@EarnBalanceLeaves", SqlDbType.Int);
        p[2].Direction = ParameterDirection.Output;
        p[3] = new SqlParameter("@HalfPaidBalanceLeaves", SqlDbType.Int);
        p[3].Direction = ParameterDirection.Output;
        p[4] = new SqlParameter("@MedicalBalanceLeaves", SqlDbType.Int);
        p[4].Direction = ParameterDirection.Output;

        SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.StoredProcedure, "spGetTotalBalanceDays", p);
        _CasualBalanceLeaves = (int)p[1].Value;
        _EarnBalanceLeaves = (int)p[2].Value;
        _HalfPaidBalanceLeaves = (int)p[3].Value;
        _MedicalBalanceLeaves = (int)p[4].Value;
        
    }

    public void AddLeaveDetails()
    {
        SqlParameter[] p = new SqlParameter[5];
        p[0] = new SqlParameter("@UserName", SqlDbType.VarChar);
        p[0].Value = _UserName;
        p[1] = new SqlParameter("@ApplicationNo", SqlDbType.Int);
        p[1].Value = _ApplicationNo;
        p[2] = new SqlParameter("@AppStatusId", SqlDbType.Int);
        p[2].Value = _AppStatusId;
        p[3] = new SqlParameter("@BalanceLeaves", SqlDbType.Int);
        p[3].Value = _BalanceLeaves;
        p[4] = new SqlParameter("@LeaveTypeId", SqlDbType.Int);
        p[4].Value = _LeaveTypeId;
        SqlHelper.ExecuteNonQuery(ClsConnectionString.getConnectionString(), CommandType.StoredProcedure, "spAddLeaveDetails", p);
    }

    public bool CheckAppNoInLeaveDetails()
    {
        SqlParameter[] p = new SqlParameter[1];
        p[0] = new SqlParameter("@ApplicationNo", SqlDbType.Int);
        p[0].Value = _ApplicationNo;
       DataSet ds= SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.StoredProcedure, "spCheckAppNoInLeaveDetails", p);
       if (ds.Tables[0].Rows.Count > 0)
           return false;
       else
           return true;
    }

    

    public DataSet GetMonthlyLeavetransactions()
    {
        string strSql = string.Empty;
        strSql = "select * from tbl_ApplicationData a,tbl_Status s,tbl_LeaveType l where a.ApplicationStatusId=s.StatusId and a.LeaveTypeId=l.LeaveTypeId ";
        if (!string.IsNullOrEmpty(_UserName))
            strSql += " and a.UserName like '%" + _UserName + "%'";
        if (!string.IsNullOrEmpty(_StartingMonth))
        {
            strSql += " and a.StartingDate >'" + _StartingMonth + "' ";
        }
        if (!string.IsNullOrEmpty(_EndingMonth))
        {
            strSql += " and a.StartingDate <'" + _EndingMonth + "' ";
        }
        if (!string.IsNullOrEmpty(_StartingDate))
        {
            strSql += " and a.StartingDate >'" + _StartingDate + "' ";
        }
        if (!string.IsNullOrEmpty(_EndingDate))
        {
            strSql += " and a.StartingDate <'" + _EndingDate + "' ";
        }
        if (Sort_On != "")
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
