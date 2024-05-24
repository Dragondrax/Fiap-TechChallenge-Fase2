using Fiap.TechChallenge.Fase1.Infraestructure.DTO;
using Fiap.TechChallenge.Fase1.Infraestructure.DTO.Usuario;
using Fiap.TechChallenge.Fase1.SharedKernel.Model;

namespace Fiap.TechChallenge.Fase1.Dominio
{
    public interface IUsuarioService
    {
        Task<ResponseModel> SalvarUsuario(CriarUsuarioDTO usuarioDto);
        Task<ResponseModel> AutenticarUsuario(AutenticarUsuarioDTO usuarioDto);
        Task<ResponseModel> BuscarUsuario(BuscarUsuarioDTO usuario);
        Task<ResponseModel> RemoverUsuario(Guid id);
    }
}
