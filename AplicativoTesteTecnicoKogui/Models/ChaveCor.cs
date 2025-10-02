using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoTesteTecnicoKogui.Models
{
    public class ChaveCor
    {
        public string Hex { get; set; } = "";
        public string Cor { get; set; } = "";
        public string Componente { get; set; } = "";

        public ChaveCor(string cor, string componente)
        {
            this.Cor = cor;
            this.Componente = componente;
        }
    }
}
