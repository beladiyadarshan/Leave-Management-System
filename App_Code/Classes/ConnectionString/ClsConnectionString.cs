using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for ClsConnectionstring
/// </summary>
public class ClsConnectionString
{
	public ClsConnectionString()
	{
		
	}
    public static string getConnectionString()
    {
        return ConfigurationManager.AppSettings["connstr"];
    }
}
