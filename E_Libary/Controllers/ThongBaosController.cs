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

        // GET: api/ThongBaos/
        [ResponseType(typeof(ThongBao))]
        [HttpGet]
        public IHttpActionResult GetThongBao(bool phanloai=true)
        {
           
                List<ThongBao> ThongBao = db.ThongBaos.Where(n=>n.PhanLoai==phanloai).ToList();
                if (ThongBao == null)
                {
                    return NotFound();
                }

                return Ok(ThongBao);
           
        }
        [Route("api/ThongBaos/TimKiem")]
        [HttpGet]
        public IHttpActionResult TimKiemThongBao(string tukhoa,bool phanloai=true )
        {

            var get = (from c in db.ThongBaos
                       where (c.NoiDung.Contains(tukhoa)||c.ChuDe.Contains(tukhoa))&& c.PhanLoai==phanloai
                       select new
                       {
                           c.NguoiGui,
                           c.NoiDung,
                           c.NgayThongBao
                           
                       }).OrderBy(x => x.NgayThongBao);

            return Ok(get);
        }

        // POST= api/ThongBaos
        [ResponseType(typeof(ThongBao))]
        public IHttpActionResult PostThongBao(ThongBao ThongBao, bool phanloai=true)
        {
            try
            {
                if (ThongBao != null)
                {
                    ThongBao.PhanLoai = phanloai;
                    ThongBao.NgayThongBao = DateTime.Now;
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