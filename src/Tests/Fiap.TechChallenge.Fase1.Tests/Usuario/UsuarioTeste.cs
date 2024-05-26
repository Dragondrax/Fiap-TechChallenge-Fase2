using Bogus;
using Fiap.TechChallenge.Fase1.Aplicacao;
using Fiap.TechChallenge.Fase1.Dominio;
using Fiap.TechChallenge.Fase1.Infraestructure.DTO;
using Fiap.TechChallenge.Fase1.Infraestructure.DTO.Usuario;
using Fiap.TechChallenge.Fase1.Infraestructure.Enum;
using Fiap.TechChallenge.Fase1.SharedKernel;
using Fiap.TechChallenge.Fase1.SharedKernel.MensagensErro;
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

        [Fact(DisplayName = "Cadastro Usuário - Validações de Input - Valido")]
        [Trait("Usuário", "Validações de Input")]
        public async void ValidacoesDeInputUsuarioValido()
        {
            //Arrange
            var usuario = CriarUsuarioValido();

            //Action
            _usuarioService.Setup(s => s.SalvarUsuario(It.IsAny<CriarAlterarUsuarioDTO>()))
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
        [Trait("Usuário", "Validações de Input")]
        public async void ValidacoesDeInputUsuarioInvalido()
        {
            //Arrange
            var usuario = CriarUsuarioInvalido();

            //Action
            _usuarioService.Setup(s => s.SalvarUsuario(It.IsAny<CriarAlterarUsuarioDTO>()))
                       .ReturnsAsync(CriarResponseModelErroUsuarioValidacao());

            var usuarioService = _usuarioService.Object;

            var result = await usuarioService.SalvarUsuario(usuario);

            Assert.NotNull(result);
            Assert.Null(result.Objeto);
            Assert.False(result.Sucesso);
            Assert.Equal(2, result.Mensagem.Count());            
            Assert.Contains(MensagemErroUsuario.MENSAGEM_EMAIL_NAO_ESTA_NO_FORMATO_CORRETO, result.Mensagem);
            Assert.Contains(MensagemErroUsuario.MENSAGEM_SENHA_NAO_PODE_SER_MENOR_QUE_10_CARACTERES, result.Mensagem);
        }

        [Fact(DisplayName = "Cadastro Usuário - Validações de Nome - Inválido")]
        [Trait("Usuário", "Validações de Input")]
        public async void ValidacoesDeNomeInvalido()
        {
            //Arrange
            var usuario = CriarUsuarioNomeInvalido();

            //ACT
            _usuarioService.Setup(s => s.SalvarUsuario(It.IsAny<CriarAlterarUsuarioDTO>()))
                           .ReturnsAsync(CriarResponseModelErroNomeValidacao());

            var usuarioService = _usuarioService.Object;

            var result = await usuarioService.SalvarUsuario(usuario);

            Assert.NotNull(result);
            Assert.Null(result.Objeto);
            Assert.False(result.Sucesso);
            Assert.Single(result.Mensagem);
            Assert.Contains(MensagemErroUsuario.MENSAGEM_NOME_NAO_PODE_SER_VAZIO, result.Mensagem);
        }


        [Fact(DisplayName = "Cadastro Usuário - Validações de Email - Inválido")]
        [Trait("Usuário", "Validações de Input")]
        public async void ValidacoesDeEmailInvalido()
        {
            //Arrange
            var usuario = CriarUsuarioEmailInvalido();

            //ACT
            _usuarioService.Setup(s => s.SalvarUsuario(It.IsAny<CriarAlterarUsuarioDTO>()))
                           .ReturnsAsync(CriarResponseModelErroEmailValidacao());

            var usuarioService = _usuarioService.Object;

            var result = await usuarioService.SalvarUsuario(usuario);

            Assert.NotNull(result);
            Assert.Null(result.Objeto);
            Assert.False(result.Sucesso);
            Assert.Single(result.Mensagem);
            Assert.Contains(MensagemErroUsuario.MENSAGEM_EMAIL_NAO_ESTA_NO_FORMATO_CORRETO, result.Mensagem);
        }

        [Fact(DisplayName = "Cadastro Usuário - Validações de Senha - Inválido")]
        [Trait("Usuário", "Validações de Input")]
        public async void ValidacoesDeSenhaInvalido()
        {
            //Arrange
            var usuario = CriarUsuarioSenhaInvalido();

            //ACT
            _usuarioService.Setup(s => s.SalvarUsuario(It.IsAny<CriarAlterarUsuarioDTO>()))
                           .ReturnsAsync(CriarResponseModelErroSenhaValidacao());

            var usuarioService = _usuarioService.Object;

            var result = await usuarioService.SalvarUsuario(usuario);

            Assert.NotNull(result);
            Assert.Null(result.Objeto);
            Assert.False(result.Sucesso);
            Assert.Single(result.Mensagem);
            Assert.Contains(MensagemErroUsuario.MENSAGEM_SENHA_NAO_PODE_SER_MENOR_QUE_10_CARACTERES, result.Mensagem);
        }

        [Fact(DisplayName = "Cadastro Usuário - Validações de Role - Inválido")]
        [Trait("Usuário", "Validações de Input")]
        public async void ValidacoesDeRoleInvalido()
        {
            //Arrange
            var usuario = CriarUsuarioRoleInvalido();

            //ACT
            _usuarioService.Setup(s => s.SalvarUsuario(It.IsAny<CriarAlterarUsuarioDTO>()))
                           .ReturnsAsync(CriarResponseModelErroRoleValidacao());

            var usuarioService = _usuarioService.Object;

            var result = await usuarioService.SalvarUsuario(usuario);

            Assert.NotNull(result);
            Assert.Null(result.Objeto);
            Assert.False(result.Sucesso);
            Assert.Single(result.Mensagem);
            Assert.Contains(MensagemErroUsuario.MENSAGEM_ROLE_NAO_EXISTE, result.Mensagem);
        }

        [Fact(DisplayName = "Autenticar Usuário - Login Correto")]
        [Trait("Usuário", "Login")]
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
        [Trait("Usuário", "Login")]
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

        [Fact(DisplayName = "Buscar Usuário - Validações de Input - Válido")]
        [Trait("Usuário", "Busca de Usuário")]
        public async void BuscaDeUsuarioPorEmailValido()
        {
            //Arrange
            var usuarioEmail = CriarUsuarioBuscarEmailValido();

            //ACT
            _usuarioService.Setup(s => s.BuscarUsuarioPorEmail(usuarioEmail))
                .ReturnsAsync(CriarResponseModelSucesso());

            var usuarioService = _usuarioService.Object;

            var result = await usuarioService.BuscarUsuarioPorEmail(usuarioEmail);

            Assert.NotNull(result);
            Assert.Null(result.Objeto);
            Assert.True(result.Sucesso);
            Assert.Equal(1, result.Mensagem.Count());
            Assert.Equal(MensagemErroGenerico.MENSAGEM_SUCESSO, result.Mensagem.First());
        }

        [Fact(DisplayName = "Busca de Usuário - Por Email Invalido")]
        [Trait("Usuário", "Busca de Usuário")]
        public async void BuscaDeUsuarioPorEmailInvalido()
        {
            //Arrange
            var usuarioEmail = CriarUsuarioBuscarEmailInvalido();

            //ACT
            _usuarioService.Setup(s => s.BuscarUsuarioPorEmail(It.IsAny<BuscarUsuarioDTO>()))
                .ReturnsAsync(CriarResponseModelErroEmailValidacao());

            var usuarioService = _usuarioService.Object;

            var result = await usuarioService.BuscarUsuarioPorEmail(usuarioEmail);

            Assert.NotNull(result);
            Assert.Null(result.Objeto);
            Assert.False(result.Sucesso);
            Assert.Single(result.Mensagem);
            Assert.Contains(MensagemErroUsuario.MENSAGEM_EMAIL_NAO_ESTA_NO_FORMATO_CORRETO, result.Mensagem);
        }

        [Fact(DisplayName = "Busca de Usuário - Por Email Invalido")]
        [Trait("Usuário", "Busca de Usuário")]
        public async void BuscaDeUsuarioPorEmailNaoEncontrado()
        {
            //Arrange
            var usuarioEmail = CriarUsuarioBuscarEmailInvalido();

            //ACT
            _usuarioService.Setup(s => s.BuscarUsuarioPorEmail(It.IsAny<BuscarUsuarioDTO>()))
                .ReturnsAsync(CriarResponseModelErroUsuarioNaoEncontrado());

            var usuarioService = _usuarioService.Object;

            var result = await usuarioService.BuscarUsuarioPorEmail(usuarioEmail);

            Assert.NotNull(result);
            Assert.Null(result.Objeto);
            Assert.False(result.Sucesso);
            Assert.Single(result.Mensagem);
            Assert.Contains(MensagemErroUsuario.MENSAGEM_USUARIO_NAO_ENCONTRADO, result.Mensagem);
        }

        [Fact(DisplayName = "Alterar Usuário - Válido")]
        [Trait("Usuário", "Alterar")]
        public async void AlterarUsuarioValido()
        {
            //Arrange
            var usuario = CriarUsuarioValido();

            //ACT
            _usuarioService.Setup(s => s.AlterarUsuario(It.IsAny<CriarAlterarUsuarioDTO>()))
                           .ReturnsAsync(CriarResponseModelSucesso());

            var usuarioService = _usuarioService.Object;

            var result = await usuarioService.AlterarUsuario(usuario);

            Assert.NotNull(result);
            Assert.Null(result.Objeto);
            Assert.True(result.Sucesso);
            Assert.Single(result.Mensagem);
            Assert.Equal(MensagemErroGenerico.MENSAGEM_SUCESSO, result.Mensagem.First());
        }

        [Fact(DisplayName = "Alterar Usuário - Usuário Não Encontrado")]
        [Trait("Usuário", "Alterar")]
        public async void AlterarUsuarioNaoEncontrado()
        {
            //Arrange
            var usuario = CriarUsuarioValido();

            //ACT
            _usuarioService.Setup(s => s.AlterarUsuario(It.IsAny<CriarAlterarUsuarioDTO>()))
                           .ReturnsAsync(CriarResponseModelErroUsuarioNaoEncontrado());

            var usuarioService = _usuarioService.Object;

            var result = await usuarioService.AlterarUsuario(usuario);

            Assert.NotNull(result);
            Assert.Null(result.Objeto);
            Assert.False(result.Sucesso);
            Assert.Single(result.Mensagem);
            Assert.Contains(MensagemErroUsuario.MENSAGEM_USUARIO_NAO_ENCONTRADO, result.Mensagem);
        }

        [Fact(DisplayName = "Remover Usuário")]
        [Trait("Usuário", "Remover")]
        public async void RemoverUsuario()
        {
            //Arrange
            Guid id = Guid.NewGuid();

            //ACT
            _usuarioService.Setup(s => s.RemoverUsuario(id))
                           .ReturnsAsync(CriarResponseModelSucesso());

            var usuarioService = _usuarioService.Object;

            var result = await usuarioService.RemoverUsuario(id);

            Assert.NotNull(result);
            Assert.Null(result.Objeto);
            Assert.True(result.Sucesso);
            Assert.Single(result.Mensagem);
            Assert.Equal(MensagemErroGenerico.MENSAGEM_SUCESSO, result.Mensagem.First());
        }

        [Fact(DisplayName = "Remover Usuário - Usuário Não Encontrado")]
        [Trait("Usuário", "Remover")]
        public async void RemoverUsuarioNaoEncontrado()
        {
            //Arrange
            Guid id = Guid.NewGuid();

            //ACT
            _usuarioService.Setup(s => s.RemoverUsuario(id))
                           .ReturnsAsync(CriarResponseModelErroUsuarioNaoEncontrado());

            var usuarioService = _usuarioService.Object;

            var result = await usuarioService.RemoverUsuario(id);

            Assert.NotNull(result);
            Assert.Null(result.Objeto);
            Assert.False(result.Sucesso);
            Assert.Single(result.Mensagem);
            Assert.Contains(MensagemErroUsuario.MENSAGEM_USUARIO_NAO_ENCONTRADO, result.Mensagem);
        }

        [Fact(DisplayName = "Validando Entidade - Criar usuário válido")]
        [Trait("Usuário", "Validações de Criar Usuário")]
        public AppDomain.Entidades.Usuario NovoUsurioValido()
        {
            AppDomain.Entidades.Usuario usuario = new AppDomain.Entidades.Usuario(_faker.Name.FullName(), _faker.Internet.Email(), _faker.Internet.Password(), (Roles)_faker.Random.Number(0, 1));

            return usuario;
        }

        [Fact(DisplayName = "Validando Entidade - Alterar usuário válido")]
        [Trait("Usuário", "Validações de Alterar Usuario")]
        public AppDomain.Entidades.Usuario AlterarUsurioValido()
        {
            AppDomain.Entidades.Usuario usuario = new AppDomain.Entidades.Usuario();

            usuario.AlterarUsuario(_faker.Name.FullName(), _faker.Internet.Email(), _faker.Internet.Password(), (Roles)_faker.Random.Number(0, 1));

            return usuario;
        }

        [Fact(DisplayName = "Validando Entidade - Excluir usuário válido")]
        [Trait("Usuário", "Validações de Excluir Usuário")]
        public AppDomain.Entidades.Usuario ExcluirUsuario()
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
        private CriarAlterarUsuarioDTO CriarUsuarioValido()
        {
            return new CriarAlterarUsuarioDTO()
            {
                Nome = _faker.Name.FullName(),
                Email = _faker.Internet.Email(),
                Senha = _faker.Internet.Password(10),
                Role = (Roles)_faker.Random.Number(0, 1)
            };
        }

        private CriarAlterarUsuarioDTO CriarUsuarioInvalido()
        {
            return new CriarAlterarUsuarioDTO()
            {
                Nome = null,
                Email = _faker.Address.City(),
                Senha = _faker.Internet.Password(5),
                Role = (Roles)_faker.Random.Number(0, 1)
            };
        }

        private CriarAlterarUsuarioDTO CriarUsuarioNomeInvalido()
        {
            return new CriarAlterarUsuarioDTO()
            {
                Nome = "",
                Email = _faker.Internet.Email(),
                Senha = _faker.Internet.Password(10),
                Role = (Roles)_faker.Random.Number(0, 1)
            };
        }

        private CriarAlterarUsuarioDTO CriarUsuarioEmailInvalido()
        {
            return new CriarAlterarUsuarioDTO()
            {
                Nome = _faker.Name.FullName(),
                Email = _faker.Address.City(),
                Senha = _faker.Internet.Password(10),
                Role = (Roles)_faker.Random.Number(0, 1)
            };
        }

        private CriarAlterarUsuarioDTO CriarUsuarioSenhaInvalido()
        {
            return new CriarAlterarUsuarioDTO()
            {
                Nome = _faker.Name.FullName(),
                Email = _faker.Internet.Email(),
                Senha = _faker.Internet.Password(5),
                Role = (Roles)_faker.Random.Number(0, 1)
            };
        }

        private CriarAlterarUsuarioDTO CriarUsuarioRoleInvalido()
        {
            return new CriarAlterarUsuarioDTO()
            {
                Nome = _faker.Name.FullName(),
                Email = _faker.Internet.Email(),
                Senha = _faker.Internet.Password(10),
                Role = (Roles)_faker.Random.Number(2, 3)
            };
        }

        private BuscarUsuarioDTO CriarUsuarioBuscarEmailValido()
        {
            return new BuscarUsuarioDTO()
            {
                Email = _faker.Internet.Email()
            };
        }
        private BuscarUsuarioDTO CriarUsuarioBuscarEmailInvalido()
        {
            return new BuscarUsuarioDTO()
            {
                Email = _faker.Internet.UserName()
            };
        }

        private ResponseModel CriarResponseModelSucesso()
            => new ResponseModel(new List<string> { MensagemErroGenerico.MENSAGEM_SUCESSO }, true, null);
        private ResponseModel CriarResponseModelErroUsuarioValidacao()
            => new ResponseModel(new List<string> { MensagemErroUsuario.MENSAGEM_EMAIL_NAO_ESTA_NO_FORMATO_CORRETO, MensagemErroUsuario.MENSAGEM_SENHA_NAO_PODE_SER_MENOR_QUE_10_CARACTERES }, false, null);
        private ResponseModel CriarResponseModelErroNomeValidacao()
            => new ResponseModel(new List<string> { MensagemErroUsuario.MENSAGEM_NOME_NAO_PODE_SER_VAZIO }, false, null);
        private ResponseModel CriarResponseModelErroSenhaValidacao()
            => new ResponseModel(new List<string> { MensagemErroUsuario.MENSAGEM_SENHA_NAO_PODE_SER_MENOR_QUE_10_CARACTERES}, false, null);
        private ResponseModel CriarResponseModelErroRoleValidacao()
            => new ResponseModel(new List<string> { MensagemErroUsuario.MENSAGEM_ROLE_NAO_EXISTE}, false, null);
        private ResponseModel CriarResponseModelErroAutenticacao()
            => new ResponseModel(new List<string> { MensagemErroUsuario.MENSAGEM_USUARIO_LOGIN_SENHA_INCORRETA }, false, null);
        private ResponseModel CriarResponseModelErroEmailValidacao()
            => new ResponseModel(new List<string> { MensagemErroUsuario.MENSAGEM_EMAIL_NAO_ESTA_NO_FORMATO_CORRETO }, false, null);
        private ResponseModel CriarResponseModelErroUsuarioNaoEncontrado()
            => new ResponseModel(new List<string> { MensagemErroUsuario.MENSAGEM_USUARIO_NAO_ENCONTRADO }, false, null);
    }
}
