using BTL_NET2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace BTL_NET2.Controllers
{
    public class TrangChuController : Controller
    {
        // GET: TrangChu
        Model1 data = new Model1();
        public ActionResult Index(int? page)
        {
            var sanphamNoiBat = (from i in data.PRODUCT where i.status==1 select i).Take(4).ToList();
            //ascending sắp xếp tăng
            //descending sắp xếp giảm

            //bien so san pham tren 1 trang
            int pageSize = 4;
            //tao bien so trang
            int pageNumber = (page ?? 1);
            IPagedList<PRODUCT> sanphammoi = (from i in data.PRODUCT orderby i.id descending select i).ToPagedList(pageNumber,pageSize);
            ViewBag.sanphamNB = sanphamNoiBat;
            ViewBag.sanphammoi = sanphammoi;
            return View(sanphammoi);
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