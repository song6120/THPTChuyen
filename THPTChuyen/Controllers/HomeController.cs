using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using THPTChuyen.Models;

namespace THPTChuyen.Controllers
{
    public class HomeController : Controller
    {
        THPTChuyenVinhEntities THPTChuyen = new THPTChuyenVinhEntities();

        public ActionResult Index()
        {
            HomeModel model = new HomeModel();
            model.listVanban = THPTChuyen.VanBans.ToList();
            model.listTintuc = (from i in THPTChuyen.TinTucs
                               select i).ToList();
            model.listTintruong = (from i in THPTChuyen.TinTucs
                                   join i1 in THPTChuyen.LoaiTins
                                   on i.MaLoaiTin equals i1.MaLoaiTin
                                   where i1.TenLoai.Equals("Nhà trường")
                                   select i).ToList();
            model.listCongdoan = (from i in THPTChuyen.TinTucs
                                  join i1 in THPTChuyen.LoaiTins
                                  on i.MaLoaiTin equals i1.MaLoaiTin
                                  where i1.TenLoai.Equals("Công đoàn")
                                  select i).ToList();
            model.listDoantruong = (from i in THPTChuyen.TinTucs
                                  join i1 in THPTChuyen.LoaiTins
                                  on i.MaLoaiTin equals i1.MaLoaiTin
                                  where i1.TenLoai.Equals("Đoàn trường")
                                  select i).ToList();
            model.listThidua = (from i in THPTChuyen.TinTucs
                                    join i1 in THPTChuyen.LoaiTins
                                    on i.MaLoaiTin equals i1.MaLoaiTin
                                    where i1.TenLoai.Equals("Thi đua khen thưởng")
                                    select i).ToList();
            model.listHocduong = (from i in THPTChuyen.TinTucs
                                    join i1 in THPTChuyen.LoaiTins
                                    on i.MaLoaiTin equals i1.MaLoaiTin
                                    where i1.TenLoai.Equals("Tin học đường")
                                    select i).ToList();
            model.listLoaivanban = THPTChuyen.LoaiVanBans.ToList();

            model.listLoaitintuc = (from item in THPTChuyen.LoaiTins
                                    select item).ToList();

            model.listToChuc = THPTChuyen.ToChucs.ToList();
            return View(model);
        }
    }
}