using System;
using System.Collections.Generic;
using System.Linq;
using Library;
using System.Web.Mvc;
//using Web.Data;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using PagedList;

namespace Web.Controllers
{
    public class MessageController : Controller
    {
        MessageWeb messageWeb = new MessageWeb();

        #region 頁面取得
        public ActionResult Index(string searchBy, string searchText)
        {

            List<Library.Message> messages = messageWeb.GetMessages().ToList();
            messages = messageWeb.GetMessages()
                    .Where(x => x.Delete == true)
                    .ToList();

            return View(messages);
        }
        #endregion

        #region 頁面取得 Index3
        [HttpGet]
        public ActionResult Index3()
        {
            //List<MessageReply> data = new List<MessageReply>();
            return View(messageWeb.GetMessages());
        }
        #endregion

        #region 建立
        [HttpGet]
        public ActionResult Create()
        {
            return View();
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
        [HttpPost]
        public ActionResult Delete(int id)
        {
            MessageWeb messageWeb = new MessageWeb();
            messageWeb.DeleteMessage(id);
            return RedirectToAction("Index");
        }
        #endregion

        #region 測試回覆Partial
        [HttpGet]
        public ActionResult Index2(int? messageId)
        {
            ViewBag.MessageId = messageId;
            ReplyWeb replyWeb = new ReplyWeb();
            List<MessageReply> data = new List<MessageReply>();
            List<Library.Reply> replys = replyWeb.GetReply().ToList();
            List<MessageReply> test = data.ToList();
            //replys = replyWeb.GetReply()
            //        .Where(x => x.MessageId == messageId)
            //        .ToList();
            //return View("_ReplyPartial", replys);

            replys = replyWeb.GetReply()
                    .Where(x => x.MessageId == messageId)
                    .ToList();
            return View("_ReplyPartial", replys);
        }
        #endregion

    }
}
