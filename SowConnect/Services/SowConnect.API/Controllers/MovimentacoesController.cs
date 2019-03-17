using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SowConnect.API.Config;
using SowConnect.API.Domain.Data;
using SowConnect.API.Domain.Model;

namespace SowConnect.API.Controllers
{
    [Route("api/[controller]")]
    public class MovimentacoesController : Controller
    {
        private readonly ConnectionStringConfig _connectionStringConfig;

        public MovimentacoesController(IOptions<ConnectionStringConfig> options)
        {
            _connectionStringConfig = options.Value;
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Movimentacao movimentacao)
        {
            MovimentacaoDal dal = new MovimentacaoDal(_connectionStringConfig);
            dal.InserirMovimentacao(movimentacao);
        }
    }
}