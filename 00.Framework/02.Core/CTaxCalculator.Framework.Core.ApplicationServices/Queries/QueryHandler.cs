using CTaxCalculator.Framework.Core.Contracts.ApplicationService.Queries;
using CTaxCalculator.Framework.Core.RequestResponse.Common;
using CTaxCalculator.Framework.Core.RequestResponse.Queries;
using CTaxCalculator.Framework.Utilities.OutServices.Services;

namespace CTaxCalculator.Framework.Core.ApplicationServices.Queries
{
    public abstract class QueryHandler<TQuery, TData> : IQueryHandler<TQuery, TData>
        where TQuery : class, IQuery<TData>
    {
        protected readonly ArkaSoftwareCMPOutServices _mafiaOuterService;
        protected readonly QueryResult<TData> result = new();

        protected virtual Task<QueryResult<TData>> ResultAsync(TData data, ApplicationServiceStatus status)
        {
            result._data = data;
            result.Status = status;
            return Task.FromResult(result);
        }

        protected virtual QueryResult<TData> Result(TData data, ApplicationServiceStatus status)
        {
            result._data = data;
            result.Status = status;
            return result;
        }

        protected virtual Task<QueryResult<TData>> ResultAsync(TData data)
        {
            var status = data != null ? ApplicationServiceStatus.Ok : ApplicationServiceStatus.NotFound;
            return ResultAsync(data, status);
        }

        protected virtual QueryResult<TData> Result(TData data)
        {
            var status = data != null ? ApplicationServiceStatus.Ok : ApplicationServiceStatus.NotFound;
            return Result(data, status);
        }

        public QueryHandler(ArkaSoftwareCMPOutServices mafiaOuterService)
        {
            _mafiaOuterService = mafiaOuterService;
        }

        protected void AddMessage(string message)
        {
            result.AddMessage(_mafiaOuterService.Translator[message]);
        }

        protected void AddMessage(string message, params string[] arguments)
        {
            result.AddMessage(_mafiaOuterService.Translator[message, arguments]);
        }

        public abstract Task<QueryResult<TData>> Handle(TQuery query);
    }
}
