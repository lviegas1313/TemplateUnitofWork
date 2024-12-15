namespace TemplateUnitofWork.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
    public interface IYourEntityRepository : IRepository<YourEntity>
    {
        // Adicione métodos específicos para YourEntity aqui
    }
}
