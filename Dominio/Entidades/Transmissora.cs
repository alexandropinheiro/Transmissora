using Dominio.Base;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Transmissora : EntidadeBase
    {
        public string Nome{ get; set; }
        public string Ons { get; set; }
        public ICollection<Fatura> Faturas { get; set; }
    }
}
