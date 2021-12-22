using GaziLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaziLibrary.Models
{
    public class MessageModel
    {
        public Message Message { get; set; }
        public List<Message> Messages { get; set; }
    }
}
