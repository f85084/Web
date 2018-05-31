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

        #region 編輯方式建立
        //[HttpGet]
        //public ActionResult Edit()
        //{
        //    return View();
        //}

        ///**更新動作**/
        //[HttpPost]
        //public ActionResult Edit([Bind(Include = "UserId,UserName, Context, CreatDate")]Library.Message message)
        //{
        //    MessageWeb messageWeb = new MessageWeb();
        //    message.UserId = messageWeb.Messages.Single(g => g.UserId == message.UserId).UserId;

        //    if (!ModelState.IsValid)
        //    {
        //        return View("Edit", message);
        //    }

        //    messageWeb.SaveMessage(message);
        //    return RedirectToAction("Index");
        //}
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
