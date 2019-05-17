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

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               name: "loaisanpham",
               url: "loai-sp/{MetaTitle}-{id}",
               defaults: new { controller = "LoaiSanPham", action = "DSLoaiSP", id = UrlParameter.Optional }
           );
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               name: "chitiet",
               url: "chi-tiet/{MetaTitle}-{id}",
               defaults: new { controller = "ChiTietSanPham", action = "index", id = UrlParameter.Optional }
           );
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Loai",
                url: "loai-san-pham",
                defaults: new { controller = "LoaiSanPham", action = "Index", id = UrlParameter.Optional }
            );

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
        }
    }
}
