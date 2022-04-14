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
    public class TaiKhoansController : ApiController
    {
        private E_LibraryEntities db = new E_LibraryEntities();

        // GET: api/TaiKhoans/5
        [ResponseType(typeof(TaiKhoan))]
        public IHttpActionResult GetTaiKhoan(int id=-1)
        {
            if (id>0)
            {
                TaiKhoan get = db.TaiKhoans.Find(id);
                if (get == null)
                {
                    return NotFound();
                }

                return Ok(get);
            }
            else
            {
                return Ok(db.TaiKhoans);
            }
        }

        // PUT: api/TaiKhoans/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTaiKhoan( int id,TaiKhoan taikhoan)
        {
            try
            {
                var put = db.TaiKhoans.SingleOrDefault(n => n.Id==id);
                if (put != null)
                {
                    put.UserName = taikhoan.UserName;
                    put.PassWord = taikhoan.PassWord;
                    put.MaNguoiDung = taikhoan.MaNguoiDung;
                    put.Ten = taikhoan.Ten;
                    put.VaiTro = taikhoan.VaiTro;

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

        // POST: api/TaiKhoans
        [ResponseType(typeof(TaiKhoan))]
        public IHttpActionResult PostTaiKhoan(TaiKhoan taikhoan)
        {
            try
            {
                if (taikhoan != null)
                {
                    db.TaiKhoans.Add(taikhoan);
                    db.SaveChanges();
                    return Ok(taikhoan);
                }
                return BadRequest("Chưa nhập dữ liệu");
            }
            catch
            {
                return BadRequest("Lỗi");
            }
        }

        // DELETE: api/TaiKhoans/5
        [ResponseType(typeof(TaiKhoan))]
        public IHttpActionResult DeleteTaiKhoan(int id)
        {
            try
            {
                var delete = db.TaiKhoans.SingleOrDefault(n => n.Id == id);
                if (delete != null)
                {
                    db.TaiKhoans.Remove(delete);
                    db.SaveChanges();
                    return Ok("Xóa thành công");
                }
                return Ok("Không có dữ liệu cần tìm");
            }
            catch (Exception ex)
            {
                return BadRequest("Lỗi");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaiKhoanExists(string id)
        {
            return db.TaiKhoans.Count(e => e.UserName == id) > 0;
        }
    }
}