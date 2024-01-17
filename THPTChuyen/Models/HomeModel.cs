using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THPTChuyen.Models
{
    public class HomeModel
    {
        public List<LoaiVanBan> listLoaivanban { get; set; }
        public List<LoaiTin> listLoaitintuc { get; set; }
        public List<ToChuc> listToChuc { get; set; }
        public List<VanBan> listVanban { get; set; }
        public List<TinTuc> listTintuc { get; set; }
        public List<TinTuc> listTintruong { get; set; }
        public List<TinTuc> listCongdoan { get; set; }
        public List<TinTuc> listDoantruong { get; set; }
        public List<TinTuc> listThidua { get; set; }
        public List<TinTuc> listHocduong { get; set; }
        public List<ToChuc> toChuc { get; set; }
        public List<GiaoVien> giaoVien { get; set; }
        public List<TinTuc> tintuc { get; set; }
        public List<LoaiTin> loaitin { get; set; }
        public List<LoaiVanBan> loaivb { get; set; }
        public List<GioiThieu> gioithieu { get; set; }
    }
}