using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;
using System.Web.Mvc;
using web.Data;
using System.Data.Entity;
using Reply = web.Models.Reply;

namespace webtext.web.Controllers
{
    public class ReplyController : Controller
    {
        public ActionResult Index()
        {
            MessageWeb messageWeb = new MessageWeb();
            List<Library.Message> messages = messageWeb.Messages.ToList();
            return View(messages);
        }

        public ActionResult Details(int id = 0)
        {
            var WebContext = new webContext();
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
                message = WebContext.Messages.Single(p => p.Id == id);
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

    }
}