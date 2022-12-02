using GamerForumWeb.Db.Data;
using GamerForumWeb.Db.Repository;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameForumWeb.Tests.Moks
{
    public class RepositoryMock : IRepository
    {
        
        protected DbContext Context { get; set; }

        protected DbSet<T> DbSet<T>() where T : class
        {
            return Context.Set<T>();
        }

        public RepositoryMock(GamerForumWebDbContext context)
        {
            Context = context;
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
            await DbSet<T>().AddAsync(entity);
        }

        public async Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class
        {
            await DbSet<T>().AddRangeAsync(entities);
        }

        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>().AsQueryable();
        }

        public IQueryable<T> All<T>(Expression<Func<T, bool>> search) where T : class
        {
            return DbSet<T>().Where(search);
        }

        public IQueryable<T> All<T>(Expression<Func<T, bool>> search, Expression<Func<T, object>> includeProperties) where T : class
        {
            return DbSet<T>().Where(search).Include(includeProperties);
        }

        
        public IQueryable<T> AllReadonly<T>() where T : class
        {
            return DbSet<T>()
                .AsNoTracking();
        }
        public IQueryable<T> AllReadonly<T>(Expression<Func<T, bool>> search) where T : class
        {
            return DbSet<T>()
                .Where(search)
                .AsNoTracking();
        }

       
        public async Task DeleteAsync<T>(object id) where T : class
        {
            T entity = await GetByIdAsync<T>(id);

            Delete(entity);
        }

        
        public void Delete<T>(T entity) where T : class
        {
            EntityEntry entry = Context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                DbSet<T>().Attach(entity);
            }

            entry.State = EntityState.Deleted;
        }

        
        public void Detach<T>(T entity) where T : class
        {
            EntityEntry entry = Context.Entry(entity);

            entry.State = EntityState.Detached;
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        
        public async Task<T> GetByIdAsync<T>(object id) where T : class
        {
            return await DbSet<T>().FindAsync(id);
        }

        public async Task<T> GetByIdsAsync<T>(object[] id) where T : class
        {
            return await DbSet<T>().FindAsync(id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }

       
        public void Update<T>(T entity) where T : class
        {
            DbSet<T>().Update(entity);
        }

        
        public void UpdateRange<T>(IEnumerable<T> entities) where T : class
        {
            DbSet<T>().UpdateRange(entities);
        }

        public void DeleteRange<T>(IEnumerable<T> entities) where T : class
        {
            DbSet<T>().RemoveRange(entities);
        }

        public void DeleteRange<T>(Expression<Func<T, bool>> deleteWhereClause) where T : class
        {
            var entities = All(deleteWhereClause);
            DeleteRange(entities);
        }
    }
}
