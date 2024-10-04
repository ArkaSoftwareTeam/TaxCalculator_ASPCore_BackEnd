using Microsoft.EntityFrameworkCore;

namespace CTaxCalculator.Framework.Infra.Data.SQLQueries.QueryDbContext
{
    public abstract class BaseQueryDbContext : DbContext
    {
        public BaseQueryDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        #region SaveChanges Methods Is Not Use And Impelements
        public override int SaveChanges()
        {
            throw new NotSupportedException("You cannot have the concept of storage on the CQRS template and using Query.");
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            throw new NotSupportedException("You cannot have the concept of storage on the CQRS template and using Query.");

        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("You cannot have the concept of storage on the CQRS template and using Query.");

        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("You cannot have the concept of storage on the CQRS template and using Query.");

        }

        #endregion
    }
}
