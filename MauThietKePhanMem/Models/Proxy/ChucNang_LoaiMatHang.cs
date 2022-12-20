using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MauThietKePhanMem.Models;

namespace MauThietKePhanMem.Models.Proxy
{
    public class ChucNang_LoaiMatHang : LoaiMatHang_Subject
    {
        MauThietKePhanMemEntities db = new MauThietKePhanMemEntities(); 
        public override void AddLoaiMatHang(LoaiMatHang loaiMatHang)
        {
            db.LoaiMatHangs.Add(loaiMatHang);
            db.SaveChanges();
        }

        public override List<LoaiMatHang> index()
        {            
            return db.LoaiMatHangs.ToList();
        }

        public override LoaiMatHang detail(int id)
        {
            return db.LoaiMatHangs.Where(x => x.IDLoaiMH == id) as LoaiMatHang;            
        }

        public override void RemoveLoaiMatHang(int id)
        {
            LoaiMatHang loaiMatHang = db.LoaiMatHangs.Find(id);
            db.LoaiMatHangs.Remove(loaiMatHang);
            db.SaveChanges();
        }

    }
}