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

        // GET: api/TaiNguyens/5                 Lấy danh sách bài giảng
        public IHttpActionResult GetTaiNguyen(string mon = null, string ten = null)
        {
            if (mon == null && ten == null)
            {
                var get = (from c in db.TaiNguyens
                           select new
                           {
                               c.Id,
                               c.LoaiFile,
                               c.Ten,
                               c.TenMon,
                               c.NguoiChinhSua,
                               c.NgayChinhSuaCuoi,
                               c.KichThuoc
                           });
                return Ok(get);
            }
            else if (mon != null)
            {
                return LocTaiNguyen(mon);
            }
            else
            {
                return TimKiemTaiNguyen(ten);
            }
        }

        public IHttpActionResult TimKiemTaiNguyen(string tukhoa)
        {

            var get = (from c in db.TaiNguyens
                       where c.Ten.Contains(tukhoa)
                       select new
                       {
                           c.Id,
                           c.LoaiFile,
                           c.Ten,
                           c.TenMon,
                           c.NguoiChinhSua,
                           c.NgayChinhSuaCuoi,
                           c.KichThuoc
                       }).OrderBy(x => x.Ten);

            return Ok(get);
        }

        public IHttpActionResult LocTaiNguyen(string tukhoa)
        {

            var get = (from c in db.TaiNguyens
                       where  c.MaMon == tukhoa
                       select new
                       {
                           c.Id,
                           c.LoaiFile,
                           c.Ten,
                           c.TenMon,
                           c.NguoiChinhSua,
                           c.NgayChinhSuaCuoi,
                           c.KichThuoc
                       }).OrderBy(x => x.Ten);

            return Ok(get);

        }

        // PUT: api/TaiNguyens/5                 Đổi tên bài giảng 
        public IHttpActionResult PutTaiNguyen(int id, string ten)
        {
            try
            {
                var put = db.TaiNguyens.SingleOrDefault(n => n.Id == id );
                if (put != null)
                {
                    if (ten != null)
                    {
                        put.Ten = ten;
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

        //POST :api/TaiNguyens
        public IHttpActionResult PostTaiNguyen(TaiNguyen TaiNguyen)
        {
            try
            {
                if (TaiNguyen != null)
                {
                    TaiNguyen.NgayChinhSuaCuoi = DateTime.Now;
                    db.TaiNguyens.Add(TaiNguyen);
                    db.SaveChanges();
                    return Ok(TaiNguyen);
                }
                return BadRequest("Chưa nhập dữ liệu");
            }
            catch
            {
                return BadRequest("Lỗi");
            }
        }
        public IHttpActionResult PostTaiNguyenMonHoc(int id, string mon)
        {
            try
            {
                TaiNguyen tainguyen = db.TaiNguyens.SingleOrDefault(n => n.Id == id);
                if (tainguyen != null)
                {
                    TaiLieu tailieu = new TaiLieu
                    {
                        Ma = tainguyen.Id,
                        LoaiTep = tainguyen.LoaiFile,
                        TenTaiLieu = tainguyen.Ten,
                        PhanLoai = false,
                        MaMon = mon,
                        NguoiTao = tainguyen.NguoiChinhSua,
                        NguoiPheDuyet = null,
                        KichThuoc = tainguyen.KichThuoc,
                        TinhTrang = "Chờ phê duyệt",
                        NgayGui = DateTime.Now,
                        GhiChu = ""
                    };
                    db.TaiLieux.Add(tailieu);
                    db.SaveChanges();
                    return Ok(tailieu);
                }
                return BadRequest("Chưa nhập dữ liệu");
            }
            catch (Exception ex)
            {
                return BadRequest("Lỗi");
            }
        }

        //DELETE :api/TaiNguyens/5
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