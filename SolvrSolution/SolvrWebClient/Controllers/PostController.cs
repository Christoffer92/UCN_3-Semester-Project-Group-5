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

        public ActionResult Index(int ID = 0)
        {

            if (DB.GetPost(ID).PostType.Equals("Physical"))
            {
                return RedirectToAction("PhysicalIndex", new { ID = ID });
            }
            else
            {
                Post post = DB.GetPost(ID);
                ViewBag.Title = post.Title;
                ViewBag.Description = post.Description;
                ViewBag.DateCreated = post.DateCreated.ToShortDateString();
                ViewBag.UserId = post.UserId;
                ViewBag.Username = DB.GetUser(post.UserId).Username;

                string tags = "";

                foreach (string item in post.Tags)
                {
                    tags = tags + " " + item;
                }

                ViewBag.Tags = tags;

                //sortere efter tid
                ViewBag.CommentList = DB.GetComments(post.Id).OrderBy(x => x.DateCreated).ToList();

                //Usorteret
                //ViewBag.CommentList = DB.GetComments(ID);

                var model = new CommentViewModel();
                model.PostId = post.Id;

                return View(model);
            }
            
        }

        public ActionResult PhysicalIndex(int ID = 1)
        {

            if (DB.GetPost(ID).PostType.Equals("Post"))
            {
                return RedirectToAction("Index", new { ID = ID });
            }
            else
            {
                PhysicalPost ppost = DB.GetPhysicalPost(ID);
                ViewBag.Title = ppost.Title;
                ViewBag.Description = ppost.Description;
                ViewBag.DateCreated = ppost.DateCreated.ToShortDateString();
                ViewBag.User = DB.GetUser(ppost.UserId);
                ViewBag.AltDescription = ppost.AltDescription;
                ViewBag.Address = ppost.Address;
                ViewBag.Zipcode = ppost.Zipcode;


                string tags = "";

                foreach (string item in ppost.Tags)
                {
                    tags = tags + " " + item;
                }

                ViewBag.Tags = tags;

                //sortere efter tid
                ViewBag.CommentList = DB.GetComments(ppost.Id).OrderBy(x => x.DateCreated).ToList();

                //Usorteret
                //ViewBag.CommentList = DB.GetComments(ID);

                var model = new CommentViewModel();
                model.PostId = ppost.Id;

                return View(model);
            }
        }


        public ActionResult PostComment(CommentViewModel model, string comment = "Post Comment")
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (comment.Equals("Post Comment"))
                    {
                        CreateComment(model);
                    }
                    else if(comment.Equals("Apply"))
                    {
                        CreateSolvr(model);
                    }
                    else
                    {
                        return View();
                    }
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

        private void CreateSolvr(CommentViewModel model)
        {
            SolvrComment sc = new SolvrComment();
            sc.Text = model.Text;
            sc.PostId = model.PostId;

            //TODO: Connect a user to this method
            //p.User = something goes here
            sc.User = DB.GetUser();
            sc.UserId = sc.User.Id;

            DB.CreateSolvrComment(sc);
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