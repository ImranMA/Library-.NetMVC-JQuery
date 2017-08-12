using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Library Management System";
            return View();
        }


        public ActionResult ManageBooks()
        {
            ViewBag.Title = "ManageBooks";
            return View();
        }

        public ActionResult ManageBorrowers()
        {
            ViewBag.Title = "ManageBorrowers";
            return View();
        }


        public ActionResult AssignBooks()
        {
            ViewBag.Title = "AssignBooks";
            return View();
        }

        public ActionResult Test()
        {
            ViewBag.Title = "Test";
            return View();
        }
    }
}
