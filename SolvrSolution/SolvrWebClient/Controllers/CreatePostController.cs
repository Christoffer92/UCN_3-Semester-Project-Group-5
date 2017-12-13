using SolvrLibrary;
using SolvrWebClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SolvrWebClient.Controllers
{
    public class CreatePostController : Controller
    {
        //Overloaded constructors for connecting to either SolvrDB or MockDB
        private static RemoteSolvrReference.ISolvrServices DB = new RemoteSolvrReference.SolvrServicesClient();
        public CreatePostController()
        {

        }

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

            p.UserId = DB.GetUser(0, (string)Session["Username"]).Id;

            return DB.CreatePost(p);
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

            p.UserId = DB.GetUser(0, (string)Session["Username"]).Id;

            p = (PhysicalPost)DB.CreatePost(p);

            return p;
        }

        //Main View for Create post
        // GET: CreatePost
        public ActionResult Index()
        {
            ViewBag.DropDownList = new SelectList(DB.GetCategoryList(), "Id", "Name");
            return View();
        }

        // POST: CreatePost/Create
        [HttpPost]
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

        // GET: CreatePost/CreatePhysical
        public ActionResult CreatePhysical()
        {
            ViewBag.DropDownList = new SelectList(DB.GetCategoryList(), "Id", "Name");
            return View();
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
        public ActionResult EditPost(int ID)
        {
            Post post = DB.GetPost(ID, false, false, true);
            PostViewModel viewPost = new PostViewModel();

            viewPost.Title = post.Title;
            viewPost.Description = post.Description;

            viewPost.postId = ID;
            viewPost.CategoryId = post.CategoryId;

            string tags = "";
            foreach (string item in post.Tags)
            {
                tags = tags + " " + item;
            }
            viewPost.TagsString = tags;

            ViewBag.CategoryName = post.Category.Name;
            ViewBag.DropdownList = new SelectList(DB.GetCategoryList(), "Id", "Name");

            return View(viewPost);
        }

        public ActionResult EditPhysicalPost(int ID)
        {
            PhysicalPost post = (PhysicalPost)DB.GetPost(ID, false, false, true);
            PhysicalPostViewModel viewPost = new PhysicalPostViewModel();

            viewPost.Title = post.Title;
            viewPost.Description = post.Description;

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

            ViewBag.CategoryName = post.Category.Name;
            ViewBag.DropdownList = new SelectList(DB.GetCategoryList(), "Id", "Name");

            return View(viewPost);
        }

        public ActionResult UpdatePost(PostViewModel model)
        {
            Post post = DB.GetPost(model.postId, false, false, true);

            if (!post.Title.Equals(model.Title))
            {
                post.Title = model.Title;
            }

            if (!post.Description.Equals(model.Description))
            {
                post.Description = model.Description;
            }

            if (post.CategoryId != model.CategoryId)
            {
                post.CategoryId = model.CategoryId;
                post.Category = DB.GetCategory(model.CategoryId);
            }

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

            DB.UpdatePost(post);

            return RedirectToAction("Index", "Post", new { ID = model.postId });
        }

        public ActionResult UpdatePhysical(PhysicalPostViewModel model)
        {
            PhysicalPost post = (PhysicalPost)DB.GetPost(model.postId, false, false, true);

            if (!post.Title.Equals(model.Title))
            {
                post.Title = model.Title;
            }

            if (!post.Description.Equals(model.Description))
            {
                post.Description = model.Description;
            }

            if (post.CategoryId != model.CategoryId)
            {
                post.CategoryId = model.CategoryId;
                post.Category = DB.GetCategory(model.CategoryId);
            }

            if (!post.AltDescription.Equals(model.AltDescription))
            {
                post.AltDescription = model.AltDescription;
            }

            if (!post.Zipcode.Equals(model.Zipcode))
            {
                post.Zipcode = model.Zipcode;
            }

            if (!post.Address.Equals(model.Address))
            {
                post.Address = model.Address;
            }

            if (post.IsLocked != model.IsLocked)
            {
                post.IsLocked = model.IsLocked;
            }

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


            DB.UpdatePost(post);

            return RedirectToAction("PhysicalIndex", "Post", new { ID = model.postId });
        }
    }
}
