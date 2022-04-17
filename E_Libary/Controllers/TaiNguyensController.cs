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
    public class TaiNguyensController : ApiController
    {
        private E_LibraryEntities1 db = new E_LibraryEntities1();

        // GET: api/TaiNguyens/5
        [ResponseType(typeof(TaiNguyen))]
        public IHttpActionResult GetTaiNguyen(int id = -1)
        {
            if (id > 0)
            {
                TaiNguyen tainguyen = db.TaiNguyens.Find(id);
                if (tainguyen == null)
                {
                    return NotFound();
                }

                return Ok(tainguyen);
            }
            else
            {
                return Ok(db.TaiNguyens);
            }
        }

        // PUT: api/TaiNguyens/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTaiNguyen(int id, TaiNguyen tainguyen)
        {
            try
            {
                var put = db.TaiNguyens.SingleOrDefault(n => n.Id == id);
                if (put != null)
                {
                    put.LoaiFile = tainguyen.LoaiFile;
                    put.Ten = tainguyen.Ten;
                    put.MonHoc = tainguyen.MonHoc;
                    put.Lop = tainguyen.Lop;
                    put.ChuDe = tainguyen.ChuDe;
                    put.NguoiChinhSua = tainguyen.NguoiChinhSua;
                    put.NgayChinhSuaCuoi = tainguyen.NgayChinhSuaCuoi;
                    put.KichThuoc = tainguyen.KichThuoc;

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

        // POST: api/TaiNguyens
        [ResponseType(typeof(TaiNguyen))]
        public IHttpActionResult PostTaiNguyen(TaiNguyen tainguyen)
        {
            try
            {
                if (tainguyen != null)
                {
                    db.TaiNguyens.Add(tainguyen);
                    db.SaveChanges();
                    return Ok(tainguyen);
                }
                return BadRequest("Chưa nhập dữ liệu");
            }
            catch
            {
                return BadRequest("Lỗi");
            }
        }

        // DELETE: api/TaiNguyens/5
        [ResponseType(typeof(TaiNguyen))]
        public IHttpActionResult DeleteTaiNguyen(int id)
        {
            try
            {
                var delete = db.TaiNguyens.SingleOrDefault(n => n.Id == id);
                if (delete != null)
                {
                    db.TaiNguyens.Remove(delete);
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

        private bool TaiNguyenExists(int id)
        {
            return db.TaiNguyens.Count(e => e.Id == id) > 0;
        }
    }
}