using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sprout.Exam.DataAccess.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity>
    {
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null);
        Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> Insert(TEntity data);
        Task<TEntity> Update(TEntity data);
    }
}
