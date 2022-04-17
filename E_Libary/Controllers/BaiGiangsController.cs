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
    public class BaiGiangsController : ApiController
    {
        private E_LibraryEntities1 db = new E_LibraryEntities1();

        // GET: api/BaiGiangs/5
        [ResponseType(typeof(BaiGiang))]
        public IHttpActionResult GetBaiGiang(int id=-1)
        {
            if (id > 0)
            {
                BaiGiang baigiang = db.BaiGiangs.Find(id);
                if (baigiang == null)
                {
                    return NotFound();
                }

                return Ok(baigiang);
            }
            else
            {
                return Ok(db.BaiGiangs);
            }
        }

        // PUT: api/BaiGiangs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBaiGiang(int id, BaiGiang baigiang)
        {
            try
            {
                var put = db.BaiGiangs.SingleOrDefault(n => n.Id == id);
                if (put != null)
                {
                    put.LoaiFile = baigiang.LoaiFile;
                    put.Ten = baigiang.Ten;
                    put.MonHoc = baigiang.MonHoc;
                    put.Lop = baigiang.Lop;
                    put.ChuDe = baigiang.ChuDe;
                    put.NguoiChinhSua = baigiang.NguoiChinhSua;
                    put.NgayChinhSuaCuoi = baigiang.NgayChinhSuaCuoi;
                    put.KichThuoc = baigiang.KichThuoc;

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

        // POST= api/BaiGiangs
        [ResponseType(typeof(BaiGiang))]
        public IHttpActionResult PostBaiGiang(BaiGiang baiGiang)
        {
            try
            {
                if (baiGiang != null)
                {
                    db.BaiGiangs.Add(baiGiang);
                    db.SaveChanges();
                    return Ok(baiGiang);
                }
                return BadRequest("Chưa nhập dữ liệu");
            }
            catch
            {
                return BadRequest("Lỗi");
            }
        }

        // DELETE: api/BaiGiangs/5
        [ResponseType(typeof(BaiGiang))]
        public IHttpActionResult DeleteBaiGiang(int id)
        {
            try
            {
                var delete = db.BaiGiangs.SingleOrDefault(n => n.Id == id);
                if (delete != null)
                {
                    db.BaiGiangs.Remove(delete);
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

        private bool BaiGiangExists(int id)
        {
            return db.BaiGiangs.Count(e => e.Id == id) > 0;
        }
    }
}