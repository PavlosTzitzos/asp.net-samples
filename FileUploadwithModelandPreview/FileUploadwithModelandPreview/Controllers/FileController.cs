using FileUploadwithModelandPreview.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileUploadwithModelandPreview.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult UploadForm()
        {
            return View("UploadFile");
        }
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                // Process the uploaded file here (e.g., save it to disk, database, etc.)
                // You can use the UploadedFile model to store information about the uploaded file.
                //var fileName = Path.GetFileName(file.FileName);
                //var path = Path.Combine(Server.MapPath("~/UploadedFiles/"), fileName);
                //file.SaveAs(path);
                string _FileName = Path.GetFileName(file.FileName);
                string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                file.SaveAs(_path);

                // Save the file information to the database or session, if needed.
                var model = new UploadFile
                {
                    FileName = _FileName,
                    ContentType = file.ContentType
                };
                ViewBag.Message = "File Uploaded Successfully!!";
                return RedirectToAction("UploadForm");
            }
            ViewBag.Message = "File upload failed!!";
            // Handle the case when no file is uploaded
            return RedirectToAction("UploadForm");
        }

    }
}