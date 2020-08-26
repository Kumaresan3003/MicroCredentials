using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagement.Models;
using UserManagement.Repository;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserDetailsRepository _userDetailsRepository;

        public UsersController(IUserDetailsRepository userDetailsRepository)
        {
            _userDetailsRepository = userDetailsRepository;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDetailModel>>> GetUsers()
        {
            var users = await _userDetailsRepository.GetUsers();
            return users.ToList();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDetailModel>> GetUserDetailModel(int id)
        {
            var userDetailModel = await _userDetailsRepository.GetUserById(id);

            if (userDetailModel == null)
            {
                return NotFound();
            }

            return userDetailModel;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserDetailModel(int id, UserDetailModel userDetailModel)
        {
            if (id != userDetailModel.Id)
            {
                return BadRequest();
            }

            try
            {
                await _userDetailsRepository.Update(id, userDetailModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                var userDetail = await _userDetailsRepository.GetUserById(id);

                if (userDetail == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserDetailModel>> PostUserDetailModel(UserDetailModel userDetailModel)
        {
            await _userDetailsRepository.Insert(userDetailModel);

            return CreatedAtAction("GetUserDetailModel", new { id = userDetailModel.Id }, userDetailModel);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDetailModel>> DeleteUserDetailModel(int id)
        {
            var userDetailModel = await _userDetailsRepository.GetUserById(id);
            if (userDetailModel == null)
            {
                return NotFound();
            }

            await _userDetailsRepository.Delete(userDetailModel);

            return userDetailModel;
        }
    }
}
