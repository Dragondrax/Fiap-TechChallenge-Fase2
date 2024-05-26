using Fiap.TechChallenge.Fase1.Infraestructure.DTO;
using Fiap.TechChallenge.Fase1.Infraestructure.DTO.Usuario;
using Fiap.TechChallenge.Fase1.SharedKernel.Model;

namespace Fiap.TechChallenge.Fase1.Aplicacao
{
    public interface IUsuarioService
    {
        Task<ResponseModel> SalvarUsuario(CriarAlterarUsuarioDTO usuarioDTO);
        Task<ResponseModel> AutenticarUsuario(AutenticarUsuarioDTO usuarioDTO);
        Task<string> GerarHashSenhaUsuario(string senha);
        Task<ResponseModel> BuscarUsuarioPorEmail(BuscarUsuarioDTO usuarioDTO);
        Task<ResponseModel> AlterarUsuario(CriarAlterarUsuarioDTO usuarioDTO);
        Task<ResponseModel> RemoverUsuario(Guid id);
    }
}
