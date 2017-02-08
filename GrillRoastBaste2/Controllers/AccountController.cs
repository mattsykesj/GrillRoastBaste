using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GrillRoastBaste2.Abstract;
using GrillRoastBaste2.Models;

namespace GrillRoastBaste2.Controllers
{
    public class AccountController : Controller
    {
        FormsAuthProvider authProvider = new FormsAuthProvider();


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if(authProvider.Authenticate(model.UserName, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username and/or password");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}