using System;

namespace SowConnect.API.Domain.Model
{
    public enum TipoMovimentacao : int
    {
        Debito = 0,
        Credito = 1,
        Transferencia = 2
    }

    public class Movimentacao
    {
        public TipoMovimentacao TipoMovimentacao { get; set; }
        public ContaBancaria ContaOrigem { get; set; }
        public ContaBancaria ContaDestino { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataMovimentacao { get; set; }
    }
}