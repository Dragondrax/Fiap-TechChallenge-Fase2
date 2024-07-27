using Fiap.TechChallenge.Fase1.Infraestructure.DTO;
using Fiap.TechChallenge.Fase1.Infraestructure.DTO.Usuario;
using Fiap.TechChallenge.Fase1.Infraestructure.Enum;
using Fiap.TechChallenge.Fase1.Integration.Tests;
using Fiap.TechChallenge.Fase1.Integration.Tests.Infra;
using Fiap.TechChallenge.Fase1.Integration.Tests.Model;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace Fiap.TechChallenge.Fase1.Integration.Test
{
    [Collection("Test Integration")]
    public class UsuarioIntegrationTest
    {
        private readonly FiapTechChallengeWebApplicationFactory _app;
        private DockerFixture _dockerFixture;

        public UsuarioIntegrationTest()
        {
            _app = new FiapTechChallengeWebApplicationFactory();
            _dockerFixture = new DockerFixture();
        }

        /// <summary>
        /// Primeiro Teste realiza a autentica��o com um usuario padr�o definido tamb�m dentro das secrets do CI do Github ACtions e configurado aqui na API
        /// </summary>
        [Fact]
        public async void Post_Efetua_Login_Com_Sucesso()
        {
            // Arrange
            using var client = _app.CreateClient();

            var usuario = new AutenticarUsuarioDTO
            {
                Email = _app._email,
                Senha = _app._senha
            };

            // Act
            var resultado = await client.PostAsJsonAsync("/api/Usuario/Autenticar", usuario);

            // Assert
            Assert.Equal(HttpStatusCode.OK, resultado.StatusCode);
        }

        /// <summary>
        /// Faz autentica��o e busca um usu�rio padr�o para retorno positivo e teste de integra��o
        /// </summary>
        [Fact]
        public async void Post_Busca_Usuario_Com_Sucesso()
        {
            // Arrange
            using var client = await _app.GetClientWithAccessTokenAsync();

            var usuario = new BuscarUsuarioDTO
            {
                Email = _app._email
            };

            // Act
            var resultado = await client.PostAsJsonAsync("/api/Usuario/BuscarUsuario", usuario);
            var aux = resultado.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.Equal(HttpStatusCode.OK, resultado.StatusCode);
        }

        [Fact]
        public async void Post_Salvar_Novo_Usuario()
        {
            // Arrange
            using var client = await _app.GetClientWithAccessTokenAsync();

            CriarAlterarUsuarioDTO criarUsuarioDTO = new()
            {
                Email = "emailcriarusuario@gmail.com",
                Nome = "Nome Teste",
                Role = (Roles)1,
                Senha = "senha123456"
            };

            // Act
            var resultado = await client.PostAsJsonAsync("/api/Usuario/CriarUsuario", criarUsuarioDTO);

            // Assert
            Assert.Equal(HttpStatusCode.OK, resultado.StatusCode);
        }

        [Fact]
        public async void Put_Alterar_Usuario()
        {
            // Arrange
            using var client = await _app.GetClientWithAccessTokenAsync();

            CriarAlterarUsuarioDTO criarUsuarioDTO = new()
            {
                Email = "emailalterausuario@gmail.com",
                Nome = "Nome Teste",
                Role = (Roles)1,
                Senha = "senha12345678"
            };

            var resultadoCriar = await client.PostAsJsonAsync("/api/Usuario/CriarUsuario", criarUsuarioDTO);
            resultadoCriar.EnsureSuccessStatusCode();

            CriarAlterarUsuarioDTO alterarUsuarioDTO = new()
            {
                Email = "emailalterausuario@gmail.com",
                Nome = "Nome Teste Alterado",
                Role = (Roles)1,
                Senha = "senha12345678"
            };

            // Act
            var resultado = await client.PutAsJsonAsync("/api/Usuario/AlterarUsuario", alterarUsuarioDTO);
            var model = await resultado.Content.ReadFromJsonAsync<ResponseModelTeste>();
            var usuarioAlteradoJson = model.Objeto.GetRawText();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var usuarioAlterado = JsonSerializer.Deserialize<UsuarioDTO>(usuarioAlteradoJson, options);


            // Assert
            Assert.Equal(HttpStatusCode.OK, resultado.StatusCode);
            Assert.Equal(alterarUsuarioDTO.Nome, usuarioAlterado.Nome);
        }

        [Fact]
        public async Task Delete_Usuario_Test()
        {
            using var client = await _app.GetClientWithAccessTokenAsync();

            // Criar usu�rio
            CriarAlterarUsuarioDTO criarUsuarioDTO = new()
            {
                Email = "emaildeleteusuario@gmail.com",
                Nome = "Nome Teste",
                Role = (Roles)1,
                Senha = "senha123456"
            };

            var resultadoCriar = await client.PostAsJsonAsync("/api/Usuario/CriarUsuario", criarUsuarioDTO);
            resultadoCriar.EnsureSuccessStatusCode();

            // Buscar usu�rio
            var usuario = new BuscarUsuarioDTO
            {
                Email = "emaildeleteusuario@gmail.com"
            };

            var usuarioRetornado = await client.PostAsJsonAsync("/api/Usuario/BuscarUsuario", usuario);
            usuarioRetornado.EnsureSuccessStatusCode();

            var model = await usuarioRetornado.Content.ReadFromJsonAsync<ResponseModelTeste>();

            // Verifica��o da propriedade Objeto como string
            var usuarioEncontradoJson = model.Objeto.GetRawText();

            // Desserializar para UsuarioDTO com case-insensitive options
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var usuarioEncontrado = JsonSerializer.Deserialize<UsuarioDTO>(usuarioEncontradoJson, options);

            // Assert se o usu�rio foi encontrado
            Assert.NotNull(usuarioEncontrado);
            Assert.NotEqual(Guid.Empty, usuarioEncontrado.Id);

            // Excluir usu�rio
            var resultado = await client.DeleteAsync($"/api/Usuario/RemoverUsuario?id={usuarioEncontrado.Id}");

            // Assert
            Assert.Equal(HttpStatusCode.OK, resultado.StatusCode);
        }
    }
}