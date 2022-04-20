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
    public class TepRiengsController : Controller
    {
        private E_LibraryEntities1 db = new E_LibraryEntities1();

        // GET: TepRiengs
        public ActionResult Index()
        {
            return View(db.TepRiengs.ToList());
        }

        // GET: TepRiengs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TepRieng tepRieng = db.TepRiengs.Find(id);
            if (tepRieng == null)
            {
                return HttpNotFound();
            }
            return View(tepRieng);
        }

        // GET: TepRiengs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TepRiengs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TheLoai,TenTep,NguoiSua,NgaySuaLanCuoi,KichThuoc")] TepRieng tepRieng)
        {
            if (ModelState.IsValid)
            {
                db.TepRiengs.Add(tepRieng);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tepRieng);
        }

        // GET: TepRiengs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TepRieng tepRieng = db.TepRiengs.Find(id);
            if (tepRieng == null)
            {
                return HttpNotFound();
            }
            return View(tepRieng);
        }

        // POST: TepRiengs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TheLoai,TenTep,NguoiSua,NgaySuaLanCuoi,KichThuoc")] TepRieng tepRieng)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tepRieng).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tepRieng);
        }

        // GET: TepRiengs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TepRieng tepRieng = db.TepRiengs.Find(id);
            if (tepRieng == null)
            {
                return HttpNotFound();
            }
            return View(tepRieng);
        }

        // POST: TepRiengs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TepRieng tepRieng = db.TepRiengs.Find(id);
            db.TepRiengs.Remove(tepRieng);
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
