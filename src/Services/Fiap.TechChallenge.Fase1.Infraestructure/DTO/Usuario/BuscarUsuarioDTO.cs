using Fiap.TechChallenge.Fase1.Infraestructure.Enum;
using Fiap.TechChallenge.Fase1.SharedKernel;
using FluentValidation;

namespace Fiap.TechChallenge.Fase1.Infraestructure.DTO.Usuario
{
    public class BuscarUsuarioDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public Roles Role { get; set; }

        public BuscarUsuarioDTO(string nome, string email, Roles role)
        {
            Nome = nome;
            Email = email;
            Role = role;
        }
    }

    public class BuscarUsuarioDTOValidator : AbstractValidator<BuscarUsuarioDTO>
    {
        public BuscarUsuarioDTOValidator()
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
        }
    }
}
