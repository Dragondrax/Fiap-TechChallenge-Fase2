using Fiap.TechChallenge.Fase1.SharedKernel;
using Fiap.TechChallenge.Fase1.SharedKernel.MensagensErro;
using FluentValidation;
using System.Linq;

namespace Fiap.TechChallenge.Fase1.Infraestructure.DTO.Contato;

public class CriarAlterarContatoDTO
{
    public string Nome { get; set; }
    public int DDD { get; set; }
    public string Telefone { get;  set; }
    public string Email { get; set; }

    public CriarAlterarContatoDTO() { }

    public CriarAlterarContatoDTO(string nome, int ddd, string telefone, string email)
    {
        Nome = nome;
        DDD = ddd;
        Telefone = telefone;
        Email = email;
    }
}

public class CriarContatoDTOValidator : AbstractValidator<CriarAlterarContatoDTO>
{
    public CriarContatoDTOValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage(MensagemErroContato.MENSAGEM_NOME_NAO_PODE_SER_VAZIO)
            .NotNull()
            .WithMessage(MensagemErroContato.MENSAGEM_NOME_NAO_PODE_SER_NULO);

        RuleFor(x => x.DDD)
            .NotNull()
            .WithMessage(MensagemErroContato.MENSAGEM_DDD_NAO_PODE_SER_NULO)
            .Must(ddd => DDDValidator.DDDsValidos.Contains(ddd.ToString()))
            .WithMessage(MensagemErroContato.MENSAGEM_DDD_INVALIDO);

        RuleFor(x => x.Telefone)
            .NotEmpty()
            .WithMessage(MensagemErroContato.MENSAGEM_TELEFONE_NAO_PODE_SER_VAZIO)
            .NotNull()
            .WithMessage(MensagemErroContato.MENSAGEM_TELEFONE_NAO_PODE_SER_NULO)
            .MinimumLength(8)
            .WithMessage(MensagemErroContato.MENSAGEM_TELEFONE_MINIMO_OITO_CARACTERES);

        RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage(MensagemErroContato.MENSAGEM_EMAIL_NAO_PODE_SER_VAZIO)
                .NotNull()
                .WithMessage(MensagemErroContato.MENSAGEM_EMAIL_NAO_PODE_SER_NULO)
                .EmailAddress()
                .WithMessage(MensagemErroContato.MENSAGEM_EMAIL_NAO_ESTA_NO_FORMATO_CORRETO);
    }
}

public static class DDDValidator
{
    public static readonly HashSet<string> DDDsValidos = new()
    {
        "0", "11", "12", "13", "14", "15", "16", "17", "18", "19",
        "21", "22", "24",
        "27", "28",
        "31", "32", "33", "34", "35", "37", "38",
        "41", "42", "43", "44", "45", "46",
        "47", "48", "49",
        "51", "53", "54", "55",
        "61",
        "62", "64",
        "63",
        "65", "66",
        "67",
        "68",
        "69",
        "71", "73", "74", "75", "77",
        "79",
        "81", "87",
        "82",
        "83",
        "84",
        "85", "88",
        "86", "89",
        "91", "93", "94",
        "92", "97",
        "95",
        "96",
        "98", "99"
    };
}
