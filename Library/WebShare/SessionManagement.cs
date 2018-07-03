using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebShare
{
    public class SessionManagement 
    {
        internal struct SessionKey
        {
            internal const string LoginUser = "LoginUser";
        }

        public static User LoginUser
        {
            get
            {
                return System.Web.HttpContext.Current.Session[SessionKey.LoginUser] as User;
            }
            set
            {
                System.Web.HttpContext.Current.Session[SessionKey.LoginUser] = value;
            }
        }

    }
}
