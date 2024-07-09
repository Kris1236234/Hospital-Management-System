using Hospital.Models;
using Hospital.Repositories.Interfaces;
using Hospital.Web.Models;

namespace Hospital.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ApplicationUser GetUserByLogin(string loginName)
        {
           
            return (ApplicationUser)_context.Users.FirstOrDefault(u => u.UserName == loginName);
        }
    }
}
