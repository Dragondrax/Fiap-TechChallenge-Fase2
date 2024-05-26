using Fiap.TechChallenge.Fase1.Infraestructure.DTO;
using Fiap.TechChallenge.Fase1.Infraestructure.DTO.Usuario;
using Fiap.TechChallenge.Fase1.SharedKernel.Model;

namespace Fiap.TechChallenge.Fase1.Aplicacao
{
    public interface IUsuarioService
    {
        Task<ResponseModel> SalvarUsuario(CriarAlterarUsuarioDTO usuarioDto);
        Task<ResponseModel> AutenticarUsuario(AutenticarUsuarioDTO usuarioDto);
        Task<string> GerarHashSenhaUsuario(string senha);
        Task<ResponseModel> BuscarUsuario(BuscarUsuarioDTO usuarioDTO);
        Task<ResponseModel> AlterarUsuario(CriarAlterarUsuarioDTO usurrioDTO);
        Task<ResponseModel> RemoverUsuario(Guid id);
    }
}
