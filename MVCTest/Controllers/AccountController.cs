using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCTest.Model;
using MVCTest.DB.DbOperation;
using System.Web.Security;

namespace MVCTest.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Account

        AccountOperation account = null;

        public AccountController()
        {
            account = new AccountOperation();
        }
        public ActionResult login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult login(UserModel model)
        {

            if(ModelState.IsValid)
            {
                bool isvalid = account.loginUser(model);
                if(isvalid)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid User Name or Password");
                    return View();
                }

            }
           // ModelState.AddModelError("", "Invalid User Name or Password");
            return View();

        }

        public ActionResult Signup()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Signup(UserModel model)
        {
            if(ModelState.IsValid)
            {
                int id = account.AddUser(model);
                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.msg = "User Added";
                }
            }
            return RedirectToAction("login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login");
        }
    }
}