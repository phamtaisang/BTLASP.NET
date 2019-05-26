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
            //ViewBag.id = id;
            var chitiet = (from ct in data.PRODUCT where ct.id == id select ct).ToList();
            var cmm = (from cm in data.feedback
                       join us in data.account on cm.accountid equals us.id
                       where cm.productid == id select cm).ToList();

            foreach (var ct in chitiet)
            {
                //ViewBag.idLoai = i.producerid;
                var splienquan = (from lq in data.PRODUCT where lq.producerid == ct.producerid select lq).Take(3).ToList();
                ViewBag.splienquan = splienquan;
            }
            var sanphammoi = (from i in data.PRODUCT orderby i.id descending select i).Take(4).ToList();
            ViewBag.sanphammoi = sanphammoi;
            ViewBag.cmm = cmm;
            ViewBag.chitiet = chitiet;
            return View();
        }
        public ActionResult Commnet(string txtNoiDung,int id)
        {
            feedback phanhoi = new feedback();
            account user = (account)Session["TaiKhoan"];
          
            phanhoi.accountid = user.id;
            phanhoi.productid = id;
            phanhoi.comment = txtNoiDung;
            phanhoi.created_at = DateTime.Today;
            phanhoi.update_at = DateTime.Now;
            data.feedback.Add(phanhoi);
            data.SaveChanges();
           return RedirectToAction("Index","ChiTietSanPham");
        }
    }
}