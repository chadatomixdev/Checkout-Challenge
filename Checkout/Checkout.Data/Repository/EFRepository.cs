using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Checkout.Data.Repository
{
    public class EFRepository
    {
        public CheckoutDBContext Context { get; }

        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// 
        public EFRepository(CheckoutDBContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        #region Add

        /// <summary>
        /// Add Single Entity
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// 
        public TEntity Add<TEntity>(TEntity item) where TEntity : class
        {
            Context.Add(item);
            return item;
        }

        /// <summary>
        /// Add Multiple Entities 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> Add<TEntity>(IEnumerable<TEntity> items) where TEntity : class
        {
            Context.AddRange(items);

            return items;
        }

        #endregion

        #region Delete

        /// <summary>
        /// Delete Single Entity
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Delete<TEntity>(TEntity item) where TEntity : class
        {
            Context.Attach(item);
            Context.Remove(item);

            return true;
        }

        /// <summary>
        /// Delete Multiple Entities
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public bool Delete<TEntity>(IEnumerable<TEntity> items) where TEntity : class
        {
            Context.AttachRange(items);
            Context.RemoveRange(items);

            return true;
        }

        #endregion

        #region Update

        /// <summary>
        /// Update Single Entity
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update<TEntity>(TEntity item) where TEntity : class
        {
            Context.Attach(item);
            Context.Update(item);
            Context.Entry(item).State = EntityState.Modified;

            return true;
        }

        /// <summary>
        /// Update Multiple Entities
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public bool Update<TEntity>(IEnumerable<TEntity> items) where TEntity : class
        {
            Context.AttachRange(items);
            Context.UpdateRange(items);

            return true;
        }

        #endregion

        #region Select

        /// <summary>
        /// Get Single Entity By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity GetByID<TEntity>(Expression<Func<TEntity, bool>> id) where TEntity : class
        {
            return Context.Set<TEntity>().SingleOrDefault(id);
        }

        /// <summary>
        /// Get All Records of an Entity
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return Context.Set<TEntity>();
        }

        /// <summary>
        /// Get All Records of an Entity and Order the Results
        /// </summary>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public IQueryable<TEntity> GetAll<TEntity, TKey>(Expression<Func<TEntity, TKey>> orderBy) where TEntity : class
        {
            return Context.Set<TEntity>().OrderBy(orderBy);
        }

        /// <summary>
        /// Get All records of an Entity by page index and size
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IQueryable<TEntity> GetAll<TEntity>(int pageIndex, int pageSize) where TEntity : class
        {
            return Context.Set<TEntity>().Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public IQueryable<TEntity> GetAll<TEntity, TKey>(int pageIndex, int pageSize, Expression<Func<TEntity, TKey>> orderBy) where TEntity : class
        {
            return Context.Set<TEntity>().Skip((pageIndex - 1) * pageSize).Take(pageSize).OrderBy(orderBy);
        }

        /// <summary>
        /// Get an Entity by predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IQueryable<TEntity> Find<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        /// 
        public IQueryable<TEntity> Find<TEntity, TKey>(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, Expression<Func<TEntity, TKey>> orderBy) where TEntity : class
        {
            return Context.Set<TEntity>().Where(predicate).Skip((pageIndex - 1) * pageSize).Take(pageSize).OrderBy(orderBy);
        }

        #endregion
    }
}
