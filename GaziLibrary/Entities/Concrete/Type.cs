using GaziLibrary.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GaziLibrary.Entities.Concrete
{
    public class Type : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public List<Book> Books { get; set; }
    }
}
