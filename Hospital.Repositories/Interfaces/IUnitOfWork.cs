using Hospital.Models;
using System;


namespace Hospital.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> GenericRepository<T>() where T : class;
        IGenericRepository<ApplicationUser> UserRepository { get; }
        IGenericRepository<Appointment> AppointmentRepository { get; }
        IGenericRepository<Patient> PatientRepository { get; }

        void Save();
        Task SaveAsync();

        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
