using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using THPTChuyen.Models;

namespace THPTChuyen.Controllers
{
    public class VanBanController : Controller
    {
        // GET: VanBan
        private THPTChuyenVinhEntities THPTChuyen = new THPTChuyenVinhEntities();

        // GET: Admin/VanBans
        public ActionResult Index(int id)
        {
            HomeModel model = new HomeModel();
            model.listLoaivanban = THPTChuyen.LoaiVanBans.ToList();

            model.listLoaitintuc = (from item in THPTChuyen.LoaiTins
                                    select item).ToList();

            model.listToChuc = THPTChuyen.ToChucs.ToList();

            model.loaivb = (from i in THPTChuyen.LoaiVanBans
                            where i.MaLoaiVanBan == id
                            select i).ToList();

            model.listVanban = (from i in THPTChuyen.VanBans
                                where i.MaLoaiVanBan == id
                          select i).ToList();

            return View(model);
        }
        public ActionResult Chitiet(int id)
        {
            HomeModel model = new HomeModel();
            model.listLoaivanban = THPTChuyen.LoaiVanBans.ToList();

            model.listLoaitintuc = (from item in THPTChuyen.LoaiTins
                                    select item).ToList();

            model.listToChuc = THPTChuyen.ToChucs.ToList();
            model.listVanban = (from i in THPTChuyen.VanBans
                                where i.MaVanBan == id
                                select i).ToList();
            return View(model);
        }
    }
}