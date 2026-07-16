using Microsoft.EntityFrameworkCore;
using MvcAyudAR.Application.Services.Commands.Publication;
using MvcAyudAR.Infrastructure;
using MvcAyudAR.Infrastructure.Persistence;
using MvcAyudAR.Infrastructure.Repository;
using MvcAyudAR.Middleware;
using MvcAyudAR.Services.Commands.User;
using MvcAyudAR.Services.DTOs;
using MvcAyudAR.Services.Interfaces.User;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Dependency injection

//USER
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICreateUserHandler, CreateUserHandler>();
builder.Services.AddScoped<ILoginUserHandler, LoginUserHandler>();

//PUBLICATION
builder.Services.AddScoped<IPublicationRepository, PublicationRepository>();
builder.Services.AddScoped<ICreatePublicationHandler, CreatePublicationHandler>();



var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
