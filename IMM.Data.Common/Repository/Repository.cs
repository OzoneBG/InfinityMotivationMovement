namespace IMM.Data.Common.Repository
{
    using IMM.Data.Common.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class Repository<T> : GenericRepository<T>, IRepository<T>
        where T : class, IDeletableEntity
    {
        public Repository(DbContext context)
            : base(context)
        {
        }

        public override IQueryable<T> All()
        {
            return base.All().Where(x => !x.IsDeleted);
        }

        public IQueryable<T> AllWithDeleted()
        {
            return base.All();
        }
    }
}
