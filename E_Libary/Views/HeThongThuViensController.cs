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
    public class HeThongThuViensController : Controller
    {
        private E_LibraryEntities1 db = new E_LibraryEntities1();

        // GET: HeThongThuViens
        public ActionResult Index()
        {
            return View(db.HeThongThuViens.ToList());
        }

        // GET: HeThongThuViens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeThongThuVien heThongThuVien = db.HeThongThuViens.Find(id);
            if (heThongThuVien == null)
            {
                return HttpNotFound();
            }
            return View(heThongThuVien);
        }

        // GET: HeThongThuViens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HeThongThuViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MaTruong,TenTruong,LoaiTruong,HieuTruong,Website,TenThuVien,DiaChiTruyCap,SĐT,Email,NgonNgu,NienKhoa")] HeThongThuVien heThongThuVien)
        {
            if (ModelState.IsValid)
            {
                db.HeThongThuViens.Add(heThongThuVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(heThongThuVien);
        }

        // GET: HeThongThuViens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeThongThuVien heThongThuVien = db.HeThongThuViens.Find(id);
            if (heThongThuVien == null)
            {
                return HttpNotFound();
            }
            return View(heThongThuVien);
        }

        // POST: HeThongThuViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MaTruong,TenTruong,LoaiTruong,HieuTruong,Website,TenThuVien,DiaChiTruyCap,SĐT,Email,NgonNgu,NienKhoa")] HeThongThuVien heThongThuVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(heThongThuVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(heThongThuVien);
        }

        // GET: HeThongThuViens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeThongThuVien heThongThuVien = db.HeThongThuViens.Find(id);
            if (heThongThuVien == null)
            {
                return HttpNotFound();
            }
            return View(heThongThuVien);
        }

        // POST: HeThongThuViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HeThongThuVien heThongThuVien = db.HeThongThuViens.Find(id);
            db.HeThongThuViens.Remove(heThongThuVien);
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
