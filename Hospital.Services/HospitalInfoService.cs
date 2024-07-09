using Hospital.Models;
using Hospital.Repositories.Interfaces;
using Hospital.ViewModels;
using hospitals.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital.Services
{
    public class HospitalInfoService : IHospitalInfo
    {
        private readonly IUnitOfWork _unitOfWork;

        public HospitalInfoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public void DeleteHospitalInfo(int id)
        {
            var model = _unitOfWork.GenericRepository<HospitalInfo>().GetById(id);
            _unitOfWork.GenericRepository<HospitalInfo>().Delete(model);
            _unitOfWork.Save();
        }

        public PagedResult<HospitalInfoViewModel> GetAll(int pageNumber, int pageSize)
        {
            int totalCount;
            List<HospitalInfoViewModel> vmList;

            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;

                var modelList = _unitOfWork.GenericRepository<HospitalInfo>().GetAll()
                    .Skip(ExcludeRecords).Take(pageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<HospitalInfo>().GetAll().Count();

                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }

            var result = new PagedResult<HospitalInfoViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return result;
        }

        public IEnumerable<HospitalInfoViewModel> GetAll()
        {
            var hospitalInfoList = _unitOfWork.GenericRepository<HospitalInfo>().GetAll().ToList();
            var vmList = ConvertModelToViewModelList(hospitalInfoList);
            return vmList;
        }

        public HospitalInfoViewModel GetHospitalById(int hospitalId)
        {
            var model = _unitOfWork.GenericRepository<HospitalInfo>().GetById(hospitalId);
            return new HospitalInfoViewModel(model);
        }

        public IEnumerable<HospitalInfoViewModel> GetHospitalsByCity(string city)
        {
            var hospitalInfoList = _unitOfWork.GenericRepository<HospitalInfo>().GetAll()
                .Where(h => h.City == city)
                .ToList();

            return ConvertModelToViewModelList(hospitalInfoList);
        }

        public IEnumerable<HospitalInfoViewModel> GetHospitalsByType(string type)
        {
            var hospitalInfoList = _unitOfWork.GenericRepository<HospitalInfo>().GetAll()
                .Where(h => h.Type == type)
                .ToList();

            return ConvertModelToViewModelList(hospitalInfoList);
        }

        public void InsertHospitalInfo(HospitalInfoViewModel hospitalInfo)
        {
            var model = hospitalInfo.ConvertViewModel();
            _unitOfWork.GenericRepository<HospitalInfo>().Add(model);
            _unitOfWork.Save();
        }

        public IEnumerable<HospitalInfoViewModel> SearchHospitals(string searchTerm)
        {
            var foundHospitals = GetAll()
                .Where(h => h.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return foundHospitals;
        }

        public void UpdateHospitalInfo(HospitalInfoViewModel hospitalInfo)
        {
            var model = hospitalInfo.ConvertViewModel();
            var modelById = _unitOfWork.GenericRepository<HospitalInfo>().GetById(model);
            modelById.Name = hospitalInfo.Name;
            modelById.City = hospitalInfo.City;
            modelById.PinCode = hospitalInfo.PinCode;
            modelById.Country = hospitalInfo.Country;
            _unitOfWork.GenericRepository<HospitalInfo>().Update(modelById);
            _unitOfWork.Save();
        }

        private List<HospitalInfoViewModel> ConvertModelToViewModelList(List<HospitalInfo> modelList)
        {
            return modelList.Select(x => new HospitalInfoViewModel(x)).ToList();
        }
    }
}
