using System.Threading.Tasks;

namespace src.CsharpBasicSkeleton.Shared.Domain.Bus.Queries
{
    public interface QueryBus
    {
        Task<TResponse> Ask<TResponse>(Query request);
    }
}