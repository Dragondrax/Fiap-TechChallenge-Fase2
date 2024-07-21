using Fiap.TechChallenge.Fase1.Data.Context;
using Fiap.TechChallenge.Fase1.Integration.Tests.Infra;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Fiap.TechChallenge.Fase1.Infraestructure.DTO.Usuario;
using System.Net.Http.Json;
using Fiap.TechChallenge.Fase1.SharedKernel.Model;

namespace Fiap.TechChallenge.Fase1.Integration.Tests
{
    public class FiapTechChallengeWebApplicationFactory : WebApplicationFactory<Program>
    {
        private readonly DockerFixture _dockerFixture;
        private readonly string _connectionString;

        public FiapTechChallengeWebApplicationFactory()
        {
            _dockerFixture = new DockerFixture();
            _connectionString = _dockerFixture.GetConnectionString();
        }

        //protected override void ConfigureWebHost(IWebHostBuilder builder)
        //{
        //    CreateTables();

        //    builder.ConfigureServices(services =>
        //    {
        //        services.RemoveAll(typeof(DbContextOptions<ContextTechChallenge>));

        //        services.AddDbContext<ContextTechChallenge>(options => options.UseNpgsql(_connectionString));

        //    });
        //    base.ConfigureWebHost(builder);
        //}

        public async  Task<HttpClient> GetClientWithAccessTokenAsync()
        {
            var client = this.CreateClient();

            var usuario = new AutenticarUsuarioDTO
            {
                Email = "filipe.rosa@gmail.com",
                Senha = "Teste@102030"
            };

            var resultado = await client.PostAsJsonAsync("/api/Usuario/Autenticar", usuario);

            resultado.EnsureSuccessStatusCode();

            var result = await resultado.Content.ReadFromJsonAsync<ResponseModel>();

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", result!.Objeto.ToString());

            return client;
        }

        public bool CreateTables()
        {
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    string createTableQuery = @"
                        CREATE TABLE quotes (
                              id SERIAL PRIMARY KEY,
                              language VARCHAR(255),
                              region VARCHAR(255),
                              quote_type VARCHAR(255),
                              type_disp VARCHAR(255),
                              quote_source_name VARCHAR(255),
                              triggerable BOOLEAN,
                              custom_price_alert_confidence VARCHAR(255),
                              trending_score DOUBLE PRECISION,
                              exchange VARCHAR(255),
                              market VARCHAR(255),
                              full_exchange_name VARCHAR(255),
                              company_logo_url VARCHAR(255),
                              logo_url VARCHAR(255),
                              market_state VARCHAR(255),
                              source_interval INT,
                              exchange_data_delayed_by INT,
                              exchange_timezone_name VARCHAR(255),
                              exchange_timezone_short_name VARCHAR(255),
                              gmt_offset_milliseconds INT,
                              esg_populated BOOLEAN,
                              tradeable BOOLEAN,
                              crypto_tradeable BOOLEAN,
                              first_trade_date_milliseconds BIGINT,
                              price_hint INT,
                              regular_market_change_percent DOUBLE PRECISION,
                              regular_market_time INT,
                              symbol VARCHAR(255)
                            );
                    ";

                    connection.Execute(createTableQuery);
                }
            }
            catch (Exception)
            {
                return false;
            }
            
            return true;
        }
    }
}
