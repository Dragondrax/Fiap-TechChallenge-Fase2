using Fiap.TechChallenge.Fase1.Infraestructure.DTO.Usuario;

namespace Fiap.TechChallenge.Fase1.Dominio
{
    public interface ITokenService
    {
        Task<string> ObterToken(AutenticarUsuarioDTO usuario);
    }
}
