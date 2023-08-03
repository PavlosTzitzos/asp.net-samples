using IronOcr;
using OCRwithTesseract.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using static OCRwithTesseract.Models.UploadFile;
using static System.Net.WebRequestMethods;

namespace OCRwithTesseract.Controllers
{
    public class FileController : Controller
    {
        private readonly UploadFileDBContext db = new UploadFileDBContext("Name=OCRwithTesseract");

        // GET: File
        public ActionResult Index()
        {
            return View();
        }

        //one file upload :
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                string _FileName = Path.GetFileName(file.FileName);
                string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                file.SaveAs(_path);
                //
                var Ocr = new IronTesseract(); // nothing to configure
                Ocr.Language = OcrLanguage.English; // one language
                // Add as many secondary languages as you like : (dont forget to add the NuGet Package)
                Ocr.AddSecondaryLanguage(OcrLanguage.Greek);
                Ocr.Configuration.TesseractVersion = TesseractVersion.Tesseract5;
                string ExtractedText;
                using (var Input = new OcrInput())
                {
                    Input.AddImage(_path);
                    Input.DeNoise();
                    var Result = Ocr.Read(Input);
                    ExtractedText = Result.Text;
                }
                //
                // Save the file information to the database or session, if needed.
                //Saving the data in the DB
                byte[] fileContent;
                using (var binaryReader = new BinaryReader(file.InputStream))
                {
                    fileContent = binaryReader.ReadBytes(file.ContentLength);
                }
                var model = new UploadFile
                {
                    FileName = file.FileName,
                    ContentType = file.ContentType,
                    Content = fileContent,
                    FilePath = _path,
                    ExtractedText = ExtractedText
                };
                // Save the uploadedFile object to the database using your DbContext
                db.UploadFiles.Add(model);
                db.SaveChanges();
                
                return RedirectToAction("Index");
            }
            ViewBag.Message = "File upload failed!!";
            // Handle the case when no file is uploaded
            return RedirectToAction("Index");
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