using Docker.DotNet;
using Docker.DotNet.Models;

namespace Fiap.TechChallenge.Fase1.Integration.Tests.Infra
{
    public class DockerFixture : IDisposable
    {
        private DockerClient _dockerClient;
        private string _containerId;
        private readonly string _environment;

        public DockerFixture()
        {
            _dockerClient = new DockerClientConfiguration().CreateClient();

            //var createContainerResponse = _dockerClient.Containers.CreateContainerAsync(new CreateContainerParameters
            //{
            //    Name = "postgres-fiap-tests-integracao",
            //    Image = "postgres",
            //    Env = new List<string> { "POSTGRES_DB=fiap-teste", "POSTGRES_PASSWORD=1020304050" },
            //    HostConfig = new HostConfig
            //    {
            //        PortBindings = new Dictionary<string, IList<PortBinding>>()
            //        {
            //            { "5432/tcp", new List<PortBinding> { new PortBinding { HostPort = "5432" } } }
            //        },
            //        PublishAllPorts = true // Optional: Set this to true if you want to publish all exposed ports
            //    }
            //}).GetAwaiter().GetResult();


            //_containerId = createContainerResponse.ID;

            _containerId = "694b9430fad2477e9653ee9ba6e717b214f8029823136dc05c1f37666f4b6a11";

            //_dockerClient.Containers.StartContainerAsync(_containerId, new ContainerStartParameters()).GetAwaiter().GetResult();
        }
        public string GetConnectionString()
        {
            var _connectionString = $"Server=localhost;Port=5432;Database=fiap-teste;User Id=postgres;Password=1020304050;";
            return _connectionString;
        }

        public void Dispose()
        {
            _dockerClient.Containers.StopContainerAsync(_containerId, new ContainerStopParameters()).GetAwaiter().GetResult();
            //_dockerClient.Containers.RemoveContainerAsync(_containerId, new ContainerRemoveParameters()).GetAwaiter().GetResult();
            _dockerClient.Dispose();
        }
    }
}
