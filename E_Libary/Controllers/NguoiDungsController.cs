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
    public class NguoiDungsController : ApiController
    {
        private E_LibraryEntities1 db = new E_LibraryEntities1();

        // GET: api/NguoiDungs/5         Xem các tài khoản người dùng và tên vai trò
        [ResponseType(typeof(NguoiDung))]
        public IHttpActionResult GetNguoiDung(string tukhoa=null)
        {
            if (tukhoa == null)
            {
                var get = (from s in db.Roles
                           join c in db.NguoiDungs on s.Id equals c.VaiTro
                           select new 
                           {
                               c.MaNguoiDung,
                               c.TenNguoiDung,
                               c.Email,
                               s.TenVaiTro
                           }).OrderBy(x => x.MaNguoiDung);
                return Ok(get);
            }
            else if(char.IsNumber(tukhoa[0]))
            {
                return LocNguoiDung(Convert.ToInt32(tukhoa));
            }
            else
            {
                return TimKiemNguoiDung(tukhoa);
            }
        }

        public IHttpActionResult TimKiemNguoiDung(string tukhoa)
        {

            var get = (from s in db.Roles
                       join c in db.NguoiDungs on s.Id equals c.VaiTro
                       where c.TenNguoiDung.Contains(tukhoa)
                       select new
                       {
                           c.MaNguoiDung,
                           c.TenNguoiDung,
                           c.Email,
                           s.TenVaiTro
                       }).OrderBy(x => x.MaNguoiDung);

            return Ok(get);
        }

        public IHttpActionResult LocNguoiDung(int tukhoa)
        {

            var get = (from s in db.Roles
                       join c in db.NguoiDungs on s.Id equals c.VaiTro
                       where c.VaiTro ==tukhoa
                       select new
                       {
                           c.MaNguoiDung,
                           c.TenNguoiDung,
                           c.Email,
                           s.TenVaiTro
                       }).OrderBy(x => x.MaNguoiDung);

            return Ok(get);
        }

        // PUT: api/NguoiDungs/5            Chỉnh sửa thông tin người dùng
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNguoiDung(string ma, NguoiDung nguoidung)
        {
            try
            {
                var put = db.NguoiDungs.SingleOrDefault(n => n.MaNguoiDung==ma);
                if (put != null)
                {
                    put.TenNguoiDung = nguoidung.TenNguoiDung;
                    put.Email = nguoidung.Email;
                    put.SDT = nguoidung.SDT;
                    put.VaiTro = nguoidung.VaiTro;

                    db.SaveChanges();
                    return Ok(String.Format("TenNguoiDung: {0}, " +
                        "Email: {1},"+
                        "SDT: {2} "+
                        "VaiTro: {3}",put.TenNguoiDung,put.Email,put.SDT,put.VaiTro ));
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest(ModelState);
            }
        }

        // POST: api/NguoiDungs              Thêm người dùng vào hệ thống
        [ResponseType(typeof(NguoiDung))]
        public IHttpActionResult PostNguoiDung(NguoiDung nguoidung)
        {
            try
            {
                if (nguoidung != null)
                {
                    db.NguoiDungs.Add(nguoidung);
                    db.SaveChanges();
                    return Ok(nguoidung);
                }
                return BadRequest("Chưa nhập dữ liệu");
            }
            catch
            {
                return BadRequest("Lỗi");
            }
        }

        // DELETE: api/NguoiDungs/5          Xóa người dùng
        [ResponseType(typeof(NguoiDung))]
        public IHttpActionResult DeleteNguoiDung(string ma)
        {
            try
            {
                var delete = db.NguoiDungs.SingleOrDefault(n => n.MaNguoiDung == ma);
                if (delete != null)
                {
                    db.NguoiDungs.Remove(delete);
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

        private bool NguoidungExists(string ma)
        {
            return db.NguoiDungs.Count(e => e.MaNguoiDung == ma) > 0;
        }
    }
}