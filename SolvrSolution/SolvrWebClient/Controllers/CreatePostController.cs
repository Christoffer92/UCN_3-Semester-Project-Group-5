using SolvrLibrary;
using DataAccesLayer;
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
        ISolvrDB DB;
        public CreatePostController()
        {
            DB = new SolvrDB();
        }
        public CreatePostController(ISolvrDB _DB)
        {
            DB = _DB;
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
            //TODO: Connect a user to this method
            //p.User = something goes here
            p.User = DB.GetUser();
            p.UserId = p.User.Id;

            
            return DB.CreatePost(p);
        }

        //CreatePhysicalPost:
        //  Create a physical post with the following attributes from PhysicalPostViewModel model.
        //  Also add the logged in user as the owner of the post.
        //  Tags:
        //      Adds an array of strings to the tag list by seperating them with the split function
        //      Space, hashtags, commas, and full stop will split the tag string up.
        public void CreatePhysicalPost(PhysicalPostViewModel model)
        {
            PhysicalPost p = new PhysicalPost();
            p.Title = model.Title;
            p.Description = model.Description;
            p.Category = DB.GetCategory(model.CategoryId);

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
            //TODO: Connect a user to this method
            //p.User = something goes here

            DB.CreatePhysicalPost(p);
        }

        //Main View for Create post
        // GET: CreatePost
        public ActionResult Index()
        {
            ViewBag.DropDownList = new SelectList(DB.GetAllCategories(), "Id", "Name");
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
                Console.WriteLine(e.Message);
                //TODO: Print error message
                return View();
            }
            return RedirectToAction("Index", "Post", new { ID = post.Id });
        }

        // GET: CreatePost/CreatePhysical
        public ActionResult CreatePhysical()
        {
            ViewBag.DropDownList = new SelectList(DB.GetAllCategories(), "Id", "Name");
            return View();
        }

        // POST: CreatePost/CreatePhysical
        [HttpPost]
        public ActionResult CreatePhysical(PhysicalPostViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CreatePhysicalPost(model);
                }
            }
            catch
            {
                //TODO: Print error message
                return View();
            }
            return RedirectToAction("Index", "Post", model);
        }

        // GET: CreatePost/Edit/id
        public ActionResult EditPost(int ID)
        {
            Post post = DB.GetPost(ID);
            PostViewModel viewPost = new PostViewModel();

            viewPost.Title = post.Title;
            viewPost.Description = post.Description;

            viewPost.postId = ID;
            viewPost.CategoryId = post.CategoryId;

            //TODO Tags should be fixed
            string tags = "";
            foreach (string item in post.Tags)
            {
                tags = tags + " " + item;
            }
            viewPost.TagsString = tags;

            ViewBag.CategoryName = post.Category.Name;
            ViewBag.DropdownList = new SelectList(DB.GetAllCategories(), "Id", "Name");

            return View(viewPost);
        }

        public ActionResult EditPhysicalPost(int ID)
        {
            PhysicalPost post = DB.GetPhysicalPost(ID);
            PhysicalPostViewModel viewPost = new PhysicalPostViewModel();

            viewPost.Title = post.Title;
            viewPost.Description = post.Description;

            viewPost.postId = ID;
            viewPost.CategoryId = post.CategoryId;
            viewPost.AltDescription = post.AltDescription;
            viewPost.Zipcode = post.Zipcode;
            viewPost.Address = post.Address;
            viewPost.IsLocked = post.IsLocked;

            // TODO Tags should be fixed
            string tags = "";
            foreach (string item in post.Tags)
            {
                tags = tags + " " + item;
            }
            viewPost.TagsString = tags;

            ViewBag.CategoryName = post.Category.Name;
            ViewBag.DropdownList = new SelectList(DB.GetAllCategories(), "Id", "Name");

            return View(viewPost);
        }

        //TODO Cleanup this method
        public ActionResult UpdatePost(PostViewModel model)
        {
            Post post = DB.GetPost(model.postId);

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

            //TODO make as an extension method to String
            List<string> tagsList = new List<string>();
            foreach (string item in model.TagsString.Split(' ', '#', ',', '.'))
            {
                if (!item.Equals("") && !item.Equals("#") && !item.Equals(",") && !item.Equals("."))
                {
                    tagsList.Add(item);
                }
            }

            post.Tags = tagsList;

            DB.UpdatePost(post);

            return RedirectToAction("Index", "Post", new {ID = model.postId });
        }

        //TODO Cleanup this method
        public ActionResult UpdatePhysical(PhysicalPostViewModel model)
        {
            PhysicalPost post = DB.GetPhysicalPost(model.postId);

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

            //TODO make as an extension method to String
            List<string> tagsList = new List<string>();
            foreach (string item in model.TagsString.Split(' ', '#', ',', '.'))
            {
                if (!item.Equals("") && !item.Equals("#") && !item.Equals(",") && !item.Equals("."))
                {
                    tagsList.Add(item);
                }
            }

            post.Tags = tagsList;

            DB.UpdatePhysicalPost(post);

            return RedirectToAction("PhysicalIndex", "Post", new { ID = model.postId });
        }


        //// POST: CreatePost/Edit/id
        //[HttpPost]
        //public ActionResult Edit(PostViewModel model)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
