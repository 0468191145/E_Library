using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using E_Libary.Models;
using Castle.Core.Smtp;
using System.Threading.Tasks;
using E_Libary.Mail;

namespace E_Libary.Controllers
{
    public class DangNhapController : ApiController
    {
        private E_LibraryEntities1 db = new E_LibraryEntities1();
        private SmtpClient client = new SmtpClient("smtp.gmail.com");
        private string _from = "ptai22092001@gmail.com";
        private string _to = "ptai22092001@gmail.com"; 
        private string _subject = "Mã xác thực ";
        private string _body = "22092001";



        // GET: api/DangNhap/5
        [ResponseType(typeof(TaiKhoan))]
        public IHttpActionResult GetTaiKhoan(string username ,string password)
        {
            var taikhoan = db.TaiKhoans.SingleOrDefault(n=> n.Username==username && n.PassWord==password);

            if (taikhoan == null)
            {
                return BadRequest("Nhập sai tài khoản hoặc mật khẩu");
            }

            var thongtin = from c in db.TaiKhoans
                            join s in db.NguoiDungs on c.MaNguoiDung equals s.MaNguoiDung
                            join v in db.Roles on s.VaiTro equals v.Id
                            where c.Username == taikhoan.Username && taikhoan.PassWord == password
                            select new
                            {
                                TenNguoiDung = s.TenNguoiDung,
                                TenVaiTro=v.TenVaiTro
                            };

            return Ok(thongtin);
        }

        // PUT: api/DangNhap/5

        [Route("api/KhoiPhucMatKhau")]
        [HttpPost]
        public async Task<string> GetKhoiPhucmatkhau()
        {
            try
            {
                var message = await MailUtils.SendMail(_from, _to, _subject, _body);
                return message   ;
            }
            catch (Exception ex)
            {
                return ex.Message ;
            }
        }
        
    }
}