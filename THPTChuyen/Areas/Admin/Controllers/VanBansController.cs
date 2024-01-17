using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using THPTChuyen.Models;
using PagedList.Mvc;

namespace THPTChuyen.Areas.Admin.Controllers
{
    public class VanBansController : Controller
    {
        private THPTChuyenVinhEntities db = new THPTChuyenVinhEntities();

        // GET: Admin/VanBans
        public IEnumerable<VanBan> ListAllVanban(int page, int pageSize)
        {
            return db.VanBans.OrderBy(t => t.MaVanBan).ToPagedList(page, pageSize);
        }
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var vanBans = ListAllVanban(page, pageSize);
            return View(vanBans);
        }

        // GET: Admin/VanBans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VanBan vanBan = db.VanBans.Find(id);
            if (vanBan == null)
            {
                return HttpNotFound();
            }
            return View(vanBan);
        }

        // GET: Admin/VanBans/Create
        public ActionResult Create()
        {
            ViewBag.MaLoaiVanBan = new SelectList(db.LoaiVanBans, "MaLoaiVanBan", "TenLoaiVanBan");
            return View();
        }

        // POST: Admin/VanBans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaVanBan,TieuDe,KiHieu,NgayBanHanh,NgayHieuLuc,MaLoaiVanBan,NguoiKy,DuongDan")] VanBan vanBan, HttpPostedFileBase file1)
        {
            if (ModelState.IsValid)
            {
                if (file1 != null && file1.ContentLength > 0)
                {
                    string ten = Path.GetFileNameWithoutExtension(file1.FileName);
                    string duoi = Path.GetExtension(file1.FileName);
                    string daydu = ten + duoi;
                    string path = Path.Combine(Server.MapPath("~/UploadFile/File/"), daydu);
                    file1.SaveAs(path);

                    vanBan.DuongDan = daydu;
                }
                db.VanBans.Add(vanBan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoaiVanBan = new SelectList(db.LoaiVanBans, "MaLoaiVanBan", "TenLoaiVanBan", vanBan.MaLoaiVanBan);
            return View(vanBan);
        }

        // GET: Admin/VanBans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VanBan vanBan = db.VanBans.Find(id);
            if (vanBan == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoaiVanBan = new SelectList(db.LoaiVanBans, "MaLoaiVanBan", "TenLoaiVanBan", vanBan.MaLoaiVanBan);
            return View(vanBan);
        }

        // POST: Admin/VanBans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaVanBan,TieuDe,KiHieu,NgayBanHanh,NgayHieuLuc,MaLoaiVanBan,NguoiKy,DuongDan")] VanBan vanBan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vanBan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoaiVanBan = new SelectList(db.LoaiVanBans, "MaLoaiVanBan", "TenLoaiVanBan", vanBan.MaLoaiVanBan);
            return View(vanBan);
        }

        // GET: Admin/VanBans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VanBan vanBan = db.VanBans.Find(id);
            if (vanBan == null)
            {
                return HttpNotFound();
            }
            return View(vanBan);
        }

        // POST: Admin/VanBans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VanBan vanBan = db.VanBans.Find(id);
            db.VanBans.Remove(vanBan);
            db.SaveChanges();
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
