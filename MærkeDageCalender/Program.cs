using DataAccessLibrary;
using DataAccessLibrary.ApiAccess;
using DataAccessLibrary.Models;
using MærkeDageCalender.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// EF
builder.Services.AddDbContext<EntityFrameworkConnection>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<EntityFrameworkConnection>();
builder.Services.AddScoped<EntityFrameworkCRUD>();
builder.Services.AddScoped<BirthdayModel>();
builder.Services.AddScoped<ICRUD<BirthdayModel>, EntityFrameworkCRUD>();
builder.Services.AddScoped<SallingApiAccess>();
builder.Services.AddScoped<Month>();

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
