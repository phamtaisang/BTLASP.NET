using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BTL_NET2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //lấy id loai sản phẩm ở cotroller loaisanpham
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               name: "loaiid",
               url: "loai/{MetaTitle}-{id}",
               defaults: new { controller = "LoaiSanPham", action = "DS_sanpham", id = UrlParameter.Optional }
           );
            //lay chi tiet san pham theo id
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               name: "chitiet",
               url: "chi-tiet/{MetaTitle}-{id}",
               defaults: new { controller = "ChiTietSanPham", action = "index", id = UrlParameter.Optional }
           );
      
          

            //loai san pham ở thanh header
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Loai",
                url: "loai-san-pham",
                defaults: new { controller = "LoaiSanPham", action = "Index", id = UrlParameter.Optional }
            );
            //cái này mặc định dữ nguyên pải để xuống dưới cùng
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
        }
    }
}
