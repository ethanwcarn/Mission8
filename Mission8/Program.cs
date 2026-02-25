using Microsoft.EntityFrameworkCore;
using Mission8.Data;

var builder = WebApplication.CreateBuilder(args);

// =============================================================================
// JARED - Assignment #1: Configure all needed settings/services/endpoints here
// (DbContext, Repository registrations, etc.)
// =============================================================================

builder.Services.AddDbContext<Mission8Context>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Mission8Connection")
                      ?? "Data Source=Mission8.db"));

builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapStaticAssets();

// Ensure the database and seed data exist on startup for local development.
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<Mission8Context>();
    dbContext.Database.EnsureCreated();
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
