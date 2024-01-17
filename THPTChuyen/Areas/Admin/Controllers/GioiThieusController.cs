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
    public class GioiThieusController : Controller
    {
        private THPTChuyenVinhEntities db = new THPTChuyenVinhEntities();

        // GET: Admin/GioiThieus
        public ActionResult Index()
        {
            return View(db.GioiThieux.ToList());
        }

        // GET: Admin/GioiThieus/Details/5

        // GET: Admin/GioiThieus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/GioiThieus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaGioiThieu,LichSuPhatTrien,NhiemVu,PhanCong")] GioiThieu gioiThieu)
        {
            if (ModelState.IsValid)
            {
                db.GioiThieux.Add(gioiThieu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gioiThieu);
        }

        // GET: Admin/GioiThieus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GioiThieu gioiThieu = db.GioiThieux.Find(id);
            if (gioiThieu == null)
            {
                return HttpNotFound();
            }
            return View(gioiThieu);
        }

        // POST: Admin/GioiThieus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaGioiThieu,LichSuPhatTrien,NhiemVu,PhanCong")] GioiThieu gioiThieu)
        {
            var gioithieu = db.GioiThieux.Find(gioiThieu.MaGioiThieu);
            if (String.IsNullOrEmpty(gioiThieu.LichSuPhatTrien))
            {
                return View(gioiThieu);
            }
            gioithieu.LichSuPhatTrien = gioiThieu.LichSuPhatTrien;
            gioithieu.NhiemVu = gioiThieu.NhiemVu;
            gioithieu.PhanCong = gioiThieu.PhanCong;
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
