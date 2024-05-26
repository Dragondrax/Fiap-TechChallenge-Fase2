using Bogus;
using Fiap.TechChallenge.Fase1.Aplicacao;
using Fiap.TechChallenge.Fase1.Infraestructure.DTO;
using Fiap.TechChallenge.Fase1.Infraestructure.DTO.Usuario;
using Fiap.TechChallenge.Fase1.Infraestructure.Enum;
using Fiap.TechChallenge.Fase1.SharedKernel;
using Fiap.TechChallenge.Fase1.SharedKernel.Model;
using Moq;
using Xunit;
using AppDomain = Fiap.TechChallenge.Fase1.Dominio;

namespace Fiap.TechChallenge.Fase1.Tests.Usuario
{
    public class UsuarioTeste
    {
        private readonly Mock<IUsuarioService> _usuarioService;
        private readonly Faker _faker;

        public UsuarioTeste()
        {
            _usuarioService = new Mock<IUsuarioService>();
            _faker = new Faker("pt_BR");
        }

        [Fact(DisplayName = "Cadastrar Usuário - Validações de Input - Valido")]
        [Trait("Usuario", "Validações de Input")]
        public async void ValidacoesDeInputValido()
        {
            //Arrange
            var usuario = CriarUsuarioValido();

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

        [Fact(DisplayName = "Cadastrar Usuário - Validações de Input - Invalido")]
        [Trait("Usuario", "Validações de Input")]
        public async void ValidacoesDeInputInvalido()
        {
            //Arrange
            var usuario = CriarUsuarioInvalido();

            //Action
            _usuarioService.Setup(s => s.SalvarUsuario(It.IsAny<CriarUsuarioDTO>()))
                       .ReturnsAsync(CriarResponseModelErroValidacao());

            var usuarioService = _usuarioService.Object;

            var result = await usuarioService.SalvarUsuario(usuario);

            Assert.NotNull(result);
            Assert.Null(result.Objeto);
            Assert.False(result.Sucesso);
            Assert.Equal(2, result.Mensagem.Count());
            Assert.Contains(MensagemErroUsuario.MENSAGEM_EMAIL_NAO_ESTA_NO_FORMATO_CORRETO, result.Mensagem);
            Assert.Contains(MensagemErroUsuario.MENSAGEM_SENHA_NAO_PODE_SER_MENOR_QUE_10_CARACTERES, result.Mensagem);
        }

        [Fact(DisplayName = "Autenticar Usuário - Login Correto")]
        [Trait("Usuario", "Login")]
        public async void AutenticarUsuarioLoginCorreto()
        {
            //Arrange
            var usuario = CriarAutenticarValido();

            //Action
            _usuarioService.Setup(s => s.AutenticarUsuario(It.IsAny<AutenticarUsuarioDTO>()))
                       .ReturnsAsync(CriarResponseModelSucesso());

            var usuarioService = _usuarioService.Object;

            var result = await usuarioService.AutenticarUsuario(usuario);

            Assert.NotNull(result);
            Assert.Null(result.Objeto);
            Assert.True(result.Sucesso);
            Assert.Equal(1, result.Mensagem.Count());
            Assert.Equal(MensagemErroGenerico.MENSAGEM_SUCESSO, result.Mensagem.First());
        }

        [Fact(DisplayName = "Autenticar Usuário - Login Incorreto")]
        [Trait("Usuario", "Login")]
        public async void AutenticarUsuarioLoginIncorreto()
        {
            //Arrange
            var usuario = CriarAutenticarValido();

            //Action
            _usuarioService.Setup(s => s.AutenticarUsuario(It.IsAny<AutenticarUsuarioDTO>()))
                       .ReturnsAsync(CriarResponseModelErroAutenticacao());

            var usuarioService = _usuarioService.Object;

            var result = await usuarioService.AutenticarUsuario(usuario);

            Assert.NotNull(result);
            Assert.Null(result.Objeto);
            Assert.False(result.Sucesso);
            Assert.Equal(1, result.Mensagem.Count());
            Assert.Equal(MensagemErroUsuario.MENSAGEM_USUARIO_LOGIN_SENHA_INCORRETA, result.Mensagem.First());
        }

        [Fact(DisplayName = "Validando busca usuário válido")]
        [Trait("Categoria", "Validando Usuario")]
        private async void ValidacoesDeBuscaValido()
        {
            var usuario = new BuscarUsuarioDTO(_faker.Name.FullName(), _faker.Internet.Email(), (Roles)_faker.Random.Number(0, 1)); ;

            var response = new ResponseModel(new List<string> { MensagemErroGenerico.MENSAGEM_SUCESSO }, true, usuario);

            _usuarioService.Setup(s => s.BuscarUsuario(It.IsAny<BuscarUsuarioDTO>())).ReturnsAsync(response);

            var usuarioService = _usuarioService.Object;

            var result = await usuarioService.BuscarUsuario(usuario);

            Assert.NotNull(result);
            Assert.NotNull(result.Objeto);
            Assert.True(result.Sucesso);
            Assert.Equal(1, result.Mensagem.Count());
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

        private AutenticarUsuarioDTO CriarAutenticarValido()
        {
            return new AutenticarUsuarioDTO()
            {
                Email = _faker.Internet.Email(),
                Senha = _faker.Internet.Password(10),
            };
        }

        private CriarUsuarioDTO CriarUsuarioValido()
        {
            return new CriarUsuarioDTO()
            {
                Nome = _faker.Name.FullName(),
                Email = _faker.Internet.Email(),
                Senha = _faker.Internet.Password(10),
                Role = (Roles)_faker.Random.Number(0, 1)
            };
        }

        private CriarUsuarioDTO CriarUsuarioInvalido()
        {
            return new CriarUsuarioDTO()
            {
                Nome = _faker.Name.FullName(),
                Email = _faker.Address.City(),
                Senha = _faker.Internet.Password(5),
                Role = (Roles)_faker.Random.Number(0, 1)
            };
        }
        private ResponseModel CriarResponseModelSucesso()
            => new ResponseModel(new List<string> { MensagemErroGenerico.MENSAGEM_SUCESSO }, true, null);

        private ResponseModel CriarResponseModelErroValidacao()
            => new ResponseModel(new List<string> { MensagemErroUsuario.MENSAGEM_EMAIL_NAO_ESTA_NO_FORMATO_CORRETO, MensagemErroUsuario.MENSAGEM_SENHA_NAO_PODE_SER_MENOR_QUE_10_CARACTERES }, false, null);
        private ResponseModel CriarResponseModelErroAutenticacao()
            => new ResponseModel(new List<string> { MensagemErroUsuario.MENSAGEM_USUARIO_LOGIN_SENHA_INCORRETA }, false, null);
    }
}
