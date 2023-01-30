using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using podsticarijum_backend;
using podsticarijum_backend.DTO;
using podsticarijum_backend.Repository;
using podsticarijum_backend.Application;
using podsticarijum_backend.Application.Options;
using podsticarijum_backend.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.Configure<MailDataConfig>(builder.Configuration.GetSection("MailData"));

builder.Services.AddScoped<IPodsticarijumMailService, PodsticarijumMailService>();

builder.Services.AddDbContext<PodsticarijumContext>();


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

//app.UseAuthorization();

app.MapGet("/", () => { return Results.Ok("OK!"); });

app.Run();