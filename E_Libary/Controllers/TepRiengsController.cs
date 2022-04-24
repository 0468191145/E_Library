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
    public class TepRiengsController : ApiController
    {
        private E_LibraryEntities1 db = new E_LibraryEntities1();

        // GET: api/TepRiengs/
        [ResponseType(typeof(TepRieng))]
        public IHttpActionResult GetTepRieng(string loaitep=null,string tentep=null)
        {
            if (loaitep==null&&tentep==null)
            {
                return Ok(db.TepRiengs);
            }
            else if(loaitep!=null)
            {
                return LocTepRieng(loaitep);
            }
            else
            {
                return TimKiemTepRieng(tentep);
            }
        }

        public IHttpActionResult TimKiemTepRieng(string tukhoa)
        {

            var get = (from c in db.TepRiengs
                       where c.TenTep.Contains(tukhoa)
                       select new
                       {
                          c
                       });

            return Ok(get);
        }

        public IHttpActionResult LocTepRieng(string tukhoa)
        {

            var get = (from c in db.TepRiengs
                       where c.TheLoai.Contains(tukhoa)
                       select new
                       {
                           c
                       });

            return Ok(get);

        }

        // PUT: api/TepRiengs/5
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult PutTepRieng(int id, string teprieng)
        {
            try
            {
                var put = db.TepRiengs.SingleOrDefault(n => n.Id == id);
                if (put != null)
                {
                    put.TenTep = teprieng;

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

        // POST= api/TepRiengs
        [ResponseType(typeof(TepRieng))]
        public IHttpActionResult PostTepRieng(TepRieng teprieng)
        {
            try
            {
                if (teprieng != null)
                {
                    db.TepRiengs.Add(teprieng);
                    db.SaveChanges();
                    return Ok(teprieng);
                }
                return BadRequest("Chưa nhập dữ liệu");
            }
            catch
            {
                return BadRequest("Lỗi");
            }
        }

        // DELETE: api/TepRiengs/5
        [ResponseType(typeof(TepRieng))]
        public IHttpActionResult DeleteTepRieng(int id)
        {
            try
            {
                var delete = db.TepRiengs.SingleOrDefault(n => n.Id == id);
                if (delete != null)
                {
                    db.TepRiengs.Remove(delete);
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

        private bool TepRiengExists(int id)
        {
            return db.TepRiengs.Count(e => e.Id == id) > 0;
        }
    }
}