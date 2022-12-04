using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Trasuanhom15.Models;
using System.Security.Cryptography;
using System.Text;

namespace Trasuanhom15.Controllers
{
    public class AdminUsersController : Controller
    {
        private TrasuaDBEntities1 db = new TrasuaDBEntities1();

        // GET: AdminUsers
        public ActionResult Index()
        {
            return View(db.AdminUsers.ToList());
        }

        // GET: AdminUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminUser adminUser = db.AdminUsers.Find(id);
            if (adminUser == null)
            {
                return HttpNotFound();
            }
            return View(adminUser);
        }

        // GET: AdminUsers/Create
        public ActionResult SignUp()
        {
            return View();
        }

        // POST: AdminUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp([Bind(Include = "ID,NameUser,RoleUser,PasswordUser")] AdminUser adminUser)
        {
            if (ModelState.IsValid)
            {
                db.AdminUsers.Add(adminUser);
                db.SaveChanges();
                return RedirectToAction("../Home");
            }

            return View(adminUser);
        }

        // GET: AdminUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminUser adminUser = db.AdminUsers.Find(id);
            if (adminUser == null)
            {
                return HttpNotFound();
            }
            return View(adminUser);
        }

        // POST: AdminUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NameUser,RoleUser,PasswordUser")] AdminUser adminUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adminUser);
        }

        // GET: AdminUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminUser adminUser = db.AdminUsers.Find(id);
            if (adminUser == null)
            {
                return HttpNotFound();
            }
            return View(adminUser);
        }
        public ActionResult Login()
        {
            return View();
        }

        // POST: AdminUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdminUser adminUser = db.AdminUsers.Find(id);
            db.AdminUsers.Remove(adminUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "NameUser,PasswordUser")] AdminUser adminUser)
        {
            if (ModelState.IsValid)
            {           
                var account = db.AdminUsers.FirstOrDefault(x => x.NameUser.Equals(adminUser.NameUser) && x.PasswordUser.Equals(adminUser.PasswordUser));
                if (account != null)
                {
                    Session["IDCus"] = account.ID;
                    Session["UserName"]=adminUser.NameUser;
                    Session["Password"] = adminUser.PasswordUser;
                    return RedirectToAction("../Home");
                }
                else
                {
                    ViewBag.Message = String.Format("Login Fail");
                    return View();
                }
            }
            return View();
        }

        public ActionResult Information(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AdminUser adminUser = db.AdminUsers.Find(id);
            if (adminUser == null)
            {
                return HttpNotFound();
            }
            return View(adminUser);
        }
        public ActionResult Logout()
        {
            Session["User"] = null;
            Session["IDCus"] = null;
            Session["Password"] = null;
            return RedirectToAction("../Home");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
