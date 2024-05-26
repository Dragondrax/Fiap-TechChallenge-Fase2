using Fiap.TechChallenge.Fase1.SharedKernel;
using FluentValidation;

namespace Fiap.TechChallenge.Fase1.Infraestructure.DTO.Usuario;

public class BuscarUsuarioDTO
{
    public string Email { get; set; }

    public BuscarUsuarioDTO() { }

    public BuscarUsuarioDTO(string email)
    {
        Email = email;
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
    }
}

