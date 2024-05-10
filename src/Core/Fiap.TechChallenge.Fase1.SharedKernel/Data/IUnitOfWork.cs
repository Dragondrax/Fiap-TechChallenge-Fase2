namespace Fiap.TechChallenge.Fase1.SharedKernel.Data
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}
