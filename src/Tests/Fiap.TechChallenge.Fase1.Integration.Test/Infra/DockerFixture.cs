using Docker.DotNet;
using Docker.DotNet.Models;
using Fiap.TechChallenge.Fase1.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Fiap.TechChallenge.Fase1.Integration.Tests.Infra
{
    public class DockerFixture : IDisposable
    {
        private string _containerId;
        private readonly string _environment;
        private readonly string containerName = "postgres-fiap-integracao";
        private readonly DockerClient _dockerClient = new DockerClientConfiguration().CreateClient();

        public DockerFixture()
        {
            var existingContainer = _dockerClient.Containers.ListContainersAsync(new ContainersListParameters { All = true }).GetAwaiter().GetResult()
                                                            .FirstOrDefault(c => c.Names.Contains($"/{containerName}"));

            if (existingContainer != null)
            {
                _containerId = existingContainer.ID;
                if (existingContainer.State != "running")
                {
                    _dockerClient.Containers.StartContainerAsync(_containerId, new ContainerStartParameters()).GetAwaiter().GetResult();
                }
            }
            else
            {
                var createContainerResponse = _dockerClient.Containers.CreateContainerAsync(new CreateContainerParameters
                {
                    Name = containerName,
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

                var context = new ContextTechChallenge(options);
                context.Database.MigrateAsync().GetAwaiter().GetResult();
            }
        }

        public string GetConnectionString()
        {
            var _connectionString = $"Server=localhost;Port=5432;Database=techchallenge;User Id=postgres;Password=102030;";
            return _connectionString;
        }

        public void Dispose()
        {
            var existingContainer = _dockerClient.Containers.ListContainersAsync(new ContainersListParameters { All = true }).GetAwaiter().GetResult()
                    .FirstOrDefault(c => c.Names.Contains($"/{containerName}"));

            if (existingContainer != null)
            {
                _containerId = existingContainer.ID;
                if (existingContainer.State == "running")
                {
                    _dockerClient.Containers.StopContainerAsync(_containerId, new ContainerStopParameters()).GetAwaiter().GetResult();
                    _dockerClient.Containers.RemoveContainerAsync(_containerId, new ContainerRemoveParameters()).GetAwaiter().GetResult();
                    _dockerClient.Dispose();
                }
            }
        }
    }
}