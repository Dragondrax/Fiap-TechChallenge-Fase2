using Fiap.TechChallenge.Fase1.Data.Entidades;
using Fiap.TechChallenge.Fase1.Dominio;
using Fiap.TechChallenge.Fase1.Infraestructure.DTO;
using Fiap.TechChallenge.Fase1.Infraestructure.DTO.Usuario;
using Fiap.TechChallenge.Fase1.SharedKernel;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.TechChallenge.Fase1.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("CriarUsuario")]
        public async Task<IActionResult> SalvarNovoUsuario(CriarUsuarioDTO usuario)
        {
            var resultado = await _usuarioService.SalvarUsuario(usuario);
            if (resultado.Sucesso == true)
                return Ok(resultado);
            else if (resultado.Sucesso == false && resultado.Objeto is null && resultado.Mensagem.Any(x => String.IsNullOrEmpty(x)))
                return StatusCode(500, MensagemErroGenerico.MENSAGEM_ERRO_500);
            else
                return BadRequest(resultado);
        }

        [HttpPost("Autenticar")]
        public async Task<IActionResult> Autenticar(AutenticarUsuarioDTO usuario)
        {
            var resultado = await _usuarioService.AutenticarUsuario(usuario);
            if (resultado.Sucesso == true)
                return Ok(resultado);
            else if (resultado.Sucesso == false && resultado.Objeto is null && resultado.Mensagem.Any(x => String.IsNullOrEmpty(x)))
                return StatusCode(500, MensagemErroGenerico.MENSAGEM_ERRO_500);
            else
                return BadRequest(resultado);
        }

        [HttpPost("BuscarUsuario")]
        public async Task<IActionResult> BuscarUsuario(BuscarUsuarioDTO usuario)
        {
            var resultado = await _usuarioService.BuscarUsuario(usuario);
            if (resultado.Sucesso == true)
                return Ok(resultado);
            else if (resultado.Sucesso == false && resultado.Objeto is null && resultado.Mensagem.Any(x => String.IsNullOrEmpty(x)))
                return StatusCode(500, MensagemErroGenerico.MENSAGEM_ERRO_500);
            else
                return BadRequest(resultado);
        }

        [HttpDelete("RemoverUsuario")]
        public async Task<IActionResult> RemoverUsuario(Guid id)
        {
            var resultado = await _usuarioService.RemoverUsuario(id);
            if (resultado.Sucesso == true)
                return Ok(resultado);
            else if (resultado.Sucesso == false && resultado.Objeto is null && resultado.Mensagem.Any(x => String.IsNullOrEmpty(x)))
                return StatusCode(500, MensagemErroGenerico.MENSAGEM_ERRO_500);
            else
                return BadRequest(resultado);
        }
    }
}
