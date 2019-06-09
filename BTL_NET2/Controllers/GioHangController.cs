using BTL_NET2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_NET2.Controllers
{
    public class GioHangController : Controller
    {
        Model1 db = new Model1();
        // GET: GioHang
        public ActionResult Index()
        {
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
           
            return View(giohang);

        }
        public RedirectToRouteResult ThemVaoGio(int SanPhamID)
        {
            if (Session["giohang"] == null) // Nếu giỏ hàng chưa được khởi tạo
            {
                Session["giohang"] = new List<CartItem>();  // Khởi tạo Session["giohang"] là 1 List<CartItem>
            }

            List<CartItem> giohang = Session["giohang"] as List<CartItem>;  // Gán qua biến giohang dễ code

            // Kiểm tra xem sản phẩm khách đang chọn đã có trong giỏ hàng chưa

            if (giohang.FirstOrDefault(m => m.SanPhamID == SanPhamID) == null) // ko co sp nay trong gio hang
            {
                PRODUCT sp = db.PRODUCT.Find(SanPhamID);  // tim sp theo sanPhamID

                CartItem newItem = new CartItem()
                {
                    SanPhamID = SanPhamID,
                    TenSanPham = sp.name,
                    SoLuong = 1,
                    Hinh = sp.images,
                    DonGia = sp.price

                };  // Tạo ra 1 CartItem mới

                giohang.Add(newItem);  // Thêm CartItem vào giỏ 
            }
            else
            {
                // Nếu sản phẩm khách chọn đã có trong giỏ hàng thì không thêm vào giỏ nữa mà tăng số lượng lên.
                CartItem cardItem = giohang.FirstOrDefault(m => m.SanPhamID == SanPhamID);
                cardItem.SoLuong++;
            }

            // Action này sẽ chuyển hướng về trang chi tiết sp khi khách hàng đặt vào giỏ thành công. Bạn có thể chuyển về chính trang khách hàng vừa đứng bằng lệnh return Redirect(Request.UrlReferrer.ToString()); nếu muốn.
            // return RedirectToAction("ChiTiet", "SanPham", new { id = SanPhamID });
            return RedirectToAction("index");
        }
        public RedirectToRouteResult SuaSoLuong(int SanPhamID, int soluongmoi)
        {
            // tìm carditem muon sua
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            CartItem itemSua = giohang.FirstOrDefault(m => m.SanPhamID == SanPhamID);
            if (itemSua != null)
            {
                itemSua.SoLuong = soluongmoi;
            }
            return RedirectToAction("Index");
        }
        public RedirectToRouteResult XoaKhoiGio(int SanPhamID)
        {
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            CartItem itemXoa = giohang.FirstOrDefault(m => m.SanPhamID == SanPhamID);
            if (itemXoa != null)
            {
                giohang.Remove(itemXoa);
            }
            return RedirectToAction("Index");
        }

        // tien hanh dat hang
        [HttpPost]
        public ActionResult ThanhToan()
        {
            if (Session["giohang"] == null)
            {
                RedirectToAction("index", "TrangChu");
            }
            //them don hang
            else
            {
                if (Session["TaiKhoan"] == null || Session["TaiKhoan"] == "")
                {
                    RedirectToAction("DangNhap", "DangNhap");
                }
                else
                {
                    bill bl = new bill();
                    account user = (account)Session["TaiKhoan"];
                    bl.accountId = user.id;
                    bl.total = 1;
                    bl.status = 1;
                    bl.created_at = DateTime.Now;
                    bl.update_at = DateTime.Now;
                    db.bill.Add(bl);
                    ////them tiep vao billdetal
                    //billdetail bdt = new billdetail();
                    //bdt.billID = bl.id;
                    //List<CartItem> gh = giohang();
                    //foreach (var item in giohang)
                    //{
                    //    gh.SanPhamID = bdt.productId;
                    //    gh.SoLuong = bdt.quantity;
                    //    gh.DonGia = bdt.price;
                    //    bdt.discount = 1;
                    //    gh.DonGia = gh.SoLuong * bdt.sum_price;
                    //    bdt.created_at = DateTime.Now;
                    //    bdt.update_at = DateTime.Now;
                    //    db.billdetail.Add(bdt);
                    //}
                   
                    db.SaveChanges();
                }
            }
            return View();
        }
    }
}