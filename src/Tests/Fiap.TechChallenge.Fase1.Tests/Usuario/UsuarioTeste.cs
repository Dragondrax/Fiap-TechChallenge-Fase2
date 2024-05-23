using Bogus;
using Fiap.TechChallenge.Fase1.Dominio;
using Fiap.TechChallenge.Fase1.Infraestructure.DTO;
using Fiap.TechChallenge.Fase1.Infraestructure.Enum;
using Fiap.TechChallenge.Fase1.SharedKernel;
using Fiap.TechChallenge.Fase1.SharedKernel.Model;
using Moq;
using Xunit;

namespace Fiap.TechChallenge.Fase1.Tests.Usuario
{
    public class UsuarioTeste
    {
        private readonly Mock<IUsuarioService> _usuarioService;
        private readonly Faker _faker;

        public UsuarioTeste()
        {
            _usuarioService = new Mock<IUsuarioService>();
            _faker = new Faker();
        }

        [Fact(DisplayName = "Cadastrar Usuário - Validações de Input - Valido")]
        [Trait("Usuario", "Validações de Input")]
        public async void ValidacoesDeInputValido()
        {
            //Arrange
            var usuario = CriarUsuario();

            //Action
            _usuarioService.Setup(s => s.SalvarUsuario(It.IsAny<CriarUsuarioDTO>()))
                       .ReturnsAsync(CriarResponseModelSucesso());

            var usuarioService = _usuarioService.Object;

            var result = await usuarioService.SalvarUsuario(usuario);

            Assert.NotNull(result);
            Assert.Null(result.Objeto);
            Assert.True(result.Sucesso);
            Assert.Equal(1, result.Mensagem.Count());
            Assert.Equal(MensagemErroGenerico.MENSAGEM_SUCESSO, result.Mensagem.First());
        }

        private CriarUsuarioDTO CriarUsuario()
        {
            return new CriarUsuarioDTO()
            {
                Nome = _faker.Name.FullName(),
                Email = _faker.Internet.Email(),
                Senha = _faker.Random.String2(10),
                Role = (Roles)_faker.Random.Number(0, 1)
            };
        }

        private ResponseModel CriarResponseModelSucesso()
            => new ResponseModel() 
            { 
                Mensagem = new List<string> { MensagemErroGenerico.MENSAGEM_SUCESSO }, 
                Sucesso = true,
                Objeto = null
            };
    }
}
