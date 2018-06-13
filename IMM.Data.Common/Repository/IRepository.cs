namespace IMM.Data.Common.Repository
{
    using System.Linq;

    public interface IRepository<T> : IGenericRepository<T> where T : class
    {
        IQueryable<T> AllWithDeleted();
    }
}
