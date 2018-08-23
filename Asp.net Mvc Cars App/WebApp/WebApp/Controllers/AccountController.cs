using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using System.Web.Security;
using WebApp.Filters;

namespace WebApp.Controllers
{
    [Localization]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult LoginPage()
        {
            return View("Login");
        }

        public ActionResult Login(User user)
        {
            using (var ctx = new carShopEntities())
            {
                try
                {

                    var query1 = (from que in ctx.Users where que.Password == user.Password select que).FirstOrDefault();
                    var query2 = (from que in ctx.Users where que.UserName == user.UserName select que).FirstOrDefault();

                    if (query1.UserId != query2.UserId)
                    {
                        return View("Login");

                    }

                    FormsAuthentication.SetAuthCookie(query1.UserName, false);


                    return RedirectToAction("Index", "Home");
                }
                catch (Exception)
                {

                    return RedirectToAction("Error", "Home");
                }

            }
        }


        public ActionResult SignupPage()
        {
            return View();
        }



        public ActionResult Signup(Users users)
        {
            using (var ctx = new carShopEntities())
            {
                try
                {

                    User user = new User()
                    {
                        UserName = users.UserName,
                        Password = users.Password,

                    };
                    ctx.Users.Add(user);
                    ctx.SaveChanges();

                    TempData["message"] = "You successfully signed up. Please log in!";
                    return RedirectToAction("Index", "Home");


                }
                catch (Exception)
                {

                    return RedirectToAction("Error", "Home");
                }

            }
        }



        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }



    }
}