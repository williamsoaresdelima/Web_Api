using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    public class Materia
    {
        public int id { get; set; }
        public string name { get; set; }
        public int isactive { get; set; }
        public int isdelete { get; set; }
    }
}
