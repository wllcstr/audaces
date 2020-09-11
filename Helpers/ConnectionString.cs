using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Audaces.Helpers
{
    public class ConnectionString
    {
        public static string getConnectionString()
        {
            string server = "audacesteste.database.windows.net";
            string database = "teste_audaces";
            string user = "wllcstr";
            string pwd = "q1w2e3r4!";
            return "Data Source= " + server + ";Initial Catalog=" + database + ";User ID=" + user + ";Password=" + pwd;
        }
    }
}
