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


///<summary>
//This is BOL Common_Logic Class
/// Created By: Team A PropertyNet
/// Created On: 19-Oct-2007
/// Last Modified By: Team A PropertyNet
/// Last Modified On: 19-Oct-2007
/// </summary 
public class clsCommon_Logic
{
  
    private string _CountryName;
    private int _CountryId;
    private int _StateId;
    private string _StateName;
    private int _CityId;
    private string _CityName;

	public clsCommon_Logic()
	{
        
	}

    public string pro_CountryName
    {
        get
        {
            return _CountryName;
        }
        set
        {
            _CountryName = value;
        }

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
    public int pro_StateId
    {
        get
        {
            return _StateId;
        }
        set
        {
            _StateId = value;
        }

    }
    public string pro_StateName
    {
        get
        {
            return _StateName;
        }
        set
        {
            _StateName = value;
        }

    }
    public int pro_CityId
    {
        get
        {
            return _CityId;
        }
        set
        {
            _CityId = value;
        }
    }
    public string pro_CityName
    {
        get
        {
            return _CityName;
        }
        set
        {
            if (value.ToString() == "")
            {
                _CityName = "";
            }
            else
            {
                _CityName = value;
            }
        }
    }
    
    public DataSet GetStatusName()
    {
        string strSql = string.Empty;
        strSql += "select StatusName,StatusId from tbl_Status";
        DataSet dsTemp;
        dsTemp = SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.Text, strSql);
        return dsTemp;
    }
    public DataSet GetCountryName()
    { 
    string strSql=string.Empty;
        strSql+="select CountryName,CountryId from tbl_Country ";
        DataSet dsTemp;
        dsTemp = SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.Text, strSql);
        return dsTemp;
    }
    public DataSet GetStateName()
    {

        string strSql = string.Empty;
        strSql += "select StateName,StateId from tbl_State";
        if(_CountryId!=0)
        strSql += " where CountryId=" + _CountryId;
        DataSet dsTemp;
        dsTemp = SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.Text, strSql);
        return dsTemp;
    }
    public DataSet GetCityName()
    {
        string strSql = string.Empty;
        strSql += "select CityName,CityId from tbl_CityDetails";
        if (_StateId != 0)
            strSql += " where StateId="+_StateId;
        DataSet dsTemp;
        dsTemp = SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.Text, strSql);
        return dsTemp;
    }
    public DataSet GetDeptName()
    {
        string strSql = string.Empty;
        strSql += "select DeptName,DeptId from tbl_Dept";
        DataSet dsTemp;
        dsTemp = SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.Text, strSql);
        return dsTemp;
    }
    public DataSet GetDesignation()
    {
        string strSql = string.Empty;
        strSql += "select * from tbl_Designation";
        DataSet dsTemp;
        dsTemp = SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.Text, strSql);
        return dsTemp;
    }

  /*  public Boolean CheckMemberId(string memberid)
    {
        string strSql = string.Empty;
        strSql += "select count(*) from tbl_Member_Details where MemberId='" + memberid + "'";
        DataSet ds = objDbConnector.GetDataSet(strSql);
        //string q = ds.Tables[0].Rows[0][0].ToString();
        //SqlDataReader sqlDr = objDbConnector.getSqlDataReader(strSql);
        //string s = sqlDr[0].ToString();
        if (int.Parse(ds.Tables[0].Rows[0][0].ToString()) == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }*/
}
