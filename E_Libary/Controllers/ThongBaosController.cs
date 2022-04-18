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
    public class ThongBaosController : ApiController
    {
        private E_LibraryEntities1 db = new E_LibraryEntities1();

        // GET: api/ThongBaos/5
        [ResponseType(typeof(ThongBao))]
        public IHttpActionResult GetThongBao(int id = -1)
        {
            if (id > 0)
            {
                ThongBao ThongBao = db.ThongBaos.Find(id);
                if (ThongBao == null)
                {
                    return NotFound();
                }

                return Ok(ThongBao);
            }
            else
            {
                return Ok(db.ThongBaos);
            }
        }

        // PUT: api/ThongBaos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutThongBao(int id, ThongBao ThongBao)
        {
            try
            {
                var put = db.ThongBaos.SingleOrDefault(n => n.Id == id);
                if (put != null)
                {
                    put.PhanLoai = ThongBao.PhanLoai;
                    put.ChuDe = ThongBao.ChuDe;
                    put.NoiDung = ThongBao.NoiDung;
                    put.NguoiGui = ThongBao.NguoiGui;
                    put.NguoiNhan = ThongBao.NguoiNhan;
                    put.TrangThai = ThongBao.TrangThai;
                    put.NgayThongBao = ThongBao.NgayThongBao;

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

        // POST= api/ThongBaos
        [ResponseType(typeof(ThongBao))]
        public IHttpActionResult PostThongBao(ThongBao ThongBao)
        {
            try
            {
                if (ThongBao != null)
                {
                    db.ThongBaos.Add(ThongBao);
                    db.SaveChanges();
                    return Ok(ThongBao);
                }
                return BadRequest("Chưa nhập dữ liệu");
            }
            catch
            {
                return BadRequest("Lỗi");
            }
        }

        // DELETE: api/ThongBaos/5
        [ResponseType(typeof(ThongBao))]
        public IHttpActionResult DeleteThongBao(int id)
        {
            try
            {
                var delete = db.ThongBaos.SingleOrDefault(n => n.Id == id);
                if (delete != null)
                {
                    db.ThongBaos.Remove(delete);
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

        private bool ThongBaoExists(int id)
        {
            return db.ThongBaos.Count(e => e.Id == id) > 0;
        }
    }
}