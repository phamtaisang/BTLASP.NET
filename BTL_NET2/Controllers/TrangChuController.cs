using BTL_NET2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_NET2.Controllers
{
    public class TrangChuController : Controller
    {
        // GET: TrangChu
        Model1 data = new Model1();
        public ActionResult Index()
        {
            var sanpham = data.PRODUCT.ToList();
            ViewBag.sanpham = sanpham;
            return View();
        }
        public ActionResult HeaderLoaiSP()
        {

            return View();
        }
        public ActionResult DSLoaiSP(int id)
        {
            ViewBag.id = id;
            return View();
        }
    }
}