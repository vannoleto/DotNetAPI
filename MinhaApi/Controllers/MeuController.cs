using Microsoft.AspNetCore.Mvc;
using MinhaApi.Models;
using MinhaApi.Services.Interfaces;

namespace MinhaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeuController : ControllerBase
    {
        private readonly IMeuServico _meuServico;

        public MeuController(IMeuServico meuServico)
        {
            _meuServico = meuServico;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MeuModelo>> Get()
        {
            var modelos = _meuServico.ObterTodos();
            return Ok(modelos);
        }

        [HttpGet("{id}")]
        public ActionResult<MeuModelo> Get(int id)
        {
            var modelo = _meuServico.ObterPorId(id);
            if (modelo == null)
            {
                return NotFound();
            }
            return Ok(modelo);
        }

        [HttpPost]
        public ActionResult<MeuModelo> Post([FromBody] MeuModelo modelo)
        {
            if (modelo == null)
            {
                return BadRequest();
            }
            _meuServico.Criar(modelo);
            return CreatedAtAction(nameof(Get), new { id = modelo.Id }, modelo);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] MeuModelo modelo)
        {
            if (id != modelo.Id)
            {
                return BadRequest();
            }
            _meuServico.Atualizar(modelo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var modelo = _meuServico.ObterPorId(id);
            if (modelo == null)
            {
                return NotFound();
            }
            _meuServico.Excluir(id);
            return NoContent();
        }
    }
}