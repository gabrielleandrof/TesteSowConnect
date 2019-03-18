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
    [ApiController]
    public class ContaBancariaController : ControllerBase
    {
        private readonly ConnectionStringConfig _connectionStringConfig;

        public ContaBancariaController(IOptions<ConnectionStringConfig> options)
        {
            _connectionStringConfig = options.Value;
        }

        // GET: api/ContaBancaria/ObterContas
        [HttpGet]
        [Route("ObterContas")]
        public IEnumerable<ContaBancaria> ObterContas()
        {
            ContaBancariaDal dal = new ContaBancariaDal(_connectionStringConfig);
            return dal.ObterContas();
        }

        // GET: api/ContaBancaria/ObterContasPorCliente/5
        [HttpGet]
        [Route("ObterContasPorCliente/{id}")]
        public IEnumerable<ContaBancaria> ObterContasPorCliente(int id)
        {
            ContaBancariaDal dal = new ContaBancariaDal(_connectionStringConfig);
            return dal.ObterContasPorCliente(id);
        }

        // GET: api/ContaBancaria/5
        [HttpGet("{id}")]
        public ContaBancaria ObterConta(int id)
        {
            ContaBancariaDal dal = new ContaBancariaDal(_connectionStringConfig);
            return dal.ObterConta(id);
        }

        // POST: api/ContaBancaria/CriarContaBancaria
        [HttpPost]
        [Route("CriarContaBancaria")]
        public object CriarContaBancaria([FromBody] ContaBancaria conta)
        {
            try
            {
                ContaBancariaDal dal = new ContaBancariaDal(_connectionStringConfig);
                dal.CriarContaBancaria(conta);
                return HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                return HttpStatusCode.InternalServerError;
            }
        }

        // POST: api/ContaBancaria
        [HttpPost]
        [Route("AtualizarSaldo/{id}/{saldo}")]
        public object AtualizarSaldo(int id, decimal saldo)
        {
            try
            {
                ContaBancariaDal dal = new ContaBancariaDal(_connectionStringConfig);
                dal.AtualizarSaldo(id, saldo);
                return HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                return HttpStatusCode.InternalServerError;
            }
        }
    }
}