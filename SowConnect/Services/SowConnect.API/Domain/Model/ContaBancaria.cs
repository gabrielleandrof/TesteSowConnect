namespace SowConnect.API.Domain.Model
{
    public class ContaBancaria
    {
        public ContaBancaria()
        {
            this.Id = 0;
            this.IdBanco = 0;
            this.IdCliente = 0;
            this.Agencia = 0;
            this.ContaCorrente = 0;
            this.Saldo = 0;
        }

        public int Id { get; set; }
        public int IdBanco { get; set; }
        public int IdCliente { get; set; }
        public int Agencia { get; set; }
        public int ContaCorrente { get; set; }
        public decimal Saldo { get; set; }
    }
}