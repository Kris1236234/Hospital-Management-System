using Hospital.Models;
using Hospital.Repositories.Interfaces;
using Hospital.ViewModels;
using hospitals.Utilities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ApplicationUserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public ApplicationUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PagedResult<ApplicationUserViewModel> GetAll(int PageNumber, int PageSize)
        {
            int ExcludeRecords = (PageSize * PageNumber) - PageSize;

            var userQuery = _unitOfWork.GenericRepository<ApplicationUser>()
                            .GetAll();

            int totalCount = userQuery.Count();

            var userList = userQuery.Skip(ExcludeRecords)
                                    .Take(PageSize)
                                    .ToList();

            var userViewModelList = ConvertModelToViewModelList(userList);

            var result = new PagedResult<ApplicationUserViewModel>
            {
                Data = (List<ApplicationUserViewModel>)userViewModelList,
                TotalItems = totalCount,
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            return result;
        }

        public void CreateUser(ApplicationUserViewModel viewModel)
        {
            var user = viewModel.ConvertViewModelToModel();
            _unitOfWork.GenericRepository<ApplicationUser>().Add(user);
            _unitOfWork.Save();
        }

        public void UpdateUser(ApplicationUserViewModel viewModel)
        {
            var user = _unitOfWork.GenericRepository<ApplicationUser>().GetById(viewModel.Id);
            if (user == null) return;

            user.Name = viewModel.Name;
            user.City = viewModel.City;
            user.Gender = viewModel.Gender;
            user.IsDoctor = viewModel.IsDoctor;
            user.Specialist = viewModel.Specialist;
            user.Email = viewModel.Email;
            user.UserName = viewModel.UserName;

            _unitOfWork.GenericRepository<ApplicationUser>().Update(user);
            _unitOfWork.Save();
        }

        public void DeleteUser(string userId)
        {
            var user = _unitOfWork.GenericRepository<ApplicationUser>().GetById(userId);
            if (user == null) return;

            _unitOfWork.GenericRepository<ApplicationUser>().Delete(user);
            _unitOfWork.Save();
        }

        private List<ApplicationUserViewModel> ConvertUserModelToViewModelList(List<ApplicationUser> userList)
        {
            return userList.Select(u => new ApplicationUserViewModel(u)).ToList();
        }

        public PagedResult<ApplicationUserViewModel> GetAllDoctor(int PageNumber, int PageSize)
        {
            int ExcludeRecords = (PageSize * PageNumber) - PageSize;

            var doctorQuery = _unitOfWork.GenericRepository<ApplicationUser>()
                                .GetAll(u => u.IsDoctor);

            int totalCount = doctorQuery.Count();

            var doctorList = doctorQuery.Skip(ExcludeRecords)
                                        .Take(PageSize)
                                        .ToList();

            var doctorViewModelList = ConvertModelToViewModelList(doctorList);

            var result = new PagedResult<ApplicationUserViewModel>
            {
                Data = (List<ApplicationUserViewModel>)doctorViewModelList,
                TotalItems = totalCount,
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            return result;
        }

        public PagedResult<ApplicationUserViewModel> GetAllPatient(int PageNumber, int PageSize)
        {
            int ExcludeRecords = (PageSize * PageNumber) - PageSize;

            var patientQuery = _unitOfWork.GenericRepository<ApplicationUser>()
                                .GetAll(u => !u.IsDoctor);

            int totalCount = patientQuery.Count();

            var patientList = patientQuery.Skip(ExcludeRecords)
                                          .Take(PageSize)
                                          .ToList();

            var patientViewModelList = ConvertModelToViewModelList(patientList);

            var result = new PagedResult<ApplicationUserViewModel>
            {
                Data = (List<ApplicationUserViewModel>)patientViewModelList,
                TotalItems = totalCount,
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            return result;
        }

        public PagedResult<ApplicationUserViewModel> SearchDoctor(int PageNumber, int PageSize, string Speciality = null, string City = null)
        {
            int ExcludeRecords = (PageSize * PageNumber) - PageSize;

            var doctorQuery = _unitOfWork.GenericRepository<ApplicationUser>()
                                .GetAll(u => u.IsDoctor &&
                                             (Speciality == null || u.Specialist.Contains(Speciality)) &&
                                             (City == null || u.City == City));

            int totalCount = doctorQuery.Count();

            var doctorList = doctorQuery.Skip(ExcludeRecords)
                                        .Take(PageSize)
                                        .ToList();

            var doctorViewModelList = ConvertModelToViewModelList(doctorList);

            var result = new PagedResult<ApplicationUserViewModel>
            {
                Data = (List<ApplicationUserViewModel>)doctorViewModelList,
                TotalItems = totalCount,
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            return result;
        }

        private List<ApplicationUserViewModel> ConvertModelToViewModelList(List<ApplicationUser> userList)
        {
            return userList.Select(u => new ApplicationUserViewModel(u)).ToList();
        }

        public PagedResult<ApplicationUserViewModel> GetUsersByRole(int PageNumber, int PageSize, string roleName)
        {
 
            var role = _roleManager.FindByNameAsync(roleName).Result;
            if (role == null)
            {
        
                throw new Exception($"Rola o nazwie {roleName} nie istnieje.");
            }

   
            var usersInRole = _userManager.GetUsersInRoleAsync(roleName).Result;

          
            var usersViewModels = usersInRole
                .Select(user => new ApplicationUserViewModel(user))
                .ToList();

            return new PagedResult<ApplicationUserViewModel>
            {
                Data = usersViewModels.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList(),
                TotalItems = usersViewModels.Count,
                PageNumber = PageNumber,
                PageSize = PageSize
            };
        }


        public void ResetUserPassword(string userId, string newPassword)
        {
         
            var user = _userManager.FindByIdAsync(userId).Result;
            if (user == null)
            {
          
                throw new Exception($"Użytkownik o identyfikatorze {userId} nie istnieje.");
            }

            
            var token = _userManager.GeneratePasswordResetTokenAsync(user).Result;
            var result = _userManager.ResetPasswordAsync(user, token, newPassword).Result;
            if (!result.Succeeded)
            {
                
                throw new Exception($"Nie udało się zresetować hasła użytkownika {user.UserName}.");
            }
        }

    }
}