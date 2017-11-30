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

        public ActionResult Index(int ID = 1)
        {
            Post post = DB.GetPost(ID);
            ViewBag.Title = post.Title;
            ViewBag.Description = post.Description;
            ViewBag.DateCreated = post.DateCreated.ToShortDateString();
            ViewBag.UserName = DB.GetUser(post.UserId).Username;
            ViewBag.UserID = post.UserId;

            //sortere efter tid
            ViewBag.CommentList = DB.GetComments(ID).OrderBy(x => x.DateCreated).ToList();

            //Usorteret
            //ViewBag.CommentList = DB.GetComments(ID);

            var model = new CommentViewModel();
            model.PostId = post.Id;

            return View(model);
        }

        public ActionResult PostComment(CommentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CreateComment(model);
                }
            }
            catch (Exception e)
            {
                //TODO: Print error message
                return View();
            }
            
            return RedirectToAction("Index", new { ID = model.PostId });
        }

        private void CreateComment(CommentViewModel model)
        {
            Comment c = new Comment();
            c.Text = model.Text;
            c.PostId = model.PostId;

            //TODO: Connect a user to this method
            //p.User = something goes here
            c.User = DB.GetUser();
            c.UserId = c.User.Id;

            DB.CreateComment(c);
        }

        //public ActionResult Index(Post post)
        //{
        //    //Post post = DB.GetPost(ID);
        //    ViewBag.Title = post.Title;
        //    ViewBag.Description = post.Description;
        //    ViewBag.DateCreated = post.DateCreated.ToShortDateString();
        //    ViewBag.UserName = DB.GetUser(post.UserId).Username;

        //    return View();
        //}
    }
}