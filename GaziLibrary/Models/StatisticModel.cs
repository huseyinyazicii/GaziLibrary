using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaziLibrary.Models
{
    public class StatisticModel
    {
        public int NumberOfBooks { get; set; }
        public int NumberOfAuthors { get; set; }
        public int NumberOfUsers { get; set; }
        public int NumberOfBorrowedBooks { get; set; }
        public int NumberOfMessages { get; set; }
        public int NumberOfTypes { get; set; }
        public int NumberOfPositions { get; set; }
    }
}
