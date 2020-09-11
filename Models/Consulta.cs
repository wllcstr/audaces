using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Audaces.Models
{
    public class Consulta
    {
        public string sequencia { get; set; }
        public int alvo { get; set; }
        public string data_consulta { get; set; }
        public string retorno { get; set; }

        public Consulta() { }
    }
}
