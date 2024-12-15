using TemplateUnitofWork.Data;
using TemplateUnitofWork.Repository;

namespace TemplateUnitofWork.Repositories
{
    public class UnitOfWork(DbContexto context) : IUnitOfWork
    {
        private YourEntityRepository? _yourEntities;
        private bool _disposed = false; // Flag to indicate if the object has been disposed

        public IYourEntityRepository YourEntities => _yourEntities ??= new YourEntityRepository(context);

        public async Task<int> CompleteAsync()
        {
            return await context.SaveChangesAsync();
        }

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                // Dispose managed state (managed objects).
                context.Dispose();
            }

            // Free any unmanaged resources (if any) here.

            _disposed = true;
        }

        // Destructor to ensure Dispose is called
        ~UnitOfWork()
        {
            Dispose(false);
        }
    }


}
