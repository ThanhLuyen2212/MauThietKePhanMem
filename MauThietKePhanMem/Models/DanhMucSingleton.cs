using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MauThietKePhanMem.Models;

namespace MauThietKePhanMem.Models
{
    public sealed class DanhMucSingleton
    {
        public static DanhMucSingleton Instance { get; } = new DanhMucSingleton();
        public List<LoaiMatHang> listDanhMuc { get; } = new List<LoaiMatHang>();
        private DanhMucSingleton() { }
        public void Init()
        {
            MauThietKePhanMemEntities data = new MauThietKePhanMemEntities();
            var danhmuc = (from s in data.LoaiMatHangs select s).ToList();
            foreach(var item in danhmuc)
            {
                listDanhMuc.Add(item);
            }
        }
        public void Update()
        {            
            listDanhMuc.Clear();
            Init();
        }
    }
    
}