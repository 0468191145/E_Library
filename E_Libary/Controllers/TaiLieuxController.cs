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
        public IHttpActionResult GetTaiLieux(string mon = null, string gv = null,string tinhtrang=null,string ten=null)
        {
            if (mon == null && gv == null&& tinhtrang==null&& ten==null)
            {
                var get = (from c in db.TaiLieux
                           join b in db.BaiGiangs_TaiNguyens on c.Ma equals b.Id
                           join a in db.NguoiDungs on b.NguoiChinhSua equals a.MaNguoiDung 
                           select new
                           {
                               c.Id,
                               b.LoaiFile,
                               b.Ten,
                               PhanLoai= b.PhanLoai==true?"bài giảng":"tài nguyên",
                               b.TenMon,
                               NguoiGui= a.TenNguoiDung,
                               c.NguoiPheDuyet,
                               c.NgayGui,
                               c.TinhTrang,
                               b.KichThuoc
                           });
                return Ok(get);
            }
            else if (ten == null)
            {
                return LocTaiLieu(mon,gv,tinhtrang);
            }
            else
            {
                return TimKiemTaiLieu(ten);
            }
        }

        public IHttpActionResult TimKiemTaiLieu(string tukhoa)
        {

            var get = (from c in db.TaiLieux
                       join b in db.BaiGiangs_TaiNguyens on c.Ma equals b.Id
                       join a in db.NguoiDungs on b.NguoiChinhSua equals a.MaNguoiDung
                       where  b.Ten.Contains(tukhoa)
                       select new
                       {
                           b.Id,
                           b.LoaiFile,
                           b.Ten,
                           PhanLoai = b.PhanLoai == true ? "bài giảng" : "tài nguyên",
                           b.TenMon,
                           NguoiGui = a.TenNguoiDung,
                           c.NguoiPheDuyet,
                           c.NgayGui,
                           c.TinhTrang,
                           b.KichThuoc
                       }).OrderBy(x => x.Ten);

            return Ok(get);
        }

        public IHttpActionResult LocTaiLieu(string mon , string gv , string tinhtrang )
        {

            var get = (from c in db.TaiLieux
                       join b in db.BaiGiangs_TaiNguyens on c.Ma equals b.Id
                       join a in db.NguoiDungs on b.NguoiChinhSua equals a.MaNguoiDung
                       where b.MaMon == mon || b.NguoiChinhSua== gv|| c.TinhTrang== tinhtrang
                       select new
                       {
                           b.Id,
                           b.LoaiFile,
                           b.Ten,
                           PhanLoai = b.PhanLoai == true ? "bài giảng" : "tài nguyên",
                           b.TenMon,
                           NguoiGui = a.TenNguoiDung,
                           c.NguoiPheDuyet,
                           c.NgayGui,
                           c.TinhTrang,
                           b.KichThuoc
                       }).OrderBy(x => x.Ten);

            return Ok(get);

        }

       
        [Route("api/TaiLieux")]
        [HttpPut]
        public IHttpActionResult PheDuyet(int id, string nguoipheduyet, string tinhtrang, string ghichu = null)
        {
            TaiLieu tailieu = db.TaiLieux.SingleOrDefault(n => n.Id == id);
            try
            {
                if (tailieu != null)
                {
                    tailieu.NguoiPheDuyet = nguoipheduyet;
                    tailieu.TinhTrang = tinhtrang;
                    tailieu.GhiChu = ghichu;
                    db.SaveChanges();
                    return Ok(tinhtrang);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest("Lỗi");
            }

        }


        private bool TaiLieuExists(int id)
        {
            return db.TaiLieux.Count(e => e.Id == id) > 0;
        }
    }
}