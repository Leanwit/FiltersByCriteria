using System.Threading.Tasks;

namespace src.CsharpBasicSkeleton.Shared.Domain.Bus.Queries
{
    public interface QueryHandler<TQuery, TResponse> where TQuery : Query
    {
        Task<TResponse> Handle(TQuery query);
    }
}