using Fiap.TechChallenge.Fase1.SharedKernel;
using FluentValidation;

namespace Fiap.TechChallenge.Fase1.Infraestructure.DTO.Usuario
{
    public class AutenticarUsuarioDTO
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }

    public class AutenticarUsuarioDTOValidator : AbstractValidator<AutenticarUsuarioDTO>
    {
        public AutenticarUsuarioDTOValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage(MensagemErroUsuario.MENSAGEM_EMAIL_NAO_PODE_SER_VAZIO)
                .NotNull()
                .WithMessage(MensagemErroUsuario.MENSAGEM_EMAIL_NAO_PODE_SER_NULO)
                .EmailAddress()
                .WithMessage(MensagemErroUsuario.MENSAGEM_EMAIL_NAO_ESTA_NO_FORMATO_CORRETO);

            RuleFor(x => x.Senha)
                .NotEmpty()
                .WithMessage(MensagemErroUsuario.MENSAGEM_SENHA_NAO_PODE_SER_VAZIO)
                .NotNull()
                .WithMessage(MensagemErroUsuario.MENSAGEM_SENHA_NAO_PODE_SER_NULO);
        }
    }
}
