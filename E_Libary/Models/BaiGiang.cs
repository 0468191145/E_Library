//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class BaiGiang
    {
        public int Id { get; set; }
        public string LoaiFile { get; set; }
        public string Ten { get; set; }
        public string MonHoc { get; set; }
        public string Lop { get; set; }
        public string ChuDe { get; set; }
        public string NguoiChinhSua { get; set; }
        public Nullable<System.DateTime> NgayChinhSuaCuoi { get; set; }
        public Nullable<double> KichThuoc { get; set; }
    }
}
