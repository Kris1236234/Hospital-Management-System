using Hospital.Models;

namespace Hospital.Repositories.Interfaces
{
    public interface IUserRepository
    {
        ApplicationUser GetUserByLogin(string loginName);
    }
}
