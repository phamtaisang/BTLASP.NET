using BTL_NET2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_NET2.Controllers
{
    public class TimKiemController : Controller
    { 
        // GET: TimKiem
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult TimKiem(string searchString)
        {
            Model1 db = new Model1();
            //ViewBag.timkiem = searchString;
            var links = from l in db.PRODUCT // lấy toàn bộ liên kết
                        select l;

            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                links = links.Where(s => s.name.Contains(searchString)); //lọc theo chuỗi tìm kiếm
            }

            ViewBag.show = links;
            return View();
        }
    }
}