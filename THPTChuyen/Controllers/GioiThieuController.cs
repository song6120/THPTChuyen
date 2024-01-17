using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using THPTChuyen.Models;

namespace THPTChuyen.Controllers
{
    public class GioiThieuController : Controller
    {
        THPTChuyenVinhEntities THPTChuyen = new THPTChuyenVinhEntities();
        // GET: GioiThieu
        public ActionResult Index()
        {
            HomeModel model = new HomeModel();
            model.listLoaivanban = THPTChuyen.LoaiVanBans.ToList();

            model.listLoaitintuc = (from item in THPTChuyen.LoaiTins
                                    select item).ToList();

            model.listToChuc = THPTChuyen.ToChucs.ToList();
            model.gioithieu = THPTChuyen.GioiThieux.ToList();
            return View(model);
        }
        public ActionResult phancong()
        {
            HomeModel model = new HomeModel();
            model.listLoaivanban = THPTChuyen.LoaiVanBans.ToList();

            model.listLoaitintuc = (from item in THPTChuyen.LoaiTins
                                    select item).ToList();

            model.listToChuc = THPTChuyen.ToChucs.ToList();
            model.gioithieu = THPTChuyen.GioiThieux.ToList();
            return View(model);
        }
        public ActionResult nhiemvu()
        {
            HomeModel model = new HomeModel();
            model.listLoaivanban = THPTChuyen.LoaiVanBans.ToList();

            model.listLoaitintuc = (from item in THPTChuyen.LoaiTins
                                    select item).ToList();

            model.listToChuc = THPTChuyen.ToChucs.ToList();
            model.gioithieu = THPTChuyen.GioiThieux.ToList();
            return View(model);
        }
    }
}