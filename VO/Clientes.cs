using System;
using System.Collections.Generic;
using System.Text;

namespace Avaliação1.VO
{
    public class Clientes
    {
        public int codigo { get; set; } 
        public string nome { get; set; }
        public string cpf { get; set; }
        public string endereco { get; set; }
        public string numero { get; set; }
       
        public string cidade { get; set; }
        public string estado { get; set; }
        public string pais { get; set; }
    }
}
