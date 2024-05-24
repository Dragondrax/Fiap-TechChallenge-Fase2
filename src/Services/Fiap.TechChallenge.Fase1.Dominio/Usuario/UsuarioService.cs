using Fiap.TechChallenge.Fase1.Data.Entidades;
using Fiap.TechChallenge.Fase1.Data.Repository;
using Fiap.TechChallenge.Fase1.Dominio.Token;
using Fiap.TechChallenge.Fase1.Infraestructure.DTO;
using Fiap.TechChallenge.Fase1.Infraestructure.DTO.Usuario;
using Fiap.TechChallenge.Fase1.SharedKernel;
using Fiap.TechChallenge.Fase1.SharedKernel.Model;
using static BCrypt.Net.BCrypt;

namespace Fiap.TechChallenge.Fase1.Dominio
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITokenService _tokenService;
        private List<string> _mensagem = new List<string>();
        private const int WorkFactor = 12;

        public UsuarioService(IUsuarioRepository usuarioRepository, ITokenService tokenService)
        {
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService;
        }

        public async Task<ResponseModel> SalvarUsuario(CriarUsuarioDTO usuarioDto)
        {
            var validacao = new CriarUsuarioDTOValidator().Validate(usuarioDto);
            if (!validacao.IsValid)
            {
                _mensagem = validacao.Errors.Select(x => x.ErrorMessage).ToList();
                return new ResponseModel(_mensagem, false, null);
            }

            var usuario = await _usuarioRepository.ObterPorEmailAsync(usuarioDto.Email);
            
            if(usuario is null)
            {
                var hashSenha = await GerarHashSenhaUsuario(usuarioDto.Senha);

                var novoUsuario = new Usuario(usuarioDto.Nome, usuarioDto.Email, hashSenha, usuarioDto.Role);

                await _usuarioRepository.AdicionarAsync(novoUsuario);

                _mensagem.Add(MensagemErroGenerico.MENSAGEM_SUCESSO);

                return new ResponseModel(_mensagem, true, novoUsuario);
            }

            _mensagem.Add(MensagemErroUsuario.MENSAGEM_USUARIO_JA_EXISTENTE);

            return new ResponseModel(_mensagem, false, null);
        }

        public async Task<ResponseModel> AutenticarUsuario(AutenticarUsuarioDTO usuarioDto)
        {
            var validacao = new AutenticarUsuarioDTOValidator().Validate(usuarioDto);
            if (!validacao.IsValid)
            {
                _mensagem = validacao.Errors.Select(x => x.ErrorMessage).ToList();
                return new ResponseModel(_mensagem, false, null);
            }

            var usuario = await _usuarioRepository.ObterPorEmailAsync(usuarioDto.Email);

            if(usuario is not null)
            {
                //Valida Senha
                if(Verify(usuarioDto.Senha, usuario.Senha))
                {
                    var token = await _tokenService.ObterToken(usuarioDto);

                    _mensagem.Add(MensagemErroGenerico.MENSAGEM_SUCESSO);
                    return new ResponseModel(_mensagem, true, token);
                }
            }

            _mensagem.Add(MensagemErroUsuario.MENSAGEM_USUARIO_LOGIN_SENHA_INCORRETA);
            return new ResponseModel(_mensagem, false, null);
        }

        public async Task<string> GerarHashSenhaUsuario(string senha)
        {
            return await Task.FromResult(HashPassword(senha, WorkFactor));
        }
    }
}
