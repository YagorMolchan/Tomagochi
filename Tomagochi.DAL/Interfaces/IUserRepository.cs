using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomagochi.DAL.Entities;

namespace Tomagochi.DAL.Interfaces
{
    public interface IUserRepository:IRepositoryBase<User>
    {
        bool HasUser(string email);

        void CreateUser(User user);
    }
}
