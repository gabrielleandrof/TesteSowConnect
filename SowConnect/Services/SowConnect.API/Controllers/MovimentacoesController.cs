using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SowConnect.API.Config;
using SowConnect.API.Domain.Data;
using SowConnect.API.Domain.Model;
using System;
using System.Net;

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
        public object Post([FromBody]Movimentacao movimentacao)
        {
            try
            {
                MovimentacaoDal dal = new MovimentacaoDal(_connectionStringConfig);
                dal.InserirMovimentacao(movimentacao);
                return HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                return HttpStatusCode.InternalServerError;
            }
        }
    }
}