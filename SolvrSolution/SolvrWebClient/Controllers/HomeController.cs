using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SolvrLibrary;
using System.Threading.Tasks;

namespace SolvrWebClient.Controllers
{
    public class HomeController : Controller
    {
        private static RemoteSolvrReference.ISolvrServices DB = new RemoteSolvrReference.SolvrServicesClient();

        public HomeController()
        { 
        }
        

        public async Task<ActionResult> Index(int offSet = 0)
        {
            List<Post> posts = (await DB.GetPostListAsync(offSet, 24, true, false)).ToList();
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