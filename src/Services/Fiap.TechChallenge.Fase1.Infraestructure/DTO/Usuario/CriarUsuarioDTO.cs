using Fiap.TechChallenge.Fase1.Infraestructure.Enum;
using FluentValidation;

namespace Fiap.TechChallenge.Fase1.Infraestructure.DTO
{
    public class CriarUsuarioDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Roles Role { get; set; }
    }

    public class CriarUsuarioDTOValidator : AbstractValidator<CriarUsuarioDTO>
    {
        public CriarUsuarioDTOValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O Email não pode ser vazio")
                .NotNull()
                .WithMessage("O Email não pode ser nulo")
                .EmailAddress()
                .WithMessage("O Email não está no formato correto");

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O Nome não pode ser vazio")
                .NotNull()
                .WithMessage("O Nome não pode ser nulo");

            RuleFor(x => x.Role)
                .NotNull()
                .WithMessage("O Role não pode ser nulo");

            RuleFor(x => x.Senha)
                .NotEmpty()
                .WithMessage("A Senha não pode ser vazio")
                .MinimumLength(10)
                .WithMessage("A Senha não pode ser menor que 10 caracteres")
                .NotNull()
                .WithMessage("A Senha não pode ser nulo");
        }
    }
}
