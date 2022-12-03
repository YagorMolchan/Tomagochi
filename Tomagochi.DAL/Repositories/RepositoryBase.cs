using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tomagochi.DAL.EFCore;
using Tomagochi.DAL.Interfaces;

namespace Tomagochi.DAL.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected TomagochiDbContext Context { get; set; }

        public RepositoryBase(TomagochiDbContext context)
        {
            Context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().AsNoTracking().ToList();
        }

        public void Create(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }

        public bool HasEntity(Expression<Func<T, bool>> anyExpression)
        {
            return Context.Set<T>().Any(anyExpression);
        }
    }
}
