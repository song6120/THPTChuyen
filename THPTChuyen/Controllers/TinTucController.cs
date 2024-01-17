using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using THPTChuyen.Models;

namespace THPTChuyen.Controllers
{
    public class TinTucController : Controller
    {
        THPTChuyenVinhEntities THPTChuyen = new THPTChuyenVinhEntities();
        // GET: TinTuc
        public ActionResult Index(int id)
        {
            HomeModel model = new HomeModel();
            model.listLoaivanban = THPTChuyen.LoaiVanBans.ToList();

            model.listLoaitintuc = (from item in THPTChuyen.LoaiTins
                                    select item).ToList();

            model.listToChuc = THPTChuyen.ToChucs.ToList();

            model.tintuc = (from i in THPTChuyen.TinTucs
                            join lt in THPTChuyen.LoaiTins
                            on i.MaLoaiTin equals lt.MaLoaiTin
                            where lt.MaLoaiTin == id
                            select i).ToList();

            model.loaitin = (from i in THPTChuyen.LoaiTins
                             where i.MaLoaiTin == id
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

            model.tintuc= (from item in THPTChuyen.TinTucs
                           where item.MaTinTuc == id
                           select item).ToList();
            
            model.loaitin = (from lt in THPTChuyen.LoaiTins
                             join tt in THPTChuyen.TinTucs
                             on lt.MaLoaiTin equals tt.MaLoaiTin
                             where tt.MaTinTuc == id
                             select lt).ToList();

            return View(model);
        }
    }
}