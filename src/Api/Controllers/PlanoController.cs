using Application.Planos.Commands.ApagarPlanoSimples;
using Application.Planos.Commands.AtualizarPlanoSimples;
using Application.Planos.Commands.RegistraPlanoSimples;
using Application.Planos.Queries.ObterPlanoPorIdentificador;
using Application.Planos.Queries.ObterTodosPlanos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PlanoController(
        IRegistraPlanoSimplesCommand registraPlanoSimplesCommand, 
        IAtualizarPlanoSimplesCommand atualizarPlanoSimplesCommand, 
        IObterPlanoPorIdentificadorQuerie obterPlanoPorIdentificadorQuerie,
        IObterTodosPlanosQuerie obterTodosPlanosQuerie,
        IApagarPlanoSimplesCommand apagarPlanoSimplesCommand) : Controller
    {
        [HttpPost("registra-plano-simples")]
        public IActionResult RegistraPlanoSimples([FromBody] RegistraPlanoSimplesInputModel inputModel)
        {
            registraPlanoSimplesCommand.Execute(inputModel);
            return Created();
        }

        [HttpPut("atualiza-plano-simples")]
        public IActionResult AtualizaPlanoSimples([FromBody] AtualizarPlanoSimplesInputModel inputModel)
        {
            atualizarPlanoSimplesCommand.Execute(inputModel);
            return Ok();
        }

        [HttpGet("obter-plano-por-identificado")]
        public IActionResult ObterPlanoPorIdentificado([FromQuery] int idPlano)
        {
            var plano = obterPlanoPorIdentificadorQuerie.Execute(idPlano);
            if (plano == null)
            {
                return NotFound();
            }

            return Ok(plano);
        }

        [HttpGet("obter-todos-planos")]
        public IActionResult ObterTodosPlanos()
        {
            var planos = obterTodosPlanosQuerie.Execute();
            if (planos == null)
            {
                return NotFound();
            }

            return Ok(planos);
        }

        [HttpDelete("apagar-plano-simples/{id}")]
        public IActionResult ApagarPlanoSimples([FromRoute] int id)
        {
            apagarPlanoSimplesCommand.Execute(id);
            return NoContent();
        }
    }
}
