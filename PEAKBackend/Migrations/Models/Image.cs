using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PEAKBackend.Models
{
    public class Image
    {
        public int Id { get; set; }

        [Required]
        public string ContentType { get; set; }

        public override string ToString()
        {
            return Id + FileExtension();
        }

        public string FileExtension()
        {
            switch (ContentType.ToLower())
            {
                case "image/jpeg":
                    return ".jpeg";
                case "image/png":
                    return ".png";
            }
            return null;
        }

        public static bool IsContentTypeValid(string contentType)
        {
            return contentType.Equals("image/jpeg") ||
                   contentType.Equals("image/png");
        }
    }
}