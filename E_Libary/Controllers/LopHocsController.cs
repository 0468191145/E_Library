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
using Microsoft.AspNetCore.Mvc;

namespace E_Libary.Controllers
{
    public class LopHocsController : ApiController
    {
        private E_LibraryEntities1 db = new E_LibraryEntities1();

        [ResponseType(typeof(LopHoc))]              //Hiện danh sách lớp học
        public IHttpActionResult GetLopHoc(string mon=null, string tenlop=null)
        {
            if (mon==null&&tenlop==null)
            {
                var get = (from l in db.LopHocs
                           select new
                           {
                               l.MaLop,
                               l.Lop
                           }).OrderBy(x => x.Lop);
                return Ok(get);
            }
            else if(mon!=null)
            {
                var get = (from gd in db.GiangDays
                           join m in db.MonHocs on gd.MaMon equals m.MaMon
                           join l in db.LopHocs on gd.MaLop equals l.MaLop
                           join gv in db.NguoiDungs on gd.MaGV equals gv.MaNguoiDung
                           where gd.MaMon == mon
                           select new
                           {
                               m.TenMonHoc,
                               l.Lop,
                               TenGV =gv.TenNguoiDung
                           }).OrderBy(x => x.TenMonHoc);
                return Ok(get);
            }
            else
            {
                var get = (from gd in db.GiangDays
                           join m in db.MonHocs on gd.MaMon equals m.MaMon
                           join l in db.LopHocs on gd.MaLop equals l.MaLop
                           join gv in db.NguoiDungs on gd.MaGV equals gv.MaNguoiDung
                           where l.Lop.Contains(tenlop)
                           select new
                           {
                               m.TenMonHoc,
                               l.Lop,
                               TenGV =gv.MaNguoiDung
                           }).OrderBy(x => x.TenMonHoc);
                return Ok(get);
            }
            
        }

        // PUT: api/LopHocs/5
        public IHttpActionResult PutLopHoc(int id, LopHoc lopHoc)
        {
            try {
                var put = db.LopHocs.SingleOrDefault(n => n.Id == id);
                if(put!=null)
                {
                    put.Lop = lopHoc.Lop;
                    db.SaveChanges();
                    return Ok(put);
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex) {
                return BadRequest(ModelState);
            }
        }

        // POST: api/LopHocs
        [ResponseType(typeof(LopHoc))]
        public IHttpActionResult PostLopHoc(LopHoc lopHoc)
        {
            try
            {
                if(lopHoc!=null)
                {
                    db.LopHocs.Add(lopHoc);
                    db.SaveChanges();
                    return Ok(lopHoc);
                }
                return BadRequest("Chưa nhập dữ liệu");
            }
            catch
            {
                return BadRequest("Lỗi");
            }
        }

        // DELETE: api/LopHocs/5
        [ResponseType(typeof(LopHoc))]
        public IHttpActionResult DeleteLopHoc(int id)
        {
            try
            {
                var delete = db.LopHocs.SingleOrDefault(n => n.Id == id);
                if (delete != null)
                {
                    db.LopHocs.Remove(delete);
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

        private bool LopHocExists(int id)
        {
            return db.LopHocs.Count(e => e.Id == id) > 0;
        }
    }
}