using System;
using System.Collections.Generic;
using System.Text;

namespace Avaliação1.VO
{
   public class Veiculos
    {
        public int codigo { get; set; }
        public string modelo { get; set; }
        public string potencia { get; set; }
        public int ano { get; set; }
        public Fabricante fabricante { get; set; }
    }
}
