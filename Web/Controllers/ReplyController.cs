using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;
using System.Web.Mvc;
using System.Data.Entity;

namespace Web.Controllers
{
    public class ReplyController : Controller
    {
        #region 頁面取得
        public ActionResult Index()
        {
            ReplyWeb replyWeb = new ReplyWeb();
            return View(replyWeb.GetReply());

        }
        #endregion

        #region 建立回覆
        /// <summary>
        /// 建立回覆
        /// </summary>
        /// <param name="messageId">留言message的Id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(int? messageId)
        {
            ViewBag.MessageId = messageId;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Library.Reply reply ,int? messageId)
        {

            if (!ModelState.IsValid)
            {
                return View("Create");
            }

            if (messageId == 0 || (messageId == null))
            {
                return View("Index", "Message");
            }

            ReplyWeb replyWeb = new ReplyWeb();
            replyWeb.AddReply(reply);
            return RedirectToAction("Index" , "Message");
        }
        #endregion

    }
}