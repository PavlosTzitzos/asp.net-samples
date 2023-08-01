using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.EnterpriseServices;
using System.Linq;
using System.Web;

namespace FileUploadwithModelandPreview.Models
{
    public class UploadFile
    {
        [DisplayName("ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FileId { get; set; }

        [DisplayName("File Name")]
        public string FileName { get; set; }

        [DisplayName("File Type")]
        public string ContentType { get; set; }

        [DisplayName("File Content")]
        public byte[] Content { get; set; }


        public class UploadFileDBContext : DbContext
        {
            public UploadFileDBContext(string nameOrConnectionString) : base(nameOrConnectionString) { }
            public DbSet<UploadFile> UploadFiles { get; set; }
        }
    }
}