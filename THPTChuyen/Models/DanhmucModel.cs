using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THPTChuyen.Models
{
    public class DanhmucModel
    {
        public List<LoaiVanBan> listLoaivanban { get; set; }
        public List<TinTuc> listTintuc { get; set; }
        public List<ChucVu> listChucVu { get; set; }
        public List<ToChuc> listToChuc { get; set; }
    }
}