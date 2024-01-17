using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using THPTChuyen.Models;

namespace THPTChuyen.Controllers
{
    
    public class GiaoVienController : Controller
    {
        THPTChuyenVinhEntities THPTChuyen = new THPTChuyenVinhEntities();
        // GET: GiaoVien
        public ActionResult Index(int id)
        {
            HomeModel model = new HomeModel();
            model.listLoaivanban = THPTChuyen.LoaiVanBans.ToList();

            model.listLoaitintuc = (from item in THPTChuyen.LoaiTins
                                    select item).ToList();

            model.listToChuc = THPTChuyen.ToChucs.ToList();

            model.toChuc = (from i in THPTChuyen.ToChucs
                           where i.MaToChuc == id
                           select i).ToList();

            model.giaoVien = (from i in THPTChuyen.GiaoViens
                              join cv in THPTChuyen.ChucVus
                              on i.MaChucVu equals cv.MaChucVu
                              where i.MaToChuc == id
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

            model.toChuc = (from i in THPTChuyen.ToChucs
                            join gv in THPTChuyen.GiaoViens
                            on i.MaToChuc equals gv.MaToChuc
                            where gv.MaGiaoVien == id
                            select i).ToList();

            model.giaoVien = (from i in THPTChuyen.GiaoViens
                              where i.MaGiaoVien == id
                              select i).ToList();
            return View(model);
        }

    }
}
