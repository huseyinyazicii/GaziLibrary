using GaziLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaziLibrary.Models
{
    public class UserModel
    {
        public List<User> Users { get; set; }
        public User User { get; set; }
        public List<Position> Positions { get; set; }
        public BorrowedBook BorrowedBook { get; set; }
    }
}
