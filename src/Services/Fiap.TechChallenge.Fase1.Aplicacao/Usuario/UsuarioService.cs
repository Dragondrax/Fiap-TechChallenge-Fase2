using Fiap.TechChallenge.Fase1.Data.Repository;
using Fiap.TechChallenge.Fase1.Dominio;
using Fiap.TechChallenge.Fase1.Dominio.Entidades;
using Fiap.TechChallenge.Fase1.Infraestructure.DTO;
using Fiap.TechChallenge.Fase1.Infraestructure.DTO.Usuario;
using Fiap.TechChallenge.Fase1.Infraestructure.Enum;
using Fiap.TechChallenge.Fase1.SharedKernel;
using Fiap.TechChallenge.Fase1.SharedKernel.Model;
using static BCrypt.Net.BCrypt;

namespace Fiap.TechChallenge.Fase1.Aplicacao
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

        public async Task<ResponseModel> SalvarUsuario(CriarAlterarUsuarioDTO usuarioDTO)
        {
            var validacao = new CriarAlterarUsuarioDTOValidator().Validate(usuarioDTO);
            if (!validacao.IsValid)
            {
                _mensagem = validacao.Errors.Select(x => x.ErrorMessage).ToList();
                return new ResponseModel(_mensagem, false, null);
            }

            var usuario = await _usuarioRepository.ObterPorEmailAsync(usuarioDTO.Email.ToLower());

            if (usuario is null)
            {
                var hashSenha = await GerarHashSenhaUsuario(usuarioDTO.Senha);

                Usuario novoUsuario = new (usuarioDTO.Nome, usuarioDTO.Email.ToLower(), hashSenha, usuarioDTO.Role);

                await _usuarioRepository.AdicionarAsync(novoUsuario);

                UsuarioDTO exibeUsuario = new (novoUsuario.Id, novoUsuario.Nome, novoUsuario.Email.ToLower(), novoUsuario.Role);

                _mensagem.Add(MensagemErroGenerico.MENSAGEM_SUCESSO);
                return new ResponseModel(_mensagem, true, exibeUsuario);
            }

            _mensagem.Add(MensagemErroUsuario.MENSAGEM_USUARIO_JA_EXISTENTE);
            return new ResponseModel(_mensagem, false, null);
        }

        public async Task<ResponseModel> AutenticarUsuario(AutenticarUsuarioDTO usuarioDTO)
        {
            var validacao = new AutenticarUsuarioDTOValidator().Validate(usuarioDTO);
            if (!validacao.IsValid)
            {
                _mensagem = validacao.Errors.Select(x => x.ErrorMessage).ToList();
                return new ResponseModel(_mensagem, false, null);
            }

            var usuario = await _usuarioRepository.ObterPorEmailAsync(usuarioDTO.Email.ToLower());

            if (usuario is not null)
            {
                //Valida Senha
                if (Verify(usuarioDTO.Senha, usuario.Senha))
                {
                    var token = await _tokenService.ObterToken(usuarioDTO);

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

        public async Task<ResponseModel> BuscarUsuarioPorEmail(BuscarUsuarioDTO usuarioDTO)
        {
            var validacao = new BuscarUsuarioDTOValidator().Validate(usuarioDTO);
            if (!validacao.IsValid)
            {
                _mensagem = validacao.Errors.Select(x => x.ErrorMessage).ToList();
                return new ResponseModel(_mensagem, false, null);
            }

            var usuarioValido = await _usuarioRepository.ObterPorEmailAsync(usuarioDTO.Email.ToLower());

            if (usuarioValido is not null)
            {
                UsuarioDTO exibeUsuario = new (usuarioValido.Id, usuarioValido.Nome, usuarioValido.Email.ToLower(), usuarioValido.Role);

                _mensagem.Add(MensagemErroGenerico.MENSAGEM_SUCESSO);
                return new ResponseModel(_mensagem, true, exibeUsuario);
            }

            _mensagem.Add(MensagemErroUsuario.MENSAGEM_USUARIO_NAO_ENCONTRADO);
            return new ResponseModel(_mensagem, false, null);
        }

        public async Task<ResponseModel> AlterarUsuario(CriarAlterarUsuarioDTO usuarioDTO)
        {
            var validacao = new CriarAlterarUsuarioDTOValidator().Validate(usuarioDTO);
            if (!validacao.IsValid)
            {
                _mensagem = validacao.Errors.Select(x => x.ErrorMessage).ToList();
                return new ResponseModel(_mensagem, false, null);
            }

            var usuario = await _usuarioRepository.ObterPorEmailAsync(usuarioDTO.Email.ToLower());

            if (usuario is not null)
            {
                if (usuario.Role == Roles.Administrador)
                {
                    _mensagem.Add(MensagemErroUsuario.MENSAGEM_NAO_ALTERAR_ESSE_USUARIO);
                    return new ResponseModel(_mensagem, false, null);
                }

                var hashSenha = await GerarHashSenhaUsuario(usuarioDTO.Senha);

                usuario.AlterarUsuario(usuarioDTO.Nome, usuarioDTO.Email.ToLower(), hashSenha, usuarioDTO.Role);

                await _usuarioRepository.AtualizarAsync(usuario);

                UsuarioDTO exibeUsuario = new (usuario.Id, usuario.Nome, usuario.Email.ToLower(), usuario.Role);

                _mensagem.Add(MensagemErroGenerico.MENSAGEM_SUCESSO);
                return new ResponseModel(_mensagem, true, exibeUsuario);
            }

            _mensagem.Add(MensagemErroUsuario.MENSAGEM_USUARIO_JA_EXISTENTE);
            return new ResponseModel(_mensagem, false, null);
        }

        public async Task<ResponseModel> RemoverUsuario(Guid id)
        {        
            var usuario = await _usuarioRepository.ObterPorIdAsync(id);

            if (usuario is not null)
            {
                if (usuario.Role == Roles.Administrador)
                {
                    _mensagem.Add(MensagemErroUsuario.MENSAGEM_NAO_REMOVER_ESSE_USUARIO);
                    return new ResponseModel(_mensagem, false, null);
                }

                usuario.ExcluirUsuario();

                await _usuarioRepository.RemoverAsync(usuario);

                UsuarioDTO exibeUsuario = new (usuario.Id, usuario.Nome, usuario.Email.ToLower(), usuario.Role);

                _mensagem.Add(MensagemErroGenerico.MENSAGEM_SUCESSO);
                return new ResponseModel(_mensagem, true, exibeUsuario);
            }

            _mensagem.Add(MensagemErroUsuario.MENSAGEM_USUARIO_NAO_ENCONTRADO);
            return new ResponseModel(_mensagem, false, null);
        }
    }
}
