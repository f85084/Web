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

namespace webtext.web.Controllers
{
    public class MessageController : Controller
    {
        public ActionResult Index()
        {
            MessageWeb messageWeb = new MessageWeb();
            List<Library.Message> messages = messageWeb.Messages.ToList();
            return View(messages);
        }

        public ActionResult Details(int id = 0)
        {
            var webContext = new WebContext();
            Message message;
            if (id == 0)
            {
                message = new Message
                {
                    Id = 0,
                    UserId = 0,
                    UserName = "NULL",
                    Context = "NULL",
                };
            }
            else
            {
                message = webContext.Messages.Single(p => p.Id == id);
                //Throws exception if can not find the single entity
            }
            return View(message);
        }

        /**建立**/
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

        /**更新讀取**/
        //[HttpGet]
        //public ActionResult Edit(int id)
        //{
        //    MessageWeb messageWeb = new MessageWeb();
        //    Library.Message message = messageWeb.Messages.Single(g => g.Id == id);
        //    return View(message);
        //}

        ///**更新動作**/
        //[HttpPost]
        //public ActionResult Edit([Bind(Include = "UserId, UserName, Context")]Library.Message message)
        //{
        //    MessageWeb messageWeb = new MessageWeb();
        //    message.Id = messageWeb.Messages.Single(g => g.Id == message.Id).Id;

        //    if (!ModelState.IsValid)
        //    {
        //        return View("Edit", message);
        //    }

        //    messageWeb.SaveMessage(message);

        //    return RedirectToAction("Index");
        //}

        ///**刪除動作**/
        //[HttpPost]
        //public ActionResult Delete(int id)
        //{
        //    MessageWeb messageWeb = new MessageWeb();
        //    messageWeb.DeleteMessage(id);
        //    return RedirectToAction("Index");
        //}

    }
}
