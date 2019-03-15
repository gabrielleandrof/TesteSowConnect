namespace SowConnect.API.Domain.Model
{
    public class ContaBancaria
    {
        public int Id { get; set; }
        public Banco Banco { get; set; }
        public Cliente Cliente { get; set; }
        public int Agencia { get; set; }
        public int ContaCorrente { get; set; }
        public decimal Saldo { get; set; }
    }
}