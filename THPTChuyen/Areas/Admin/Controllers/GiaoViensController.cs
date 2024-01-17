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
using static System.Net.WebRequestMethods;

namespace THPTChuyen.Areas.Admin.Controllers
{
    public class GiaoViensController : Controller
    {
        private THPTChuyenVinhEntities db = new THPTChuyenVinhEntities();

        // GET: Admin/GiaoViens
        public IEnumerable<GiaoVien> ListAllGiaoVien(int page, int pageSize)
        {
            return db.GiaoViens.OrderBy(t => t.MaGiaoVien).ToPagedList(page, pageSize);
        }
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var giaoViens = ListAllGiaoVien(page, pageSize);
            return View(giaoViens);
        }

        // GET: Admin/GiaoViens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiaoVien giaoVien = db.GiaoViens.Find(id);
            if (giaoVien == null)
            {
                return HttpNotFound();
            }
            return View(giaoVien);
        }

        // GET: Admin/GiaoViens/Create
        public ActionResult Create()
        {
            ViewBag.MaChucVu = new SelectList(db.ChucVus, "MaChucVu", "TenChucVu");
            ViewBag.MaToChuc = new SelectList(db.ToChucs, "MaToChuc", "TenToChuc");
            return View();
        }

        // POST: Admin/GiaoViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaGiaoVien,TenGiaoVien,NgaySinh,QueQuan,DiaChi,SDT,Email,TotNghiep,ChuyenNganh,CongTacNam,MaChucVu,MaToChuc")] GiaoVien giaoVien, HttpPostedFileBase file1)
        {
            if (ModelState.IsValid)
            {
                if (file1 != null && file1.ContentLength > 0)
                {
                    string ten = Path.GetFileNameWithoutExtension(file1.FileName);
                    string duoi = Path.GetExtension(file1.FileName);
                    string daydu = ten + duoi;
                    string path = Path.Combine(Server.MapPath("~/UploadFile/Image"), daydu);
                    file1.SaveAs(path);

                    giaoVien.avatar = daydu;
                }
                db.GiaoViens.Add(giaoVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaChucVu = new SelectList(db.ChucVus, "MaChucVu", "TenChucVu", giaoVien.MaChucVu);
            ViewBag.MaToChuc = new SelectList(db.ToChucs, "MaToChuc", "TenToChuc", giaoVien.MaToChuc);
            return View(giaoVien);
        }

        // GET: Admin/GiaoViens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiaoVien giaoVien = db.GiaoViens.Find(id);
            if (giaoVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaChucVu = new SelectList(db.ChucVus, "MaChucVu", "TenChucVu", giaoVien.MaChucVu);
            ViewBag.MaToChuc = new SelectList(db.ToChucs, "MaToChuc", "TenToChuc", giaoVien.MaToChuc);
            return View(giaoVien);
        }

        // POST: Admin/GiaoViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaGiaoVien,TenGiaoVien,NgaySinh,QueQuan,DiaChi,SDT,Email,TotNghiep,ChuyenNganh,CongTacNam,MaChucVu,MaToChuc")] GiaoVien giaoVien, HttpPostedFileBase file1)
        {
            if (ModelState.IsValid)
            {
                if (file1 != null && file1.ContentLength > 0)
                {
                    string ten = Path.GetFileNameWithoutExtension(file1.FileName);
                    string duoi = Path.GetExtension(file1.FileName);
                    string daydu = ten + duoi;
                    string path = Path.Combine(Server.MapPath("~/UploadFile/Image"), daydu);
                    file1.SaveAs(path);

                    giaoVien.avatar = daydu;
                }
                db.Entry(giaoVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaChucVu = new SelectList(db.ChucVus, "MaChucVu", "TenChucVu", giaoVien.MaChucVu);
            ViewBag.MaToChuc = new SelectList(db.ToChucs, "MaToChuc", "TenToChuc", giaoVien.MaToChuc);
            return View(giaoVien);
        }

        // GET: Admin/GiaoViens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiaoVien giaoVien = db.GiaoViens.Find(id);
            if (giaoVien == null)
            {
                return HttpNotFound();
            }
            return View(giaoVien);
        }

        // POST: Admin/GiaoViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GiaoVien giaoVien = db.GiaoViens.Find(id);
            db.GiaoViens.Remove(giaoVien);
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
