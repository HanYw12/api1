using Microsoft.AspNetCore.Mvc;
using Model;
using Service.Interfaces;

namespace Controllers.UsuarioController
{
    [Route("usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUserService _usuarioService;

        public UsuarioController(IUserService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("Users/{identificacion}")]
        public async Task<ActionResult<List<User>>> GetUsers(string identificacion)
        {
            try
            {
                var result = await _usuarioService.GetUser();
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}


