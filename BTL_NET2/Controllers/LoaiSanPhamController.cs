using BTL_NET2.Models;
using PagedList;
using PagedList.Mvc;
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
        public ActionResult Index(int? page)
        {
            //bien so san pham tren 1 trang
            int pageSize = 3;
            //tao bien so trang
            int pageNumber = (page ?? 1);
            var loai = data.category.ToList();
            IPagedList<PRODUCT> sp = data.PRODUCT.ToList().ToPagedList(pageNumber, pageSize);
            ViewBag.sp = sp;
            ViewBag.loai = loai;
            ViewBag.dem = data.PRODUCT.ToList().Count();
            return View(sp);
        }
        public ActionResult DS_sanpham(int id)
        {
            var loai = data.category.ToList();
            var sanpham = (from sp in data.PRODUCT join tl in data.category on sp.catID equals tl.id where tl.id==id select sp).ToList();
            ViewBag.loai = loai;
            ViewBag.id = id;
            ViewBag.sanpham = sanpham;
            
            return View();
        }


    }
}