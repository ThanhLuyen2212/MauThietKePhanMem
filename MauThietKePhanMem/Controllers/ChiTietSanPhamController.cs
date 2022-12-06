using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MauThietKePhanMem.Models;
namespace MauThietKePhanMem.Controllers
{
    public class ChiTietSanPhamController : Controller
    {
        MauThietKePhanMemEntities data = new MauThietKePhanMemEntities();
        // GET: ChiTietSanPham
        public ActionResult Index(int id)
        {

            ViewBag.BinhLuan = data.ChiTietDonDatHangs.Where(c => c.IDMH == id).ToList();
            return View(data.MatHangs.FirstOrDefault(c => c.IDMH == id));

        }
    }
}