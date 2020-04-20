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
/// This is BOL Status_Logic Class
/// Created By: Team A PropertyNet
/// Created On: 13-Oct-2007
/// Last Modified By: Team A PropertyNet
/// Last Modified On: 13-Oct-2007
/// </summary>
public class clsStatus_Logic
{
    private int _StatusId;
    private string _StatusName;
    private string _StatusDescr;
    public string Sort_On;
    //private clsDbConnector objDbConnector;
	public clsStatus_Logic()
	{
        //objDbConnector = new clsDbConnector();
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
    public string pro_StatusName
    {
        get
        {
            return _StatusName;
        }
        set
        {
            if (value.ToString() == "")
            {
                _StatusName = "";
            }
            else
            {
                _StatusName = value;
            }
        }
    }
    public string pro_StatusDescription
    {
        get
        {
            return _StatusDescr;
        }
        set
        {
            if (value.ToString() == "")
            {
                _StatusDescr = "";
            }
            else
            {
                _StatusDescr = value;
            }
        }
    }

    public DataSet GetStatus()
    {
        string strSql = string.Empty;
        strSql = "select * from tbl_Status";
        if (!string.IsNullOrEmpty(_StatusName))
            strSql += " where StatusName like '%" + _StatusName + "%'";
        if (!string.IsNullOrEmpty(Sort_On))
        {
            strSql = strSql + " ORDER BY " + Sort_On;
        }
        else
        {
            strSql = strSql + " Order By StatusName";
        }
        DataSet dsTemp;        
        dsTemp = SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.Text, strSql);
        return dsTemp;
    }
    public void AddStatus()
    {
        string strSql = string.Empty;
        strSql += "Insert into tbl_Status(StatusName,StatusDescription)";
        strSql += " values('" + _StatusName + "',";
        strSql += " '" + _StatusDescr + "')";       
        SqlHelper.ExecuteNonQuery(ClsConnectionString.getConnectionString(), CommandType.Text, strSql);
    }

    public void DeleteStatus(string StatusId)
    {
        string strSql = string.Empty;
        strSql += "delete from tbl_Status";
        strSql += " where StatusId in('" + StatusId.Replace(",","','") + "')";             
        SqlHelper.ExecuteNonQuery(ClsConnectionString.getConnectionString(), CommandType.Text, strSql);
    }
    public void GetStatusDetails()
    {
        string strSql = string.Empty;
        strSql += "select * from tbl_Status";
        strSql += " where StatusId=" + _StatusId;
        DataSet dsTemp;        
        dsTemp = SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.Text, strSql);
        DataRowCollection drc = dsTemp.Tables[0].Rows;
        if (drc.Count > 0)
        {
            _StatusName = drc[0]["StatusName"].ToString();
            _StatusDescr = drc[0]["StatusDescription"].ToString();
        }
        else
        {
            _StatusName = "";
            _StatusDescr = "";
        }
    }
    public void UpdateStatus()
    {
        string strSql = string.Empty;
        strSql += "Update tbl_Status set";
        strSql += " StatusName='" + _StatusName + "',";
        strSql += " StatusDescription='" + _StatusDescr + "'";
        strSql += " where StatusId=" + _StatusId;       
        SqlHelper.ExecuteNonQuery(ClsConnectionString.getConnectionString(), CommandType.Text, strSql);
    }
}
