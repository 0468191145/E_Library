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
    public class DeThisController : ApiController
    {
        private E_LibraryEntities db = new E_LibraryEntities();

        // GET: api/DeThis/5
        [ResponseType(typeof(DeThi))]
        public IHttpActionResult GetDeThi(int id=-1)
        {
            if (id > 0)
            {
                DeThi dethi = db.DeThis.Find(id);
                if (dethi == null)
                {
                    return NotFound();
                }

                return Ok(dethi);
            }
            else
            {
                return Ok(db.DeThis);
            }
        }

        // PUT: api/DeThis/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDeThi(int id, DeThi dethi)
        {
            try
            {
                var put = db.DeThis.SingleOrDefault(n => n.ID == id);
                if (put != null)
                {
                    put.GhiChu= dethi.GhiChu;
                    put.HinhThuc=dethi.HinhThuc;
                    put.LoaiFile=dethi.LoaiFile; 
                    put.MonHoc=dethi.MonHoc;
                    put.NgayTao=dethi.NgayTao;
                    put.NgayThi=dethi.NgayThi;
                    put.NguoiPheDuyet=dethi.NguoiPheDuyet;
                    put.NguoiTao=dethi.NguoiTao;
                    put.NoiDung=dethi.NoiDung;
                    put.PheDuyet=dethi.PheDuyet;
                    put.TenDeThi=dethi.TenDeThi;
                    put.ThoiLuong=dethi.ThoiLuong;
                    put.TinhTrang=dethi.TinhTrang;

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

        // POST: api/DeThis
        [ResponseType(typeof(DeThi))]
        public IHttpActionResult PostDeThi(DeThi dethi)
        {
            try
            {
                if (dethi != null)
                {
                    db.DeThis.Add(dethi);
                    db.SaveChanges();
                    return Ok(dethi);
                }
                return BadRequest("Chưa nhập dữ liệu");
            }
            catch
            {
                return BadRequest("Lỗi");
            }
        }

        // DELETE: api/DeThis/5
        [ResponseType(typeof(DeThi))]
        public IHttpActionResult DeleteDeThi(int id)
        {
            try
            {
                var delete = db.DeThis.SingleOrDefault(n => n.ID == id);
                if (delete != null)
                {
                    db.DeThis.Remove(delete);
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

        private bool DeThiExists(int id)
        {
            return db.DeThis.Count(e => e.ID == id) > 0;
        }
    }
}