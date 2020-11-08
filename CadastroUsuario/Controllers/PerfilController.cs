using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroUsuario.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class PerfilController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                Mensagem = "A Requisição deu certo!"
            });
        } 
    }
}
