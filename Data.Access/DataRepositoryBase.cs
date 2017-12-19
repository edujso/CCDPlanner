using Core.Common.Contracts;
using Core.Common.Data;

namespace Data.Access
{
    public abstract class DataRepositoryBase<T> : DataRepositoryBase<T, CCDPlannerDBContext>
        where T : class, new()
    {
    }
}
