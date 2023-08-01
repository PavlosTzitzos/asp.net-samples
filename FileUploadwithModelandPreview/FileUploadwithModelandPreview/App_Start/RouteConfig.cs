using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FileUploadwithModelandPreview
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
            // Custom route for the file upload form
            routes.MapRoute(
                name: "UploadForm",
                url: "File/UploadForm",
                defaults: new { controller = "File", action = "UploadForm" }
            );

            // Custom route for the file upload action
            routes.MapRoute(
                name: "Upload",
                url: "File/UploadFile",
                defaults: new { controller = "File", action = "Upload" }
            );

            // Custom route for the file preview action
            routes.MapRoute(
                name: "ViewOldUploads",
                url: "File/ViewOldUploads/{id}",
                defaults: new { controller = "File", action = "ViewOldUpload", id = UrlParameter.Optional }
            );
        }
    }
}
