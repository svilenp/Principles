using Examples.YAGNI;
using Examples.YAGNI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMemoryCache();

// Add Entity Framework services.
builder.Services.AddDbContext<UserDbContext>(opt => opt.UseInMemoryDatabase("UserDatabase"));

// Add Memory Cache
builder.Services.AddMemoryCache();

builder.Services.AddScoped<IUserDataService, UserDataService>();

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
