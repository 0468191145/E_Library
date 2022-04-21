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
    public class NhomNguoiDungsController : ApiController
    {
        private E_LibraryEntities1 db = new E_LibraryEntities1();

        // GET: api/NhomNguoiDungs/5
        //Hiện danh sách các nhóm và hiện chi tiết các tên người dùng có trong nhóm
        [ResponseType(typeof(NhomNguoiDung))]
        public IHttpActionResult GetNhomNguoiDung(int id = -1)
        {
            if (id > 0)
            {
                var get = (from nguoidung in db.TaiKhoans
                           join nhom in db.NhomNguoiDungs on nguoidung.MaNhom equals nhom.MaNhom
                           select new
                           {
                               nhom.Id,
                               nhom.TenNhom,
                               nguoidung.Ten
                           }).OrderBy(x => x.TenNhom).Where(n=>n.Id==id);

                if (get == null)
                {
                    return NotFound();
                }

                return Ok(get);
            }
            else
            {
               
                return Ok(db.NhomNguoiDungs);
            }
        }


        // PUT: api/NhomNguoiDungs/5
        //Cập nhật nhóm người dùng
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNhomNguoiDung(int id, NhomNguoiDung NhomNguoiDung)
        {
            try
            {
                var put = db.NhomNguoiDungs.SingleOrDefault(n => n.Id == id);
                if (put != null)
                {
                    foreach (TaiKhoan taiKhoan in db.TaiKhoans)
                    {
                        if (taiKhoan.MaNhom == put.MaNhom)
                        {
                            taiKhoan.MaNhom = NhomNguoiDung.MaNhom;
                        }
                    }
                    put.MaNhom = NhomNguoiDung.MaNhom;
                    put.TenNhom = NhomNguoiDung.TenNhom;
                    put.MoTa = NhomNguoiDung.MoTa;
                    put.NgayCapNhatGanNhat = DateTime.Now;

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

        // POST: api/NhomNguoiDungs
        //Thêm nhóm người dùng
        [ResponseType(typeof(NhomNguoiDung))]
        public IHttpActionResult PostNhomNguoiDung(NhomNguoiDung NhomNguoiDung)
        {
            try
            {
                if (NhomNguoiDung != null)
                {
                    NhomNguoiDung.NgayCapNhatGanNhat = DateTime.Now;
                    db.NhomNguoiDungs.Add(NhomNguoiDung);
                    db.SaveChanges();
                    return Ok(NhomNguoiDung);
                }
                return BadRequest("Chưa nhập dữ liệu");
            }
            catch
            {
                return BadRequest("Lỗi");
            }
        }

        // DELETE: api/NhomNguoiDungs/5
        // Xóa nhóm người dùng
        [ResponseType(typeof(NhomNguoiDung))]
        public IHttpActionResult DeleteNhomNguoiDung(int id)
        {
            try
            {
                var delete = db.NhomNguoiDungs.SingleOrDefault(n => n.Id == id);
                if (delete != null)
                {
                    foreach (TaiKhoan taiKhoan in db.TaiKhoans)
                    {
                        if (taiKhoan.MaNhom == delete.MaNhom)
                        {
                            taiKhoan.MaNhom = null;
                        }
                    }
                    db.NhomNguoiDungs.Remove(delete);
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

        private bool NhomNguoiDungExists(int id)
        {
            return db.NhomNguoiDungs.Count(e => e.Id == id) > 0;
        }
    }
}