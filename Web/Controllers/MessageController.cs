using System;
using System.Collections.Generic;
using System.Linq;
using Library;
using System.Web.Mvc;
using Web.Data;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using PagedList;
using Message = Web.Models.Message;
using Reply = Web.Models.Reply;

namespace Web.Controllers
{
    public class MessageController : Controller
    {
        #region 頁面取得
        public ActionResult Index()
        {
            MessageWeb messageWeb = new MessageWeb();
            List<Library.Message> messages = messageWeb.Messages.ToList();
            return View(messages);
        }
        #endregion

        #region 頁面取得 Index3
        [HttpGet]
        public ActionResult Index3(string searchBy, string searchText)
        {
            MessageWeb messageWeb = new MessageWeb();
            List<Library.Message> messages = messageWeb.Messages.ToList();
            if (searchBy == "UserName")
            {
                 messages = messageWeb.Messages
                    .Where(x => x.UserName == searchText || searchText == null)
                    .ToList();
            }
            if (searchBy == "Context")
            {
                messages = messageWeb.Messages
                    .Where(x => x.Context.Contains(searchText) || searchText == null)
                    .ToList();
            }
            //IPagedList<Message> messagePagedList = messages.ToPagedList(pageNumber ?? 1, 5);
            return View(messages);
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

            MessageWeb messageWeb = new MessageWeb();
            messageWeb.AddMessage(message);
            return RedirectToAction("Index");
        }
        #endregion

        #region 刪除
        ///**刪除動作**/
        //[HttpPost]
        //public ActionResult Delete(int id)
        //{
        //    MessageWeb messageWeb = new MessageWeb();
        //    messageWeb.DeleteMessage(id);
        //    return RedirectToAction("Index");
        //}
        #endregion

        #region 測試回覆Partial
        [HttpGet]
        public ActionResult Index2(int messageId = 36)
        {
            ReplyWeb replyWeb = new ReplyWeb();
            List<Library.Reply> replys = replyWeb.Replys.ToList();
            replys = replyWeb.Replys
                    .Where(x => x.MessageId == messageId)
                    .ToList();
            return View("_ReplyPartial", replys);
        }
        #endregion

    }
}
