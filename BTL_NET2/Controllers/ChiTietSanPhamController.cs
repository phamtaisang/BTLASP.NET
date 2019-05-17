using BTL_NET2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_NET2.Controllers
{
    public class ChiTietSanPhamController : Controller
    {
        Model1 data = new Model1();
        // GET: ChiTietSanPham
        public ActionResult Index(int id)
        {
            ViewBag.id = id;
            var chitiet = (from ct in data.PRODUCT where ct.id == id select ct).ToList();
            var cmm = (from cm in data.feedback
                       join us in data.account on cm.accountid equals us.id
                       where cm.productid == id select cm).ToList();
            ViewBag.cmm = cmm;
            ViewBag.chitiet = chitiet;
            return View();
        }
    }
}