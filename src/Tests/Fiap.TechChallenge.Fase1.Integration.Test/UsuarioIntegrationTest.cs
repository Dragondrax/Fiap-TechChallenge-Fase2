using Fiap.TechChallenge.Fase1.Infraestructure.DTO.Usuario;
using Fiap.TechChallenge.Fase1.Integration.Tests;
using Microsoft.Extensions.Configuration;
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

        /// <summary>
        /// Primeiro Teste realiza a autenticação com um usuario padrão definido também dentro das secrets do CI do Github ACtions e configurado aqui na API
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
        /// Faz autenticação e busca um usuário padrão para retorno positivo e teste de integração
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
    }
}