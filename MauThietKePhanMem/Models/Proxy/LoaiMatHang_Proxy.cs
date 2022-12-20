using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MauThietKePhanMem.Models.Proxy
{
    public class LoaiMatHang_Proxy : LoaiMatHang_Subject
    {
        LoaiMatHang_Subject subject;
        public override void AddLoaiMatHang(LoaiMatHang loaiMatHang)
        {            
            if(subject == null)
            {
                subject = new ChucNang_LoaiMatHang();
            }
            subject.AddLoaiMatHang(loaiMatHang);
        }

        public override LoaiMatHang detail(int id)
        {
            if (subject == null)
            {
                subject = new ChucNang_LoaiMatHang();
            }
            return subject.detail(id);
        }

        public override List<LoaiMatHang> index()
        {
            if (subject == null)
            {
                subject = new ChucNang_LoaiMatHang();
            }
            
            return subject.index();
        }

        public override void RemoveLoaiMatHang(int id)
        {
            if (subject == null)
            {
                subject = new ChucNang_LoaiMatHang();
            }
            subject.RemoveLoaiMatHang(id);
        }
    }
}