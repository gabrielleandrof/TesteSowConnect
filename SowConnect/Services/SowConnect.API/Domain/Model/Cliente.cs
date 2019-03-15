namespace SowConnect.API.Domain.Model
{
    public enum TipoCliente : int
    {
        PF = 0,
        PJ = 1
    }

    public class Cliente
    {
        public TipoCliente TipoCliente { get; set; }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
    }
}