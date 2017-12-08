using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SolvrLibrary;
using SolvrServices;

namespace SolvrWebClient.Controllers
{
    public class HomeController : Controller
    {
        public ISolvrServices DB;

        public HomeController()
        {
            DB = new SolvrService();
        }

        public HomeController(ISolvrServices _DB)
        {
            DB = _DB;
        }

        public ActionResult Index(int loadCount = 0)
        {
            IEnumerable<Post> posts = DB.GetPostsByBumpTime(loadCount);
            ViewBag.PostList = posts;
            ViewBag.LoadCount = loadCount;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult NotImplementedYet()
        {
            ViewBag.Message = "This page is under construction.";

            return View();
        }


    }
}