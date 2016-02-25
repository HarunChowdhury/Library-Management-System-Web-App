using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace DropDownListPractice.DAL.Gateway
{
    public class Gateway
    {
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }

        public Gateway(string connName)
        {
            Connection = new SqlConnection(WebConfigurationManager.ConnectionStrings[connName].ConnectionString);
            Command = new SqlCommand();
            Command.Connection = Connection;
        }
    }
}