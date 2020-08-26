using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Models;

namespace UserManagement.Repository
{
    public interface IUserDetailsRepository
    {
        Task<IEnumerable<UserDetailModel>> GetUsers();

        Task<UserDetailModel> GetUserById(int id);

        Task Insert(UserDetailModel entity);

        Task Update(int id, UserDetailModel entity);

        Task Delete(UserDetailModel entity);
    }
}
