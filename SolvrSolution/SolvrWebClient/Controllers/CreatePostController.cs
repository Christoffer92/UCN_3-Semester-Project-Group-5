using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SolvrLibrary;
using System.Web.ModelBinding;
using SolvrWebClient.Models;

namespace SolvrWebClient.Controllers
{
    public class CreatePostController : Controller
    {
        private ISolvrDB DB = null;

        public CreatePostController()
        {
            // TODO : Revert tilbage til dette når du comitter
            //DB = new SolvrDB();
            DB = new MockDB();
        }

        public CreatePostController(ISolvrDB _DB)
        {
            DB = _DB;
        }

        public PhysicalPost CreatePhysicalPostModel(User expectedUser, string expectedTitle, string expectedDescription, Category expectedCategory, List<string> expectedTagsList, string expectedAltDescription, string expectedZipcode, string expectedAddress)
        {
            DB.CreatePhysicalPost(expectedUser, expectedTitle, expectedDescription, expectedCategory, expectedTagsList, expectedAltDescription, expectedZipcode, expectedAddress);
            return DB.GetLastPhysicalPost();
        }
        public Post CreatePostModel(User expectedUser, string expectedPostTitle, string expectedPostDescription, Category expectedCategory, List<string> expectedTagsList)
        {
            DB.CreatePost(expectedUser, expectedPostTitle, expectedPostDescription, expectedCategory, expectedTagsList);
            return DB.GetLastPost();
        }

        // GET: CreatePost/CreatePostView
        public ActionResult CreatePostView(CreatePostViewModel model)
        {
            //List<Category> CategoryList = new List<Category>();

            //CategoryList.AddRange(DB.GetAllCategories());

            //ViewBag.SelectCategory = new SelectList(CategoryList);

            

            if (true)
            {
                List<string> CategoryList = new List<string>();

                foreach (var item in DB.GetAllCategories())
                {
                    CategoryList.Add(item.Name);
                }

                ViewBag.SelectCategory = new SelectList(CategoryList);
            }
            else
            {
                List<string> CategoryList = new List<string>();

                foreach (var item in DB.GetAllCategories())
                {
                    CategoryList.Add(item.Name + "Aids");
                }

                ViewBag.SelectCategory = new SelectList(CategoryList);
            }
            return View();
        }

        // POST: /Manage/ChangePassword
        [HttpPost]
        public ActionResult CreatePostView2(CreatePostViewModel model)
        {
            Console.WriteLine(model.NewPassword);
            return View(model);
        }

        // post: createpost/createpostview
        [HttpPost]
        public ActionResult CreatePostView3([Bind(Include = "Title,Category,Description,Tags")] Post post)
        {
            if (ModelState.IsValid)
            {
                DB.CreatePost(post);
            }

            return View();
        }
    }






    //// GET: CreatePost
    //public ActionResult Index()
    //{
    //    return View();
    //}

    //// GET: CreatePost/Details/5
    //public ActionResult Details(int id)
    //{
    //    return View();
    //}

    //// GET: CreatePost/Create
    //public ActionResult Create()
    //{
    //    return View();
    //}

    //// POST: CreatePost/Create
    //[HttpPost]
    //public ActionResult Create(FormCollection collection)
    //{
    //    try
    //    {
    //        // TODO: Add insert logic here

    //        return RedirectToAction("Index");
    //    }
    //    catch
    //    {
    //        return View();
    //    }
    //}

    //// GET: CreatePost/Edit/5
    //public ActionResult Edit(int id)
    //{
    //    return View();
    //}

    //// POST: CreatePost/Edit/5
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

    //// GET: CreatePost/Delete/5
    //public ActionResult Delete(int id)
    //{
    //    return View();
    //}

    //// POST: CreatePost/Delete/5
    //[HttpPost]
    //public ActionResult Delete(int id, FormCollection collection)
    //{
    //    try
    //    {
    //        // TODO: Add delete logic here

    //        return RedirectToAction("Index");
    //    }
    //    catch
    //    {
    //        return View();
    //    }
    //}


}
