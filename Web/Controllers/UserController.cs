using Library;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using System;

namespace Web.Controllers
{
    public class UserController : Controller
    {

        UserWeb userWeb = new UserWeb();

        #region 會員首頁取得

        /// <summary>
        /// 會員首頁取得
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            List<Library.User> users =  userWeb.GetUsers()
                    .Where(x => !x.Delete )
                    .ToList();
            return View(users);
        }
        #endregion

        #region 建立會員

        /// <summary>
        /// 建立會員
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Library.User user, string UserAccount, int UserClass )
        {
            UserWeb userWeb = new UserWeb();


            if (!ModelState.IsValid)
            {
                return View("Create");
            }

            userWeb.AddUser(user);
            if (UserClass == 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index" , "Message");
            }
        }
        #endregion

        #region 明細頁

        /// <summary>
        /// 明細頁
        /// </summary>
        /// <param name="id">會員Id</param>
        /// <returns></returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Library.User user = userWeb.GetUsers().Single(g => g.Id == id);

            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        #endregion

        #region 編輯會員資料

        /// <summary>
        /// 編輯會員資料
        /// </summary>
        /// <param name="id">會員Id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Library.User user = userWeb.GetUsers().Single(g => g.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,UserAccount, UserClass, Email, Password, UserName")]Library.User user)
        {
            user.Id = userWeb.GetUsers().Single(g => g.Id == user.Id).Id;

            if (!ModelState.IsValid)
            {
                return View("Edit", user);
            }

            userWeb.SaveUser(user);
            return RedirectToAction("Index");
        }
        #endregion

        #region 刪除會員

        /// <summary>
        /// 刪除會員
        /// </summary>
        /// <param name="id">會員Id</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id)
        {
            userWeb.DeleteUser(id);
            return RedirectToAction("Index");
        }
        #endregion

        #region 會員登入
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Logon(LogonViewModel logonModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }
        //    /*
        //    var systemuser = db.SystemUsers
        //        .Include(x => x.SystemRoles)
        //        .FirstOrDefault(x => x.Account == logonModel.Account);
        //        */

        //    UserWeb userWeb = new UserWeb();
        //    //List<Library.User> users = userWeb.Users.ToList();
        //    //users = userWeb.Users
        //    //        .Where(x => x.UserAccount == logonModel.UserAccount)
        //    //        .ToList();

        //    var userAccount = userWeb.Users
        //       .Where(x => x.UserAccount == logonModel.UserAccount);


        //    if (userAccount == null)
        //    {
        //        ModelState.AddModelError("", "請輸入正確的帳號或密碼!");
        //        return View();
        //    }

        //    var password = CryptographyPassword(logonModel.Password, BaseController.PasswordSalt);

        //    if (userAccount.Password.Equals(password))
        //    {
        //        //this.LoginProcess(userAccount);
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "請輸入正確的帳號或密碼!");
        //        return View();
        //    }
        //}
        #endregion

    }
}
