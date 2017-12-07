//Programmer : Francel D. Aquino
//Email : francel_aquino@yahoo.com
//Comment : gAwAnG pInOy!!!
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;

namespace Db_Connection 
{
	class clsConnection
	{
        static string strConnection = "Data Source=RCHSPEXTAPP;User ID=Keyman;Password=keyman567;Pooling=false";
        public  OracleConnection DbConn = new OracleConnection(strConnection);

        //Open Database Connection
        public void openConnection()
        {
            if (DbConn.State == ConnectionState.Closed)
            {
                DbConn.Open();
            }
        }

        //Close Database Connection
        public void closeConnection()
        {
            if (DbConn.State == ConnectionState.Open)
            {
                DbConn.Close();
                DbConn.Dispose();
            }
        }
        public string errors(string errmsg)
        {
            if (errmsg.Contains("12154") == true)
            {
                errmsg = "Database connection error...";

            }
            return errmsg;
        }
	}
}
