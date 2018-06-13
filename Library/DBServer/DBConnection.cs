using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Library.DBServer
{
    public class DBConnection
    {
        private static string _connectString = null;

        public static string ConnectString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectString))
                {
                    _connectString = ConfigurationManager.ConnectionStrings["WebContext"].ConnectionString;
                }
                return _connectString;
            }
        }
    }
}
