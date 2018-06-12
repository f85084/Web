using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;
using System.Web.Mvc;
//using Web.Data;
using System.Data.Entity;
//using Reply = Web.Models.Reply;


namespace Web.Controllers
{
    public class ReplyController : Controller
    {
        #region 頁面取得
        public ActionResult Index()
        {
            ReplyWeb replyWeb = new ReplyWeb();
            //List<Library.Reply> replys = replyWeb.Replys.ToList();
            return View(replyWeb.GetReply());
            //return View("_ReplyPartial", replys);

        }
        #endregion

        #region 建立
        [HttpGet]
        public ActionResult Create(int? messageId)
        {
            ViewBag.MessageId = messageId;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Library.Reply reply )
        {

            if (!ModelState.IsValid)
            {
                return View("Create");
            }

            ReplyWeb replyWeb = new ReplyWeb();
            replyWeb.AddReply(reply);
            return RedirectToAction("Index" , "Message");
        }
        #endregion

        //#region 回覆Partial
        //[HttpGet]
        //public PartialViewResult ReplyPartial(int MessageId)
        //{
        //    ReplyWeb replyWeb = new ReplyWeb();
        //    List<Library.Reply> replys = replyWeb.Replys.ToList();
        //    //Library.Reply reply = replyWeb.Replys.Single(g => g.Id == id);
        //    return PartialView(replys);
        //}
        //#endregion


        #region 測試回覆Partial
        //[HttpGet]
        //public ActionResult _ReplyPartial(int messageId)
        //{
        //    ReplyWeb replyWeb = new ReplyWeb();
        //    List<Library.Reply> replys = replyWeb.GetReply().ToList();
        //    replys = replyWeb.Replys
        //            .Where(x => x.MessageId == messageId)
        //            .ToList();
        //    return View("_ReplyPartial", replys);
        //}
        #endregion

    }
}