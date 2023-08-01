using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileUploadwithModelandPreview.Models
{
    public class UploadFile
    {
        public string FileName { get; set; }

        public string ContentType { get; set; }

        public string FileContent { get; set; }


    }
}