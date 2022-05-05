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
    public class MonHocsController : ApiController
    {
        private E_LibraryEntities1 db = new E_LibraryEntities1();

        // GET: api/MonHocs/5                   Hiện danh sách môn và số tài liệu môn chờ phê duyệt 
        [ResponseType(typeof(MonHoc))]
        public IHttpActionResult GetMonHoc(int id=-1, string tenmon=null)
        {
            if (id  <=0)
            {
                var monhoc = (from m in db.MonHocs
                              select new
                              {
                                  m.MaMon,
                                  m.TenMonHoc,
                                  m.MoTa,
                                  m.TinhTrang,
                                  SoTaiLieuChoDuyet = (from t in db.TaiLieux
                                                       join bt in db.BaiGiangs_TaiNguyens on t.Ma equals bt.Id
                                                       where bt.MaMon == m.MaMon && t.TinhTrang == "Chờ phê duyệt"
                                                       select new
                                                       {
                                                       }
                                                       ).Count()
                              }
                              );


                return Ok(monhoc);
            }
            else
                {
                return ChiTietMonHoc(id);
            }
        }
        public IHttpActionResult ChiTietMonHoc (int id )            //chi tiết môn học

        {
            var monhoc = (from m in db.MonHocs
                          join g in db.GiangDays on m.MaMon equals g.MaMon
                          join a in db.NguoiDungs on g.MaGV equals a.MaNguoiDung
                          where m.Id == id
                          select new
                          {
                              m.MaMon,
                              m.TenMonHoc,
                              m.MoTa,
                              GiangVien=a.TenNguoiDung
                          }
                              );
            return Ok(monhoc);        }

            // PUT: api/MonHocs/5               Cập nhật môn học
            [ResponseType(typeof(void))]
        public IHttpActionResult PutMonHoc(int id, MonHoc monhoc)
        {
            try
            {
                var put = db.MonHocs.SingleOrDefault(n => n.Id == id);
                if (put != null)
                {
                    put.TenMonHoc = monhoc.TenMonHoc;
                    put.MoTa = monhoc.MoTa;
                    put.NienKhoa = monhoc.NienKhoa;
                    put.ToBoMon = monhoc.ToBoMon;
                  

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

        // POST: api/MonHocs                    Thêm môn học
        [ResponseType(typeof(MonHoc))]
        public IHttpActionResult PostMonHoc(MonHoc monhoc)
        {
            try
            {
                if (monhoc != null)
                {
                    db.MonHocs.Add(monhoc);
                    db.SaveChanges();
                    return Ok(monhoc);
                }
                return BadRequest("Chưa nhập dữ liệu");
            }
            catch
            {
                return BadRequest("Lỗi");
            }
        }

        // POST: api/MonHocs/PhanCong           Phân công tài liệu

        [Route("api/MonHocs/PhanCong")]
        [HttpPost]
        public IHttpActionResult PhanCongTaiLieu(PhanCong tailieu)
        {
            try
            {
                if (tailieu != null)
                {
                    db.PhanCongs.Add(tailieu);
                    db.SaveChanges();
                    return Ok(tailieu);
                }
                return BadRequest("Chưa nhập dữ liệu");
            }
            catch
            {
                return BadRequest("Lỗi");
            }
        }

        // DELETE: api/MonHocs/5
        [ResponseType(typeof(MonHoc))]
        public IHttpActionResult DeleteMonHoc(int id)
        {
            try
            {
                var delete = db.MonHocs.SingleOrDefault(n => n.Id == id);
                if (delete != null)
                {
                    db.MonHocs.Remove(delete);
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

        private bool MonHocExists(int id)
        {
            return db.MonHocs.Count(e => e.Id == id) > 0;
        }
    }
}