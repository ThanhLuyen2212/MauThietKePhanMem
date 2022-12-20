using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MauThietKePhanMem.Models;
using MauThietKePhanMem.Models.Proxy;

namespace MauThietKePhanMem.Areas.Admin.Controllers
{
    public class AdminLoaiMatHangsController : Controller
    {
        private MauThietKePhanMemEntities db = new MauThietKePhanMemEntities();

        // GET: Admin/AdminLoaiMatHangs
        public ActionResult Index()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Index", "AdminLogin");
            }
            /*return View(db.LoaiMatHangs.ToList());*/

            LoaiMatHang_Subject proxy = new LoaiMatHang_Proxy();
            List<LoaiMatHang> listLMH = proxy.index();
            return View(listLMH);


        }

        // GET: Admin/AdminLoaiMatHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            /*LoaiMatHang loaiMatHang = db.LoaiMatHangs.Find(id);
            if (loaiMatHang == null)
            {
                return HttpNotFound();
            }
            return View(loaiMatHang);*/
            int i = (int)id;
            LoaiMatHang_Subject proxy = new LoaiMatHang_Proxy();
            LoaiMatHang lmh = proxy.detail(i);
            return View(lmh);

        }

        // GET: Admin/AdminLoaiMatHangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminLoaiMatHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDLoaiMH,TenLoaiMH")] LoaiMatHang loaiMatHang)
        {
            if (ModelState.IsValid)
            {
                /*db.LoaiMatHangs.Add(loaiMatHang);
                db.SaveChanges();
                return RedirectToAction("Index");*/

                LoaiMatHang_Subject proxy = new LoaiMatHang_Proxy();
                proxy.AddLoaiMatHang(loaiMatHang);
                return RedirectToAction("Index"); 
            }

            return View(loaiMatHang);
        }

        // GET: Admin/AdminLoaiMatHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiMatHang loaiMatHang = db.LoaiMatHangs.Find(id);
            if (loaiMatHang == null)
            {
                return HttpNotFound();
            }
            return View(loaiMatHang);
        }

        // POST: Admin/AdminLoaiMatHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDLoaiMH,TenLoaiMH")] LoaiMatHang loaiMatHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiMatHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiMatHang);
        }

        // GET: Admin/AdminLoaiMatHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiMatHang loaiMatHang = db.LoaiMatHangs.Find(id);
            if (loaiMatHang == null)
            {
                return HttpNotFound();
            }
            return View(loaiMatHang);
        }

        // POST: Admin/AdminLoaiMatHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            /*LoaiMatHang loaiMatHang = db.LoaiMatHangs.Find(id);
            db.LoaiMatHangs.Remove(loaiMatHang);
            db.SaveChanges();
            return RedirectToAction("Index");*/

            LoaiMatHang_Subject proxy = new LoaiMatHang_Proxy();
            proxy.RemoveLoaiMatHang(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
