using DoctorSystem.Shared.Model;

namespace DoctorSystem.Server.Adapter
{
    public interface IParentEntityAdapterFactory
    {
        ParentEntityAdapter<TEntity, TPrimaryKey> Get<TEntity, TPrimaryKey>() where TEntity : class, IEntity<TPrimaryKey>;
    }
}