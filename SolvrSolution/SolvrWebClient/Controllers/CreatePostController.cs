using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SolvrLibrary;

namespace SolvrWebClient.Controllers
{
    public class CreatePostController : Controller
    {
        private ISolvrDB DB = null;

        public CreatePostController(ISolvrDB _DB = null)
        {
            if (_DB == null)
            {
                DB = new SolvrDB();
            }
            else
            {
                DB = _DB;
            }
        }

        public PhysicalPost CreatePhysicalPost(User expectedUser, string expectedTitle, string expectedDescription, Category expectedCategory, List<string> expectedTagsList, string expectedAltDescription, string expectedZipcode, string expectedAddress)
        {
            DB.CreatePhysicalPost(expectedUser, expectedTitle, expectedDescription, expectedCategory, expectedTagsList, expectedAltDescription, expectedZipcode, expectedAddress);
            return DB.GetLastPhysicalPost();
        }
        public Post CreatePost(User expectedUser, string expectedPostTitle, string expectedPostDescription, Category expectedCategory, List<string> expectedTagsList)
        {
            DB.CreatePost(expectedUser, expectedPostTitle, expectedPostDescription, expectedCategory, expectedTagsList);
            return DB.GetLastPost();
        }


































        // GET: CreatePost
        public ActionResult Index()
        {
            return View();
        }

        // GET: CreatePost/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CreatePost/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CreatePost/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CreatePost/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CreatePost/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CreatePost/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CreatePost/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
    }
}
