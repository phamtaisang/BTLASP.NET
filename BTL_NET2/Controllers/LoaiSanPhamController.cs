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
        Model1 data = new Model1();
        private object sp;

        // GET: LoaiSanPham
        public ActionResult Index()
        {
            
            var loai = data.category.ToList();
            ViewBag.loai = loai;
            return View();
        }
        public ActionResult DSLoaiSP(int id)
        {
            var Hang = (from sp in data.PRODUCT join tl in data.category on sp.catID equals tl.id join h in data.producer on sp.producerid equals h.id where tl.id==id select sp).ToList();
            // var Hang = (from h in data.producer select h).ToList();
            ViewBag.id = id;
            ViewBag.Hang = Hang;
            return View();
        }

    }
}