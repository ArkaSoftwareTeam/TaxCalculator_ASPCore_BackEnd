using CTaxCalculator.Framework.Core.Contracts.Data.Commands;
using CTaxCalculator.Framework.Core.Domain.Aggregates;
using CTaxCalculator.Framework.Core.Domain.ValueOBJs;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CTaxCalculator.Framework.Infra.Data.SQLCommands.Common
{
    public class BaseCommandRepository<TEntity, TDbContext, TId> : ICommandRepository<TEntity, TId>, IUnitOfWork
        where TEntity : AggregateRoot<TId>
        where TDbContext : BaseCommandDbContext
        where TId : struct, IComparable, IComparable<TId>, IConvertible, IEquatable<TId>, IFormattable
    {
        #region DI In CTOR
        protected readonly TDbContext _dbContext;

        public BaseCommandRepository(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Deleted
        public void Delete(TId id)
        {
            var entity = _dbContext.Set<TEntity>().Find(id);
            _dbContext.Set<TEntity>().Remove(entity!);
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public void DeleteGraph(TId id)
        {
            var entity = GetGraph(id);
            if (entity is not null && !entity.Id.Equals(default))
                _dbContext.Set<TEntity>().Remove(entity);
        }
        #endregion

        #region insert

        public void Insert(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }

        public async Task InsertAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
        }
        #endregion

        #region Get Single Item
        public TEntity Get(TId id)
        {
            return _dbContext.Set<TEntity>().Find(id)!;
        }

        public TEntity Get(BusinessID businessId)
        {
            return _dbContext.Set<TEntity>().FirstOrDefault(c => c.BusinessId == businessId)!;
        }

        public async Task<TEntity> GetAsync(TId id)
        {
            var result = await _dbContext!.Set<TEntity>().FindAsync(id);
            return result!;
        }

        public async Task<TEntity> GetAsync(BusinessID businessId)
        {
            var result = await _dbContext.Set<TEntity>().FirstOrDefaultAsync(c => c.BusinessId == businessId);
            return result!;
        }
        #endregion

        #region Get single item with graph
        public TEntity GetGraph(TId id)
        {
            var graphPath = _dbContext.GetIncludePaths(typeof(TEntity));
            IQueryable<TEntity> query = _dbContext.Set<TEntity>().AsQueryable();
            var temp = graphPath.ToList();
            foreach (var item in graphPath)
            {
                query = query.Include(item);
            }
            return query.FirstOrDefault(c => c.Id.Equals(id))!;
        }

        public TEntity GetGraph(BusinessID businessId)
        {
            var graphPath = _dbContext.GetIncludePaths(typeof(TEntity));
            IQueryable<TEntity> query = _dbContext.Set<TEntity>().AsQueryable();
            var temp = graphPath.ToList();
            foreach (var item in graphPath)
            {
                query = query.Include(item);
            }
            return query.FirstOrDefault(c => c.BusinessId == businessId)!;
        }

        public async Task<TEntity> GetGraphAsync(TId id)
        {
            var graphPath = _dbContext.GetIncludePaths(typeof(TEntity));
            IQueryable<TEntity> query = _dbContext.Set<TEntity>().AsQueryable();
            foreach (var item in graphPath)
            {
                query = query.Include(item);
            }
            var result = await query.FirstOrDefaultAsync(c => c.Id.Equals(id));
            return result!;
        }

        public async Task<TEntity> GetGraphAsync(BusinessID businessId)
        {
            var graphPath = _dbContext.GetIncludePaths(typeof(TEntity));
            IQueryable<TEntity> query = _dbContext.Set<TEntity>().AsQueryable();
            foreach (var item in graphPath)
            {
                query = query.Include(item);
            }
            var result = await query.FirstOrDefaultAsync(c => c.BusinessId == businessId);
            return result!;
        }
        #endregion

        #region Exists
        public bool Exists(Expression<Func<TEntity, bool>> expression)
        {
            return _dbContext.Set<TEntity>().Any(expression);
        }

        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbContext.Set<TEntity>().AnyAsync(expression);
        }
        #endregion

        #region Transaction management
        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
        public void BeginTransaction()
        {
            _dbContext.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _dbContext.CommitTransaction();
        }
        public void RollbackTransaction()
        {
            _dbContext.RollbackTransaction();
        }
        #endregion
    }


    public class BaseCommandRepository<TEntity, TDbContext> : BaseCommandRepository<TEntity, TDbContext, long>
        where TEntity : AggregateRoot
        where TDbContext : BaseCommandDbContext
    {
        public BaseCommandRepository(TDbContext dbContext) : base(dbContext)
        {
        }
    }
}
