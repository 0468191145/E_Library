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

        [Route("api/TaiNguyens")]
        [HttpGet]
        public IHttpActionResult GetTaiNguyen(string mon = null, string ten = null)
        {
            if (mon == null && ten == null)
            {
                var get = (from c in db.BaiGiangs_TaiNguyens
                           where c.PhanLoai==false
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

            var get = (from c in db.BaiGiangs_TaiNguyens
                       where c.Ten.Contains(tukhoa) && c.PhanLoai==false
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

            var get = (from c in db.BaiGiangs_TaiNguyens
                       where  c.MaMon == tukhoa && c.PhanLoai == false
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

        [Route("api/TaiNguyens")]
        [HttpPut]
        public IHttpActionResult PutTaiNguyen(int id, string ten)
        {
            try
            {
                var put = db.BaiGiangs_TaiNguyens.SingleOrDefault(n => n.Id == id &&n.PhanLoai==false );
                if (put != null)
                {
                    if (ten != null)
                    {
                        put.Ten = ten;
                    }

                    db.SaveChanges();
                    return Ok(put);
                }
                return BadRequest("Không tìm thấy tài nguyên");
            }
            catch (Exception ex)
            {
                return BadRequest(ModelState);
            }
        }

        [Route("api/TaiNguyens")]
        [HttpPost]
        public IHttpActionResult PostTaiNguyen(BaiGiangs_TaiNguyens TaiNguyen)
        {
            try
            {
                if (TaiNguyen != null)
                {
                    TaiNguyen.PhanLoai = false;
                    TaiNguyen.NgayChinhSuaCuoi = DateTime.Now;
                    db.BaiGiangs_TaiNguyens.Add(TaiNguyen);
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

        [Route("api/TaiNguyens/MonHoc")]
        [HttpPut]
        public IHttpActionResult PutTaiNguyenMonHoc(int id, string mon)
        {
            try
            {
                BaiGiangs_TaiNguyens tainguyen = db.BaiGiangs_TaiNguyens.SingleOrDefault(n => n.Id == id &&n.PhanLoai==false);
                if (tainguyen != null)
                {
                    tainguyen.MaMon = mon;
                    db.SaveChanges();
                    return Ok(tainguyen);
                }
                return BadRequest("Chưa Chọn môn");
            }
            catch (Exception ex)
            {
                return BadRequest("Lỗi");
            }
        }

        [Route("api/TaiNguyens")]
        [HttpDelete]
        public IHttpActionResult DeleteTaiNguyen(int id)
        {
            try
            {
                var delete = db.BaiGiangs_TaiNguyens.SingleOrDefault(n => n.Id == id && n.PhanLoai == false);
                if (delete != null)
                {
                    db.BaiGiangs_TaiNguyens.Remove(delete);
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


        [Route("api/BaiGiangs")]
        [HttpGet]
        public IHttpActionResult GetBaiGiang(string mon = null, string ten = null)
        {
            if (mon == null && ten == null)
            {
                var get = (from c in db.BaiGiangs_TaiNguyens
                           where c.PhanLoai == true
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

            var get = (from c in db.BaiGiangs_TaiNguyens
                       where c.Ten.Contains(tukhoa) && c.PhanLoai == true
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

            var get = (from c in db.BaiGiangs_TaiNguyens
                       where c.MaMon == tukhoa && c.PhanLoai == true
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

        [Route("api/BaiGiangs")]
        [HttpPut]
        public IHttpActionResult PutBaiGiang(int id, string ten)
        {
            try
            {
                var put = db.BaiGiangs_TaiNguyens.SingleOrDefault(n => n.Id == id && n.PhanLoai == true);
                if (put != null)
                {
                    if (ten != null)
                    {
                        put.Ten = ten;
                    }

                    db.SaveChanges();
                    return Ok(put);
                }
                return BadRequest("Không tìm thấy tài nguyên");
            }
            catch (Exception ex)
            {
                return BadRequest(ModelState);
            }
        }
        [Route("api/BaiGiangs")]
        [HttpPost]
        public IHttpActionResult PostBaiGiang(BaiGiangs_TaiNguyens TaiNguyen)
        {
            try
            {
                if (TaiNguyen != null)
                {
                    TaiNguyen.PhanLoai = true;
                    TaiNguyen.NgayChinhSuaCuoi = DateTime.Now;
                    db.BaiGiangs_TaiNguyens.Add(TaiNguyen);
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
        [Route("api/BaiGiangs/MonHoc")]
        [HttpPut]
        public IHttpActionResult PutBaiGiangMonHoc(int id, string mon)
        {
            try
            {
                BaiGiangs_TaiNguyens tainguyen = db.BaiGiangs_TaiNguyens.SingleOrDefault(n => n.Id == id && n.PhanLoai == true);
                if (tainguyen != null)
                {
                    tainguyen.MaMon = mon;
                    db.SaveChanges();
                    return Ok(tainguyen);
                }
                return BadRequest("Chưa Chọn môn");
            }
            catch (Exception ex)
            {
                return BadRequest("Lỗi");
            }
        }

        [Route("api/BaiGiangs")]
        [HttpDelete]
        public IHttpActionResult DeleteBaiGiang(int id)
        {
            try
            {
                var delete = db.BaiGiangs_TaiNguyens.SingleOrDefault(n => n.Id == id && n.PhanLoai == true);
                if (delete != null)
                {
                    db.BaiGiangs_TaiNguyens.Remove(delete);
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

        [Route("api/PheDuyet")]
        [HttpPost]
        public IHttpActionResult GuiPheDuyet(int id)
        {
            try
            {
                var duyet = db.BaiGiangs_TaiNguyens.Where(n => n.Id == id);
                if (duyet != null)
                {
                    TaiLieu taiLieu = new TaiLieu
                    {
                        Ma = id,
                        NgayGui = DateTime.Now,
                        TinhTrang = "Chờ phê duyệt"
                    };
                    db.TaiLieux.Add(taiLieu);
                    db.SaveChanges();
                    return Ok(taiLieu);
                }
                return BadRequest("Không tìm thấy bài giảng");
            }
            catch (Exception ex)
            {
                return BadRequest("Lỗi");
            }
        }
    }

}