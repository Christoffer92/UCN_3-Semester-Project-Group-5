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
        ISolvrDB DB;
        public CreatePostController()
        {
            DB = new SolvrDB();
        }
        //public CreatePostController(ISolvrDB _DB)
        //{
        //    DB = _DB;
        //}

        //CreatePost:
        //  Create a post with the following attributes from PostViewModel model.
        //  Also add the logged in user as the owner of the post.
        //  Tags:
        //      Adds an array of strings to the tag list by seperating them with the split function
        //      Space, hashtags, commas, and full stop will split the tag string up.
        public void CreatePost(PostViewModel model)
        {
            Post p = new Post();
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
            //TODO: Connect a user to this method
            //p.User = something goes here
            
            DB.CreatePost(p);
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
            p.ZipCode = model.Zipcode;
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
            try
            {
                if (ModelState.IsValid)
                {
                    CreatePost(model);
                }
            }
            catch
            {
                //TODO: Print error message
                return View();
            }
            return RedirectToAction("Index", "Post", model);
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

        //// GET: CreatePost/Edit/id
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: CreatePost/Edit/id
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
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
