using System;
using System.Data;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using E_Libary.Models;

namespace E_Libary.Controllers
{
    public class TaiLieuxController : ApiController
    {
        private E_LibraryEntities1 db = new E_LibraryEntities1();

        [ResponseType(typeof(TaiLieu))]
        [Route("api/TaiLieux")]
        public IHttpActionResult GetTaiLieux(string mon = null, string ten = null)
        {
            if (mon == null && ten == null)
            {
                var get = (from c in db.TaiLieux
                           select new
                           {
                               c.Id,
                               c.LoaiTep,
                               c.TenTaiLieu,
                               PhanLoai= c.PhanLoai==true?"bài giảng":"tài nguyên",
                               c.TenMon,
                               NguoiGui= c.NguoiTao,
                               c.NguoiPheDuyet,
                               c.NgayGui,
                               c.TinhTrang,
                               c.KichThuoc
                           });
                return Ok(get);
            }
            else if (mon != null)
            {
                return LocTaiLieu(mon);
            }
            else
            {
                return TimKiemTaiLieu(ten);
            }
        }

        public IHttpActionResult TimKiemTaiLieu(string tukhoa)
        {

            var get = (from c in db.TaiLieux
                       where  c.TenTaiLieu.Contains(tukhoa)
                       select new
                       {
                           c.Id,
                           c.LoaiTep,
                           c.TenTaiLieu,
                           c.TenMon,
                           c.NguoiTao,
                           c.NgayGui,
                           c.KichThuoc
                       }).OrderBy(x => x.TenTaiLieu);

            return Ok(get);
        }

        public IHttpActionResult LocTaiLieu(string tukhoa)
        {

            var get = (from c in db.TaiLieux
                       where c.MaMon == tukhoa
                       select new
                       {
                               c.Id,
                           c.LoaiTep,
                           c.TenTaiLieu,
                           c.TenMon,
                           c.NguoiTao,
                           c.NgayGui,
                           c.KichThuoc
                       }).OrderBy(x => x.TenTaiLieu);

            return Ok(get);

        }

        [Route("api/TaiLieux")]
        [HttpPut]
        public IHttpActionResult PheDuyet(int id,string nguoipheduyet, string tinhtrang,string ghichu=null)
        {
            TaiLieu tailieu = db.TaiLieux.SingleOrDefault(n => n.Id == id);
            try {
                if (tailieu != null)
                {
                    tailieu.NguoiPheDuyet = nguoipheduyet;
                    tailieu.TinhTrang = tinhtrang;
                    tailieu.GhiChu = ghichu;
                    db.SaveChanges();
                    return Ok(tailieu);
                }
                return NotFound();
            }
            catch(Exception ex)
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

        private bool TaiLieuExists(int id)
        {
            return db.TaiLieux.Count(e => e.Id == id) > 0;
        }
    }
}