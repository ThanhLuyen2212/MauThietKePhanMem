using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MauThietKePhanMem.Models.Proxy
{
    public abstract class LoaiMatHang_Subject
    {
        public abstract void AddLoaiMatHang(LoaiMatHang loaiMatHang);
        public abstract List<LoaiMatHang> index();
        public abstract LoaiMatHang detail(int id);
        public abstract void RemoveLoaiMatHang(int id);
    }
}