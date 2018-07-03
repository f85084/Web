using System;
using System.Collections.Generic;
using System.Linq;
using Library;
using System.Web.Mvc;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using PagedList;
using Library.WebShare;

namespace Web.Controllers
{
    public class MessageController : Controller
    {
        MessageWeb messageWeb = new MessageWeb();

        #region 留言首頁取得 
        /// <summary>
        /// 留言首頁取得 
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Index()
        {
            List<MessageReply> model = messageWeb.GetMessageReplys().ToList();
            string UserAccount = "";
            string UserName = "";
            int Id = 0;
            byte UserClass = 0;

            if (SessionManagement.LoginUser != null)
            {

                UserAccount = Session["UserAccount"].ToString();
                ViewBag.UserAccount = UserAccount;
                UserName = Session["UserName"].ToString();
                ViewBag.UserName = UserName;
                int.TryParse(Session["Id"].ToString(), out Id);
                ViewBag.Id = Id;
                byte.TryParse(Session["UserClass"].ToString(), out UserClass);
                ViewBag.UserClass = UserClass;
            }
            return View(model);
        }

        #endregion

        #region 管理員留言首頁取得 
        /// <summary>
        /// 管理員留言首頁取得
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ManageIndex()
        {
            //List<MessageReply> data = new List<MessageReply>();
            byte UserClass = 0;
            if (SessionManagement.LoginUser != null)
            {
                byte.TryParse(Session["UserClass"].ToString(), out UserClass);
            }
            if (UserClass == 2)
            {
                return View(messageWeb.GetMessageReplys());
            }
            else
            {
                return RedirectToAction("Index", "Message");
            }
        }
        #endregion

        #region 建立留言
        /// <summary>
        /// 建立留言
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Create()
        {
            Message model = new Message();

            string UserName = "";
            int Id = 0;
            if (Session["UserAccount"] != null)
            {
                int.TryParse(Session["Id"].ToString(), out Id);
                model.UserId = Id;
                UserName = Session["UserName"].ToString();
                model.UserName = UserName;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Library.Message message)
        {
            if (!ModelState.IsValid)
            {
                return View("Create");
            }

                messageWeb.AddMessage(message);
            return RedirectToAction("Index");
        }
        #endregion

        #region 刪除
        /// <summary>
        /// 刪除留言
        /// </summary>
        /// <param name="id">留言id</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id)
        {            
            MessageWeb messageWeb = new MessageWeb();
            messageWeb.DeleteMessage(id);
            return Redirect(Request.UrlReferrer.AbsolutePath);
        }
        #endregion

        #region 回覆取得 
        /// <summary>
        /// 回覆取得 
        /// </summary>
        /// <returns></returns>

         public ActionResult ReplyIndex(int messagesId)
        {
            //List<MessageReply> model = messageWeb.GetMessageReplys().ToList();
            Library.MessageReply model = messageWeb.GetMessageReplys().ToList()
             .Find(x => x.Messages.Id == messagesId);
            string UserAccount = "";
            string UserName = "";
            int Id = 0;
            byte UserClass = 0;

            if (SessionManagement.LoginUser != null)
            {

                UserAccount = Session["UserAccount"].ToString();
                ViewBag.UserAccount = UserAccount;
                UserName = Session["UserName"].ToString();
                ViewBag.UserName = UserName;
                int.TryParse(Session["Id"].ToString(), out Id);
                ViewBag.Id = Id;
                byte.TryParse(Session["UserClass"].ToString(), out UserClass);
                ViewBag.UserClass = UserClass;
            }
            return View(model);
        }
        #endregion



    }
}
