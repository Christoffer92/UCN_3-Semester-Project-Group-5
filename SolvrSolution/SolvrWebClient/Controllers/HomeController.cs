using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SolvrLibrary;

namespace SolvrWebClient.Controllers
{
    public class HomeController : Controller
    {
        public ISolvrDB DB;

        public HomeController()
        {
            DB = new SolvrDB();
        }
        public HomeController(ISolvrDB _DB)
        {
            DB = _DB;
        }

        public ActionResult Index(int loadCount = 0)
        {
            IEnumerable<Post> posts = DB.GetPostsByBumpTime(loadCount);
            ViewBag.PostList = posts;
            

            if (posts.Count() == 0)
            {
                return View("Error");
            }
            else if (loadCount < 0)
            {
                ViewBag.LoadCount = 0;
            }
            else
            {
                ViewBag.LoadCount = loadCount;
            }

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