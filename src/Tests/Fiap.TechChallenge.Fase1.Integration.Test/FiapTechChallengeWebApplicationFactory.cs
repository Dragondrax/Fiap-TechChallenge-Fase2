using Fiap.TechChallenge.Fase1.Infraestructure.DTO.Usuario;
using Fiap.TechChallenge.Fase1.Integration.Tests.Infra;
using Fiap.TechChallenge.Fase1.SharedKernel.Model;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

namespace Fiap.TechChallenge.Fase1.Integration.Tests
{
    public class FiapTechChallengeWebApplicationFactory : WebApplicationFactory<Program>
    {
        private readonly FiapTechChallengeWebApplicationFactory _app;
        private readonly IConfiguration _configuration;
        public readonly string _email;
        public readonly string _senha;

        public FiapTechChallengeWebApplicationFactory()
        {
            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _email = _configuration.GetValue<string>("SecretEmail");
            _senha = _configuration.GetValue<string>("SecretPassWord");
        }


        public async  Task<HttpClient> GetClientWithAccessTokenAsync()
        {
            var client = this.CreateClient();

            var usuario = new AutenticarUsuarioDTO
            {
                Email = _email,
                Senha = _senha
            };

            var resultado = await client.PostAsJsonAsync("/api/Usuario/Autenticar", usuario);

            resultado.EnsureSuccessStatusCode();

            var result = await resultado.Content.ReadFromJsonAsync<ResponseModel>();

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", result!.Objeto.ToString());

            return client;
        }
    }
}
