using GaziLibrary.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaziLibrary.DataAccess.Concrete
{
    public class OracleContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle(@"User Id = HUSEYIN;Password = hy13081999;Data Source = localhost:1521/XEPDB1;");
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<BorrowedBook> BorrowedBooks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Entities.Concrete.Type> Types { get; set; }
        public DbSet<Position> Positions { get; set; }
    }
}
