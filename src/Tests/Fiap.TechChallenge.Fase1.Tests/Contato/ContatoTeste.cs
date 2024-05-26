using Bogus;
using Fiap.TechChallenge.Fase1.Dominio;
using Fiap.TechChallenge.Fase1.Infraestructure.DTO.Contato;
using Moq;

namespace Fiap.TechChallenge.Fase1.Tests.Contato;

public class ContatoTeste
{
    private readonly Mock<IContatoService> _contatoServiceMock;
    private readonly Faker _faker;

    public ContatoTeste(Mock<IContatoService> contatoServiceMock, Faker faker)
    {
        _contatoServiceMock = contatoServiceMock;
        _faker = faker;
    }

    private CriarAlterarContatoDTO CriarContatoValido()
    {
        return new CriarAlterarContatoDTO(_faker.Name.FullName(), 11, _faker.Phone.ToString()!, _faker.Internet.Email());
    }
}
