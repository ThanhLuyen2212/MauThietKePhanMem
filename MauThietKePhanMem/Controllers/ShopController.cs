using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MauThietKePhanMem.Models;
using PagedList;

namespace MauThietKePhanMem.Controllers
{
    public class ShopController : Controller
    {
        MauThietKePhanMemEntities data = new MauThietKePhanMemEntities();
        // GET: Shop

        public ActionResult Index(string idLoaiMH, string TenMatHang, int page = 1, int pagelist = 6)
        {

            // Thực hiện áp dụng singleton vào trong chương trình 

            DanhMucSingleton.Instance.Init();
            var listDanhMuc = DanhMucSingleton.Instance.listDanhMuc;
            ViewBag.Category = listDanhMuc;

            // kết thúc áp dụng sinhgleton vào chương trình


            //ViewBag.Category = data.LoaiMatHangs.ToList();
            if (idLoaiMH != null)
            {
                int a = int.Parse(idLoaiMH.ToString());
                /*ViewBag.MatHangTheoTheLoai = data.MatHangs.Where(c => c.IDLoaiMH == a).ToList();*/
                return View(data.MatHangs.Where(c => c.IDLoaiMH == a && c.SoLuong > 0).ToList().OrderByDescending(c => c.IDMH).ToPagedList(page, pagelist));
            }
            else
            if (TenMatHang != null)
            {
                return View(data.MatHangs.Where(c => c.TenMH.ToLower().Contains(TenMatHang.ToLower()) && c.SoLuong > 0).OrderByDescending(c => c.IDMH).ToPagedList(page, pagelist));
            }
            else
            {
                return View(data.MatHangs.Where(c => c.SoLuong > 0).OrderByDescending(x => x.IDLoaiMH).ToPagedList(page, pagelist));
            }
            return View(data.MatHangs.Where(c => c.SoLuong > 0).OrderByDescending(x => x.IDLoaiMH).ToPagedList(page, pagelist));

        }
    }





}