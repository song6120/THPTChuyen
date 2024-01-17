using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using THPTChuyen.Models;
using PagedList.Mvc;
using PagedList;

namespace THPTChuyen.Areas.Admin.Controllers
{
    public class TinTucsController : Controller
    {
        private THPTChuyenVinhEntities db = new THPTChuyenVinhEntities();

        // GET: Admin/TinTucs
        public IEnumerable<TinTuc> ListAllTinTuc(int page, int pageSize)
        {
            return db.TinTucs.OrderBy(t=>t.MaTinTuc).ToPagedList(page, pageSize);
        }
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var tinTucs = ListAllTinTuc(page, pageSize);
            return View(tinTucs);
        }

        // GET: Admin/TinTucs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinTuc tinTuc = db.TinTucs.Find(id);
            if (tinTuc == null)
            {
                return HttpNotFound();
            }
            return View(tinTuc);
        }

        // GET: Admin/TinTucs/Create
        public ActionResult Create()
        {
            ViewBag.MaLoaiTin = new SelectList(db.LoaiTins, "MaLoaiTin", "TenLoai");
            return View();
        }

        // POST: Admin/TinTucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTinTuc,TieuDe,HinhAnh,NoiDung,MaLoaiTin")] TinTuc tinTuc, HttpPostedFileBase file1)
        {
            if (ModelState.IsValid)
            {
                if(file1 != null && file1.ContentLength>0)
                {
                    string ten = Path.GetFileNameWithoutExtension(file1.FileName);
                    string duoi = Path.GetExtension(file1.FileName);
                    string daydu = ten + DateTime.Now.ToString("HHmmss") + duoi;
                    string path = Path.Combine(Server.MapPath("~/images"), daydu);
                    file1.SaveAs(path);
                    
                    tinTuc.HinhAnh = daydu;
                }
                db.TinTucs.Add(tinTuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoaiTin = new SelectList(db.LoaiTins, "MaLoaiTin", "TenLoai", tinTuc.MaLoaiTin);
            return View(tinTuc);
        }

        // GET: Admin/TinTucs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinTuc tinTuc = db.TinTucs.Find(id);
            if (tinTuc == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoaiTin = new SelectList(db.LoaiTins, "MaLoaiTin", "TenLoai", tinTuc.MaLoaiTin);
            return View(tinTuc);
        }

        // POST: Admin/TinTucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TinTuc tinTuc)
        {
            var tintuc = db.TinTucs.Find(tinTuc.MaTinTuc);
            if (String.IsNullOrEmpty(tinTuc.TieuDe))
            {               
 
                return View(tinTuc);
            }
            tintuc.NoiDung = tinTuc.NoiDung;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Admin/TinTucs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinTuc tinTuc = db.TinTucs.Find(id);
            if (tinTuc == null)
            {
                return HttpNotFound();
            }
            return View(tinTuc);
        }

        // POST: Admin/TinTucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TinTuc tinTuc = db.TinTucs.Find(id);
            db.TinTucs.Remove(tinTuc);
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
