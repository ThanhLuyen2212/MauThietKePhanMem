using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MauThietKePhanMem.Models;

namespace MauThietKePhanMem.Controllers
{
    public class GioHangKhachLeIIteratorController : Controller
    {
        MauThietKePhanMemEntities data = new MauThietKePhanMemEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // GET: GioHangKhachLe
        public GioHang GetHang()
        {
            GioHang gio = Session["GioHang"] as GioHang;
            if ((gio == null) || Session["GioHang"] == null)
            {
                gio = new GioHang();
                Session["GioHang"] = gio;
            }
            return gio;
        }


        public ActionResult Addto(string id)
        {
            var gio = data.MatHangs.SingleOrDefault(s => s.IDMH.ToString() == id);
            if (gio != null)
            {
                GetHang().Add(gio);

                // Số lượng hàng trong giở là bao nhiêu
                GioHang gioHang = Session["GioHang"] as GioHang;
                Session["SoLuongHangTrongGioHang"] = gioHang.sum().ToString();
            }
            return RedirectToAction("Show", "GioHangKhachLeIIterator");
        }

        public ActionResult Show()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Shop");
            }

            /*KhachHang kh = (KhachHang)Session["KhachHang"];*/

            GioHang gio = Session["GioHang"] as GioHang;

            return View(gio);
        }

        public ActionResult Update_quantity(FormCollection form)
        {
            GioHang gio = Session["GioHang"] as GioHang;
            string id_MatHang = form["ID MatHang"];
            int quatity = int.Parse(form["quantity"]);

            gio.Update_quantity(id_MatHang, quatity);

            Session["SoLuongHangTrongGioHang"] = gio.sum().ToString();

            return RedirectToAction("Show", "GioHangKhachLeIIterator");

        }

        public ActionResult Remove(int id)
        {
            GioHang gio = Session["GioHang"] as GioHang;
            gio.Remove(id);

            Session["SoLuongHangTrongGioHang"] = gio.sum().ToString();
            return RedirectToAction("Show", "GioHangKhachLeIIterator");
        }


        public PartialViewResult BagMathang()
        {
            int total = 0;
            GioHang gio = Session["GioHang"] as GioHang;
            if (gio != null)
            {
                total = gio.Total();
            }

            ViewBag.InforGio = total;
            return PartialView("BagMatHang");
        }

        public ActionResult Mua_Success()
        {
            return RedirectToAction("Index", "PhongThuThanhToan");
        }

        [HttpPost]
        public ActionResult MuaHang(FormCollection form)
        { 
            try
            {
                // Lấy tưng sản phẩm
                GioHang gio = Session["GioHang"] as GioHang;

                //List<Hang> gio = Session["GioHang"] as List<Hang>;

                double _tongHang = 0;

                GioHangIIterator giohang = new GioHangIIterator(gio.ListHang.ToList());
                _tongHang =  giohang.sum();


                foreach (var item in gio.ListHang)
                {
                    if (item._soLuongHang <= 0)
                    {
                        gio.Remove(item.gioHang.IDMH);
                    }
                    //_tongHang += item._soLuongHang;

                    if (_tongHang == 0)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    MatHang mh = data.MatHangs.Find(item.gioHang.IDMH);
                    if (item._soLuongHang > mh.SoLuong)
                    {
                        gio.Remove(item.gioHang.IDMH);
                        return Content("Số lượng mặt hàng " + mh.TenMH + " không đủ!");
                    }

                }
                Session["GioHang"] = gio;

                return RedirectToAction("XacNhan", "XacNhanDonHangKhachLe");
            }
            catch
            {
                return Content("Vui lòng kiểm tra lại thông tin!");
            }

        }
    }
}