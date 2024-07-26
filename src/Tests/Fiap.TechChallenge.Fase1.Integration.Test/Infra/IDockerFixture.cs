namespace Fiap.TechChallenge.Fase1.Integration.Tests.Infra
{
    public interface IDockerFixture
    {
        void Handle();
        string GetConnectionString();
        void Dispose();
    }
}
