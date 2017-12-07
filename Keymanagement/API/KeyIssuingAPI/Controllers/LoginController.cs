using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using KeyIssuingAPI.Models;
using Oracle.DataAccess.Client;
using Db_Connection;
using System.Data;
using Newtonsoft.Json;
using System.DirectoryServices;
namespace KeyIssuingAPI.Controllers
{
    public class LoginController : ApiController
    {

        [ActionName("checkLogin")]
        [HttpPost]
        public string checkLogin(mdlUser user)
        {



            string domain = "rchsp.med.sa";
            string usertype = "";
            string[] properties = new string[] { "fullname" };
            try
            {


            DirectoryEntry adRoot = new DirectoryEntry("LDAP://" + domain, user.username, user.password, AuthenticationTypes.Secure);
            DirectorySearcher searcher = new DirectorySearcher(adRoot);
            searcher.SearchScope = SearchScope.Subtree;
            searcher.ReferralChasing = ReferralChasingOption.All;
            searcher.PropertiesToLoad.AddRange(properties);
            searcher.Filter = "(SAMAccountName=" + user.username + ")";
            SearchResult result = null;
            
                result = searcher.FindOne();
                DirectoryEntry directoryEntry = result.GetDirectoryEntry();
                string displayName = directoryEntry.Properties["displayName"][0].ToString();
                if (!string.IsNullOrEmpty(displayName))
                {
                    clsConnection dbconn = new clsConnection();
                    dbconn.openConnection();

                    string strSQL = @"SELECT USERNAME,USERTYPE FROM USERS WHERE USERNAME=:USERNAME";

                    OracleCommand cmd = new OracleCommand(strSQL, dbconn.DbConn);
                    cmd.BindByName = true;
                    cmd.Parameters.Add("USERNAME", OracleDbType.Varchar2, user.username, ParameterDirection.Input);
                    OracleDataReader dr = cmd.ExecuteReader();
                    if (!dr.HasRows)
                    {
                        dr.Dispose();
                        cmd.Dispose();
                        dbconn.closeConnection();
                        return "";
                    }
                    else
                    {
                        dr.Read();
                        usertype = dr["USERTYPE"].ToString();

                        dr.Dispose();
                        cmd.Dispose();
                        dbconn.closeConnection();
                        return usertype;
                    }

                }
                else
                {
                    return "";
                }


            }
            catch (Exception ex)
            {
                return "";

            }




        }
    }
}