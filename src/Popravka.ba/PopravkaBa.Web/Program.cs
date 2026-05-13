using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Popravka.ba.Data;
using PopravkaBa.Application.Services;
using PopravkaBa.Application.Services.Implementation;
using PopravkaBa.Application.Services.Interface;
using PopravkaBa.Domain.Interfaces;
using PopravkaBa.Domain.Interfaces.Repositories;
using PopravkaBa.Infrastructure.Adapters;
using PopravkaBa.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

// TODO 1HIGHPRIORITY: Da li implementirati na engleskom aplikaciju?
// TODO Registriraj sve dependency injectione po dodavanju, implementirati zakomentarisane
// Dependency Injection za interfejse (Možda treba ubaciti u metodu)   
builder.Services.AddScoped<IKategorijaService, KategorijaService>();
builder.Services.AddScoped<IKategorijaRepository, KategorijaRepository>();

builder.Services.AddScoped<IMjestoService, MjestoService>();
builder.Services.AddScoped<IMjestoRepository,MjestoRepository>();

builder.Services.AddScoped<IOglasMajstoraService, OglasMajstoraService>();
builder.Services.AddScoped<IOglasMajstoraRepository, OglasMajstoraRepository>();

builder.Services.AddScoped<IOglasRadnoMjestoService, OglasRadnoMjestoService>();
builder.Services.AddScoped<IOglasRadnoMjestoRepository, OglasRadnoMjestoRepository>();
builder.Services.AddScoped<IOglasUslugeService, OglasUslugeService>();

builder.Services.AddScoped<IOglasMajstoraFacade, OglasMajstoraFacade>();
builder.Services.AddScoped<IOglasRadnoMjestoFacade, OglasRadnoMjestoFacade>();
builder.Services.AddScoped<IOglasUslugeFacade, OglasUslugeFacade>();


builder.Services.AddScoped<IPonudaUslugeService, PonudaUslugeService>();
// builder.Services.AddScoped<IPrijavaOglasService, PrijavaOglasService>();
builder.Services.AddScoped<IRecenzijaService, RecenzijaService>();







builder.Services.AddScoped<IEmailSender, SmtpEmailAdapter>();

var app = builder.Build();

// Lokalni blok koda za kreiranje uloga
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    string[] roles = { "Klijent", "Firma", "Majstor", "Administrator" };
    foreach (var r in roles)
    {
        if (!await roleManager.RoleExistsAsync(r))
            await roleManager.CreateAsync(new IdentityRole(r));
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
