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
///This is BOL State_Logic Class
/// Created By: Team A PropertyNet
/// Created On: 15-Oct-2007
/// Last Modified By: Team A PropertyNet
/// Last Modified On: 15-Oct-2007
/// </summary>
public class clsState_Logic
{
	private int _StateId;
    private string _StateName;
    private string _StateDescr;
    public string Sort_On;
    private int _StatusId;
    private string _StatusName;
    private string _CountryName;
    private int _CountryId;
    //private clsDbConnector objDbConnector;
	public clsState_Logic()
	{
        //objDbConnector = new clsDbConnector();
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
            if (value.ToString() == "")
            {
                _StateName = "";
            }
            else
            {
                _StateName = value;
            }
        }
    }
    public string pro_StateDescription
    {
        get
        {
            return _StateDescr;
        }
        set
        {
            if (value.ToString() == "")
            {
                _StateDescr = "";
            }
            else
            {
                _StateDescr = value;
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
            _CountryName= value;
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

    public DataSet GetState()
    {
        string strSql = string.Empty;
        strSql = "select st.StateId,st.StateName,st.StateDescription,c.CountryName,s.StatusName from tbl_Status s, tbl_State st,tbl_Country c where st.CountryId=c.CountryId and s.StatusId=st.StatusId";
        if (_StateName != "")
        {
            
            strSql += " and StateName like '%" + _StateName + "%'";
            
        }
        if (_CountryName != "select" && _CountryName!=null)
            strSql = strSql + " and CountryName='" + _CountryName + "'";
        //else
        //{
        //    strSql = strSql + " and CountryName='" + _CountryName + "'";
        //}
        
        if (Sort_On != "")
        {
            strSql = strSql + " ORDER BY " + Sort_On;
        }
        else
        {
            strSql = strSql + " Order By StateName";
        }
        

        DataSet dsTemp;
        //dsTemp = objDbConnector.GetDataSet(strSql);
        dsTemp = SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.Text, strSql);
        return dsTemp;
    }
    public void AddState()
    {
        string strSql = string.Empty;
        
        strSql += "Insert into tbl_State(StateName,StateDescription,CountryId,StatusId)";
        strSql += " values('" + _StateName + "',";
        strSql += " '" + _StateDescr + "',"+_CountryId+"," + _StatusId + ")";
        //objDbConnector.runSQL(strSql);
        SqlHelper.ExecuteNonQuery(ClsConnectionString.getConnectionString(), CommandType.Text, strSql);
    }

    public void DeleteState(string StateId)
    {
        string strSql = string.Empty;
        strSql += "delete from tbl_State";
        strSql += " where StateId in('" + StateId.Replace(",","','") + "')";               
        //objDbConnector.runSQL(strSql);
        SqlHelper.ExecuteNonQuery(ClsConnectionString.getConnectionString(), CommandType.Text, strSql);
    }
    public void GetStateDetails()
    {
        string strSql = string.Empty;
        strSql += "select st.StateId,st.StateName,st.StateDescription,c.CountryName,s.StatusName from tbl_Status s, tbl_State st,tbl_Country c where st.CountryId=c.CountryId and s.StatusId=st.StatusId";
        strSql += " and StateId=" + _StateId;
        DataSet dsTemp;
       // dsTemp = objDbConnector.GetDataSet(strSql);
        dsTemp = SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.Text, strSql);
        DataRowCollection drc = dsTemp.Tables[0].Rows;
        if (drc.Count > 0)
        {
            _StateName = drc[0]["StateName"].ToString();
            _StateDescr = drc[0]["StateDescription"].ToString();
            _CountryName = drc[0]["CountryName"].ToString();
            _StatusName = drc[0]["StatusName"].ToString();
        }
        else
        {
            _StateName = "";
            _StateDescr = "";
            _CountryName = "";
            _StatusName = "";
        }
    }
    public void UpdateState()
    {
        string strSql = string.Empty;
        strSql += "Update tbl_State set";
        strSql += " StateName='" + _StateName + "',";
        strSql += " StateDescription='" + _StateDescr + "',";
        strSql += " CountryId=" + _CountryId+",";
        strSql += " StatusId=" + _StatusId;
        strSql += " where StateId=" + _StateId;
        //objDbConnector.runSQL(strSql);
        SqlHelper.ExecuteNonQuery(ClsConnectionString.getConnectionString(), CommandType.Text, strSql);
    }

    public DataSet GetStatusName()
    {

        string strSql = string.Empty;
        strSql += "select StatusName,StatusId from tbl_Status";
        DataSet dsTemp;
        //ds = objDbConnector.GetDataSet(strSql);
        dsTemp = SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.Text, strSql);
        return dsTemp;

    }

    public DataSet GetCountryName()
    {
        string strSql = string.Empty;
        strSql += "select CountryName,CountryId from tbl_Country";
        DataSet dsTemp;
        //ds = objDbConnector.GetDataSet(strSql);
        dsTemp = SqlHelper.ExecuteDataset(ClsConnectionString.getConnectionString(), CommandType.Text, strSql);
        return dsTemp;
    
    }


}
