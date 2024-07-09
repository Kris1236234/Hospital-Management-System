using Hospital.ViewModels;
using hospitals.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
  public interface IDoctorService
  {
    IEnumerable<TimingViewModel> GetAll();
    PagedResult<TimingViewModel> GetAll(int pageNumber, int pageSize);
    IEnumerable<DoctorViewModel> GetAllDoctors();
    PagedResult<DoctorViewModel> GetAllDoctors(int pageNumber, int pageSize);
    TimingViewModel GetTimingById(int timingId);
    void UpdateTiming(TimingViewModel timing);
    void AddTiming(TimingViewModel timing);
    void DeleteTiming(int timingId);
    void CreateDoctor(DoctorViewModel vm);
    DoctorViewModel? GetDoctorById(int id);
    void UpdateDoctor(DoctorViewModel vm);
    void DeleteDoctor(int id);
  }
}
