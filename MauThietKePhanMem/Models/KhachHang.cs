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
    
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            this.DonDatHangs = new HashSet<DonDatHang>();
        }
    
        public int IDKH { get; set; }
        public string TenKH { get; set; }
        public string SDT { get; set; }
        public string DiaChiGiaoHang1 { get; set; }
        public string DiaChiGiaoHang2 { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<int> DiemTichLuy { get; set; }
        public Nullable<int> DiemTichLuyConLai { get; set; }
        public string LoaiKhachHang { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonDatHang> DonDatHangs { get; set; }
    }
}
