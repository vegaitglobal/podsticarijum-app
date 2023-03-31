using podsticarijum_backend.Repository;
using podsticarijum_backend.Application;
using podsticarijum_backend.Application.Options;
using podsticarijum_backend.Application.Services;
using podsticarijum_backend.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services
       .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
       .AddCookie(
                 CookieAuthenticationDefaults.AuthenticationScheme, 
                 options =>
                 {
                     options.LoginPath = "/auth/login"; 
                     options.ExpireTimeSpan = TimeSpan.FromHours(12);
                 });

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<IDataSeeder, DataSeeder>();

builder.Services.Configure<MailDataConfig>(builder.Configuration.GetSection("MailData"));

builder.Services.AddScoped<IPodsticarijumMailService, PodsticarijumMailService>();

builder.Services.AddScoped<IMainRepository, MainRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
builder.Services.AddScoped<IExpertRepository, ExpertRepository>();
builder.Services.AddScoped<IFaqRepository, FaqRepository>();

builder.Services.AddDbContext<PodsticarijumContext>(options =>
{
    options.UseSqlServer(
           builder.Configuration.GetConnectionString("PodsticarijumDb")!, 
           b => b.MigrationsAssembly("podsticarijum_backend.Repository"));
});


builder.Services
                .AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler =            ReferenceHandler.IgnoreCycles;
                });

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    PodsticarijumContext db = scope.ServiceProvider.GetRequiredService<PodsticarijumContext>();
    db.Database.Migrate();
    IDataSeeder dataSeeder = scope.ServiceProvider.GetRequiredService<IDataSeeder>();
    await dataSeeder.EnsureSuperuserSeeded();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using (var scope = app.Services.CreateScope())
    {
        IDataSeeder dataSeeder = scope.ServiceProvider.GetRequiredService<IDataSeeder>();
        await dataSeeder.EnsureInitialSeed();
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultControllerRoute();

app.MapRazorPages();
app.Run();
