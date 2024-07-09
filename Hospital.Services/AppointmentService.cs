using Hospital.Models;
using Hospital.Repositories;
using Hospital.Repositories.Interfaces;
using Hospital.ViewModels;
using hospitals.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Hospital.Services
{
  public class AppointmentService : IAppointmentService
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly ApplicationDbContext applicationDbContext;

    public AppointmentService(IUnitOfWork unitOfWork, ApplicationDbContext applicationDbContext)
    {
      _unitOfWork = unitOfWork;
      this.applicationDbContext = applicationDbContext;
    }

    public List<AppointmentViewModel> GetUpcomingAppointments()
    {
      var query = from appointment in applicationDbContext.Appointments
                  join doctor in applicationDbContext.Doctors on appointment.DoctorId equals doctor.Id
                  join patient in applicationDbContext.Patients on appointment.PatientId equals patient.Id
                  join room in applicationDbContext.Rooms on appointment.RoomId equals room.Id
                  where appointment.AppointmentTime > DateTime.Now
                  select new AppointmentViewModel()
                  {
                    Id = appointment.Id,
                    AppointmentTime = appointment.AppointmentTime,
                    AppointmentEndTime = appointment.AppointmentEndTime,
                    CreatedDate = appointment.CreatedDate,
                    Description = appointment.Description,
                    DoctorId = appointment.DoctorId,
                    Doctor = doctor,
                    Name = appointment.Name,
                    Number = appointment.Number,
                    Patient = patient,
                    PatientId = appointment.PatientId,
                    PatientName = patient.Imie,
                    Room = room,
                    RoomId = room.Id,
                    Type = appointment.Type,
                  };

      return query.ToList();
    }

    public AppointmentViewModel GetAppointmentById(int appointmentId)
    {
      var query = from appointment in applicationDbContext.Appointments
                  join doctor in applicationDbContext.Doctors on appointment.DoctorId equals doctor.Id
                  join patient in applicationDbContext.Patients on appointment.PatientId equals patient.Id
                  join room in applicationDbContext.Rooms on appointment.RoomId equals room.Id
                  where appointment.Id == appointmentId
                  select new AppointmentViewModel()
                  {
                    Id = appointment.Id,
                    AppointmentTime = appointment.AppointmentTime,
                    AppointmentEndTime = appointment.AppointmentEndTime,
                    CreatedDate = appointment.CreatedDate,
                    Description = appointment.Description,
                    DoctorId = appointment.DoctorId,
                    Doctor = doctor,
                    Name = appointment.Name,
                    Number = appointment.Number,
                    Patient = patient,
                    PatientId = appointment.PatientId,
                    PatientName = patient.Imie,
                    Room = room,
                    RoomId = room.Id,
                    Type = appointment.Type,
                  };

      var appointment2 = query.FirstOrDefault();
      if (appointment2 == null) return null;

      return appointment2;
    }

    public void CreateAppointment(AppointmentViewModel vm)
    {
      var appointment = new Appointment
      {
        Name = vm.Name,
        DoctorId = vm.DoctorId,
        PatientId = vm.PatientId,
        RoomId = vm.RoomId,
        AppointmentTime = vm.AppointmentTime,
        AppointmentEndTime = vm.AppointmentEndTime,
        CreatedDate = DateTime.Now,
        Description = vm.Description,
        DoctorStatus = "OK",
        Number = vm.Number,
        Type = vm.Type

      };
      _unitOfWork.GenericRepository<Appointment>().Add(appointment);
      _unitOfWork.Save();
    }

    public void UpdateAppointment(AppointmentViewModel vm)
    {
      var appointment = _unitOfWork.GenericRepository<Appointment>().GetById(vm.Id);
      if (appointment == null) return;
      appointment.AppointmentTime = vm.AppointmentTime;
      appointment.AppointmentEndTime = vm.AppointmentEndTime;
      appointment.Number = vm.Number;
      appointment.RoomId = vm.RoomId;
      appointment.Description = vm.Description;
      appointment.PatientId = vm.PatientId;
      appointment.DoctorId = vm.DoctorId;
      appointment.Name = vm.Name;
      appointment.Type = vm.Type;

      _unitOfWork.GenericRepository<Appointment>().Update(appointment);
      _unitOfWork.Save();
    }

    public void DeleteAppointment(int appointmentId)
    {
      var appointment = _unitOfWork.GenericRepository<Appointment>().GetById(appointmentId);
      if (appointment == null) return;

      _unitOfWork.GenericRepository<Appointment>().Delete(appointment);
      _unitOfWork.Save();
    }

    public PagedResult<AppointmentViewModel> GetAll(int pageNumber, int pageSize)
    {
      var query = from appointment in applicationDbContext.Appointments
                  join doctor in applicationDbContext.Doctors on appointment.DoctorId equals doctor.Id
                  join patient in applicationDbContext.Patients on appointment.PatientId equals patient.Id
                  join room in applicationDbContext.Rooms on appointment.RoomId equals room.Id
                  select new AppointmentViewModel()
                  {
                    Id = appointment.Id,
                    AppointmentTime = appointment.AppointmentTime,
                    AppointmentEndTime = appointment.AppointmentEndTime,
                    CreatedDate = appointment.CreatedDate,
                    Description = appointment.Description,
                    DoctorId = appointment.DoctorId,
                    Doctor = doctor,
                    Name = appointment.Name,
                    Number = appointment.Number,
                    Patient = patient,
                    PatientId = appointment.PatientId,
                    PatientName = patient.Imie,
                    Room = room,
                    RoomId = room.Id,
                    Type = appointment.Type,
                  };

      var vmList = query.Skip(pageSize * (pageNumber - 1))
                  .Take(pageSize)
                  .ToList();

      var totalCount = _unitOfWork.GenericRepository<Appointment>().GetAll().Count();


      return new PagedResult<AppointmentViewModel>()
      {
        Data = vmList,
        TotalItems = totalCount,
        PageNumber = pageNumber,
        PageSize = pageSize
      };
    }
  }
}
