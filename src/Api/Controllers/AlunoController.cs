using Application.Alunos.Commands.ApagarAlunoComPlano;
using Application.Alunos.Commands.AtualizaAlunoComPlano;
using Application.Alunos.Commands.RegistraAlunoComPlano;
using Application.Alunos.Queries.ObterAlunoPorIdentificador;
using Application.Alunos.Queries.ObterTodosAlunos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController(
        IRegistraAlunoComPlanoCommand registraAlunoComPlanoCommand, 
        IAtualizaAlunoComPlanoCommand atualizaAlunoComPlanoCommand, 
        IObterAlunoPorIdentificadorQuerie obterAlunoPorIdentificadorQuerie,
        IObterTodosAlunosQuerie obterTodosAlunosQuerie,
        IApagarAlunoComPlanoCommand apagarAlunoComPlanoCommand) : Controller
    {
        [HttpPost("registra-aluno-com-plano")]
        public IActionResult RegistraAlunoComPlano([FromBody] RegistraAlunoComPlanoInputModel inputModel)
        {
            registraAlunoComPlanoCommand.Execute(inputModel);
            return Created();
        }

        [HttpPut("atualiza-aluno-com-plano")]
        public IActionResult AtualizaAlunoComPlano([FromBody] AtualizaAlunoComPlanoInputModel inputModel)
        {
            atualizaAlunoComPlanoCommand.Execute(inputModel);
            return Ok();
        }

        [HttpGet("obter-aluno-por-identificador")]
        public IActionResult ObterAlunoPorIdentificador([FromQuery] int idAluno)
        {
            var aluno = obterAlunoPorIdentificadorQuerie.Execute(idAluno);
            if (aluno == null)
            {
                return NotFound();
            }

            return Ok(aluno);
        }

        [HttpGet("obter-todos-alunos")]
        public IActionResult ObterTodosAlunos()
        {
            var alunos = obterTodosAlunosQuerie.Execute();
            if (alunos == null)
            {
                return NotFound();
            }

            return Ok(alunos);
        }

        [HttpDelete("apagar-aluno-com-plano/{id}")]
        public IActionResult ApagarAlunoComPlano([FromRoute] int id)
        {
            apagarAlunoComPlanoCommand.Execute(id);
            return NoContent();
        }
    }
}
