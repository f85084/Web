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
        public ActionResult Index()
        {
            List<MessageReply> model = messageWeb.GetMessageReplys().ToList();
            
            //List<Library.Message> messages = messageWeb.GetMessages().ToList();
            //List<Reply> replys = new ReplyWeb().GetReply().ToList();

            //foreach (var msg in messages)
            //{
            //    MessageReply item = new MessageReply();
            //    item.Messages = msg;
            //    item.ReplyList = replys.Where(r => r.MessageId == msg.Id).ToList();
            //    model.Add(item);
            //}

            //messages = messageWeb.GetMessages()
            //        .Where(x => !x.Delete)
            //        .ToList();

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
            return View(messageWeb.GetMessages());
        }
        #endregion

        #region 建立留言
        /// <summary>
        /// 建立留言
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            Message model = new Message();
            //bool isLogin = true;

            //if (isLogin)
            //{
            //}
            //else
            //{
            //    model.UserId = 0;
            //    model.UserName = "匿名";
            //}

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
            return RedirectToAction("Index");
        }
        #endregion

    }
}
