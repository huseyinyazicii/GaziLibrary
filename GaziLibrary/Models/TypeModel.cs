using GaziLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaziLibrary.Models
{
    public class TypeModel
    {
        public Entities.Concrete.Type Type { get; set; }
        public List<Entities.Concrete.Type> Types { get; set; }
        public List<TypeWithBook> TypeWithBooks { get; set; }
    }
}
