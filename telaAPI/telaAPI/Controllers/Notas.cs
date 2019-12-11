using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace telaAPI.Controllers
{

    public class Notas
    {
        public string iC { get; set; }
        public DateTime iRC { get; set; }
        public List<Detalhe> DetalheColecao { get; set; }

    }
    
}
