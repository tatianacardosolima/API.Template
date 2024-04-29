using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Template.DatabaseRepository.Context;
using Template.Shared.Abstractions.Entities;
using Template.Shared.Interfaces.IRepositories;

namespace Template.DatabaseRepository.Abastractions
{
    public abstract class AuditRepository<T, TId> : IRepository<T, TId> where T : AuditEntityBase
        where TId : struct
    {
        private readonly TemplateContext _context;

        public AuditRepository(TemplateContext context)
        {
            _context = context;
        }


        public virtual async Task<T> Get(TId id)
        {
            var entity = await _context.Set<T>()
                                    .AsNoTracking()
                                    .Where(x => x.Id.Equals(id))
                                    .ToListAsync();

            return entity.FirstOrDefault();
        }

        public virtual async Task<List<T>> Get()
        {
            return await _context.Set<T>()
                                 .AsNoTracking()
                                 .ToListAsync();
        }


        public virtual Task<List<T>> Pagination(string filter, int skyp, int take)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(T entity)
        {
            return _context.Set<T>()
                .AddAsync(entity)
                .AsTask();
        }

        public Task InsertRangeAsync(List<T> entities)
        {
            return _context.Set<T>()
                .AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            _context.Set<T>()
                .Update(entity);
        }

        public void UpdateRange(List<T> entities)
        {
            _context.Set<T>()
                .UpdateRange(entities);
        }

        public void LogicalDeleteAsync(T entity)
        {
            entity.IsDeleted = true;
            _context.Set<T>()
                .Update(entity);
        }

        public void LogicalDelete(T entity)
        {
            entity.IsDeleted = true;
            _context.Set<T>()
                .Update(entity);
        }

        public Task<T> GetByIdAsync(TId id)
        {
            return _context.Set<T>()
               .FindAsync(id)
               .AsTask();
        }

        public Task<List<T>> GetAllAsync()
        {
            return _context.Set<T>()
               .ToListAsync();
        }

        public Task<List<T>> PaginationAsync(Expression<Func<T, bool>> expression, int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> FindAsync(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>()
               .Where(expression)
               .ToListAsync();
        }

        public Task<bool> ExistsAsync(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().AnyAsync(expression);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public virtual Task<T> GetByUniqueIdAsync(Guid uniqueId)
        {
            return _context.Set<T>()
                  .Where(x => x.UniqueId.Equals(uniqueId))
                  .FirstOrDefaultAsync();
        }

       
    }
}
