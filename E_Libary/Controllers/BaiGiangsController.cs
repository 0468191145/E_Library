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

        // GET: api/BaiGiangs/5                 Lấy danh sách bài giảng
        public IHttpActionResult GetBaiGiang(string mon = null, string ten = null)
        {
            if (mon == null && ten == null)
            {
                var get = (from c in db.BaiGiangs
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
                return LocBaiGiang(mon);
            }
            else
            {
                return TimKiemBaiGiang(ten);
            }
        }

        public IHttpActionResult TimKiemBaiGiang(string tukhoa)
        {

            var get = (from c in db.BaiGiangs
                       where   c.Ten.Contains(tukhoa)
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

        public IHttpActionResult LocBaiGiang(string tukhoa)
        {

            var get = (from c in db.BaiGiangs
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

        // PUT: api/BaiGiangs/5                 Đổi tên bài giảng 
        public IHttpActionResult PutBaiGiang(int id, string ten)
        {
            try
            {
                var put = db.BaiGiangs.SingleOrDefault(n => n.Id == id );
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

        //POST :api/BaiGiangs
        public IHttpActionResult PostBaiGiang(BaiGiang baigiang)
        {
           
                try
                {
                    if (baigiang != null)
                    {
                        baigiang.NgayChinhSuaCuoi = DateTime.Now;
                        db.BaiGiangs.Add(baigiang);
                        db.SaveChanges();
                        return Ok(baigiang);
                    }
                    return BadRequest("Chưa nhập dữ liệu");
                }
                catch (Exception ex)
                {
                    return BadRequest("Lỗi");
                }
           
        }
        public IHttpActionResult PostBaiGiangMonHoc(int id, string mon)
        {
            try
            {
                BaiGiang baigiang = db.BaiGiangs.SingleOrDefault(n => n.Id == id);
                if (baigiang != null)
                {
                    TaiLieu tailieu = new TaiLieu
                    {
                        Ma = baigiang.Id,
                        LoaiTep = baigiang.LoaiFile,
                        TenTaiLieu = baigiang.Ten,
                        PhanLoai = true,
                        MaMon = mon,
                        NguoiTao=baigiang.NguoiChinhSua,
                        NguoiPheDuyet= null,
                        KichThuoc=baigiang.KichThuoc,
                        TinhTrang="Chờ phê duyệt",
                        NgayGui =DateTime.Now,
                        GhiChu =""
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

            //DELETE :api/BaiGiangs/5
        public IHttpActionResult DeleteBaiGiang(int id)
        {
            try
            {
                var delete = db.BaiGiangs.SingleOrDefault(n => n.Id == id );
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