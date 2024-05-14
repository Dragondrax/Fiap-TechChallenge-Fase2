namespace Fiap.TechChallenge.Fase1.SharedKernel.Data
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        Task AdicionarAsync(T entidade);
        Task<T> ObterPorId(Guid id);
        Task AtualizarAsync(T entidade);
        Task RemoverAsync(T entidade);
        Task<bool> SalvarAsync();
    }
}
