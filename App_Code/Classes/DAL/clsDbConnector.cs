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
using System.Web.Configuration;
/// <summary>
/// This is DAL Class
/// Created By: Team A PropertyNet
/// Created On: 09-Oct-2007
/// Last Modified By: Team A PropertyNet
/// Last Modified On: 09-Oct-2007
/// </summary>
public class clsDbConnector
{
    private SqlConnection dbConnection;
    private SqlDataAdapter dbAdapter;
    private SqlCommand cmd; 


	public clsDbConnector()
	{
        this.dbConnection = new SqlConnection(ConfigurationManager.AppSettings["connstr"]);
        //Or
        //this.dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"]);
        if (dbConnection.State == ConnectionState.Closed)
        {
            try
            {
                if (dbConnection.State == ConnectionState.Broken)
                {
                    dbConnection.Close();
                    dbConnection.Open();
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        if (dbConnection.State == ConnectionState.Broken)
        {
            dbConnection.Close();
            dbConnection.Open();
        }
        cmd = new SqlCommand();
	}


    public DataSet GetDataSet(string strSQL)
    {
        if (dbConnection.State == ConnectionState.Closed)
        {
            dbConnection.Open();
        }
        if (dbConnection.State == ConnectionState.Broken)
        {
            dbConnection.Close();
            dbConnection.Open();
        }
        dbAdapter = new SqlDataAdapter(strSQL, dbConnection);
        DataSet dsTemp;
        dsTemp = new DataSet();
        dbAdapter.Fill(dsTemp);
        dbConnection.Close();
        return dsTemp;
    }

    public SqlDataReader getSqlDataReader(string strSQL)
    {
        if (dbConnection.State == ConnectionState.Closed)
        {
            dbConnection.Open();
        }
        if (dbConnection.State == ConnectionState.Broken)
        {
            dbConnection.Close();
            dbConnection.Open();
        }
        cmd.Connection = dbConnection;
        cmd.CommandText = strSQL;
        return cmd.ExecuteReader();
    }

    public void runSQL(string strSQL)
    {
        if (dbConnection.State == ConnectionState.Closed)
        {
            dbConnection.Open();
        }
        else if (dbConnection.State == ConnectionState.Broken)
        {
            dbConnection.Close();
            dbConnection.Open();
        }
        cmd = new SqlCommand(strSQL, dbConnection);
        cmd.ExecuteNonQuery();
        dbConnection.Close();
    }

    public Boolean BatchTransaction(string[] strSql)
    {
        
        dbConnection.Open();
        SqlTransaction t;
        SqlCommand dbCommand = new SqlCommand();
        t = dbConnection.BeginTransaction();
        dbCommand.Connection = dbConnection;
        dbCommand.Transaction = t;
        try
        {
            for (int i = 0; i < strSql.Length; i++)
            {
                if (strSql[i].ToString() == null)
                    break;
                dbCommand.CommandText = strSql[i].ToString();
                dbCommand.ExecuteNonQuery();
            }
            //Commit Transactions
            t.Commit();
            t = null;
            dbCommand.Dispose();
            dbConnection.Close();
            return true;
        }
        catch (Exception ex)
        {
            //Rollback Transactions
            t.Rollback();
            t = null;
            string str = ex.Message;
            dbCommand.Dispose();
            dbConnection.Close();
            return false;
        }
    }
}
