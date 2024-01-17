using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace THPTChuyen.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string user, string pass)
        {
            if(user == "admin" && pass == "123456")
            {
                Session["user"] = "admin";
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}