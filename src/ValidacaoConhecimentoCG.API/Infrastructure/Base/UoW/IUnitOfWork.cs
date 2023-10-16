namespace ValidacaoConhecimentoCG.API.Infrastructure.Base.UoW
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync(CancellationToken cancellationToken = default);
    }
}
