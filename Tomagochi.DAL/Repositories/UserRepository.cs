using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomagochi.DAL.EFCore;
using Tomagochi.DAL.Entities;
using Tomagochi.DAL.Interfaces;

namespace Tomagochi.DAL.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly TomagochiDbContext _dbContext;

        public UserRepository(TomagochiDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }

        public bool HasUser(string email)
        {
            return HasEntity(u => u.Email == email);
        }

        public void CreateUser(User user)
        {
            Create(user);
        }
    }
}
