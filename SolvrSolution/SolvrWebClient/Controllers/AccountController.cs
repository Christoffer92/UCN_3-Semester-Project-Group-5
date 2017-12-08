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
using DataAccesLayer.DAL;

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
            
            return View();
        }

        public ActionResult RegisterUser(RegisterViewModel model)
        {
            User user = new User();
            user.Email = model.Email;
            user.Name = model.Name;
            user.Password = model.Password;
            user.Username = model.Username;

            //bool isRegistered = false;

            try
            {
                DB.CreateUser(user);

            }
            catch (Exception e)
            {
                if (e.Message.Contains(model.Username))
                {
                    ModelState.AddModelError("Username", "Username already exists");
                }

                if (e.Message.Contains(model.Email))
                {
                    ModelState.AddModelError("Email", "Email already exists");
                }
                return View("Register", model);
            }

            return RedirectToAction("Login");
        }

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
                user = DB.GetUser(model.Username);
            }
            catch
            {

                return false;
            }
            
            // TODO Add Safety (maybe?)
            if(user != null && model.Password.Equals(user.Password))
            {
                Session["Username"] = user.Username;
                //Session["Email"] = user.Email;

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
    }

}
