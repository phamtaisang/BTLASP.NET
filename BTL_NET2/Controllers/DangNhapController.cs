using BTL_NET2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_NET2.Controllers
{
    public class DangNhapController : Controller
    {
        // GET: DangNhap
        Model1 db =  new Model1();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        } 
        [HttpPost]
        public ActionResult DangKy(account model)
        {
            if (ModelState.IsValid)
            {
                account user = new account();
                user.name = model.name;
                user.password = model.password;
                user.address = model.address;
                user.phone = model.phone;
                user.email = model.email;
                user.role = 1;
                user.status = 0;
                user.created_at = DateTime.Today;
                user.update_at = DateTime.Now;
                db.account.Add(user);
                db.SaveChanges();
            }
            else
            {
                ViewBag.loi = "email đã tồn tại";
            }
            return Redirect("DangKy");
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string TK = f.Get("txtEmail").ToString();
            string MK = f.Get("txtMatKhau").ToString();
            account dangnhap = db.account.SingleOrDefault(n=>n.email==TK && n.password == MK);
            if(dangnhap != null)
            {
               
                Session["TaiKhoan"] = dangnhap;
                return RedirectToAction("Index","TrangChu");
            }
            else
            {
                ModelState.AddModelError("", "dang nhap sai ");
                return Redirect("DangNhap");
            }
           
        }
        //thong tin dang nhap
        public ActionResult ThongTin()
        {
            return View();
        }
        //đăng xuất
        public ActionResult DangXuat()
        {
            Session["TaiKhoan"] = null;
            return new RedirectResult("DangNhap");
        }
    }
}