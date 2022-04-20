﻿using System;
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
    public class TaiLieuxController : Controller
    {
        private E_LibraryEntities1 db = new E_LibraryEntities1();

        // GET: TaiLieux
        public ActionResult Index()
        {
            return View(db.TaiLieux.ToList());
        }

        // GET: TaiLieux/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiLieu taiLieu = db.TaiLieux.Find(id);
            if (taiLieu == null)
            {
                return HttpNotFound();
            }
            return View(taiLieu);
        }

        // GET: TaiLieux/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaiLieux/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TenTaiLieu,MonHoc,PhanLoai,NguoiTao,NguoiPheDuyet,NgayGui,TinhTrang,GhiChu")] TaiLieu taiLieu)
        {
            if (ModelState.IsValid)
            {
                db.TaiLieux.Add(taiLieu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(taiLieu);
        }

        // GET: TaiLieux/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiLieu taiLieu = db.TaiLieux.Find(id);
            if (taiLieu == null)
            {
                return HttpNotFound();
            }
            return View(taiLieu);
        }

        // POST: TaiLieux/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TenTaiLieu,MonHoc,PhanLoai,NguoiTao,NguoiPheDuyet,NgayGui,TinhTrang,GhiChu")] TaiLieu taiLieu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taiLieu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taiLieu);
        }

        // GET: TaiLieux/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiLieu taiLieu = db.TaiLieux.Find(id);
            if (taiLieu == null)
            {
                return HttpNotFound();
            }
            return View(taiLieu);
        }

        // POST: TaiLieux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaiLieu taiLieu = db.TaiLieux.Find(id);
            db.TaiLieux.Remove(taiLieu);
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
