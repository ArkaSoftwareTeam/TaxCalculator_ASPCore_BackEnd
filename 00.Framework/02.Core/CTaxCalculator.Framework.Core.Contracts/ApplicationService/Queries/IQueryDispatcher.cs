using CTaxCalculator.Framework.Core.RequestResponse.Queries;

namespace CTaxCalculator.Framework.Core.Contracts.ApplicationService.Queries
{

    /// <summary>
    ///جهت اتصال ساده کوئری‌ها به هندلر‌ها  Mediator تعریف ساختار الگوی
    /// </summary>
    public interface IQueryDispatcher
    {
        Task<QueryResult<TData>> Execute<TQuery, TData>(TQuery query) where TQuery : class, IQuery<TData>;
    }
}
