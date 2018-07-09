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
using PagedList.Mvc;

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
        public ActionResult Index(int? pageNumber)
        {
            List<MessageReply> model = messageWeb.GetMessageReplys().ToList();
            IPagedList<MessageReply> messageReplyPagedList = model.ToPagedList(pageNumber ?? 1, 5);
            return View(messageReplyPagedList);
        }

        #endregion

        #region 管理員留言首頁取得 
        /// <summary>
        /// 管理員留言首頁取得
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ManageIndex(string searchText,int? pageNumber)
        {
            //List<MessageReply> data = new List<MessageReply>();
            List<MessageReply> model = messageWeb.GetMessageReplys().ToList();
            if (SessionManagement.LoginUser != null && SessionManagement.LoginUser.UserClass == 2)
            {
                if (searchText != null)
                {
                    List<Library.MessageReply> model2 = messageWeb.GetMessageReplys()
                         .Where(x => x.Messages.Context.Contains(searchText) || searchText == null).ToList();
                    IPagedList<MessageReply> messageReplyPagedList = model2.ToPagedList(pageNumber ?? 1, 10);
                    return View(messageReplyPagedList);
                }
                else
                {
                    //return View(messageWeb.GetMessageReplys());
                    IPagedList<MessageReply> messageReplyPagedList = model.ToPagedList(pageNumber ?? 1, 10);
                    return View(messageReplyPagedList);
                }
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

            if (SessionManagement.LoginUser != null)
            {
                model.UserId = SessionManagement.LoginUser.Id;
                model.UserName = SessionManagement.LoginUser.UserName;
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
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            messageWeb.DeleteMessage(id);
            if (SessionManagement.LoginUser.UserClass == 2)
            {
                return Redirect(Request.UrlReferrer.AbsolutePath);
            }
            else
            {
                return RedirectToAction("Index", "Message");
            }
        }
        #endregion

        #region 回覆取得 
        /// <summary>
        /// 回覆取得 
        /// </summary>
        /// <returns></returns>

         public ActionResult ReplyIndex(int? messagesId)
        {
            Library.MessageReply model = messageWeb.GetMessageReplys().ToList()
             .Find(x => x.Messages.Id == messagesId);
            string UserAccount = "";
            string UserName = "";

            if (messagesId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            if (SessionManagement.LoginUser != null)
            {
                UserAccount = SessionManagement.LoginUser.UserAccount;
                ViewBag.UserAccount = UserAccount;
                UserName = SessionManagement.LoginUser.UserName;
                ViewBag.UserName = UserName;
            }
            if (SessionManagement.LoginUser.UserClass != 2)
            {
                return RedirectToAction("Index");
            }
                return View(model);
        }
        #endregion

        #region 刪除回覆
        /// <summary>
        /// 刪除回覆
        /// </summary>
        /// <param name="id">留言id</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteReply(int ReplyId)
        {
            ReplyWeb replyWeb = new ReplyWeb();
            replyWeb.DeleteMessage(ReplyId);
            //return Redirect(Request.UrlReferrer.AbsolutePath);
            return RedirectToAction("ManageIndex");
        }
        #endregion


    }
}
