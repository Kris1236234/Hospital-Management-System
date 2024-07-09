using Hospital.Models;
using Hospital.Repositories.Interfaces;
using Hospital.ViewModels;
using hospitals.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
  public class PatientService : IPatientService
  {
    private readonly IUnitOfWork unitOfWork;

    public PatientService(IUnitOfWork unitOfWork)
    {
      this.unitOfWork = unitOfWork;
    }

    public void Create(PatientViewModel model)
    {
      Patient patient = new Patient()
      {
        Imie = model.Imie,
        Adres = model.Adres,
        Miasto = model.Miasto,
        PESEL = model.PESEL,
      };
      unitOfWork.GenericRepository<Patient>().Add(patient);
      unitOfWork.Save();
    }

    public void Delete(int id)
    {
      var patient = unitOfWork.GenericRepository<Patient>().GetById(id);
      unitOfWork.GenericRepository<Patient>().Delete(patient);
      unitOfWork.Save();
    }

    public IEnumerable<PatientViewModel> GetAll()
    {
      var model = unitOfWork.GenericRepository<Patient>().GetAll();
      return model.Select(t => new PatientViewModel(t)).ToList();
    }

    public PagedResult<PatientViewModel> GetAll(int pageNumber, int pageSize)
    {
      var model = unitOfWork.GenericRepository<Patient>().GetAll()
        .Skip(pageSize * (pageNumber - 1))
        .Take(pageSize)
        .ToList();
      var totalCount = unitOfWork.GenericRepository<Patient>().GetAll().Count();


           

            return new PagedResult<PatientViewModel>()
      {
        Data = model.Select(model => new PatientViewModel(model)).ToList(),
        PageNumber = pageNumber,
        PageSize = pageSize,
        TotalItems = totalCount
      };
    }

    public PatientViewModel GetById(int id)
    {
      var patient = unitOfWork.GenericRepository<Patient>().GetById(id);
      if (patient == null) return null;
      return new PatientViewModel(patient);
    }

    public void Update(PatientViewModel model)
    {
      var patient = unitOfWork.GenericRepository<Patient>().GetById(model.Id);
      if (patient == null) return;
      patient.Imie = model.Imie;
      patient.Adres = model.Adres;
      patient.Miasto = model.Miasto;
      patient.PESEL = model.PESEL;
      unitOfWork.GenericRepository<Patient>().Update(patient);
      unitOfWork.Save();
    }
  }
}
