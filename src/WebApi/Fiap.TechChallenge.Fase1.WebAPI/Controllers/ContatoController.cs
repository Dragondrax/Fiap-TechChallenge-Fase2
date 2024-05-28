using Fiap.TechChallenge.Fase1.Dominio;
using Fiap.TechChallenge.Fase1.Infraestructure.DTO.Contato;
using Fiap.TechChallenge.Fase1.SharedKernel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.TechChallenge.Fase1.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ContatoController(IContatoService contatoService) : ControllerBase
{
    private readonly IContatoService _contatoService = contatoService;

    [HttpPost("CriarContato")]
    public async Task<IActionResult> SalvarNovoContato([FromBody] CriarAlterarContatoDTO contatoDTO)
    {
        var resultado = await _contatoService.SalvarContato(contatoDTO);

        if(resultado.Sucesso)
            return Ok(resultado);
        else if (resultado.Sucesso == false && resultado.Objeto is null && resultado.Mensagem.Any(x => String.IsNullOrEmpty(x)))
            return StatusCode(500, MensagemErroGenerico.MENSAGEM_ERRO_500);
        else
            return BadRequest(resultado);
    }


    [HttpGet("FiltrarPorDDD/{DDD}")]
    public async Task<IActionResult> BuscarContatosPorDDD(int DDD)
    {
        var resultado = await _contatoService.BuscarContatosPorDDD(DDD);

        if (resultado.Sucesso)
            return Ok(resultado);
        else if (resultado.Sucesso == false && resultado.Objeto is null && resultado.Mensagem.Any(x => string.IsNullOrEmpty(x)))
            return StatusCode(500, MensagemErroGenerico.MENSAGEM_ERRO_500);
        else if (resultado.Sucesso == false && resultado.Objeto is null && resultado.Mensagem.Contains("Ops, o ddd informado não existe!"))
            return BadRequest(resultado);
        else
            return NotFound(resultado);  
    }

    [HttpPost("BuscarContatoPorEmail")]
    public async Task<IActionResult> BuscarContatoPorEmail(BuscarContatoDTO contatoDTO)
    {
        var resultado = await _contatoService.BuscarContatoPorEmail(contatoDTO);

        if (resultado.Sucesso)
            return Ok(resultado);
        else if (resultado.Sucesso == false && resultado.Objeto is null && resultado.Mensagem.Any(x => string.IsNullOrEmpty(x)))
            return StatusCode(500, MensagemErroGenerico.MENSAGEM_ERRO_500);
        else if (resultado.Sucesso == false && resultado.Objeto is null && resultado.Mensagem.Contains("Ops, email não foi encontrado em nosso banco de dados!"))
            return NotFound(resultado);
        else 
            return BadRequest(resultado);
    }

    [HttpPut("AlterarContato")]
    public async Task<IActionResult> AtualizarContato(CriarAlterarContatoDTO contatoDTO)
    {
        var resultado = await _contatoService.AlterarContato(contatoDTO);

        if (resultado.Sucesso)
            return Ok(resultado);
        else if (resultado.Sucesso == false && resultado.Objeto is null && resultado.Mensagem.Any(x => string.IsNullOrEmpty(x)))
            return StatusCode(500, MensagemErroGenerico.MENSAGEM_ERRO_500);
        else if (resultado.Sucesso == false && resultado.Objeto is null && resultado.Mensagem.Contains("Ops, email não foi encontrado em nosso banco de dados!"))
            return NotFound(resultado);
        else
            return BadRequest(resultado);
    }

    [HttpDelete("RemoverContato")]
    public async Task<IActionResult> RemoverContato(Guid id)
    {
        var resultado = await _contatoService.RemoverContato(id);

        if (resultado.Sucesso)
            return Ok(resultado);
        else if (resultado.Sucesso == false && resultado.Objeto is null && resultado.Mensagem.Any(x => string.IsNullOrEmpty(x)))
            return StatusCode(500, MensagemErroGenerico.MENSAGEM_ERRO_500);
        else if (resultado.Sucesso == false && resultado.Objeto is null && resultado.Mensagem.Contains("Ops, parece que não encontramos o contato em nossa base de dados!"))
            return NotFound(resultado);
        else
            return BadRequest(resultado);
    }
}
