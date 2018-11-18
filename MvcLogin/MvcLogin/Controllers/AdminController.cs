using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLogin.Models;
using System.Data.Entity;
using System.Data;

namespace MvcLogin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/ Index
        public ActionResult Index()
        {
            using (LoginDateBaseEntities1 dbmodel = new LoginDateBaseEntities1())
            {
                return View(dbmodel.Users.ToList());

            }


               
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            using (LoginDateBaseEntities1 dbmodel = new LoginDateBaseEntities1())
            {
                return View(dbmodel.Users.Where(x=>x.UserID== id).FirstOrDefault());

            }               
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                using (LoginDateBaseEntities1 dbmodel = new LoginDateBaseEntities1())
                {
                    dbmodel.Users.Add(user);
                    dbmodel.SaveChanges();

                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            using (LoginDateBaseEntities1 dbmodel = new LoginDateBaseEntities1())
            {
                return View(dbmodel.Users.Where(x => x.UserID == id).FirstOrDefault());

            }
            
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            try
            {
                using (LoginDateBaseEntities1 dbmodel = new LoginDateBaseEntities1())
                {
                    dbmodel.Entry(user).State = EntityState.Modified;
                    dbmodel.SaveChanges();




                }


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            using (LoginDateBaseEntities1 dbmodel = new LoginDateBaseEntities1())
            {
                return View(dbmodel.Users.Where(x => x.UserID == id).FirstOrDefault());

            }


           
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (LoginDateBaseEntities1 dbmodel = new LoginDateBaseEntities1())
                {
                    User user = dbmodel.Users.Where(x => x.UserID == id).FirstOrDefault();
                    dbmodel.Users.Remove(user);
                    dbmodel.SaveChanges();
                }


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
