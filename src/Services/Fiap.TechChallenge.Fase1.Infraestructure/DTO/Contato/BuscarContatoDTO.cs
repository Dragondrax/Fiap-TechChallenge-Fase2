using Fiap.TechChallenge.Fase1.SharedKernel.MensagensErro;
using FluentValidation;

namespace Fiap.TechChallenge.Fase1.Infraestructure.DTO.Contato;

public class BuscarContatoDTO
{
    public string Email { get; set; }

    public BuscarContatoDTO() { }

    public BuscarContatoDTO(string email)
    {
        Email = email;
    }
}

public class BuscarContatoDTOValidator : AbstractValidator<BuscarContatoDTO>
{
    public BuscarContatoDTOValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage(MensagemErroContato.MENSAGEM_EMAIL_NAO_PODE_SER_VAZIO)
            .NotNull()
            .WithMessage(MensagemErroContato.MENSAGEM_EMAIL_NAO_PODE_SER_NULO)
            .EmailAddress()
            .WithMessage(MensagemErroContato.MENSAGEM_EMAIL_NAO_ESTA_NO_FORMATO_CORRETO);
    }
}
