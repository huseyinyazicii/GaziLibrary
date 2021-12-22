using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaziLibrary.Models
{
    public class ImageBook
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfPage { get; set; }
        public IFormFile Image { get; set; }
        public int AuthorId { get; set; }
        public int TypeId { get; set; }
    }
}
