﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace E_Libary.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class E_LibraryEntities1 : DbContext
    {
        public E_LibraryEntities1()
            : base("name=E_LibraryEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BaiGiang> BaiGiangs { get; set; }
        public virtual DbSet<DeThi> DeThis { get; set; }
        public virtual DbSet<GiangDay> GiangDays { get; set; }
        public virtual DbSet<HeThongThuVien> HeThongThuViens { get; set; }
        public virtual DbSet<LopHoc> LopHocs { get; set; }
        public virtual DbSet<MonHoc> MonHocs { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<PhanCong> PhanCongs { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<TaiLieu> TaiLieux { get; set; }
        public virtual DbSet<TaiNguyen> TaiNguyens { get; set; }
        public virtual DbSet<TepRieng> TepRiengs { get; set; }
        public virtual DbSet<ThongBao> ThongBaos { get; set; }
        public virtual DbSet<TroGiup> TroGiups { get; set; }
    }
}
