using Fiap.TechChallenge.Fase1.Dominio.Entidades;
using Fiap.TechChallenge.Fase1.Dominio.Model;
using Fiap.TechChallenge.Fase1.Infraestructure.DTO.Contato;
using Fiap.TechChallenge.Fase1.Infraestructure.DTO.Usuario;
using Fiap.TechChallenge.Fase1.Integration.Tests.Infra;
using Fiap.TechChallenge.Fase1.Integration.Tests.Model;
using Fiap.TechChallenge.Fase1.SharedKernel.Model;
using System.Dynamic;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace Fiap.TechChallenge.Fase1.Integration.Tests;

public class ContatoIntegrationTest
{
    private readonly FiapTechChallengeWebApplicationFactory _app;
    private DockerFixture _dockerFixture;

    public ContatoIntegrationTest()
    {
        _app = new FiapTechChallengeWebApplicationFactory();
        _dockerFixture = new DockerFixture();
    }

    [Fact]
    public async void Post_Criar_Novo_Usuario()
    {
        // Arrange
        using var client = await _app.GetClientWithAccessTokenAsync();

        CriarAlterarContatoDTO criarContato = new()
        {
            Email = "emailCriarContato@gmail.com",
            Nome = "Nome Teste",
            Telefone = "994918888",
            DDD = 11,
        };

        // Act
        var resultado = await client.PostAsJsonAsync("/api/Contato/CriarContato", criarContato);

        // Assert
        Assert.Equal(HttpStatusCode.OK, resultado.StatusCode);
    }

    [Fact]
    public async void Get_Filtrar_Por_DDD()
    {
        // Arrange
        using var client = await _app.GetClientWithAccessTokenAsync();


        CriarAlterarContatoDTO criarContato = new()
        {
            Email = "emailProcuraDDD@gmail.com",
            Nome = "Nome Teste",
            Telefone = "994918888",
            DDD = 11,
        };

        var resultadoCriar = await client.PostAsJsonAsync("/api/Contato/CriarContato", criarContato);
        resultadoCriar.EnsureSuccessStatusCode();

        // Act
        var resultado = await client.GetAsync($"/api/Contato/FiltrarPorDDD/{11}");

        // Arrange
        Assert.Equal(HttpStatusCode.OK, resultado.StatusCode);
    }

    [Fact]
    public async void Post_Buscar_Contato_Por_Email()
    {
        // Arrange
        using var client = await _app.GetClientWithAccessTokenAsync();

        CriarAlterarContatoDTO criarContato = new()
        {
            Email = "emailBusca@gmail.com",
            Nome = "Nome Teste",
            Telefone = "994918888",
            DDD = 11,
        };

        var resultadoCriar = await client.PostAsJsonAsync("/api/Contato/CriarContato", criarContato);
        resultadoCriar.EnsureSuccessStatusCode();

        BuscarContatoDTO buscarContato = new()
        {
            Email = "emailBusca@gmail.com"
        };

        // Act
        var resultado = await client.PostAsJsonAsync("/api/Contato/BuscarContatoPorEmail", buscarContato);
        var model = await resultado.Content.ReadFromJsonAsync<ResponseModelTeste>();
        var contatoEncontradoJson = model.Objeto.GetRawText();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var contatoEncontrado = JsonSerializer.Deserialize<ResponseBuscarContato>(contatoEncontradoJson, options);


        // Arrange
        Assert.Equal(HttpStatusCode.OK, resultado.StatusCode);
        Assert.Equal(criarContato.Email, contatoEncontrado.Contato.Email);

    }

    [Fact]
    public async Task Put_Alterar_Contato()
    {
        // Arrange
        using var client = await _app.GetClientWithAccessTokenAsync();

        // Criar o contato
        var criarContato = new CriarAlterarContatoDTO
        {
            Email = "alteraContato@gmail.com",
            Nome = "Nome Teste",
            Telefone = "994918888",
            DDD = 11,
        };

        var resultadoCriar = await client.PostAsJsonAsync("/api/Contato/CriarContato", criarContato);
        resultadoCriar.EnsureSuccessStatusCode(); 

        var buscarContato = new BuscarContatoDTO
        {
            Email = "alteraContato@gmail.com"
        };

        var resultadoBuscar = await client.PostAsJsonAsync("/api/Contato/BuscarContatoPorEmail", buscarContato);
        resultadoBuscar.EnsureSuccessStatusCode(); 

        var modelBuscar = await resultadoBuscar.Content.ReadFromJsonAsync<ResponseModelTeste>();
        var contatoBuscadoJson = modelBuscar.Objeto.GetRawText();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var contatoBuscado = JsonSerializer.Deserialize<ResponseBuscarContato>(contatoBuscadoJson, options);

        Assert.NotNull(contatoBuscado);
        Assert.Equal(criarContato.Email, contatoBuscado.Contato.Email);

        // Preparar para alterar o contato
        var alterarContato = new CriarAlterarContatoDTO
        {
            Email = "alteraContato@gmail.com", 
            Nome = "Nome Teste Alterado",
            Telefone = "994917188",
            DDD = 12,
        };

        // Act - Alterar o contato
        var resultadoAlterar = await client.PutAsJsonAsync("/api/Contato/AlterarContato", alterarContato);
        Assert.Equal(HttpStatusCode.OK, resultadoAlterar.StatusCode);

        // Verificar se a alteração foi bem-sucedida
        //var resultadoBuscarAlterado = await client.PostAsJsonAsync("/api/Contato/BuscarContatoPorEmail", buscarContato);
        //var modelAlterado = await resultadoBuscarAlterado.Content.ReadFromJsonAsync<ResponseModelTeste>();
        //var contatoAlteradoJson = modelAlterado.Objeto.GetRawText();
        //var contatoAlterado = JsonSerializer.Deserialize<ResponseBuscarContato>(contatoAlteradoJson, options);

        //// Assert
        //Assert.Equal(HttpStatusCode.OK, resultadoAlterar.StatusCode);
        //Assert.Equal(alterarContato.Nome, contatoAlterado.Contato.Nome);
    }

    [Fact]
    public async void Delete_Remover_Contato()
    {
        // Arrange
        using var client = await _app.GetClientWithAccessTokenAsync();

        CriarAlterarContatoDTO criarContato = new()
        {
            Email = "emailDelete@gmail.com",
            Nome = "Nome Teste",
            Telefone = "994918888",
            DDD = 11,
        };

        var resultadoCriar = await client.PostAsJsonAsync("/api/Contato/CriarContato", criarContato);
        resultadoCriar.EnsureSuccessStatusCode();

        BuscarContatoDTO buscarContato = new()
        {
            Email = "emailDelete@gmail.com"
        };

        var resultadoBuscar = await client.PostAsJsonAsync("/api/Contato/BuscarContatoPorEmail", buscarContato);
        var model = await resultadoBuscar.Content.ReadFromJsonAsync<ResponseModelTeste>();

        // Verificação da propriedade Objeto como string
        var contatoEncontradoJson = model.Objeto.GetRawText();

        // Desserializar para UsuarioDTO com case-insensitive options
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var contatoEncontrado = JsonSerializer.Deserialize<ResponseBuscarContato>(contatoEncontradoJson, options);



        // Act
        var resultado = await client.DeleteAsync($"/api/Contato/RemoverContato?id={contatoEncontrado.Contato.Id}");

        // Arrange
        Assert.Equal(HttpStatusCode.OK, resultado.StatusCode);
    }
}
