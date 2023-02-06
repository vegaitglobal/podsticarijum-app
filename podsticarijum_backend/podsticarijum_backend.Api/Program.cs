using podsticarijum_backend.Repository;
using podsticarijum_backend.Application;
using podsticarijum_backend.Application.Options;
using podsticarijum_backend.Application.Services;
using podsticarijum_backend.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.Configure<MailDataConfig>(builder.Configuration.GetSection("MailData"));

builder.Services.AddScoped<IPodsticarijumMailService, PodsticarijumMailService>();

builder.Services.AddScoped<IMainRepository, MainRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
builder.Services.AddScoped<IExpertRepository, ExpertRepository>();
builder.Services.AddScoped<IFaqRepository, FaqRepository>();

builder.Services.AddDbContext<PodsticarijumContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PodsticarijumDb"));
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

//app.UseAuthorization();

app.Run();