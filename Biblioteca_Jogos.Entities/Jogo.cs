using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Jogos.Entities
{
    public class Jogo
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public double? ValorPago { get; set; }
        public string Imagem { get; set; }
        public DateTime? DataCompra { get; set; }       
    }
}
