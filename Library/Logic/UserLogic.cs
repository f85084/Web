using Library;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Configuration;
using System.Data.SqlClient;
using System;
using System.Web;

namespace Library.Logic
{
    public class UserLogic
    {
        UserWeb userWeb = new UserWeb();


        #region 會員登入

        /// <summary>
        /// 會員登入
        /// </summary>
        /// <returns></returns>
        public string LoginCheck(string UserAccount, string Password)
        {
            if (userWeb.CheckAccount(UserAccount))
            {
                //驗證密碼
                if (userWeb.CheckPassword(UserAccount, Password))
                {
                    return "";
                }
                else
                {
                    return "密碼輸入錯誤...";
                }
            }
            else
            {
                return "找不到帳號...";
            }
        }
        #endregion

        #region 取得角色
        ////取得會員的權限角色資料
        //public string GetRole(string UserName)
        //{
        //    //宣告初始角色字串
        //    string Role = "User";
        //    //取得傳入帳號的會員資料
        //    User LoginMember = userWeb.GetUsers().ToList().Find(UserName);
        //    //判斷資料庫欄位，用以確認是否為Admon
        //    if (LoginMember.UserClass)
        //    {
        //        Role += ",Admin"; //添加Admin
        //    }
        //    //回傳最後結果
        //    return Role;
        //}
        #endregion

    }
}
