using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using SolvrWebClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using SolvrLibrary;

namespace SolvrWebClient.Controllers
{
    public class AccountController : Controller
    {
        public ISolvrDB DB;

        public AccountController()
        {
            DB = new SolvrDB();
        }

        public AccountController(ISolvrDB _DB)
        {
            DB = _DB;
        }

        public ActionResult Register()
        {
            return View("Register");
        }
       /* public ActionResult Register(LoginViewModel model)
        {
            return View();
        }*/



            public ActionResult Index()
        {
            return View("Login");
        }
        public ActionResult Login(LoginViewModel model)
        {
            bool valid = false;
            try

            { 
                if(ModelState.IsValid)
                {
                    valid  = CheckCredentials(model);
                }
            }
            catch (Exception e)
            {
                return View();
            } 

            if (valid == true)
            {
                return RedirectToAction("Index", "Home");
            }
            else 
            {
                return View();
            }
        }

        private bool CheckCredentials(LoginViewModel model)

        {
            User user = null;
            try
            {
                user = DB.GetUser(model.Email);
            }
            catch
            {

                return false;
            }
            
            // TODO Add Safety (maybe?)
            if(user != null && model.Password.Equals(user.Password))
            {
                Session["Username"] = user.Username;
                Session["Email"] = user.Email;

                return true;
            }
            else
            {

                return false;
            }

        }
        
        public ActionResult LogOut()
        {
            Session.Abandon();
            //return View("Login");
            return RedirectToAction("Index","Home");
        }













        /*
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        */

        // TODO Lav UserManager, SignInManager, ect. ændre til korrekte navne
        /*
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model,string returnUrl)
        {   
            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = UserManager.FindByNameAsync(model.Email);
            if (user != null)
            {
                if(!await UserManager.IsEmailConfirmedAsync(user.id))
                ViewBag.Errormessage = "Email is not registeret";
                return View("Error");
            }
            var result = await SignInManager.PasswordSignIn(model.Email, model.Password, model.RememberMe);
            switch (result)
            {
                case SignInStatus.Success:
                    return Index(returnUrl);
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("","Invalid login attempt");
                    return View(model);
            }
                        
            
        }
        */

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
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

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Account/Edit/5
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

        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Account/Delete/5
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
