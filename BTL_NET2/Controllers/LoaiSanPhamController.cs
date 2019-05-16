using BTL_NET2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_NET2.Controllers
{
    public class LoaiSanPhamController : Controller
    {
        
        // GET: LoaiSanPham
        public ActionResult Index()
        {
            Model1 data = new Model1();
            var loai = data.category.ToList();
            ViewBag.loai = loai;
            return View();
        }
        public ActionResult DSLoaiSP(int id)
        {
            ViewBag.id = id;
            
            return View();
        }

    }
}