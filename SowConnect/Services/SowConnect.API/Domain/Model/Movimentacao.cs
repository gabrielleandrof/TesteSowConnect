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
        public int Id { get; set; }
        public TipoMovimentacao TipoMovimentacao { get; set; }
        public int IdContaOrigem { get; set; }
        public int IdContaDestino { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataMovimentacao { get; set; }
    }
}