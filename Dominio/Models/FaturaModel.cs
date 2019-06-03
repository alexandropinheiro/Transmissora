using System;

namespace Dominio.Models
{
    public class FaturaModel
    {
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public string UrlBoleto { get; set; }
        public string UrlNotaFiscal { get; set; }
        public int IdTransmissora { get; set; }
    }
}
