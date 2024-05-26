using Bogus;
using Fiap.TechChallenge.Fase1.Dominio;
using Fiap.TechChallenge.Fase1.Infraestructure.DTO.Contato;
using Fiap.TechChallenge.Fase1.SharedKernel;
using Fiap.TechChallenge.Fase1.SharedKernel.MensagensErro;
using Fiap.TechChallenge.Fase1.SharedKernel.Model;
using Moq;
using Xunit;

namespace Fiap.TechChallenge.Fase1.Tests.Contato;

public class ContatoTeste
{
    private readonly Mock<IContatoService> _contatoService;
    private readonly Faker _faker;

    public ContatoTeste()
    {
       _contatoService = new Mock<IContatoService>();
       _faker = new Faker("pt_BR");
    }

    [Fact(DisplayName = "Cadastro Contato - Validações de Input - Válido")]
    [Trait("Contato", "Validações de Input")]
    public async void ValidacoesDeInputValido()
    {
        //Arrange
        var contato = CriarContatoValido();

        //ACT
        _contatoService.Setup(s => s.SalvarContato(It.IsAny<CriarAlterarContatoDTO>()))
                       .ReturnsAsync(CriarResponseModelSucesso());

        var contatoService = _contatoService.Object;

        var result = await contatoService.SalvarContato(contato);

        Assert.NotNull(result);
        Assert.Null(result.Objeto);
        Assert.True(result.Sucesso);
        Assert.Single(result.Mensagem);
        Assert.Equal(MensagemErroGenerico.MENSAGEM_SUCESSO, result.Mensagem.First());
    }

    [Fact(DisplayName = "Cadastro Contato - Validações de Nome - Inválido")]
    [Trait("Contato", "Validações de Input")]
    public async void ValidacoesDeNomeInvalido()
    {
        //Arrange
        var contato = CriarContatoNomeInvalido();

        //ACT
        _contatoService.Setup(s => s.SalvarContato(It.IsAny<CriarAlterarContatoDTO>()))
                       .ReturnsAsync(CriarResponseModelErroNomeValidacao());

        var contatoService = _contatoService.Object;

        var result = await contatoService.SalvarContato(contato);

        Assert.NotNull(result);
        Assert.Null(result.Objeto);
        Assert.False(result.Sucesso);
        Assert.Single(result.Mensagem);
        Assert.Contains(MensagemErroContato.MENSAGEM_NOME_NAO_PODE_SER_VAZIO, result.Mensagem);
    }

    [Fact(DisplayName = "Cadastro Contato - Validações de DDD - Inválido")]
    [Trait("Contato", "Validações de Input")]
    public async void ValidacoesDeDDDInvalido()
    {
        //Arrange
        var contato = CriarContatoDDDInvalido();

        //ACT
        _contatoService.Setup(s => s.SalvarContato(It.IsAny<CriarAlterarContatoDTO>()))
                       .ReturnsAsync(CriarResponseModelErroDDDValidacao());

        var contatoService = _contatoService.Object;

        var result = await contatoService.SalvarContato(contato);

        Assert.NotNull(result);
        Assert.Null(result.Objeto);
        Assert.False(result.Sucesso);
        Assert.Single(result.Mensagem);
        Assert.Contains(MensagemErroContato.MENSAGEM_DDD_INVALIDO, result.Mensagem);
    }

    [Fact(DisplayName = "Cadastro Contato - Validações de Telefone - Inválido")]
    [Trait("Contato", "Validações de Input")]
    public async void ValidacoesDeTelefoneInvalido()
    {
        //Arrange
        var contato = CriarContatoTelefoneInvalido();

        //ACT
        _contatoService.Setup(s => s.SalvarContato(It.IsAny<CriarAlterarContatoDTO>()))
                       .ReturnsAsync(CriarResponseModelErroTelefoneValidacao());

        var contatoService = _contatoService.Object;

        var result = await contatoService.SalvarContato(contato);

        Assert.NotNull(result);
        Assert.Null(result.Objeto);
        Assert.False(result.Sucesso);
        Assert.Single(result.Mensagem);
        Assert.Contains(MensagemErroContato.MENSAGEM_TELEFONE_MINIMO_OITO_CARACTERES, result.Mensagem);
    }

    [Fact(DisplayName = "Cadastro Contato - Validações de Email - Inválido")]
    [Trait("Contato", "Validações de Input")]
    public async void ValidacoesDeEmailInvalido()
    {
        //Arrange
        var contato = CriarContatoEmailInvalido();

        //ACT
        _contatoService.Setup(s => s.SalvarContato(It.IsAny<CriarAlterarContatoDTO>()))
                       .ReturnsAsync(CriarResponseModelErroEmailValidacao());

        var contatoService = _contatoService.Object;

        var result = await contatoService.SalvarContato(contato);

        Assert.NotNull(result);
        Assert.Null(result.Objeto);
        Assert.False(result.Sucesso);
        Assert.Single(result.Mensagem);
        Assert.Contains(MensagemErroContato.MENSAGEM_EMAIL_NAO_ESTA_NO_FORMATO_CORRETO, result.Mensagem);
    }

    [Fact(DisplayName = "Busca de Contato - Por DDD - Sucesso")]
    [Trait("Contato", "Busca de Contato")]
    public async void BuscaDeContatoPorDDDSucesso()
    {
        //Arrange
        int dddValido = 11;

        //ACT
        _contatoService.Setup(s => s.BuscarContatosPorDDD(dddValido))
        .ReturnsAsync(CriarResponseModelSucesso());

        var contatoService = _contatoService.Object;

        var result = await contatoService.BuscarContatosPorDDD(dddValido);

        Assert.NotNull(result);
        Assert.Null(result.Objeto);
        Assert.True(result.Sucesso);
        Assert.Single(result.Mensagem);
        Assert.Equal(MensagemErroGenerico.MENSAGEM_SUCESSO, result.Mensagem.First());
    }

    [Fact(DisplayName = "Busca de Contato - Por DDD - Lista De Contatos Vazia")]
    [Trait("Contato", "Busca de Contato")]
    public async void BuscaDeContatoPorDDDListaDeContatosVazia()
    {
        //Arrange
        int dddValido = 11;

        //ACT
        _contatoService.Setup(s => s.BuscarContatosPorDDD(dddValido))
        .ReturnsAsync(CriarResponseModelErroListaDeContatoVazia());

        var contatoService = _contatoService.Object;

        var result = await contatoService.BuscarContatosPorDDD(dddValido);

        Assert.NotNull(result);
        Assert.Null(result.Objeto);
        Assert.False(result.Sucesso);
        Assert.Single(result.Mensagem);
        Assert.Contains(MensagemErroContato.MENSAGEM_LISTA_DE_CONTATO_VAZIA, result.Mensagem);
    }

    [Fact(DisplayName = "Busca de Contato - Por DDD Invalido")]
    [Trait("Contato", "Busca de Contato")]
    public async void BuscaDeContatoPorDDDInvalido()
    {
        //Arrange
        int dddValido = 10;

        //ACT
        _contatoService.Setup(s => s.BuscarContatosPorDDD(dddValido))
        .ReturnsAsync(CriarResponseModelErroDDDValidacao());

        var contatoService = _contatoService.Object;

        var result = await contatoService.BuscarContatosPorDDD(dddValido);

        Assert.NotNull(result);
        Assert.Null(result.Objeto);
        Assert.False(result.Sucesso);
        Assert.Single(result.Mensagem);
        Assert.Contains(MensagemErroContato.MENSAGEM_DDD_INVALIDO, result.Mensagem);
    }

    [Fact(DisplayName = "Busca de Contato - Por Email - Sucesso")]
    [Trait("Contato", "Busca de Contato")]
    public async void BuscaDeContatoPorEmailSucesso()
    {
        //Arrange
        var contatoEmail = CriarContatoBuscarEmailValido();

        //ACT
        _contatoService.Setup(s => s.BuscarContatoPorEmail(contatoEmail))
        .ReturnsAsync(CriarResponseModelSucesso());

        var contatoService = _contatoService.Object;

        var result = await contatoService.BuscarContatoPorEmail(contatoEmail);

        Assert.NotNull(result);
        Assert.Null(result.Objeto);
        Assert.True(result.Sucesso);
        Assert.Single(result.Mensagem);
        Assert.Equal(MensagemErroGenerico.MENSAGEM_SUCESSO, result.Mensagem.First());
    }

    [Fact(DisplayName = "Busca de Contato - Por Email Invalido")]
    [Trait("Contato", "Busca de Contato")]
    public async void BuscaDeContatoPorEmailInvalido()
    {
        //Arrange
        var contatoEmail = CriarContatoBuscarEmailInvalido();

        //ACT
        _contatoService.Setup(s => s.BuscarContatoPorEmail(contatoEmail))
        .ReturnsAsync(CriarResponseModelErroEmailValidacao());

        var contatoService = _contatoService.Object;

        var result = await contatoService.BuscarContatoPorEmail(contatoEmail);

        Assert.NotNull(result);
        Assert.Null(result.Objeto);
        Assert.False(result.Sucesso);
        Assert.Single(result.Mensagem);
        Assert.Contains(MensagemErroContato.MENSAGEM_EMAIL_NAO_ESTA_NO_FORMATO_CORRETO, result.Mensagem);
    }

    [Fact(DisplayName = "Busca de Contato - Por Email - Contato Não Encontrado")]
    [Trait("Contato", "Busca de Contato")]
    public async void BuscaDeContatoPorEmailContatoNaoEncontrado()
    {
        //Arrange
        var contatoEmail = CriarContatoBuscarEmailInvalido();

        //ACT
        _contatoService.Setup(s => s.BuscarContatoPorEmail(contatoEmail))
        .ReturnsAsync(CriarResponseModelErroContatoNaoEncontrado());

        var contatoService = _contatoService.Object;

        var result = await contatoService.BuscarContatoPorEmail(contatoEmail);

        Assert.NotNull(result);
        Assert.Null(result.Objeto);
        Assert.False(result.Sucesso);
        Assert.Single(result.Mensagem);
        Assert.Contains(MensagemErroContato.MENSAGEM_CONTATO_NAO_ENCONTRADO, result.Mensagem);
    }

    [Fact(DisplayName = "Alterar Contato - Válido")]
    [Trait("Contato", "Alterar")]
    public async void AlterarContatoValido()
    {
        //Arrange
        var contato = CriarContatoValido();

        //ACT
        _contatoService.Setup(s => s.AlterarContato(It.IsAny<CriarAlterarContatoDTO>()))
                       .ReturnsAsync(CriarResponseModelSucesso());

        var contatoService = _contatoService.Object;

        var result = await contatoService.AlterarContato(contato);

        Assert.NotNull(result);
        Assert.Null(result.Objeto);
        Assert.True(result.Sucesso);
        Assert.Single(result.Mensagem);
        Assert.Equal(MensagemErroGenerico.MENSAGEM_SUCESSO, result.Mensagem.First());
    }

    [Fact(DisplayName = "Alterar Contato - Contato Não Encontrado")]
    [Trait("Contato", "Alterar")]
    public async void AlterarContatoNaoEncontrado()
    {
        //Arrange
        var contato = CriarContatoValido();

        //ACT
        _contatoService.Setup(s => s.AlterarContato(It.IsAny<CriarAlterarContatoDTO>()))
                       .ReturnsAsync(CriarResponseModelErroContatoNaoEncontrado());

        var contatoService = _contatoService.Object;

        var result = await contatoService.AlterarContato(contato);

        Assert.NotNull(result);
        Assert.Null(result.Objeto);
        Assert.False(result.Sucesso);
        Assert.Single(result.Mensagem);
        Assert.Contains(MensagemErroContato.MENSAGEM_CONTATO_NAO_ENCONTRADO, result.Mensagem);
    }

    [Fact(DisplayName = "Remover Contato")]
    [Trait("Contato", "Remover")]
    public async void RemoverContato()
    {
        //Arrange
        Guid id = Guid.NewGuid();

        //ACT
        _contatoService.Setup(s => s.RemoverContato(id))
                       .ReturnsAsync(CriarResponseModelSucesso());

        var contatoService = _contatoService.Object;

        var result = await contatoService.RemoverContato(id);

        Assert.NotNull(result);
        Assert.Null(result.Objeto);
        Assert.True(result.Sucesso);
        Assert.Single(result.Mensagem);
        Assert.Equal(MensagemErroGenerico.MENSAGEM_SUCESSO, result.Mensagem.First());
    }

    [Fact(DisplayName = "Remover Contato - Contato Não Encontrado")]
    [Trait("Contato", "Remover")]
    public async void RemoverContatoNaoEncontrado()
    {
        //Arrange
        Guid id = Guid.NewGuid();

        //ACT
        _contatoService.Setup(s => s.RemoverContato(id))
                       .ReturnsAsync(CriarResponseModelErroContatoNaoEncontrado());

        var contatoService = _contatoService.Object;

        var result = await contatoService.RemoverContato(id);

        Assert.NotNull(result);
        Assert.Null(result.Objeto);
        Assert.False(result.Sucesso);
        Assert.Single(result.Mensagem);
        Assert.Contains(MensagemErroContato.MENSAGEM_CONTATO_NAO_ENCONTRADO, result.Mensagem);
    }



    private CriarAlterarContatoDTO CriarContatoValido()
    {
        return new CriarAlterarContatoDTO()
        {
            Nome = _faker.Name.FullName(),
            DDD = 11,
            Telefone = _faker.Phone.Locale,
            Email = _faker.Internet.Email(),
        };
    }

    private CriarAlterarContatoDTO CriarContatoNomeInvalido()
    {
        return new CriarAlterarContatoDTO()
        {
            Nome = "",
            DDD = 11,
            Telefone = _faker.Phone.Locale,
            Email = _faker.Internet.Email(),
        };
    }

    private CriarAlterarContatoDTO CriarContatoDDDInvalido()
    {
        return new CriarAlterarContatoDTO()
        {
            Nome = _faker.Name.FullName(),
            DDD = 10,
            Telefone = _faker.Phone.Locale,
            Email = _faker.Internet.Email(),
        };
    }

    private CriarAlterarContatoDTO CriarContatoTelefoneInvalido()
    {
        return new CriarAlterarContatoDTO()
        {
            Nome = _faker.Name.FullName(),
            DDD = 10,
            Telefone = "9783465",
            Email = _faker.Internet.Email(),
        };
    }

    private CriarAlterarContatoDTO CriarContatoEmailInvalido()
    {
        return new CriarAlterarContatoDTO()
        {
            Nome = _faker.Name.FullName(),
            DDD = 10,
            Telefone = _faker.Phone.Locale,
            Email = "testeUsuario",
        };
    }

    private BuscarContatoDTO CriarContatoBuscarEmailValido()
    {
        return new BuscarContatoDTO()
        {
            Email = _faker.Internet.Email(),
        };
    }

    private BuscarContatoDTO CriarContatoBuscarEmailInvalido()
    {
        return new BuscarContatoDTO()
        {
            Email = "contato",
        };
    }


    private ResponseModel CriarResponseModelSucesso()
            => new ResponseModel(new List<string> { MensagemErroGenerico.MENSAGEM_SUCESSO }, true, null);

    private ResponseModel CriarResponseModelErroNomeValidacao()
            => new ResponseModel(new List<string> { MensagemErroContato.MENSAGEM_NOME_NAO_PODE_SER_VAZIO }, false, null);

    private ResponseModel CriarResponseModelErroDDDValidacao()
            => new ResponseModel(new List<string> { MensagemErroContato.MENSAGEM_DDD_INVALIDO }, false, null);

    private ResponseModel CriarResponseModelErroTelefoneValidacao()
            => new ResponseModel(new List<string> { MensagemErroContato.MENSAGEM_TELEFONE_MINIMO_OITO_CARACTERES }, false, null);

    private ResponseModel CriarResponseModelErroEmailValidacao()
            => new ResponseModel(new List<string> { MensagemErroContato.MENSAGEM_EMAIL_NAO_ESTA_NO_FORMATO_CORRETO }, false, null);

    private ResponseModel CriarResponseModelErroListaDeContatoVazia()
            => new ResponseModel(new List<string> { MensagemErroContato.MENSAGEM_LISTA_DE_CONTATO_VAZIA }, false, null);

    private ResponseModel CriarResponseModelErroContatoNaoEncontrado()
            => new ResponseModel(new List<string> { MensagemErroContato.MENSAGEM_CONTATO_NAO_ENCONTRADO }, false, null);


    
}
