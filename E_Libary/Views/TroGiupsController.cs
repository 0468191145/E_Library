using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using E_Libary.Models;

namespace E_Libary.Views
{
    public class TroGiupsController : Controller
    {
        private E_LibraryEntities1 db = new E_LibraryEntities1();

        // GET: TroGiups
        public ActionResult Index()
        {
            return View(db.TroGiups.ToList());
        }

        // GET: TroGiups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TroGiup troGiup = db.TroGiups.Find(id);
            if (troGiup == null)
            {
                return HttpNotFound();
            }
            return View(troGiup);
        }

        // GET: TroGiups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TroGiups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TieuDe,NoiDung,NguoiGui,NgayGui,TrangThai")] TroGiup troGiup)
        {
            if (ModelState.IsValid)
            {
                db.TroGiups.Add(troGiup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(troGiup);
        }

        // GET: TroGiups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TroGiup troGiup = db.TroGiups.Find(id);
            if (troGiup == null)
            {
                return HttpNotFound();
            }
            return View(troGiup);
        }

        // POST: TroGiups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TieuDe,NoiDung,NguoiGui,NgayGui,TrangThai")] TroGiup troGiup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(troGiup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(troGiup);
        }

        // GET: TroGiups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TroGiup troGiup = db.TroGiups.Find(id);
            if (troGiup == null)
            {
                return HttpNotFound();
            }
            return View(troGiup);
        }

        // POST: TroGiups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TroGiup troGiup = db.TroGiups.Find(id);
            db.TroGiups.Remove(troGiup);
            db.SaveChanges();
            return RedirectToAction("Index");
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
