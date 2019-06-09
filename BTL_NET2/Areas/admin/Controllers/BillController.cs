using BTL_NET2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_NET2.Areas.admin.Controllers
{
    public class BillController : Controller
    {
        // GET: admin/Bill
        Model1 data = new Model1();
        public ActionResult Index()
        {
            var hoadon = (from i in data.bill select i).ToList();
            ViewBag.hoadon = hoadon;
            return View();
        }

        public ActionResult DS_Bill(int idBill)
        {            
            var bil = (from cm in data.billdetail where cm.billID == idBill select cm).ToList();
            var nameBill = from i in data.bill where i.id == idBill select i;

            ViewBag.bil = bil;
            ViewBag.nameBill = nameBill;

            return View();
        }

        public ActionResult Xoa_bill(int idBill)
        {
            bill bi = data.bill.SingleOrDefault(n => n.id == idBill);
            if (bi == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.bill.Remove(bi);
            data.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Xoa_billdetail(int idBilldetail)
        {
            billdetail bi = data.billdetail.SingleOrDefault(n => n.id == idBilldetail);
            if (bi == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.billdetail.Remove(bi);
            data.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}