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

///<summary >
///This is BOL Country_Logic Class
/// Created By: Team A PropertyNet
/// Created On: 16-Oct-2007
/// Last Modified By: Team A PropertyNet
/// Last Modified On: 16-Oct-2007
/// </summary>
public class clsCountry_Logic
{
    private int _CountryId;
    private string _CountryName;
    private string _CountryDescr;
    private string _StatusName;
    public string Sort_On;
    private int _StatusId;
    //int statusId;
    //private clsDbConnector objDbConnector;
	public clsCountry_Logic()
	{
        //objDbConnector = new clsDbConnector();
	}
    public int pro_CountryId
    {
        get
        {
            return _CountryId; 
        }
        set
        {
           _CountryId = value;
        }
    
    }

    public string pro_CountryName
    {
        get
        {
            return _CountryName;
        }
        set
        {
            if (value.ToString() == "")
            {
                _CountryName = "";
            }
            else
            {
                _CountryName = value;
            }
        }
    }


    public string pro_CountryDescription
    {
        get
        {
            return _CountryDescr;
        }
        set
        {
            if (value.ToString() == "")
            {
                _CountryDescr = "";
            }
            else
            {
                _CountryDescr = value;
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


    public DataSet GetCountry()
    {
        string strSql = string.Empty;
        strSql = "select c.CountryId,c.CountryName,c.CountryDescription,s.StatusName from tbl_Country c,tbl_Status s where c.StatusId=s.StatusId";
        if (_CountryName != "")
            strSql += " and CountryName like '%" + _CountryName + "%'";
        if (Sort_On != "")
        {
            strSql = strSql + " ORDER BY " + Sort_On;
        }
        else
        {
            strSql = strSql + " Order By CountryName";
        }
        DataSet dsTemp;
        dsTemp = SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.Text, strSql);
        return dsTemp;
    }

    public void AddCountry()
    {
        string strSql = string.Empty;
        strSql += "Insert into tbl_Country(CountryName,CountryDescription,StatusId)";
        strSql += " values('" + _CountryName + "',";
        strSql += " '" + _CountryDescr + "',"+_StatusId+")";
        SqlHelper.ExecuteNonQuery(ClsConnectionString.getConnectionString(), CommandType.Text, strSql);
    }

    public void DeleteCountry(string CountryId)
    {
        string strSql = string.Empty;
        strSql += "delete from tbl_Country";
        strSql += " where CountryId in('" + CountryId.Replace(",", "','") + "')";
        SqlHelper.ExecuteNonQuery(ClsConnectionString.getConnectionString(), CommandType.Text, strSql);
    }

    public void GetCountryDetails()
    {
        string strSql = string.Empty;
        strSql += "select c.CountryId,c.CountryName,c.CountryDescription,s.StatusName from tbl_Country c,tbl_Status s where c.StatusId=s.StatusId";
        strSql += " and c.CountryId=" + _CountryId;
        DataSet dsTemp;
        dsTemp = SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.Text, strSql);
        DataRowCollection drc = dsTemp.Tables[0].Rows;
        if (drc.Count > 0)
        {
            _CountryName = drc[0]["CountryName"].ToString();
            _CountryDescr = drc[0]["CountryDescription"].ToString();
            _StatusName = drc[0]["StatusName"].ToString();
        }
        else
        {
            _CountryName = "";
            _CountryDescr = "";
        }
    }


    public void UpdateCountry()
    {
        string strSql = string.Empty;
        strSql += "Update tbl_Country set";
        strSql += " CountryName='" + _CountryName + "',";
        strSql += " CountryDescription='" + _CountryDescr + "',";
        strSql += " StatusId=" + _StatusId;
        strSql += " where CountryId=" + _CountryId;
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
