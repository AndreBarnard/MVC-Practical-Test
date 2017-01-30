using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using System.Messaging;
using PracticalTest.Models;

namespace PracticalTest.Controllers
{
    public class PlayersController : Controller
    {
        // GET: Players
        public ActionResult Index()
        {
            return View();
        }

        // GET: Players/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Players/Create
        [HttpPost]
        public ActionResult Create(Players player)
        {
            try
            {
                SendMessageToQueue(player);

                return RedirectToAction("Sent");
            }
            catch
            {
                return View();
            }
        }

        private void SendMessageToQueue(Players player)
        {
            string queueName = @".\private$\PlayerQueue";
            MessageQueue msMq = null;

            if (!MessageQueue.Exists(queueName))
            {
                msMq = MessageQueue.Create(queueName);
            }
            else
            {
                msMq = new MessageQueue(queueName);
            }

            msMq.Send(player);
        }
        
    }
}
