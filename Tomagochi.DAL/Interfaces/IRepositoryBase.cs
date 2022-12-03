using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Tomagochi.DAL.Interfaces
{
    public interface IRepositoryBase<T> where T: class
    {
        IEnumerable<T> GetAll();
        bool HasEntity(Expression<Func<T, bool>> anyExpression);
        void Create(T entity);
        Task SaveAsync();
    }
}
