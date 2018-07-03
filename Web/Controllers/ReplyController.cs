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
            Reply model = new Reply();
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
        public ActionResult Create(Library.Reply reply, int? messageId)
        {

            if (!ModelState.IsValid)
            {
                return View("Create");
            }

            if (messageId == 0)
            {
                return View("Index", "Message");
            }

            ReplyWeb replyWeb = new ReplyWeb();
            replyWeb.AddReply(reply);
            return RedirectToAction("Index", "Message");
        }
        #endregion
    }
}