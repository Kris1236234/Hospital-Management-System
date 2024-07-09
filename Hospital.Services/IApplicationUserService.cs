using Hospital.ViewModels;
using hospitals.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public interface IApplicationUserService
    {
        PagedResult<ApplicationUserViewModel> GetAll(int PageNumber, int PageSize);
        PagedResult<ApplicationUserViewModel> GetUsersByRole(int PageNumber, int PageSize, string roleName);
        void DeleteUser(string userId);
        void ResetUserPassword(string userId, string newPassword);

        PagedResult<ApplicationUserViewModel> GetAllDoctor(int PageNumber, int PageSize);
        PagedResult<ApplicationUserViewModel> GetAllPatient(int PageNumber, int PageSize);
        PagedResult<ApplicationUserViewModel> SearchDoctor(int PageNumber, int PageSize, string Spicility=null,string City=null);
    }
}
