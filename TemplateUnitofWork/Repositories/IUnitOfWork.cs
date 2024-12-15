using TemplateUnitofWork.Repository;

namespace TemplateUnitofWork.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IYourEntityRepository YourEntities { get; }
        Task<int> CompleteAsync();
    }


}
