using Fiap.TechChallenge.Fase1.Infraestructure.DTO;
using Fiap.TechChallenge.Fase1.Infraestructure.DTO.Usuario;
using Fiap.TechChallenge.Fase1.WebAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.TechChallenge.Fase1.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TokenController(ITokenService service) : ControllerBase
{
    private readonly ITokenService _service = service;

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AutenticarUsuarioDTO usuario)
    {
        string token = await _service.GetToken(usuario);

        if(!string.IsNullOrWhiteSpace(token)) 
        {
            return Ok(token);
        }

        return Unauthorized();
    }
}
