using System;
using System.Collections.Generic;
using System.Linq;
using Library;
using System.Web.Mvc;
using Web.Data;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Message = Web.Models.Message;

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

        //#region 建立
        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Create(Library.Message message)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View("Create");
        //    }

        //    MessageWeb messageWeb = new MessageWeb();
        //    messageWeb.AddMessage(message);
        //    return RedirectToAction("Index");
        //}
        //#endregion

        #region 建立
        [HttpGet]
        public ActionResult Edit(int userId)
        {
            MessageWeb messageWeb = new MessageWeb();
            Library.Message message = messageWeb.Messages.Single(g => g.UserId == userId);
            return View(message);
        }

        /**更新動作**/
        [HttpPost]
        public ActionResult Edit([Bind(Include = "UserId,UserName, Context, CreatDate")]Library.Message message)
        {
            MessageWeb messageWeb = new MessageWeb();
            message.UserId = messageWeb.Messages.Single(g => g.UserId == message.UserId).UserId;

            if (!ModelState.IsValid)
            {
                return View("Edit", message);
            }

            messageWeb.SaveMessage(message);
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
        public ActionResult Index2()
        {
            ReplyWeb replyWeb = new ReplyWeb();
            List<Library.Reply> replys = replyWeb.Replys.ToList();
            //return View(replys);
            return View("_ReplyPartial", replys);
        }
        #endregion

    }
}
