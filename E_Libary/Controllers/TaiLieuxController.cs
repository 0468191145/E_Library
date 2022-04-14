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
    public class TaiLieuxController : ApiController
    {
        private E_LibraryEntities db = new E_LibraryEntities();

        // GET: api/TaiLieux/5
        [ResponseType(typeof(TaiLieu))]
        public IHttpActionResult GetTaiLieu(int id = -1)
        {
            if (id > 0)
            {
                TaiLieu tailieu = db.TaiLieux.Find(id);
                if (tailieu == null)
                {
                    return NotFound();
                }

                return Ok(tailieu);
            }
            else
            {
                return Ok(db.TaiLieux);
            }
        }

        // PUT: api/TaiLieux/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTaiLieu(int id, TaiLieu tailieu)
        {
            try
            {
                var put = db.TaiLieux.SingleOrDefault(n => n.Id == id);
                if (put != null)
                {
                    {
                        put.TenTaiLieu = tailieu.TenTaiLieu;
                        put.MonHoc = tailieu.MonHoc;
                        put.PhanLoai = tailieu.PhanLoai;
                        put.NguoiTao = tailieu.NguoiTao;
                        put.NguoiPheDuyet = put.NguoiPheDuyet;
                        put.NgayGui = tailieu.NgayGui;
                        put.TinhTrang = tailieu.TinhTrang;
                        put.GhiChu = tailieu.GhiChu;
}

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

        // POST: api/TaiLieux
        [ResponseType(typeof(TaiLieu))]
        public IHttpActionResult PostTaiLieu(TaiLieu tailieu)
        {
            try
            {
                if (tailieu != null)
                {
                    db.TaiLieux.Add(tailieu);
                    db.SaveChanges();
                    return Ok(tailieu);
                }
                return BadRequest("Chưa nhập dữ liệu");
            }
            catch
            {
                return BadRequest("Lỗi");
            }
        }

        // DELETE: api/TaiLieux/5
        [ResponseType(typeof(TaiLieu))]
        public IHttpActionResult DeleteTaiLieu(int id)
        {
            try
            {
                var delete = db.TaiLieux.SingleOrDefault(n => n.Id == id);
                if (delete != null)
                {
                    db.TaiLieux.Remove(delete);
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

        private bool TaiLieuExists(int id)
        {
            return db.TaiLieux.Count(e => e.Id == id) > 0;
        }
    }
}