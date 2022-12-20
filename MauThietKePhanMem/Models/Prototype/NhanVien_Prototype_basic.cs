using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MauThietKePhanMem.Models.Prototype
{
    public abstract class NhanVien_Prototype_basic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien_Prototype_basic()
        {
            this.DonDatHangs = new HashSet<DonDatHang>();
        }

        public int IDNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string ChucVu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonDatHang> DonDatHangs { get; set; }


        public abstract NhanVien_Prototype_basic Clone(NhanVien nv);


    }
}