using Fiap.TechChallenge.Fase1.Data.Entidades;
using Fiap.TechChallenge.Fase1.Infraestructure.DTO;
using Fiap.TechChallenge.Fase1.Infraestructure.DTO.Usuario;

namespace Fiap.TechChallenge.Fase1.WebAPI.Interfaces;

public interface ITokenService
{
    Task<string> GetToken(AutenticarUsuarioDTO usuario);
}
