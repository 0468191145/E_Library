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
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using E_Libary.Session;

namespace E_Libary.Controllers
{
    public class DangNhapController : ApiController
    {
        private E_LibraryEntities1 db = new E_LibraryEntities1();
        private SmtpClient client = new SmtpClient("smtp.gmail.com");
        private string _from = "ptai22092001@gmail.com";
        private string _to = "ptai22092001@gmail.com"; 
        private string _subject = "Mã xác thực ";
        private string _body = "Mã xác thực của bạn là ";



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
        [Route("api/NhapXacNhan")]
        [HttpPost]
        public IHttpActionResult PostXacNhan(string code)
        {
            string ss = UserLogin.code;
            if(string.IsNullOrEmpty(ss))
            {
                return BadRequest("Lỗi");
            }
            if (ss == code)
            {
                return Ok("Xác thực thành công quay lại trang đặt lại mật khẩu /api/DatMatKhau");
            }
            else 
                return BadRequest("Mã xác thực không đúng");
        }
        [Route("api/DatMatKhau")]
        [HttpPut]
        public IHttpActionResult PutMatKhau(string username,string pass)
        {
            var ss = db.TaiKhoans.SingleOrDefault(n=>n.Username==username) ;
            if (ss==null)
            {
                return BadRequest("Lỗi không tìm thấy tài khoản");
            }
            ss.PassWord = pass;
            db.SaveChanges();
            
            return Ok(string.Format("Cập nhật thành công \n {0}",ss));
        }



        [Route("api/KhoiPhucMatKhau")]
        [HttpPost]
        public async Task<string> GetKhoiPhucmatkhau(string username)
        {
            var taikhoan = db.TaiKhoans.SingleOrDefault(n => n.Username == username);
            if (taikhoan != null)
            {
                Random rd = new Random();
                string code = "";
                for (int i = 0; i < 6; i++)
                {
                    code += rd.Next(9);
                }
                _body += code;
                UserLogin.code=code;
                UserLogin.username = username;
            }
            else
                return "Không tìm thấy tài khoản";

            try
            {
                var message = await MailUtils.SendMail(_from, _to, _subject, _body);
                return message+" /api/NhapXacNhan"   ;
            }
            catch (Exception ex)
            {
                return ex.Message ;
            }
        }
     } 
}