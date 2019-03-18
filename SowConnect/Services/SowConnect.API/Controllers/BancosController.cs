using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SowConnect.API.Config;
using SowConnect.API.Domain.Data;
using SowConnect.API.Domain.Model;
using System;
using System.Collections.Generic;
using System.Net;

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
        public object InserirBanco([FromBody]Banco banco)
        {
            try
            {
                BancoDal dal = new BancoDal(_connectionStringConfig);
                dal.InserirBanco(banco);
                return HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                return HttpStatusCode.InternalServerError;
            }
        }
    }
}