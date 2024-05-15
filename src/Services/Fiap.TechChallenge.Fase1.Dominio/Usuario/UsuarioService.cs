using Fiap.TechChallenge.Fase1.Data.Entidades;
using Fiap.TechChallenge.Fase1.Data.Repository;
using Fiap.TechChallenge.Fase1.Infraestructure.DTO;
using Fiap.TechChallenge.Fase1.SharedKernel.Model;

namespace Fiap.TechChallenge.Fase1.Dominio
{ 
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private List<string> _mensagem = new List<string>();
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            
            _usuarioRepository = usuarioRepository;
        }
        public async Task<ResponseModel> SalvarUsuario(CriarUsuarioDTO usuarioDto)
        {
            var validacao = new CriarUsuarioDTOValidator().Validate(usuarioDto);

            if (!validacao.IsValid)
            {
                _mensagem = validacao.Errors.Select(x => x.ErrorMessage).ToList();
                return new ResponseModel(_mensagem, false, null);
            }

            var usuario = await _usuarioRepository.ObterPorEmail(usuarioDto.Email);
            
            if(usuario is null)
            {
                var novoUsuario = new Usuario(usuarioDto.Nome, usuarioDto.Email, usuarioDto.Senha, usuarioDto.Role);

                await _usuarioRepository.AdicionarAsync(novoUsuario);

                _mensagem.Add("Sucesso");

                return new ResponseModel(_mensagem, true, novoUsuario);
            }

            return new ResponseModel(_mensagem, false, null);
        }
    }
}
