using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoctorSystem.Server.Database;
using DoctorSystem.Shared.Model;
using DoctorSystem.Shared.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DoctorSystem.Server.Adapter
{
    public class EntityAdapter<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public EntityAdapter(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<TResult>> Query<TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> func)
        {
            TResult[] data = await func(_applicationDbContext.Set<TEntity>().AsNoTracking()).ToArrayAsync();
            return (IEnumerable<TResult>)data;
        }

        public virtual Task<TEntity> GetById(TPrimaryKey id)
        {
            return _applicationDbContext.Set<TEntity>().AsNoTracking().Where(c => c.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public virtual async Task<(AdapterOperationResult result, TEntity entity, Exception exception)> AddOrUpdateEntity(
            TEntity entity)
        {
            if (!_applicationDbContext.Entry(entity).IsKeySet)
                // New Entity
                _applicationDbContext.Set<TEntity>().Add(entity);
            // May Exiting Entity
            else if (await _applicationDbContext.Set<TEntity>().FindAsync(entity.Id) is TEntity databaseEntity)
            {
                // Using rowVersion from dto
                _applicationDbContext.Entry(databaseEntity).CurrentValues.SetValues(entity);
                _applicationDbContext.Entry(databaseEntity).OriginalValues[nameof(IEntity<TPrimaryKey>.RowVersion)] = entity.RowVersion;
            }
            try
            {
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException concurrencyException)
            {
                foreach (var e in concurrencyException.Entries)
                {
                    if (e.Entity is TEntity entry)
                    {
                        PropertyValues dbValues = e.GetDatabaseValues();
                        return (AdapterOperationResult.Conflict, (TEntity)dbValues.ToObject(), null);
                    }
                }
                return (AdapterOperationResult.Error, null, concurrencyException);
            }
            catch (Exception updateException)
            {
                return (AdapterOperationResult.Error, null, updateException);
            }
            // return 200 OK
            return (AdapterOperationResult.Succeed, entity, null);
        }
        public virtual async Task<(AdapterOperationResult result, Exception exception)> DeleteById(int id)
        {
            if (await _applicationDbContext.Set<TEntity>().FindAsync(id) is TEntity entity)
                _applicationDbContext.Set<TEntity>().Remove(entity);
            else
                return (AdapterOperationResult.NotFound, null);
            try
            {
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (DbUpdateException exception)
            {
                return (AdapterOperationResult.Error, exception);
            }
            return (AdapterOperationResult.Succeed, null);
        }
    }
}