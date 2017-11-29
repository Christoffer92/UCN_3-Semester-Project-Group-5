using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SolvrWebClient.Models;
using SolvrLibrary;

namespace SolvrWebClient.Controllers
{
    public class PostController : Controller
    {
        public ISolvrDB DB;

        public PostController()
        {
            DB = new SolvrDB();
        }
        public PostController(ISolvrDB _DB)
        {
            DB = _DB;
        }

        public ActionResult Index(Post post)
        {
            //Post post = DB.GetPost(ID);
            ViewBag.Title = post.Title;
            ViewBag.Description = post.Description;
            ViewBag.DateCreated = post.DateCreated.ToShortDateString();
            ViewBag.UserName = DB.GetUser(post.UserId).Username;

            return View();
        }
    }
}