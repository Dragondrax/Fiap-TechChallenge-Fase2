using Fiap.TechChallenge.Fase1.Data.Context;
using Fiap.TechChallenge.Fase1.Infraestructure.DTO.Usuario;
using Fiap.TechChallenge.Fase1.SharedKernel.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
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


        /// <summary>
        /// Trecho reconfigurar a string de conexão caso precise para os testes
        /// </summary>
        /// <param name="builder"></param>
        //protected override void ConfigureWebHost(IWebHostBuilder builder)
        //{
        //    builder.ConfigureServices(services =>
        //    {
        //        services.RemoveAll(typeof(DbContextOptions<ContextTechChallenge>));

        //        services.AddDbContext<ContextTechChallenge>(options => options.UseNpgsql("string nova de conection aqui"));

        //    });
        //    base.ConfigureWebHost(builder);
        //}


        /// <summary>
        /// Configuração para na hora do teste, chamar esse trecho para realizar a autenticação na API com o usuário e senha que contenham dentro da database. Nesse caso será inserido o mesmo usuário e senha via CI
        /// </summary>
        /// <returns></returns>
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
