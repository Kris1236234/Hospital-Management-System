using Hospital.ViewModels;
using hospitals.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
  public interface IPatientService
  {
    IEnumerable<PatientViewModel> GetAll();
    PagedResult<PatientViewModel> GetAll(int pageNumber, int pageSize);
    PatientViewModel GetById(int id);
    void Create(PatientViewModel model);
    void Update(PatientViewModel model);
    void Delete(int id);
  }
}
