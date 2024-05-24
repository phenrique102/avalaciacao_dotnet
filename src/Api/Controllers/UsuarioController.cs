using Application.Usuarios.Commands.RegistraUsuarioInterno;
using Application.Usuarios.Queries.LoginComCredenciais;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController(IRegistroUsuarioInternoCommand registroUsuarioInternoCommand, ILoginComCredenciaisQuerie loginComCredenciaisQuerie) : ControllerBase
    {
        [HttpPost("registrar-usuario-interno"), AllowAnonymous]
        public IActionResult RegistrarUsuarioInterno([FromBody] RegistroUsuarioInternoInputModel inputModel)
        {
            registroUsuarioInternoCommand.Execute(inputModel);
            return Created();
        }

        [HttpPost("login"), AllowAnonymous]
        public IActionResult Login([FromBody] LoginComCredenciaisInputModel inputModel)
        {
            return Ok(loginComCredenciaisQuerie.Execute(inputModel));
        }
    }
}
