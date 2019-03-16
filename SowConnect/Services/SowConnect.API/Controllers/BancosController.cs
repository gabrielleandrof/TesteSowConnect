using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SowConnect.API.Config;
using SowConnect.API.Domain.Data;
using SowConnect.API.Domain.Model;

namespace SowConnect.API.Controllers
{
    [Route("api/[controller]")]
    public class BancosController : Controller
    {
        private readonly ConnectionStringConfig _connectionStringConfig;

        public BancosController(IOptions<ConnectionStringConfig> options)
        {
            _connectionStringConfig = options.Value;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Banco> ObterBancos()
        {
            BancoDal dal = new BancoDal(_connectionStringConfig);
            return dal.ObterBancos();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Banco ObterBanco(int id)
        {
            BancoDal dal = new BancoDal(_connectionStringConfig);
            return dal.ObterBanco(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void InserirBanco([FromBody]string value)
        {
            BancoDal dal = new BancoDal(_connectionStringConfig);
            Banco banco = new Banco();
            banco.NomeInstituicao = "Teste S.A.";
            banco.CodigoInstituicao = 1234;
            dal.InserirBanco(banco);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
