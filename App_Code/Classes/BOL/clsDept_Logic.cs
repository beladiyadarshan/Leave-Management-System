using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.ApplicationBlocks.Data;

/// <summary>
/// Summary description for clsDept_Logic
/// </summary>
public class clsDept_Logic
{
    private int _DeptId;
    private string _DeptName;
    private string _DeptDescr;
    private string _StatusName;
    public string Sort_On;
    private int _StatusId;
    //int statusId;
    //private clsDbConnector objDbConnector;
    public clsDept_Logic()
    {
        //objDbConnector = new clsDbConnector();
    }
    public int pro_DeptId
    {
        get
        {
            return _DeptId;
        }
        set
        {
            _DeptId = value;
        }

    }

    public string pro_DeptName
    {
        get
        {
            return _DeptName;
        }
        set
        {
            if (value.ToString() == "")
            {
                _DeptName = "";
            }
            else
            {
                _DeptName = value;
            }
        }
    }


    public string pro_DeptDescription
    {
        get
        {
            return _DeptDescr;
        }
        set
        {
            if (value.ToString() == "")
            {
                _DeptDescr = "";
            }
            else
            {
                _DeptDescr = value;
            }
        }
    }

    public string pro_StatusName
    {
        get
        {
            return _StatusName;
        }
        set
        {
            _StatusName = value;

        }
    }
    public int pro_StatusId
    {
        get
        {
            return _StatusId;
        }
        set
        {
            _StatusId = value;
        }

    }


    public DataSet GetDept()
    {
        string strSql = string.Empty;
        //strSql = "select c.DeptId,c.DeptName,c.DeptDescription,s.StatusName from tbl_Dept c,tbl_Status s where c.StatusId=s.StatusId";
        strSql += "select * from tbl_Dept where 1=1";
        if (_DeptName != "")
            strSql += " and DeptName like '%" + _DeptName + "%'";
        if (Sort_On != "")
        {
            strSql = strSql + " ORDER BY " + Sort_On;
        }
        else
        {
            strSql = strSql + " Order By DeptName";
        }
        DataSet dsTemp;
        dsTemp = SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.Text, strSql);
        return dsTemp;
    }

    public void AddDept()
    {
        string strSql = string.Empty;
        strSql += "Insert into tbl_Dept(DeptName,DeptDescription)";
        strSql += " values('" + _DeptName + "',";
        strSql += " '" + _DeptDescr + "')";
        SqlHelper.ExecuteNonQuery(ClsConnectionString.getConnectionString(), CommandType.Text, strSql);
    }

    public void DeleteDept(string DeptId)
    {
        string strSql = string.Empty;
        strSql += "delete from tbl_Dept";
        strSql += " where DeptId in('" + DeptId.Replace(",", "','") + "')";
        SqlHelper.ExecuteNonQuery(ClsConnectionString.getConnectionString(), CommandType.Text, strSql);
    }

    public void GetDeptDetails()
    {
        string strSql = string.Empty;
//        strSql += "select c.DeptId,c.DeptName,c.DeptDescription,s.StatusName from tbl_Dept c,tbl_Status s where c.StatusId=s.StatusId";
        strSql += "select * from tbl_Dept where 1=1";
        strSql += " and DeptId=" + _DeptId;
        DataSet dsTemp;
        dsTemp = SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.Text, strSql);
        DataRowCollection drc = dsTemp.Tables[0].Rows;
        if (drc.Count > 0)
        {
            _DeptName = drc[0]["DeptName"].ToString();
            _DeptDescr = drc[0]["DeptDescription"].ToString();
            //_StatusName = drc[0]["StatusName"].ToString();
        }
        else
        {
            _DeptName = "";
            _DeptDescr = "";
        }
    }


    public void UpdateDept()
    {
        string strSql = string.Empty;
        strSql += "Update tbl_Dept set";
        strSql += " DeptName='" + _DeptName + "',";
        strSql += " DeptDescription='" + _DeptDescr + "'";
      //  strSql += " StatusId=" + _StatusId;
        strSql += " where DeptId=" + _DeptId;
        SqlHelper.ExecuteNonQuery(ClsConnectionString.getConnectionString(), CommandType.Text, strSql);
    }

    public DataSet GetStatusName()
    {

        string strSql = string.Empty;
        strSql += "select StatusName,StatusId from tbl_Status";
        DataSet dsTemp;
        dsTemp = SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.Text, strSql);
        return dsTemp;

    }



}

