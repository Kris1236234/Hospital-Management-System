using Hospital.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using hospitals.Utilities;
using Hospital.Repositories.Interfaces;
using Hospital.Repositories.Implementation;
using Microsoft.AspNetCore.Identity.UI.Services;
using Hospital.Services;
using Microsoft.Extensions.Configuration;
using MDriven.MDrivenServer;

var builder = WebApplication.CreateBuilder(args);

// Dodawanie us³ug
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Konfiguracja bazy danych
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Konfiguracja Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Dodanie us³ugi walidacji modelu
builder.Services.AddRazorPages().AddMvcOptions(options =>
{
    options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
        _ => "Pole nie mo¿e byæ puste.");
});

// Rejestracja us³ug i repozytoriów
builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddTransient<IHospitalInfo, HospitalInfoService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddTransient<IContactService, ContactService>();
builder.Services.AddTransient<IApplicationUserService, ApplicationUserService>();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddScoped<IEmailSender>(serviceProvider =>
{
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();

    var smtpServer = configuration["EmailSettings:SmtpServer"];
    var smtpPort = int.Parse(configuration["EmailSettings:SmtpPort"]);
    var smtpUsername = configuration["EmailSettings:SmtpUsername"];
    var smtpPassword = configuration["EmailSettings:SmtpPassword"];
    var enableSsl = bool.Parse(configuration["EmailSettings:EnableSsl"]);
    var fromAddress = configuration["EmailSettings:FromAddress"];
    var fromName = configuration["EmailSettings:FromName"];

    return new EmailSender(
        smtpServer,
        smtpPort,
        smtpUsername,
        smtpPassword,
        enableSsl,
        fromAddress,
        fromName);
});



// Konfiguracja œcie¿ek dostêpu
builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "admin",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{Area=admin}/{controller=Hospitals}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();

DataSedding();

void DataSedding()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        dbInitializer.Initialize();
        dbInitializer.ClearDatabase();
        dbInitializer.SeedData();
    }
}
