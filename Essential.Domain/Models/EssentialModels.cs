using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essential.Domain.Models
{
    public class EssentialModels
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public int BookNumber { get; set; }
        public int UnitNumber { get; set; }
        public string EngWord { get; set; }
        public string UzbWord { get; set;}
        public string RusWord { get; set;}
    }
}
