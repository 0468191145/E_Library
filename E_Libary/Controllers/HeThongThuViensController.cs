using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using E_Libary.Models;

namespace E_Libary.Controllers
{
    public class HeThongThuViensController : ApiController
    {
        private E_LibraryEntities1 db = new E_LibraryEntities1();

        // GET: api/ThuViens/5          Hiển thị thông tin hệ thống thư viện
        [ResponseType(typeof(HeThongThuVien))]
        public IHttpActionResult GetThuVien(int id = -1)
        {
            if (id > 0)
            {
                HeThongThuVien thuvien = db.HeThongThuViens.Find(id);
                if (thuvien == null)
                {
                    return NotFound();
                }

                return Ok(thuvien);
            }
            else
            {
                return Ok(db.HeThongThuViens);
            }
        }

        // PUT: api/ThuViens/5          Cập nhật thông tin hệ thống thư viện
        [ResponseType(typeof(void))]
        public IHttpActionResult PutThuVien(int id, HeThongThuVien thuvien)
        {
            try
            {
                var put = db.HeThongThuViens.SingleOrDefault(n => n.Id == id);
                if (put != null)
                {
                    put.DiaChiTruyCap = thuvien.DiaChiTruyCap;
                    put.Email = thuvien.Email;
                    put.HieuTruong = thuvien.HieuTruong;
                    put.LoaiTruong = thuvien.LoaiTruong;
                    put.MaTruong = thuvien.MaTruong;
                    put.NgonNgu = thuvien.NgonNgu;
                    put.NienKhoa = thuvien.NienKhoa;
                    put.SĐT = thuvien.SĐT;
                    put.TenThuVien = thuvien.TenThuVien;
                    put.TenTruong = thuvien.TenTruong;
                    put.Website = thuvien.Website;


                    db.SaveChanges();
                    return Ok(put);
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest(ModelState);
            }
        }

        // POST: api/ThuViens
        [ResponseType(typeof(HeThongThuVien))]
       

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HeThongThuVienExists(string id)
        {
            return db.HeThongThuViens.Count(e => e.MaTruong == id) > 0;
        }
    }
}