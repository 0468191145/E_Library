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
    public class LopHocsController : ApiController
    {
        private E_LibraryEntities db = new E_LibraryEntities();

        [ResponseType(typeof(LopHoc))]
        public IHttpActionResult GetLopHoc(int id=-1)
        {
            if (id >0)
            {
                LopHoc lopHoc = db.LopHocs.Find(id);
                if (lopHoc == null)
                {
                    return NotFound();
                }

                return Ok(lopHoc);
            }
            else
            {
                return Ok(db.LopHocs);
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
                    put.GVPhuTrach = lopHoc.GVPhuTrach;
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LopHocExists(int id)
        {
            return db.LopHocs.Count(e => e.Id == id) > 0;
        }
    }
}