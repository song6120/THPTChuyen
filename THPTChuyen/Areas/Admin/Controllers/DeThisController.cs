using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using THPTChuyen.Models;

namespace THPTChuyen.Areas.Admin.Controllers
{
    public class DeThisController : Controller
    {
        private THPTChuyenVinhEntities db = new THPTChuyenVinhEntities();

        // GET: Admin/DeThis
        public ActionResult Index()
        {
            return View(db.DeThis.ToList());
        }

        // GET: Admin/DeThis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeThi deThi = db.DeThis.Find(id);
            if (deThi == null)
            {
                return HttpNotFound();
            }
            return View(deThi);
        }

        // GET: Admin/DeThis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DeThis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDeThi,TieuDe,DuongDan")] DeThi deThi)
        {
            if (ModelState.IsValid)
            {
                db.DeThis.Add(deThi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deThi);
        }

        // GET: Admin/DeThis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeThi deThi = db.DeThis.Find(id);
            if (deThi == null)
            {
                return HttpNotFound();
            }
            return View(deThi);
        }

        // POST: Admin/DeThis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDeThi,TieuDe,DuongDan")] DeThi deThi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deThi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deThi);
        }

        // GET: Admin/DeThis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeThi deThi = db.DeThis.Find(id);
            if (deThi == null)
            {
                return HttpNotFound();
            }
            return View(deThi);
        }

        // POST: Admin/DeThis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeThi deThi = db.DeThis.Find(id);
            db.DeThis.Remove(deThi);
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
