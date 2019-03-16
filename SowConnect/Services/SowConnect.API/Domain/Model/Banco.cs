namespace SowConnect.API.Domain.Model
{
    public class Banco
    {
        public Banco()
        {
            this.Id = 0;
            this.NomeInstituicao = string.Empty;
            this.CodigoInstituicao = string.Empty;
        }

        public int Id { get; set; }
        public string NomeInstituicao { get; set; }
        public string CodigoInstituicao { get; set; }
    }
}