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
        private static RemoteSolvrReference.ISolvrServices DB = new RemoteSolvrReference.SolvrServicesClient();

        public HomeController()
        { 
        }
        

        public ActionResult Index(int offSet = 0)
        {
            List<Post> posts = DB.GetPostList(offSet, 24, true, false).ToList();
            ViewBag.PostList = posts;
            

            if (posts.Count() == 0)
            {
                return View("Error");
            }
            else if (offSet < 0)
            {
                ViewBag.offSet = 0;
            }
            else
            {
                ViewBag.offSet = offSet;
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