using Dominio.Base;
using System;

namespace Dominio.Entidades
{
    public class Fatura : EntidadeBase
    {
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }        
        public string UrlBoleto { get; set; }
        public string UrlNotaFiscal { get; set; }
        public Guid IdTransmissora { get; set; }
        public Transmissora Transmissora { get; set; }
    }
}
