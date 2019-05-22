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
            var sanphamNoiBat = (from i in data.PRODUCT where i.status==1 select i).ToList();

            //ascending sắp xếp tăng
            //descending sắp xếp giảm
            IPagedList<PRODUCT> sanphammoi = (from i in data.PRODUCT orderby i.id descending select i).ToPagedList(page ?? 1 ,20);
            ViewBag.sanphamNB = sanphamNoiBat;
            ViewBag.sanphammoi = sanphammoi;
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