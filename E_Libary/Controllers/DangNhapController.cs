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
        private string _to = "0468191145@caothang.edu.vn";
        private string _mymail = "ptai22092001@gmail.com";
        private string _mypass = "9longgiang";


        // GET: api/DangNhap/5
        [ResponseType(typeof(TaiKhoan))]
        public IHttpActionResult GetTaiKhoan(string username ,string password)
        {
            var taikhoan = db.TaiKhoans.SingleOrDefault(n=> n.Username==username && n.PassWord==password);

            if (taikhoan == null)
            {
                return BadRequest("Nhập sai tài khoản hoặc mật khẩu");
            }

            return Ok("Đăng nhập thành công");
        }

        // PUT: api/DangNhap/5

        [Route("api/KhoiPhucMatKhau")]
        [HttpPost]
        public string GetKhoiPhucmatkhau()
        {
            if(MailUtils.SendMail(_from, _to,
                      "Gửi mail", "Nội dung Email", client))
            {
                return "Gửi mail thành công";
            }
            else
            {
                return "Gửi mail thất bại";
            }
        }
        
    }
}