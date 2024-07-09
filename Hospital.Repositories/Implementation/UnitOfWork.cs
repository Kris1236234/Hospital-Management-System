using Hospital.Models;
using Hospital.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Hospital.Repositories.Implementation
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        private bool disposed = false;

        public IGenericRepository<ApplicationUser> UserRepository => new GenericRepository<ApplicationUser>(_context);

        public IGenericRepository<Appointment> AppointmentRepository => new GenericRepository<Appointment>(_context);

        public IGenericRepository<Patient> PatientRepository => new GenericRepository<Patient>(_context);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

            }
            this.disposed = true;
        }

        public IGenericRepository<T> GenericRepository<T>() where T : class
        {
            return new GenericRepository<T>(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void BeginTransaction()
        {
            
             _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
         
             _context.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
         
             _context.Database.RollbackTransaction();
        }
    }
}
