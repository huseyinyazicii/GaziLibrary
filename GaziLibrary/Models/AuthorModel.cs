using GaziLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaziLibrary.Models
{
    public class AuthorModel
    {
        public Author Author { get; set; }
        public List<Author> Authors { get; set; }
        public List<AuthorWithBook> AuthorWithBooks { get; set; }
    }
}
