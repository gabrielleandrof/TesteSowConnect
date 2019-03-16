namespace SowConnect.API.Domain.Model
{
    public enum TipoCliente : int
    {
        PF = 0,
        PJ = 1
    }

    public class Cliente
    {
        public Cliente()
        {
            this.Id = 0;
            this.IdBanco = 0;
            this.TipoCliente = 0;
            this.Nome = string.Empty;
        }

        public int Id { get; set; }
        public int IdBanco { get; set; }
        public TipoCliente TipoCliente { get; set; }
        public string Nome { get; set; }
    }
}