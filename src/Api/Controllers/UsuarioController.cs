using Application.Usuarios.Commands.RegistraUsuarioInterno;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController(IRegistroUsuarioInternoCommand registroUsuarioInternoCommand) : ControllerBase
    {
        [HttpPost]
        public IActionResult RegistrarUsuarioInterno([FromBody] RegistroUsuarioInternoInputModel inputModel)
        {
            try
            {
                registroUsuarioInternoCommand.Execute(inputModel);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
