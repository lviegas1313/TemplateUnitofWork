using TemplateUnitofWork.Data;
using TemplateUnitofWork.Repository;

namespace TemplateUnitofWork.Repositories
{
    public class YourEntityRepository : RepositoryBase<YourEntity>, IYourEntityRepository
    {
        public YourEntityRepository(DbContexto context) : base(context)
        {
        }

        // Métodos adicionais específicos para YourEntity podem ser adicionados aqui
    }   
}
