using Fiap.TechChallenge.Fase1.Infraestructure.Enum;
using Fiap.TechChallenge.Fase1.SharedKernel;
using FluentValidation;

namespace Fiap.TechChallenge.Fase1.Infraestructure.DTO
{
    public class CriarAlterarUsuarioDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Roles Role { get; set; }
    }

    public class CriarAlterarUsuarioDTOValidator : AbstractValidator<CriarAlterarUsuarioDTO>
    {
        public CriarAlterarUsuarioDTOValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage(MensagemErroUsuario.MENSAGEM_EMAIL_NAO_PODE_SER_VAZIO)
                .NotNull()
                .WithMessage(MensagemErroUsuario.MENSAGEM_EMAIL_NAO_PODE_SER_NULO)
                .EmailAddress()
                .WithMessage(MensagemErroUsuario.MENSAGEM_EMAIL_NAO_ESTA_NO_FORMATO_CORRETO);

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage(MensagemErroUsuario.MENSAGEM_NOME_NAO_PODE_SER_VAZIO)
                .NotNull()
                .WithMessage(MensagemErroUsuario.MENSAGEM_NOME_NAO_PODE_SER_NULO);

            RuleFor(x => x.Role)
                .NotNull()
                .WithMessage(MensagemErroUsuario.MENSAGEM_ROLE_NAO_PODE_SER_NULO);

            RuleFor(x => x.Senha)
                .NotEmpty()
                .WithMessage(MensagemErroUsuario.MENSAGEM_SENHA_NAO_PODE_SER_VAZIO)
                .MinimumLength(10)
                .WithMessage(MensagemErroUsuario.MENSAGEM_SENHA_NAO_PODE_SER_MENOR_QUE_10_CARACTERES)
                .NotNull()
                .WithMessage(MensagemErroUsuario.MENSAGEM_SENHA_NAO_PODE_SER_NULO);
        }
    }
}
