using HealthDataApp.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure DbContext (optimized for Azure SQL)
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("AzureSQL"),
        sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null);
            sqlOptions.CommandTimeout(120);
        });
});

var app = builder.Build();

// Apply pending migrations (safe for production)
try
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
    Console.WriteLine("Database migrations applied successfully");
}
catch (Exception ex)
{
    Console.WriteLine($"Migration error: {ex.Message}");
    // Continue running even if migrations fail
}

// Configure the HTTP pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/HealthData/Error"); // Point to your controller
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

// Minimal middleware setup
app.UseHttpsRedirection();
app.UseStaticFiles(); // Works even without wwwroot folder
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=HealthData}/{action=Index}/{id?}");

app.Run();