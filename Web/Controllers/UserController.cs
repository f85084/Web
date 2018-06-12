using Library;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
//using Web.Data;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Configuration;
//using User = Web.Models.User;
using System.Data.SqlClient;
using System.Web.Security;
using System;

namespace Web.Controllers
{
    public class UserController : Controller
    {
        #region 密碼加密
        /// <summary>
        /// 密碼加密
        /// </summary>
        /// <param name="password">密碼</param>
        /// <param name="salt">加密</param>
        /// <returns></returns>
        //protected string CryptographyPassword(string password, string salt)
        //{
        //    string cryptographyPassword =
        //        FormsAuthentication.HashPasswordForStoringInConfigFile(password + salt, "sha1");

        //    return cryptographyPassword;
        //}
        #endregion

        UserWeb userWeb = new UserWeb();

        #region 頁面取得
        public ActionResult Index()
        {
            //List<Library.User> users = userWeb.Users.ToList();
            List<Library.User> users = userWeb.GetUsers().ToList();
            users = userWeb.GetUsers()
                    .Where(x => x.Delete == true)
                    .ToList();
            return View(users);
        }
        #endregion

        #region 建立
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Library.User user, string UserAccount, int UserClass )
        {
            UserWeb userWeb = new UserWeb();

            //帳號重覆
            //List<Library.User> users = userWeb.GetUsers().ToList();
            //users = userWeb.GetUsers()
            //        .Where(x => x.UserAccount == UserAccount)
            //        .ToList();
            //UserAccount = users.ExecuteReader()
            //if ()
            //{
            //    ViewBag.Message = "帳號已重覆";
            //    return View("Create");
            //}
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

        #region 明細
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

        #region 更新
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //List<Library.User> users = userWeb.GetUsers().ToList();
            //users = userWeb.GetUsers()
            //        .Where(x => x.Id == id)
            //        .ToList();

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

        #region 刪除
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

        #region 帳號註冊重複確認
        //確認要註冊帳號是否有被註冊過的方法
        public bool AccountCheck(string UserAccount)
        {
            //藉由傳入帳號取得會員資料
            List<Library.User> users = userWeb.GetUsers().ToList();
            users = userWeb.GetUsers()
                    .Where(x => x.UserAccount == UserAccount)
                    .ToList();
            //判斷是否有查詢到會員
            bool result = (users == null);
            return result; //回傳結果
        }
        #endregion

    }
}
