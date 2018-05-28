using ElectionAutomationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectionAutomationSystem.Controllers
{
    public class HomeController : Controller
    {
        private ElectionDatabaseEntities db = new ElectionDatabaseEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View(db);
        }
    }
}