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
        IObterTodosAlunosQuerie obterTodosAlunosQuerie) : Controller
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
            return Ok(obterAlunoPorIdentificadorQuerie.Execute(idAluno));
        }

        [HttpGet("obter-todos-alunos")]
        public IActionResult ObterTodosAlunos()
        {
            return Ok(obterTodosAlunosQuerie.Execute());
        }
    }
}
