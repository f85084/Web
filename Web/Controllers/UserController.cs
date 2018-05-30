using Library;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Web.Data;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Configuration;
using User = Web.Models.User;
using System.Data.SqlClient;

namespace Web.Controllers
{
    public class UserController : Controller
    {

        #region 頁面取得
        public ActionResult Index()
        {
            UserWeb context = new UserWeb();
            List<Library.User> users = context.Users.ToList();
            return View(users);
        }
        #endregion

        #region 明細
        public ActionResult Details(int id = 0)
        {
            var webContext = new WebContext();
            //string connectionString = ConfigurationManager.ConnectionStrings["webContext"].ConnectionString;

            //using (SqlConnection con = new SqlConnection(connectionString))
            {
                User user;
                if (id == 0)
                {
                    user = new User
                    {
                        Id = 0,
                        UserAccount = "Name0",
                        UserClass = 0,
                        Email = "NULL",
                        Password = "NULL",
                        UserName = "NULL"
                    };
                }
                else
                {
                    user = webContext.Users.Single(p => p.Id == id);
                    //    //Throws exception if can not find the single entity

                    //UserWeb userWeb = new UserWeb();
                    //Library.User users = userWeb.Users.Single(g => g.Id == id);
                }
                return View(user);
            }
        }
        #endregion


        #region 建立
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Library.User user)
        {
            if (!ModelState.IsValid)
            {
                return View("Create");
            }

            UserWeb userWeb = new UserWeb();
            userWeb.AddUser(user);
            return RedirectToAction("Index");
        }
        #endregion

        #region 更新
        [HttpGet]
        public ActionResult Edit(int id)
        {
            UserWeb userWeb = new UserWeb();
            Library.User user = userWeb.Users.Single(g => g.Id == id);
            return View(user);
        }

        /**更新動作**/
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,UserAccount, UserClass, Email, Password, UserName")]Library.User user)
        {
            UserWeb userWeb = new UserWeb();
            user.Id = userWeb.Users.Single(g => g.Id == user.Id).Id;

            if (!ModelState.IsValid)
            {
                return View("Edit", user);
            }

            userWeb.SaveUser(user);
            return RedirectToAction("Index");
        }
        #endregion

        #region 刪除
        [HttpPost]
        public ActionResult Delete(int id)
        {
            UserWeb userWeb = new UserWeb();
            userWeb.DeleteUser(id);
            return RedirectToAction("Index");
        }
        #endregion


    }
}
