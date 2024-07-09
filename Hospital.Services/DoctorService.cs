using Hospital.Models;
using Hospital.Repositories;
using Hospital.Repositories.Interfaces;
using Hospital.ViewModels;
using hospitals.Utilities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
  public class DoctorService : IDoctorService
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly ApplicationDbContext applicationDbContext;

    public DoctorService(IUnitOfWork unitOfWork, ApplicationDbContext applicationDbContext)
    {
      _unitOfWork = unitOfWork;
      this.applicationDbContext = applicationDbContext;
    }

    public void AddTiming(TimingViewModel timing)
    {
      var model = timing.ConvertViewModelToModel();
      _unitOfWork.GenericRepository<Timing>().Add((Timing)model);
      _unitOfWork.Save();
    }

    public void UpdateTiming(TimingViewModel timingViewModel)
    {
      var existingTiming = _unitOfWork.GenericRepository<Timing>().GetById(timingViewModel.Id);

      if (existingTiming != null)
      {
   
        existingTiming.MorningShiftStartTime = timingViewModel.MorningShiftStartTime;
        existingTiming.MorningShiftEndTime = timingViewModel.MorningShiftEndTime;
        existingTiming.AfternoonShiftStartTime = timingViewModel.AfternoonShiftStartTime;
        existingTiming.AfternoonShiftEndTime = timingViewModel.AfternoonShiftEndTime;
        existingTiming.Duration = timingViewModel.Duration;
        existingTiming.Status = timingViewModel.Status;
        existingTiming.DoctorId = timingViewModel.DoctorId;
        _unitOfWork.GenericRepository<Timing>().Update(existingTiming);
      }

      _unitOfWork.Save();
    }
    public void DeleteTiming(int timingId)
    {
      var model = _unitOfWork.GenericRepository<Timing>().GetById(timingId);
      _unitOfWork.GenericRepository<Timing>().Delete(model);
      _unitOfWork.Save();
    }

    public PagedResult<TimingViewModel> GetAll(int pageNumber, int pageSize)
    {
      DbSet<Timing> timings = applicationDbContext.Timings;
      DbSet<Doctor> doctors = applicationDbContext.Doctors;
      var modelList = timings.Join(
        doctors,
        timing => timing.DoctorId,
        doctor => doctor.Id,
        (timing, doctor) => new TimingViewModel(timing) { Doctor = doctor })
                      .Skip((pageNumber - 1) * pageSize)
                      .Take(pageSize)
                      .ToList();


      var totalCount = _unitOfWork.GenericRepository<Timing>().GetAll().Count();


      return new PagedResult<TimingViewModel>
      {
        Data = modelList,
        TotalItems = totalCount,
        PageNumber = pageNumber,
        PageSize = pageSize
      };
    }

    public IEnumerable<TimingViewModel> GetAll()
    {
      var timingList = _unitOfWork.GenericRepository<Timing>().GetAll().ToList();
      return timingList.Select(t => new TimingViewModel(t)).ToList();
    }

    public PagedResult<DoctorViewModel> GetAllDoctors(int pageNumber, int pageSize)
    {
      var doctors = _unitOfWork.GenericRepository<Doctor>().GetAll()
        .OrderBy(d => d.Specialization)
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToList();

      var totalCount = _unitOfWork.GenericRepository<Timing>().GetAll().Count();
      var vmList = doctors.Select(x => new DoctorViewModel(x)).ToList();

      return new PagedResult<DoctorViewModel>()
      {
        Data = vmList,
        TotalItems = totalCount,
        PageNumber = pageNumber,
        PageSize = pageSize
      };
    }

    public IEnumerable<DoctorViewModel> GetAllDoctors()
    {
      var doctors = _unitOfWork.GenericRepository<Doctor>().GetAll();
      return doctors.Select(x => new DoctorViewModel(x)).ToList();
    }

    public TimingViewModel GetTimingById(int timingId)
    {
      var result = from timing in applicationDbContext.Timings
                   join doctor in applicationDbContext.Doctors on timing.DoctorId equals doctor.Id
                   where timing.Id == timingId
                   select new TimingViewModel(timing) { Doctor = doctor };

      var model = result.FirstOrDefault();
      return model;
    }

    private List<TimingViewModel> ConvertModelToViewModelList(List<Timing> modelList)
    {
      return modelList.Select(x => new TimingViewModel(x)).ToList();
    }

    public void CreateDoctor(DoctorViewModel vm)
    {
      var model = DoctorViewModel.ConvertViewModel(vm);
      _unitOfWork.GenericRepository<Doctor>().Add(model);
      _unitOfWork.Save();

    }

    public DoctorViewModel? GetDoctorById(int id)
    {
      var model = _unitOfWork.GenericRepository<Doctor>().GetById(id);
      return model != null ? new DoctorViewModel(model) : null;
    }

    public void UpdateDoctor(DoctorViewModel vm)
    {
      var model = _unitOfWork.GenericRepository<Doctor>().GetById(vm.Id);
      model.Name = vm.Name;
      model.LastName = vm.LastName;
      model.Specialization = vm.Specialization;
            model.PWZNumber = vm.PWZNumber;
      _unitOfWork.Save();
    }

    public void DeleteDoctor(int id)
    {
      var model = _unitOfWork.GenericRepository<Doctor>().GetById(id);
      _unitOfWork.GenericRepository<Doctor>().Delete(model);
      _unitOfWork.Save();
    }
  }
}
