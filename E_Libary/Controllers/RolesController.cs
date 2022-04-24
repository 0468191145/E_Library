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
    public class RolesController : ApiController
    {
        private E_LibraryEntities1 db = new E_LibraryEntities1();

        // GET: api/NhomNguoiDungs/5    Hiện danh sách các nhóm người dùng và hiện chi tiết các thành viên trong nhóm
        [ResponseType(typeof(void))]
        public IHttpActionResult GetRole(int ma = -1)
        {
            if (ma > 0)
            {
                var get = (from s in db.Roles
                           join c in db.NguoiDungs on s.Id equals c.VaiTro
                           where s.Id == ma
                           select new
                           {
                               s.TenVaiTro,
                               c.MaNguoiDung,
                               c.TenNguoiDung,
                               c.Email,
                               c.SDT,

                           }
                           ).OrderBy(x => x.TenVaiTro);
                if (get == null)
                {
                    return NotFound();
                }

                return Ok(get);
            }
            else
            {
                var get = (from s in db.Roles
                           select new
                           {
                               s.TenVaiTro,
                               s.MoTa,
                               s.NgayChinhSua
                           }
                           );
                return Ok(get);
            }
        }

        // PUT: api/Roles/5             Cập nhật vai trò người dùng
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRole(int id, Role role)
        {
            try
            {
                var put = db.Roles.SingleOrDefault(n => n.Id == id);
                if (put != null)
                {
                    put.De = role.De;
                    put.MonHoc = role.MonHoc;
                    put.MoTa = role.MoTa;
                    put.NguoiDung = role.NguoiDung;
                    put.PhanQuyen = role.PhanQuyen;
                    put.TaiNguyen = role.TaiNguyen;
                    put.TenVaiTro = role.TenVaiTro;
                    put.TepRiengTu = role.TepRiengTu;
                    put.ThongBao = role.ThongBao;
                    put.NgayChinhSua = DateTime.Now;


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

        // POST: api/Roles              Thêm vai trò người dùng
        [ResponseType(typeof(Role))]
        public IHttpActionResult PostRole(Role role)
        {
            try
            {
                if (role != null)
                {
                    role.NgayChinhSua = DateTime.Now;
                    db.Roles.Add(role);
                    db.SaveChanges();
                    return Ok(role);
                }
                return BadRequest("Chưa nhập dữ liệu");
            }
            catch
            {
                return BadRequest("Lỗi");
            }
        }

        // DELETE: api/Roles/5          Xóa vai trò người dùng
        [ResponseType(typeof(Role))]   
        public IHttpActionResult DeleteRole(int id)
        {
            try
            {
                var delete = db.Roles.SingleOrDefault(n => n.Id == id);
                if (delete != null)
                {
                    db.Roles.Remove(delete);
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

        private bool RoleExists(int id)
        {
            return db.Roles.Count(e => e.Id == id) > 0;
        }
    }
}