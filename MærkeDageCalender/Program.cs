using DataAccessLibrary;
using DataAccessLibrary.ApiAccess;
using DataAccessLibrary.Models;
using MærkeDageCalender.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<HttpClient>();

// Services
builder.Services.AddScoped<SallingApiAccess>();
builder.Services.AddScoped<Date>();
builder.Services.AddScoped<SelectedOptionService>();
builder.Services.AddScoped<EventModel>();
builder.Services.AddScoped<UserModel>();
builder.Services.AddScoped<PublicHolidayLists>();
builder.Services.AddScoped<EventLists>();
builder.Services.AddScoped<UserLists>();


// Entity Framework
builder.Services.AddDbContext<EntityFrameworkConnection>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<EntityFrameworkCRUD>();
builder.Services.AddScoped<ICRUDEvent<EventModel>, EntityFrameworkCRUD>();
builder.Services.AddScoped<ICRUDUser<UserModel>, EntityFrameworkCRUD>();

// ADO
builder.Services.AddScoped<SqlConnectionCRUD>();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
