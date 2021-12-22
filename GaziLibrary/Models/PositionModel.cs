using GaziLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaziLibrary.Models
{
    public class PositionModel
    {
        public Position Position { get; set; }
        public List<Position> Positions { get; set; }
        public List<PositionWithUser> PositionWithUsers { get; set; }
    }
}
