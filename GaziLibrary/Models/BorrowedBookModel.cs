using GaziLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaziLibrary.Models
{
    public class BorrowedBookModel
    {
        public BorrowedBook BorrowedBook { get; set; }
        public List<BorrowedBook> BorrowedBooks { get; set; }
    }
}
