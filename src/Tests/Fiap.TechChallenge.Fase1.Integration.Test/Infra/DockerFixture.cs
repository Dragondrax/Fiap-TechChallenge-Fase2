﻿using Docker.DotNet;
using Docker.DotNet.Models;
using Fiap.TechChallenge.Fase1.Data.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Moq;

namespace Fiap.TechChallenge.Fase1.Integration.Tests.Infra
{
    public class DockerFixture : IDockerFixture, IDisposable
    {
        private DockerClient _dockerClient;
        private string _containerId;
        private readonly string _environment;
        public string GetConnectionString()
        {
            var _connectionString = $"Server=localhost;Port=5432;Database=techchallenge;User Id=postgres;Password=102030;";
            return _connectionString;
        }

        public void Dispose()
        {
            _dockerClient.Containers.StopContainerAsync(_containerId, new ContainerStopParameters()).GetAwaiter().GetResult();
            _dockerClient.Containers.RemoveContainerAsync(_containerId, new ContainerRemoveParameters()).GetAwaiter().GetResult();
            _dockerClient.Dispose();
        }

        public void Handle()
        {
            try
            {
                _dockerClient = new DockerClientConfiguration().CreateClient();

                var createContainerResponse = _dockerClient.Containers.CreateContainerAsync(new CreateContainerParameters
                {
                    Name = "postgres-fiap-integracao",
                    Image = "postgres",
                    Env = new List<string> { "POSTGRES_DB=techchallenge", "POSTGRES_USER=postgres", "POSTGRES_PASSWORD=102030" },
                    HostConfig = new HostConfig
                    {
                        PortBindings = new Dictionary<string, IList<PortBinding>>()
                    {
                        { "5432/tcp", new List<PortBinding> { new PortBinding { HostPort = "5432" } } }
                    },
                        PublishAllPorts = true // Optional: Set this to true if you want to publish all exposed ports
                    }
                }).GetAwaiter().GetResult();

                _containerId = createContainerResponse.ID;

                _dockerClient.Containers.StartContainerAsync(_containerId, new ContainerStartParameters()).GetAwaiter().GetResult();

                var options = new DbContextOptionsBuilder<ContextTechChallenge>()
                    .UseNpgsql(GetConnectionString())
                    .Options;

                using (var context = new ContextTechChallenge(options))
                {
                    context.Database.Migrate();
                }
            }
            catch
            {
                Dispose();
            }

        }
    }
}