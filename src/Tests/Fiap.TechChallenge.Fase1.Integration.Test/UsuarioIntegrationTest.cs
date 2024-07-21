using Fiap.TechChallenge.Fase1.Infraestructure.DTO.Usuario;
using Fiap.TechChallenge.Fase1.Integration.Tests;
using System.Net;
using System.Net.Http.Json;

namespace Fiap.TechChallenge.Fase1.Integration.Test
{
    public class UsuarioIntegrationTest
    {
        private readonly FiapTechChallengeWebApplicationFactory _app;

        public UsuarioIntegrationTest()
        {
            _app = new FiapTechChallengeWebApplicationFactory();
        }

        [Fact]
        public async void Post_Efetua_Login_Com_Sucesso()
        {
            // Arrange
            using var client = _app.CreateClient();

            var usuario = new AutenticarUsuarioDTO
            {
                Email = "filipe.rosa@gmail.com",
                Senha = "Teste@102030"
            };

            // Act
            var resultado = await client.PostAsJsonAsync("/api/Usuario/Autenticar", usuario);

            // Assert
            Assert.Equal(HttpStatusCode.OK, resultado.StatusCode);
        }

        [Fact]
        public async void Post_Busca_Usuario_Com_Sucesso()
        {
            // Arrange
            using var client = await _app.GetClientWithAccessTokenAsync();

            var usuario = new BuscarUsuarioDTO
            {
                Email = "filipe.rosa@gmail.com"
            };

            // Act
            var resultado = await client.PostAsJsonAsync("/api/Usuario/BuscarUsuario", usuario);
            var aux = resultado.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.Equal(HttpStatusCode.OK, resultado.StatusCode);
        }
    }
}