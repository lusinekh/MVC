using MvcLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLogin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Autherise(MvcLogin.Models.User usermodel1)
        {
            using (LoginDateBaseEntities1 db =new LoginDateBaseEntities1() )
            {

                var userDetails = db.Users.Where(x => x.UserName == usermodel1.UserName && x.Password == usermodel1.Password).FirstOrDefault();
                if(userDetails == null)
                {
                    usermodel1.LoginErrorMessage = "wrong username or passworg";
                    return View("Index", usermodel1);
                }


                else
                {
                    Session["UserID"] = userDetails.UserID;
                    Session["UserName"] = userDetails.UserName;
                    return RedirectToAction("Index", "Home");

                }
            }

          

        }

        public ActionResult LogOut()
        {
            int userid =(int) Session["UserID"];
            Session.Abandon();
                
            return RedirectToAction("Index", "Login");
    }


    }  


}