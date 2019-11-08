using Checkout.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Checkout.Data.Services
{
    public class RepositoryService
    {
        private const bool SAVE = true;
        private readonly EFRepository repository;

        public RepositoryService(EFRepository repository)
        {
            this.repository = repository;
        }
        public TEntity Add<TEntity>(TEntity item, bool AutoSave = SAVE) where TEntity : class
        {
            repository.Add(item);

            if (AutoSave)
            {
                SaveChanges();
            }
            return item;
        }

        public IEnumerable<TEntity> Add<TEntity>(IEnumerable<TEntity> items, bool AutoSave = SAVE) where TEntity : class
        {
            repository.Add(items);

            if (AutoSave)
            {
                SaveChanges();
            }
            return items;
        }

        public bool Update<TEntity>(TEntity item, bool AutoSave = SAVE) where TEntity : class
        {
            var result = repository.Update(item);

            if (AutoSave)
            {
                SaveChanges();
            }
            return result;
        }

        public bool Update<TEntity>(IEnumerable<TEntity> items, bool AutoSave = SAVE) where TEntity : class
        {
            var result = repository.Update(items);

            if (AutoSave)
            {
                SaveChanges();
            }
            return result;
        }

        public bool Delete<TEntity>(TEntity item, bool AutoSave = SAVE) where TEntity : class
        {
            bool result = repository.Delete(item);
            if (AutoSave)
            {
                SaveChanges();
            }
            return result;
        }

        public bool Delete<TEntity>(IEnumerable<TEntity> items, bool AutoSave = SAVE) where TEntity : class
        {
            bool result = repository.Delete(items);
            if (AutoSave)
            {
                SaveChanges();
            }
            return result;
        }

        public bool DeleteByID<TEntity>(Expression<Func<TEntity, bool>> predicate, bool AutoSave = SAVE) where TEntity : class
        {
            var result = false;

            var items = repository.Find(predicate);
            if (items != null)
            {

                result = repository.Delete<TEntity>(items);

                if (AutoSave)
                {
                    SaveChanges();
                }

                return result;
            }
            return result;
        }

        public int SaveChanges()
        {
            return repository.Context.SaveChanges();
        }

        public TEntity GetByID<TEntity>(Expression<Func<TEntity, bool>> id) where TEntity : class
        {
            TEntity item = repository.GetByID(id);

            return item;
        }

        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return repository.GetAll<TEntity>();
        }

        public IQueryable<TEntity> GetAll<TEntity, TKey>(Expression<Func<TEntity, TKey>> orderBy) where TEntity : class
        {
            return repository.GetAll(orderBy);
        }

        public IQueryable<TEntity> GetAll<TEntity>(int pageIndex, int pageSize) where TEntity : class
        {
            return repository
                .GetAll<TEntity>(pageIndex, pageSize);
        }

        public IQueryable<TEntity> GetAll<TEntity, TKey>(int pageIndex, int pageSize, Expression<Func<TEntity, TKey>> orderBy) where TEntity : class
        {
            return repository
                .GetAll(pageIndex, pageSize, orderBy);
        }

        public IQueryable<TEntity> Find<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return repository
                .Find(predicate);
        }
        public IQueryable<TEntity> Find<TEntity, TKey>(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, Expression<Func<TEntity, TKey>> orderBy) where TEntity : class
        {
            return repository
                .Find(predicate, pageIndex, pageSize, orderBy);
        }
    }
}
