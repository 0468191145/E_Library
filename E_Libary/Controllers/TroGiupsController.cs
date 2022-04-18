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
    public class TroGiupsController : ApiController
    {
        private E_LibraryEntities1 db = new E_LibraryEntities1();

        // GET: api/TroGiups/5
        [ResponseType(typeof(TroGiup))]
        public IHttpActionResult GetTroGiup(int id = -1)
        {
            if (id > 0)
            {
                TroGiup TroGiup = db.TroGiups.Find(id);
                if (TroGiup == null)
                {
                    return NotFound();
                }

                return Ok(TroGiup);
            }
            else
            {
                return Ok(db.TroGiups);
            }
        }

        // PUT: api/TroGiups/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTroGiup(int id, TroGiup TroGiup)
        {
            try
            {
                var put = db.TroGiups.SingleOrDefault(n => n.Id == id);
                if (put != null)
                {
                    put.TieuDe = TroGiup.TieuDe;
                    put.NoiDung = TroGiup.NoiDung;
                    put.NgayGui = TroGiup.NgayGui;
                    put.NguoiGui = TroGiup.NguoiGui;
                    put.TrangThai = TroGiup.TrangThai;

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

        // POST= api/TroGiups
        [ResponseType(typeof(TroGiup))]
        public IHttpActionResult PostTroGiup(TroGiup TroGiup)
        {
            try
            {
                if (TroGiup != null)
                {
                    db.TroGiups.Add(TroGiup);
                    db.SaveChanges();
                    return Ok(TroGiup);
                }
                return BadRequest("Chưa nhập dữ liệu");
            }
            catch
            {
                return BadRequest("Lỗi");
            }
        }

        // DELETE: api/TroGiups/5
        [ResponseType(typeof(TroGiup))]
        public IHttpActionResult DeleteTroGiup(int id)
        {
            try
            {
                var delete = db.TroGiups.SingleOrDefault(n => n.Id == id);
                if (delete != null)
                {
                    db.TroGiups.Remove(delete);
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

        private bool TroGiupExists(int id)
        {
            return db.TroGiups.Count(e => e.Id == id) > 0;
        }
    }
}