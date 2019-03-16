namespace SowConnect.API.Domain.Model
{
    public class ContaBancaria
    {
        public ContaBancaria()
        {
            this.Id = 0;
            this.IdBanco = 0;
            this.IdCliente = 0;
            this.Agencia = string.Empty;
            this.ContaCorrente = string.Empty;
            this.Saldo = 0;
        }

        public int Id { get; set; }
        public int IdBanco { get; set; }
        public int IdCliente { get; set; }
        public string Agencia { get; set; }
        public string ContaCorrente { get; set; }
        public decimal Saldo { get; set; }
    }
}