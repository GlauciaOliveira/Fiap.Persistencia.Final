using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fiap.Persistencia.Final.Core.Data;
using Fiap.Persistencia.Final.Core.Models;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fiap.Persistencia.Final.Api.Controllers
{
    [Route("api/[controller]")]
    public class VersaoController : Controller
    {
        Core.Repository.Versao contextVersion = new Core.Repository.Versao(new Context());

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var result = contextVersion.Listar();
            //var teste = JsonConvert.SerializeObject(result);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = contextVersion.Buscar(id);
            
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post(Versao entity)
        {
            try
            {
                contextVersion.Incluir(entity);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Versao entity)
        {
            try
            {
                contextVersion.Atualizar(entity);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var entidade = contextVersion.Buscar(id);
                contextVersion.Remover(entidade);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
