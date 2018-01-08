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
        private static RemoteSolvrReference.ISolvrServices DB = new RemoteSolvrReference.SolvrServicesClient();


        public ActionResult Index(int ID = 0)
        {

            if (DB.GetPost(ID, false, false, true).PostType.Equals("Physical"))
            {
                return RedirectToAction("PhysicalIndex", new { ID = ID });
            }
            else
            {
                Post post = DB.GetPost(ID, true, true, true);
                ViewBag.Title = post.Title;
                ViewBag.Description = post.Description;
                ViewBag.DateCreated = post.DateCreated.ToShortDateString();
                ViewBag.UserId = post.UserId;
                ViewBag.Username = DB.GetUser(post.UserId, "").Username;
                ViewBag.LastEdited = post.LastEdited;

                string tags = "";

                foreach (string item in post.Tags)
                {
                    tags = tags + " " + item;
                }

                ViewBag.Tags = tags;

                ViewBag.UserIsOwner = false;
                User user = null;
                try
                {
                    if (Session["Username"] != null)
                    {
                        user = DB.GetUser(0, (string)Session["Username"]);

                        if (user != null && user.Id == post.UserId)
                            ViewBag.UserIsOwner = true;
                    }
                    
                }
                catch
                {
                    // empty catch, because any exceptions here would (hopefully) not affect the program on runtime.
                }


                //sortere efter tid
                ViewBag.CommentList = DB.GetCommentList(post.Id, true).OrderBy(x => x.DateCreated).ToList();


                var model = new CommentViewModel();
                model.PostId = post.Id;

                return View(model);
            }

        }

        public ActionResult PhysicalIndex(int ID = 0)
        {

            if (DB.GetPost(ID, false, false, true).PostType.Equals("Post"))
            {
                return RedirectToAction("Index", new { ID = ID });
            }
            else
            {
                PhysicalPost ppost = (PhysicalPost)DB.GetPost(ID, true, true, true);
                ViewBag.Title = ppost.Title;
                ViewBag.Description = ppost.Description;
                ViewBag.DateCreated = ppost.DateCreated.ToShortDateString();
                ViewBag.Username = DB.GetUser(ppost.UserId, "").Username;
                ViewBag.UserId = ppost.UserId;
                ViewBag.AltDescription = ppost.AltDescription;
                ViewBag.Address = ppost.Address;
                ViewBag.Zipcode = ppost.Zipcode;
                ViewBag.IsLocked = ppost.IsLocked;
                ViewBag.LastEdited = ppost.LastEdited;

                string tags = "";

                foreach (string item in ppost.Tags)
                {
                    tags = tags + " " + item;
                }

                ViewBag.Tags = tags;

                //sorteret omvendt efter tid
                IEnumerable<Comment> commentList = DB.GetCommentList(ppost.Id, true).OrderByDescending(x => x.DateCreated).ToList();
                ViewBag.CommentList = commentList;

                User user = null;
                ViewBag.UserIsAccepted = false;
                try
                {
                    if (Session["Username"] != null)
                    {
                        user = DB.GetUser(0, (string)Session["Username"]);
                        foreach (SolvrComment item in commentList)
                        {
                            if (item.CommentType.Equals("Solvr") && item.IsAccepted && item.UserId == user.Id)
                            {
                                ViewBag.UserIsAccepted = true;
                                break;
                            }
                        }
                    }
                }
                catch
                {
                    ViewBag.UserIsAccepted = false;
                }

                ViewBag.UserIsOwner = false;

                if (user != null && user.Id == ppost.UserId)
                    ViewBag.UserIsOwner = true;



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
                    else if (comment.Equals("Apply"))
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
                return View("Error");
            }

            return RedirectToAction("Index", new { ID = model.PostId });
        }

        private void CreateComment(CommentViewModel model)
        {
            Comment c = new Comment();
            c.Text = model.Text;
            c.PostId = model.PostId;
            try
            {
                c.User = DB.GetUser(0, (string)Session["Username"]);
                c.UserId = c.User.Id;
            }
            catch (Exception)
            {

                throw new ArgumentNullException();
            }


            DB.CreateComment(c);
        }

        private void CreateSolvr(CommentViewModel model)
        {
            SolvrComment sc = new SolvrComment();
            sc.Text = model.Text;
            sc.PostId = model.PostId;

            sc.User = DB.GetUser(0, (string)Session["Username"]);
            sc.UserId = sc.User.Id;

            DB.CreateComment(sc);
        }

        public ActionResult ChooseSolvr(int ID = 0)
        {
            SolvrComment sc = (SolvrComment)DB.GetComment(ID, false, false);

            if (sc.IsAccepted)
            {
                sc.IsAccepted = false;
            }
            else
            {
                sc.TimeAccepted = DateTime.Now;
                sc.IsAccepted = true;
            }

            DB.UpdateComment(sc);

            return RedirectToAction("Index", new { ID = sc.PostId });
        }

        public ActionResult Report(int ID = 0, string type = "", string username = "")
        {
            ReportViewModel model = new ReportViewModel();

            try
            {
                if ((ID > 0 || !username.Equals("")) && !type.Equals(""))
                {
                    switch (type)
                    {
                        case "Post":
                            model.PostId = DB.GetPost(ID, false, false, false).Id;
                            break;

                        case "Comment":
                            model.CommentId = DB.GetComment(ID, false, false).Id;
                            break;

                        case "User":
                            model.UserId = DB.GetUser(0, username).Id;
                            break;

                        default:
                            throw new ArgumentException();
                    }
                }
            }
            catch (Exception e)
            {
                return View("Error");
            }

            model.ReportType = type;

            return View(model);
        }

        public ActionResult SubmitReport(ReportViewModel model)
        {
            Report rep = new Report();
            rep.Title = model.Title;
            rep.Description = model.Description;

            try
            {
                switch (model.ReportType)
                {
                    case "Post":
                        rep.ReportType = "post";
                        rep.PostId = model.PostId;
                        break;

                    case "Comment":
                        rep.ReportType = "comment";
                        rep.CommentId = model.CommentId;
                        break;

                    case "User":
                        rep.ReportType = "user";
                        rep.UserId = model.UserId;
                        break;

                    default:
                        throw new ArgumentException();
                }

                DB.CreateReport(rep);
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("Index", "Home");
        }
    }
}