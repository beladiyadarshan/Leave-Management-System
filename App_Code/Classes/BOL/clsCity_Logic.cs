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
///This is BOL City_Logic Class
/// Created By: Team A PropertyNet
/// Created On: 16-Oct-2007
/// Last Modified By: Team A PropertyNet
/// Last Modified On: 16-Oct-2007
/// </summary>
public class clsCity_Logic
{
	 private int _CityId;
    private string _CityName;
    private string _CityDescr;
    public string Sort_On;
    private int _StatusId;
    private string _StatusName;
    private string _CountryName;
    private int _CountryId;
    private int _StateId;
    private string _StateName;
    //private clsDbConnector objDbConnector;
	public clsCity_Logic()
	{
        //objDbConnector = new clsDbConnector();
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
    public string pro_CityDescription
    {
        get
        {
            return _CityDescr;
        }
        set
        {
            if (value.ToString() == "")
            {
                _CityDescr = "";
            }
            else
            {
                _CityDescr = value;
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

    public DataSet GetCity()
    {
        string strSql = string.Empty;
        strSql = "select d.CityId,d.CityName,d.CityDescription,st.StateName,c.CountryName,s.StatusName from tbl_CityDetails d,tbl_Country c,tbl_State st,tbl_Status s where d.StatusId=s.StatusId and d.StateId=st.StateId  and d.CountryId=c.CountryId";
        if (_CityName != "")
            strSql += " and CityName like '%" + _CityName + "%'";
        if (_CountryName != "select" && _CountryName!=null)
        {
            strSql += " and CountryName='" + _CountryName+"'";
        }
        if (_StateName != "select" && _StateName!=null)
        {            
            strSql += " and StateName='" + _StateName+"'"; 
        }
        if (Sort_On != "")
        {
            strSql = strSql + " ORDER BY " + Sort_On;
        }
        else
        {
            strSql = strSql + " Order By CityName";
        }
        DataSet dsTemp;
        dsTemp = SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.Text, strSql);
        return dsTemp;
    }
    public void AddCity()
    {
        string strSql = string.Empty;
        strSql += "Insert into tbl_CityDetails(CityName,CityDescription,StateId,CountryId,StatusId)";
        strSql += " values('" + _CityName + "',";
        strSql += " '" + _CityDescr + "',";
        strSql += _StateId + ",";
        strSql += _CountryId + ",";
        strSql += _StatusId + ")";
        //objDbConnector.runSQL(strSql);
        SqlHelper.ExecuteNonQuery(ClsConnectionString.getConnectionString(), CommandType.Text, strSql);
    }

    public void DeleteCity(string CityId)
    {
        string strSql = string.Empty;
        strSql += "delete from tbl_CityDetails";
        strSql += " where CityId in('" + CityId.Replace(",","','") + "')";        
        //objDbConnector.runSQL(strSql);
        SqlHelper.ExecuteNonQuery(ClsConnectionString.getConnectionString(), CommandType.Text, strSql);
    }
    public void GetCityDetails()
    {
        string strSql = string.Empty;
        strSql += "select d.CityId,d.CityName,d.CityDescription,st.StateName,c.CountryName,s.StatusName from tbl_CityDetails d,tbl_Country c,tbl_State st,tbl_Status s where d.StatusId=s.StatusId and d.StateId=st.StateId  and d.CountryId=c.CountryId";
        strSql += " and CityId=" + _CityId;
        DataSet dsTemp;
        //dsTemp = objDbConnector.GetDataSet(strSql);
        dsTemp = SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.Text, strSql);
        DataRowCollection drc = dsTemp.Tables[0].Rows;
        if (drc.Count > 0)
        {
            _CityName = drc[0]["CityName"].ToString();
            _CityDescr = drc[0]["CityDescription"].ToString();
            _StateName = drc[0]["StateName"].ToString();
            _CountryName = drc[0]["CountryName"].ToString();
            _StatusName = drc[0]["StatusName"].ToString();
        }
        else
        {
            _CityName = "";
            _CityDescr = "";
            _CountryName = "";
            _StateName = "";
            _StatusName = "";
        }
    }
    public void UpdateCity()
    {
        string strSql = string.Empty;
        strSql += "Update tbl_CityDetails set";
        strSql += " CityName='" + _CityName + "',";
        strSql += " CityDescription='" + _CityDescr + "',";
        strSql+=" StateId="+_StateId+",";
        strSql += " CountryId=" + _CountryId + ",";
        strSql += " StatusId=" + _StatusId;
        strSql += " where CityId=" + _CityId;
        //objDbConnector.runSQL(strSql);
        SqlHelper.ExecuteNonQuery(ClsConnectionString.getConnectionString(), CommandType.Text, strSql);
    }
    public DataSet GetStatus()
    {

        string strSql = string.Empty;
        strSql += "select StatusName,StatusId from tbl_Status";
        DataSet dsTemp;
        //ds = objDbConnector.GetDataSet(strSql);
        dsTemp = SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.Text, strSql);
        return dsTemp;

    }

    public DataSet GetState()
    {

        string strSql = string.Empty;
        strSql += "select StateName,StateId from tbl_State";
        if(_CountryId!=0)
        strSql += " where CountryId=" + _CountryId;
        DataSet dsTemp;
        //ds = objDbConnector.GetDataSet(strSql);
        dsTemp = SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.Text, strSql);
        return dsTemp;

    }
    public DataSet GetCountry()
    {
        string strSql = string.Empty;
        strSql += "select CountryName,CountryId from tbl_Country";
        DataSet dsTemp;
        //ds = objDbConnector.GetDataSet(strSql);
        dsTemp = SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.Text, strSql);
        return dsTemp;
    
    }

}
