//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MauThietKePhanMem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChiTietDonDatHang
    {
        public int IDChiTietDDH { get; set; }
        public Nullable<int> IDDDH { get; set; }
        public Nullable<int> IDMH { get; set; }
        public Nullable<double> DonGia { get; set; }
        public Nullable<int> DanhGiaSanPham { get; set; }
        public string BinhLuan { get; set; }
        public Nullable<int> SoluongMH { get; set; }
    
        public virtual DonDatHang DonDatHang { get; set; }
        public virtual MatHang MatHang { get; set; }
    }
}
