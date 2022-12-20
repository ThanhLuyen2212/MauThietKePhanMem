using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MauThietKePhanMem.Models.Prototype
{
    public class NhanVienBanHang : NhanVien_Prototype_basic
    {

        public NhanVienBanHang (string ten,string diachi, string sdt, string email)
        {
            TenNhanVien = ten;
            ChucVu = "Nhân viên bán hàng";
            DiaChi = diachi;
            SDT = sdt;
            Email = email;
        }
        

        public override NhanVien_Prototype_basic Clone(NhanVien nv)
        {
            MauThietKePhanMemEntities db = new MauThietKePhanMemEntities();
            db.NhanViens.Add(nv);
            db.SaveChanges();
            return this.MemberwiseClone() as NhanVienBanHang;
        }
    }
}