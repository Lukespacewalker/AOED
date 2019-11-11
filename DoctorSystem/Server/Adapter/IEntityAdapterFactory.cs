using DoctorSystem.Shared.Model;
using DoctorSystem.Shared.Model.Entity;

namespace DoctorSystem.Server.Adapter
{
    public interface IEntityAdapterFactory
    {
        EntityAdapter<TEntity, TPrimaryKey> Get<TEntity, TPrimaryKey>() where TEntity : class, IEntity<TPrimaryKey>;
    }
}