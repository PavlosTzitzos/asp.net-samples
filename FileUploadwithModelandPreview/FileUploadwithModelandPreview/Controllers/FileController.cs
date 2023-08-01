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

        //one file upload version :
        /*
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
        }*/
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file1, HttpPostedFileBase file2)
        {
            
            if ((file1 != null && file1.ContentLength > 0) && (file2 != null && file2.ContentLength > 0))
            {
                string _FileName1 = Path.GetFileName(file1.FileName);
                string _path1 = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName1);
                file1.SaveAs(_path1);

                // Save the file information to the database or session, if needed.
                // For the purpose of this example, we won't be saving the details of the file in the database.
                var model1 = new UploadFile
                {
                    FileName = _FileName1,
                    ContentType = file1.ContentType
                };
                ViewBag.Message = "File Uploaded Successfully!!";
            
                string _FileName2 = Path.GetFileName(file2.FileName);
                string _path2 = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName2);
                file2.SaveAs(_path2);

                // Save the file information to the database or session, if needed.
                // For the purpose of this example, we won't be saving the details of the file in the database.
                var model2 = new UploadFile
                {
                    FileName = _FileName2,
                    ContentType = file2.ContentType
                };
                ViewBag.Message = "File Uploaded Successfully!!";
            }
            else
            {
                ViewBag.Message = "!!! WARNING !!! Both files must be uploaded!!";
                return View("UploadFile");
            }

            return View("UploadFile");
        }

    }
}