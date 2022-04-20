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
    public class BaiGiangsController : Controller
    {
        private E_LibraryEntities1 db = new E_LibraryEntities1();

        // GET: BaiGiangs
        public ActionResult Index()
        {
            return View(db.BaiGiangs.ToList());
        }

        // GET: BaiGiangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiGiang baiGiang = db.BaiGiangs.Find(id);
            if (baiGiang == null)
            {
                return HttpNotFound();
            }
            return View(baiGiang);
        }

        // GET: BaiGiangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BaiGiangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LoaiFile,Ten,MonHoc,Lop,ChuDe,NguoiChinhSua,NgayChinhSuaCuoi,KichThuoc")] BaiGiang baiGiang)
        {
            if (ModelState.IsValid)
            {
                db.BaiGiangs.Add(baiGiang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(baiGiang);
        }

        // GET: BaiGiangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiGiang baiGiang = db.BaiGiangs.Find(id);
            if (baiGiang == null)
            {
                return HttpNotFound();
            }
            return View(baiGiang);
        }

        // POST: BaiGiangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LoaiFile,Ten,MonHoc,Lop,ChuDe,NguoiChinhSua,NgayChinhSuaCuoi,KichThuoc")] BaiGiang baiGiang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baiGiang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(baiGiang);
        }

        // GET: BaiGiangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiGiang baiGiang = db.BaiGiangs.Find(id);
            if (baiGiang == null)
            {
                return HttpNotFound();
            }
            return View(baiGiang);
        }

        // POST: BaiGiangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BaiGiang baiGiang = db.BaiGiangs.Find(id);
            db.BaiGiangs.Remove(baiGiang);
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
