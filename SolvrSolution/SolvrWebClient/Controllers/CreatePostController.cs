using SolvrLibrary;
using SolvrWebClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;

namespace SolvrWebClient.Controllers
{
    public class CreatePostController : Controller
    {
        private static RemoteSolvrReference.ISolvrServices DB = new RemoteSolvrReference.SolvrServicesClient();

        //CreatePost:
        //  Create a post with the following attributes from PostViewModel model.
        //  Also add the logged in user as the owner of the post.
        //  Tags:
        //      Adds an array of strings to the tag list by seperating them with the split function
        //      Space, hashtags, commas, and full stop will split the tag string up.
        public Post CreatePost(PostViewModel model)
        {
            Post p = new Post();
            p.Title = model.Title;
            p.CategoryId = model.CategoryId;
            p.Description = model.Description;

            foreach (string item in model.TagsString.Split(' ', '#', ',', '.'))
            {
                if (!item.Equals("") && !item.Equals("#") && !item.Equals(",") && !item.Equals("."))
                {
                    p.Tags.Add(item);
                }
            }

            try
            {
                p.UserId = DB.GetUser(0, (string)Session["Username"]).Id;
                return DB.CreatePost(p);
            }
            catch (Exception)
            {
                return null;
            }

        }

        //CreatePhysicalPost:
        //  Create a physical post with the following attributes from PhysicalPostViewModel model.
        //  Also add the logged in user as the owner of the post.
        //  Tags:
        //      Adds an array of strings to the tag list by seperating them with the split function
        //      Space, hashtags, commas, and full stop will split the tag string up.
        public PhysicalPost CreatePhysicalPost(PhysicalPostViewModel model)
        {
            PhysicalPost p = new PhysicalPost();
            p.Title = model.Title;
            p.Description = model.Description;
            p.CategoryId = model.CategoryId;

            foreach (string item in model.TagsString.Split(' ', '#', ',', '.'))
            {
                if (!item.Equals("") && !item.Equals("#") && !item.Equals(",") && !item.Equals("."))
                {
                    p.Tags.Add(item);
                }
            }
            p.AltDescription = model.AltDescription;
            p.Zipcode = model.Zipcode;
            p.Address = model.Address;

            try
            {
                p.UserId = DB.GetUser(0, (string)Session["Username"]).Id;

                p = (PhysicalPost)DB.CreatePost(p);

                return p;
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        //Main View for Create post
        public ActionResult Index()
        {
            try
            {
                ViewBag.DropDownList = new SelectList(DB.GetCategoryList(), "Id", "Name");

                return View();
            }
            catch (Exception)
            {
                return View("Error");
            }
            
        }

        public ActionResult Create(PostViewModel model)
        {
            Post post = null;
            try
            {
                if (ModelState.IsValid)
                {
                    post = CreatePost(model);
                }
            }
            catch (Exception e)
            {
                return View("Error");
            }
            return RedirectToAction("Index", "Post", new { ID = post.Id });
        }

        public ActionResult CreatePhysical()
        {
            try
            {
                ViewBag.DropDownList = new SelectList(DB.GetCategoryList(), "Id", "Name");
                return View();
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        // POST: CreatePost/CreatePhysical
        [HttpPost]
        public ActionResult CreatePhysical(PhysicalPostViewModel model)
        {
            PhysicalPost ppost = null;
            try
            {
                if (ModelState.IsValid)
                {
                    ppost = CreatePhysicalPost(model);
                }
            }
            catch
            {
                return View("Error");
            }
            return RedirectToAction("Index", "Post", new { ID = ppost.Id });
        }

        // GET: CreatePost/Edit/id
        public ActionResult EditPost(int ID, string errorMsg = "")
        {

            if (!errorMsg.Equals(""))
            {
                ModelState.AddModelError("", errorMsg);
            }

            Post post = null;
            try
            {
                post = DB.GetPost(ID, false, false, true);
                ViewBag.CategoryName = post.Category.Name;
                ViewBag.DropdownList = new SelectList(DB.GetCategoryList(), "Id", "Name");

            }
            catch (Exception)
            {
                return View("Error");
            }
            
            PostViewModel viewPost = new PostViewModel();

            viewPost.Title = post.Title;
            viewPost.Description = post.Description;
            viewPost.LastEdited = post.LastEdited;

            viewPost.postId = ID;
            viewPost.CategoryId = post.CategoryId;

            string tags = "";
            foreach (string item in post.Tags)
            {
                tags = tags + " " + item;
            }
            viewPost.TagsString = tags;

            
            return View(viewPost);
        }

        public ActionResult EditPhysicalPost(int ID)
        {
            PhysicalPost post = null;
            try
            {
                post = (PhysicalPost)DB.GetPost(ID, false, false, true);

                ViewBag.CategoryName = post.Category.Name;
                ViewBag.DropdownList = new SelectList(DB.GetCategoryList(), "Id", "Name");
            }
            catch (Exception)
            {
                return View("Error");
            }

            PhysicalPostViewModel viewPost = new PhysicalPostViewModel();

            viewPost.Title = post.Title;
            viewPost.Description = post.Description;
            viewPost.LastEdited = post.LastEdited;

            viewPost.postId = ID;
            viewPost.CategoryId = post.CategoryId;
            viewPost.AltDescription = post.AltDescription;
            viewPost.Zipcode = post.Zipcode;
            viewPost.Address = post.Address;
            viewPost.IsLocked = post.IsLocked;

            string tags = "";
            foreach (string item in post.Tags)
            {
                tags = tags + " " + item;
            }
            viewPost.TagsString = tags;
            
            return View(viewPost);
        }

        [HttpPost]
        public ActionResult UpdatePost(PostViewModel model)
        {
            Post post = null;
            try
            {
                post = DB.GetPost(model.postId, false, false, true);
                post.CategoryId = model.CategoryId;
                post.Category = DB.GetCategory(model.CategoryId);

            }
            catch (Exception)
            {
                return View("Error");
            }

            post.Title = model.Title;
            post.Description = model.Description;
            post.LastEdited = model.LastEdited;

            
            List<string> tagsList = new List<string>();


            if (model.TagsString != null)
            {
                foreach (string item in model.TagsString.Split(' ', '#', ',', '.'))
                {
                    if (!item.Equals("") && !item.Equals("#") && !item.Equals(",") && !item.Equals("."))
                    {
                        tagsList.Add(item);
                    }
                }
            }

            post.Tags = tagsList;

            try
            {
                DB.UpdatePost(post);
            }
            catch (FaultException e)
            {
                if (e.Message.Contains("0917"))
                {
                    return RedirectToAction("EditPost", "CreatePost", new { ID = model.postId, errorMsg = "Post have been edited by an admin, please re-read your post before editing it." });
                }
                else
                {
                    ViewBag.ErrorMsg = e.Message;
                    return View("Error");
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorMsg = e.Message;
                return View("Error");
            }

            return RedirectToAction("Index", "Post", new { ID = model.postId });
        }

        [HttpPost]
        public ActionResult UpdatePhysical(PhysicalPostViewModel model)
        {
            PhysicalPost post = null;
            try
            {
                post = (PhysicalPost)DB.GetPost(model.postId, false, false, true);
                post.CategoryId = model.CategoryId;
                post.Category = DB.GetCategory(model.CategoryId);

            }
            catch (Exception)
            {

                throw;
            }

            post.Title = model.Title;
            post.Description = model.Description;
            
            post.AltDescription = model.AltDescription;
            post.Zipcode = model.Zipcode;
            post.Address = model.Address;
            post.IsLocked = model.IsLocked;

            List<string> tagsList = new List<string>();

            if (model.TagsString != null)
            {
                foreach (string item in model.TagsString.Split(' ', '#', ',', '.'))
                {
                    if (!item.Equals("") && !item.Equals("#") && !item.Equals(",") && !item.Equals("."))
                    {
                        tagsList.Add(item);
                    }
                }
                
            }

            post.Tags = tagsList;
            post.LastEdited = model.LastEdited;

            try
            {
                DB.UpdatePost(post);

            }
            catch (FaultException e)
            {
                if (e.Message.Contains("0917"))
                {
                    return RedirectToAction("EditPost", "CreatePost", new { ID = model.postId, errorMsg = "Post have been edited by an admin, please re-read your post before editing it." });
                }
                else
                {
                    ViewBag.ErrorMsg = e.Message;
                    return View("Error");
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorMsg = e.Message;
                return View("Error");
            }

            return RedirectToAction("PhysicalIndex", "Post", new { ID = model.postId });
        }
    }
}
