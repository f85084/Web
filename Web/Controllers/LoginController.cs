using Library;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
//using Web.Data;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
//using User = Web.Models.User;
using System.Web.Security;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //    [HttpPost]
        //    public ActionResult Login(Library.User login)
        //    {
        //        UserWeb userWeb = new UserWeb();
        //        List<Library.User> users = userWeb.Users.ToList();

        //        if (!ModelState.IsValid)
        //        {
        //            FormsAuthentication.RedirectFromLoginPage(login.UserAccount, false);

        //            return RedirectToAction("Index");
        //        }

        //        //UserWeb userWeb = new UserWeb();
        //        return View("Index", "Message");
        //    }
        //}

        //private bool LoginCheck(Library.User login)
        //{
        //    return (
        //        login.UserAccount == "test@gmail.com" &&
        //        login.Password == "123"
        //        );
    }

}