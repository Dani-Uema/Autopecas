using System;
using System.Collections.Generic;
using System.Text;

namespace Avaliação1.VO
{
    public class Pedidos
    {
        public int codvenda { get; set; }
        public Clientes codcliente { get; set; }
        public Pecas codigo { get; set; }
        public DateTime data  { get; set; }
    }
}
