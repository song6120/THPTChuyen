using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using THPTChuyen.Models;

namespace THPTChuyen.Controllers
{
    public class HinhAnhController : Controller
    {
        THPTChuyenVinhEntities THPTChuyen = new THPTChuyenVinhEntities();

        // GET: HinhAnh
        public ActionResult Index()
        {
            HomeModel model = new HomeModel();
            model.listLoaivanban = THPTChuyen.LoaiVanBans.ToList();

            model.listLoaitintuc = (from item in THPTChuyen.LoaiTins
                                    select item).ToList();

            model.listToChuc = THPTChuyen.ToChucs.ToList();
            model.tintuc = THPTChuyen.TinTucs.ToList();
            return View(model);
        }
    }
}