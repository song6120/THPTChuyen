using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using THPTChuyen.Models;

namespace THPTChuyen.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        private THPTChuyenVinhEntities db = new THPTChuyenVinhEntities();
        // GET: Admin/Home
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string user, string pass)
        {
            if (user == "admin" && pass == "123456" )
            {
                Session["user"] = "admin";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Tài khoản đăng nhập không đúng!";
                return View();
            }

        }
        public ActionResult Logout()
        {
            Session.Remove("user");
            FormsAuthentication.SignOut();
            return View("Login");
        }
    }
}