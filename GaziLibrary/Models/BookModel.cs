using GaziLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaziLibrary.Models
{
    public class BookModel
    {
        public List<Book> Books { get; set; }
        public Book Book { get; set; }
        public ImageBook ImageBook { get; set; }
        public List<AuthorWithFullName> Authors { get; set; }
        public List<Entities.Concrete.Type> Types { get; set; }
    }
}
