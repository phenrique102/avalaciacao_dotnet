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
        IObterTodosPlanosQuerie obterTodosPlanosQuerie) : Controller
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
            return Ok(obterPlanoPorIdentificadorQuerie.Execute(idPlano));
        }

        [HttpGet("obter-todos-planos")]
        public IActionResult ObterTodosPlanos()
        {
            return Ok(obterTodosPlanosQuerie.Execute());
        }
    }
}
