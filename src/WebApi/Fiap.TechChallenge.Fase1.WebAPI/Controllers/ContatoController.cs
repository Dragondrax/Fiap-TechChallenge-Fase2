using Fiap.TechChallenge.Fase1.Dominio;
using Fiap.TechChallenge.Fase1.Infraestructure.DTO.Contato;
using Fiap.TechChallenge.Fase1.SharedKernel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.TechChallenge.Fase1.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContatoController(IContatoService contatoService) : ControllerBase
{
    private readonly IContatoService _contatoService = contatoService;

    [HttpPost("CriarContato")]
    [Authorize]
    public async Task<IActionResult> SalvarNovoContato([FromBody] CriarContatoDTO contatoDTO)
    {
        var resultado = await _contatoService.SalvarContato(contatoDTO);

        if(resultado.Sucesso)
            return Ok(resultado);
        else if (resultado.Sucesso == false && resultado.Objeto is null && resultado.Mensagem.Any(x => String.IsNullOrEmpty(x)))
            return StatusCode(500, MensagemErroGenerico.MENSAGEM_ERRO_500);
        else
            return BadRequest(resultado);
    }
}
