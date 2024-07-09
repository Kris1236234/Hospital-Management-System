using Hospital.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Hospital.Repositories
{
  public class ApplicationDbContext : IdentityDbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Timing> Timings { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<HospitalInfo> HospitalInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
    {
    
            base.OnModelCreating(builder);
           builder.Entity<Patient>()
                .HasIndex(m => m.Imie)
                   .IsUnique();

    }

  }
}
