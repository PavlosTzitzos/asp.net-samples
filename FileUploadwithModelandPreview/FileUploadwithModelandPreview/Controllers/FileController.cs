using FileUploadwithModelandPreview.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using static FileUploadwithModelandPreview.Models.UploadFile;

namespace FileUploadwithModelandPreview.Controllers
{
    public class FileController : Controller
    {
        private readonly UploadFileDBContext db = new UploadFileDBContext("Name=FileUploadwithModelandPreview");
        
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
                //Saving the data in the DB
                byte[] fileContent1;
                using (var binaryReader1 = new BinaryReader(file1.InputStream))
                {
                    fileContent1 = binaryReader1.ReadBytes(file1.ContentLength);
                }
                var model1 = new UploadFile
                {
                    FileName = file1.FileName,
                    ContentType = file1.ContentType,
                    Content = fileContent1
                };
                // Save the uploadedFile object to the database using your DbContext
                db.UploadFiles.Add(model1);
                db.SaveChanges();
                string _FileName2 = Path.GetFileName(file2.FileName);
                string _path2 = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName2);
                file2.SaveAs(_path2);

                // Save the file information to the database or session, if needed.
                //Saving the data in the DB
                byte[] fileContent2;
                using (var binaryReader2 = new BinaryReader(file2.InputStream))
                {
                    fileContent2 = binaryReader2.ReadBytes(file2.ContentLength);
                }
                var model2 = new UploadFile
                {
                    FileName = file2.FileName,
                    ContentType = file2.ContentType,
                    Content = fileContent2
                };
                ViewBag.Message = "File Uploaded Successfully!!";

                // Save the uploadedFile object to the database using your DbContext
                db.UploadFiles.Add(model2);
                db.SaveChanges();

            }
            else
            {
                ViewBag.Message = "!!! WARNING !!! Both files must be uploaded!!";
                return View("UploadFile");
            }

            return View("UploadFile");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UploadFile UploadedFile = db.UploadFiles.Find(id);
            if (UploadedFile == null)
            {
                return HttpNotFound();
            }
            db.UploadFiles.Remove(UploadedFile);
            db.SaveChanges();
            return RedirectToAction("ViewOldUpload");
        }

        public ActionResult ViewOldUpload()
        {
            return View(db.UploadFiles.ToList());
        }
    }
}