using Bogus;
using Fiap.TechChallenge.Fase1.Dominio;
using Fiap.TechChallenge.Fase1.Infraestructure.DTO.Usuario;
using Fiap.TechChallenge.Fase1.Infraestructure.Enum;
using Fiap.TechChallenge.Fase1.SharedKernel;
using Fiap.TechChallenge.Fase1.SharedKernel.Model;
using Moq;
using AppDomain = Fiap.TechChallenge.Fase1.Data;

namespace Fiap.TechChallenge.Fase1.Tests
{
    public class UsuarioTeste
    {
        private readonly Faker _faker;
        private readonly Mock<IUsuarioService> _usuarioService;

        public UsuarioTeste()
        {
            _usuarioService = new Mock<IUsuarioService>();
            _faker = new Faker("pt_BR");
        }

        [Fact(DisplayName = "Validando busca usuário válido")]
        [Trait("Categoria", "Validando Usuario")]
        private async void ValidacoesDeBuscaValido()
        {
            var usuario = new BuscarUsuarioDTO(_faker.Name.FullName(), _faker.Internet.Email(), (Roles)_faker.Random.Number(0, 1)); ;

            var response = new ResponseModel(new List<string>{ MensagemErroGenerico.MENSAGEM_SUCESSO }, true, usuario);

            _usuarioService.Setup(s => s.BuscarUsuario(It.IsAny<BuscarUsuarioDTO>())).ReturnsAsync(response);

            var usuarioService = _usuarioService.Object;

            var result = await usuarioService.BuscarUsuario(usuario);

            Assert.NotNull(result);
            Assert.NotNull(result.Objeto);
            Assert.True(result.Sucesso);
            Assert.Equal(1,result.Mensagem.Count());
            Assert.Equal(MensagemErroGenerico.MENSAGEM_SUCESSO, result.Mensagem.First());
        }

        [Fact(DisplayName = "Validando Novo usuário válido")]
        [Trait("Categoria", "Validando Usuario")]
        private AppDomain.Entidades.Usuario NovoUsurioValido()
        {
            AppDomain.Entidades.Usuario usuario = new AppDomain.Entidades.Usuario(_faker.Name.FullName(), _faker.Internet.Email(), _faker.Internet.Password(), (Roles)_faker.Random.Number(0, 1));

            return usuario;
        }

        [Fact(DisplayName = "Validando Alterar usuário válido")]
        [Trait("Categoria", "Validando Usuario")]
        private AppDomain.Entidades.Usuario AlterarUsurioValido()
        {
            AppDomain.Entidades.Usuario usuario = new AppDomain.Entidades.Usuario();

            usuario.AlterarUsuario(_faker.Name.FullName(), _faker.Internet.Email(), _faker.Internet.Password(), (Roles)_faker.Random.Number(0, 1));

            return usuario;
        }

        [Fact(DisplayName = "Validando Excluir usuário válido")]
        [Trait("Categoria", "Validando Usuario")]
        private AppDomain.Entidades.Usuario ExcluirUsuario()
        {
            AppDomain.Entidades.Usuario usuario = new AppDomain.Entidades.Usuario();

            usuario.ExcluirUsuario();

            return usuario;
        }
    }
}