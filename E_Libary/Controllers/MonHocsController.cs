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
    public class MonHocsController : ApiController
    {
        private E_LibraryEntities db = new E_LibraryEntities();

        // GET: api/MonHocs/5
        [ResponseType(typeof(MonHoc))]
        public IHttpActionResult GetMonHoc(int id = -1)
        {
            if (id > 0)
            {
                MonHoc monhoc = db.MonHocs.Find(id);
                if (monhoc == null)
                {
                    return NotFound();
                }

                return Ok(monhoc);
            }
            else
            {
                return Ok(db.MonHocs);
            }
        }

        // PUT: api/MonHocs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMonHoc(int id, MonHoc monhoc)
        {
            try
            {
                var put = db.MonHocs.SingleOrDefault(n => n.Id == id);
                if (put != null)
                {
                    put.MaMon = monhoc.MaMon;
                    put.TenMonHoc = monhoc.TenMonHoc;
                    put.MoTa = monhoc.MoTa;
                    put.GiangVien = monhoc.GiangVien;
                    put.ToBoMon = monhoc.ToBoMon;
                  

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

        // POST: api/MonHocs
        [ResponseType(typeof(MonHoc))]
        public IHttpActionResult PostMonHoc(MonHoc monhoc)
        {
            try
            {
                if (monhoc != null)
                {
                    db.MonHocs.Add(monhoc);
                    db.SaveChanges();
                    return Ok(monhoc);
                }
                return BadRequest("Chưa nhập dữ liệu");
            }
            catch
            {
                return BadRequest("Lỗi");
            }
        }

        // DELETE: api/MonHocs/5
        [ResponseType(typeof(MonHoc))]
        public IHttpActionResult DeleteMonHoc(int id)
        {
            try
            {
                var delete = db.MonHocs.SingleOrDefault(n => n.Id == id);
                if (delete != null)
                {
                    db.MonHocs.Remove(delete);
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

        private bool MonHocExists(int id)
        {
            return db.MonHocs.Count(e => e.Id == id) > 0;
        }
    }
}