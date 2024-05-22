﻿using Fiap.TechChallenge.Fase1.Data.Entidades;
using Fiap.TechChallenge.Fase1.Data.Repository;
using Fiap.TechChallenge.Fase1.Infraestructure.DTO;
using Fiap.TechChallenge.Fase1.Infraestructure.DTO.Usuario;
using Fiap.TechChallenge.Fase1.Infraestructure.Enum;
using Fiap.TechChallenge.Fase1.SharedKernel;
using Fiap.TechChallenge.Fase1.SharedKernel.Model;
using static BCrypt.Net.BCrypt;

namespace Fiap.TechChallenge.Fase1.Dominio
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private List<string> _mensagem = new List<string>();
        private const int WorkFactor = 12;
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

            var usuario = await _usuarioRepository.ObterPorEmailAsync(usuarioDto.Email.ToLower());

            if (usuario is null)
            {
                var hashSenha = await GerarHashSenhaUsuario(usuarioDto.Senha);

                var novoUsuario = new Usuario(usuarioDto.Nome, usuarioDto.Email.ToLower(), hashSenha, usuarioDto.Role);

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

            var usuario = await _usuarioRepository.ObterPorEmailAsync(usuarioDto.Email.ToLower());

            if (usuario is not null)
            {
                //Valida Senha
                if (Verify(usuarioDto.Senha, usuario.Senha))
                {
                    var token = ""; //gerar token com os dados

                    _mensagem.Add(MensagemErroGenerico.MENSAGEM_SUCESSO);
                    return new ResponseModel(_mensagem, true, token);
                }
            }

            _mensagem.Add(MensagemErroUsuario.MENSAGEM_USUARIO_LOGIN_SENHA_INCORRETA);
            return new ResponseModel(_mensagem, false, null);
        }
        private async Task<string> GerarHashSenhaUsuario(string senha)
        {
            return await Task.FromResult(HashPassword(senha, WorkFactor));
        }
        public async Task<ResponseModel> BuscarUsuario(string email)
        {
            var usuario = await _usuarioRepository.ObterPorEmailAsync(email.ToLower());

            if (usuario is not null)
            {
                var exibeUsuario = new UsuarioDTO(usuario.Nome, usuario.Email.ToLower(), usuario.Role);

                _mensagem.Add(MensagemErroGenerico.MENSAGEM_SUCESSO);
                return new ResponseModel(_mensagem, true, exibeUsuario);
            }

            _mensagem.Add(MensagemErroUsuario.MENSAGEM_USUARIO_NAO_ENCONTRADO);
            return new ResponseModel(_mensagem, false, null);
        }
        public async Task<ResponseModel> RemoverUsuario(string email)
        {
            var usuario = await _usuarioRepository.ObterPorEmailAsync(email.ToLower());

            if (usuario is not null)
            {
                if (usuario.Role == Roles.Administrador)
                {
                    _mensagem.Add(MensagemErroUsuario.MENSAGEM_NAO_REMOVER_ESSE_USUARIO);
                    return new ResponseModel(_mensagem, false, null);
                }

                usuario.ExcluirUsuario();

                await _usuarioRepository.RemoverAsync(usuario);

                _mensagem.Add(MensagemErroGenerico.MENSAGEM_SUCESSO);
                return new ResponseModel(_mensagem, true, usuario);
            }

            _mensagem.Add(MensagemErroUsuario.MENSAGEM_USUARIO_NAO_ENCONTRADO);
            return new ResponseModel(_mensagem, false, null);
        }
    }
}
