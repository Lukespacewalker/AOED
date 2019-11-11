using DoctorSystem.Server.Database;
using DoctorSystem.Shared.Model.Entity;

namespace DoctorSystem.Server.Adapter
{
    public class EntityAdapterFactory : IEntityAdapterFactory
    {
        private readonly ApplicationDbContext _dbContext;

        public EntityAdapterFactory(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public EntityAdapter<TEntity, TPrimaryKey> Get<TEntity, TPrimaryKey>() where TEntity : class, IEntity<TPrimaryKey>
        {
            return new EntityAdapter<TEntity, TPrimaryKey>(_dbContext);
        }
    }
}