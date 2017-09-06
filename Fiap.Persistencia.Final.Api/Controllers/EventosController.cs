using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fiap.Persistencia.Final.Core.Data;
using Newtonsoft.Json;
using Fiap.Persistencia.Final.Core.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fiap.Persistencia.Final.Api.Controllers
{
    [Route("api/[controller]")]
    public class EventosController : Controller
    {
        Core.Repository.Versao contextVersion = new Core.Repository.Versao(new Context());
        Core.Repository.Eventos contextEventos = new Core.Repository.Eventos(new Context());

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var result = contextEventos.Listar();
            var teste = JsonConvert.SerializeObject(result);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = contextEventos.Buscar(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post(Eventos entity)
        {
            try
            {
                contextEventos.Incluir(entity);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Eventos entity)
        {
            try
            {
                contextEventos.Atualizar(entity);
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
                var entidade = contextEventos.Buscar(id);
                contextEventos.Remover(entidade);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
