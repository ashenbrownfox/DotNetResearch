using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageScrapperRazor.Models
{
    public class ImageFile
    {
        public int Id { get; set; }
        public string ImgSrc { get; set; }
        public string ParentSite { get; set; }
        public string Date { get; set; }
    }
}
