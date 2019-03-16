using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SowConnect.API.Config;
using SowConnect.API.Domain.Data;
using SowConnect.API.Domain.Model;
using System.Collections.Generic;

namespace SowConnect.API.Controllers
{
    [Route("api/[controller]")]
    public class ClientesController : Controller
    {
        private readonly ConnectionStringConfig _connectionStringConfig;

        public ClientesController(IOptions<ConnectionStringConfig> options)
        {
            _connectionStringConfig = options.Value;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Cliente> ObterClientes()
        {
            ClienteDal dal = new ClienteDal(_connectionStringConfig);
            return dal.ObterClientes();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Cliente ObterCliente(int id)
        {
            ClienteDal dal = new ClienteDal(_connectionStringConfig);
            return dal.ObterCliente(id);
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("ObterClientePorBanco/{id}")]
        public IEnumerable<Cliente> ObterClientePorBanco(int id)
        {
            ClienteDal dal = new ClienteDal(_connectionStringConfig);
            return dal.ObterClientesPorBanco(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void InserirCliente([FromBody]Cliente cliente)
        {
            ClienteDal dal = new ClienteDal(_connectionStringConfig);
            dal.InserirCliente(cliente);
        }
    }
}