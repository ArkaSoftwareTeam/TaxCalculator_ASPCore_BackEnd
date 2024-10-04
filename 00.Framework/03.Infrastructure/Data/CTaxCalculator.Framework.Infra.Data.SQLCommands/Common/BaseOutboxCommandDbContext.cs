using CTaxCalculator.Framework.Infra.Data.SQLCommands.Extensions;
using CTaxCalculator.Framework.Infra.Data.SQLCommands.OutBoxEventItems;
using Extensions.Serializers.Abstractions;
using Extensions.UsersManagement.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CTaxCalculator.Framework.Infra.Data.SQLCommands.Common
{
    public abstract class BaseOutboxCommandDbContext : BaseCommandDbContext
    {
        public DbSet<OutBoxEventItem> OutBoxEventItems { get; set; }

        #region Constractors
        public BaseOutboxCommandDbContext(DbContextOptions options) : base(options)
        {

        }

        protected BaseOutboxCommandDbContext()
        {
        }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new OutBoxEventItemConfigure());
        }
        protected override void BeforeSaveTriggers()
        {
            base.BeforeSaveTriggers();
            AddOutboxEvetItems();
        }
        private void AddOutboxEvetItems()
        {
            var changedAggregates = ChangeTracker.GetAggregatesWithEvent();
            var userInfoService = this.GetService<IUserInfoService>();
            var serialize = this.GetService<IJsonSerializer>();
            foreach (var aggregate in changedAggregates)
            {
                var events = aggregate.GetEvents();
                foreach (var @event in events)
                {
                    OutBoxEventItems.Add(new OutBoxEventItem
                    {
                        EventId = Guid.NewGuid(),
                        AccruedByUserId = userInfoService.UserId().ToString(),
                        AccruedOn = DateTime.Now,
                        AggregateId = aggregate.BusinessId.ToString(),
                        AggregateName = aggregate.GetType().Name,
                        AggregateTypeName = aggregate.GetType().FullName!,
                        EventName = @event.GetType().Name,
                        EventTypeName = @event.GetType().FullName!,
                        EventPayload = serialize.Serialize(@event),
                        IsProcessed = false
                    });
                }
            }
        }
    }
}

