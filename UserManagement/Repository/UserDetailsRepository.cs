using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Models;

namespace UserManagement.Repository
{
    public class UserDetailsRepository : IUserDetailsRepository
    {
        private readonly UserDbContext _userDbContext;

        public UserDetailsRepository(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        public async Task Delete(UserDetailModel userDetailModel)
        {
            _userDbContext.UserDetails.Remove(userDetailModel);
            await _userDbContext.SaveChangesAsync();
        }

        public async Task<UserDetailModel> GetUserById(int id) => await _userDbContext.UserDetails.FindAsync(id);

        public async Task<IEnumerable<UserDetailModel>> GetUsers()
        {
            return await _userDbContext.UserDetails.ToListAsync();
        }

        public async Task Insert(UserDetailModel entity)
        {
            _userDbContext.UserDetails.Add(entity);
            await _userDbContext.SaveChangesAsync();
        }
        public async Task Update(int id, UserDetailModel entity)
        {
            _userDbContext.Entry(entity).State = EntityState.Modified;
            await _userDbContext.SaveChangesAsync();
        }
    }
}
