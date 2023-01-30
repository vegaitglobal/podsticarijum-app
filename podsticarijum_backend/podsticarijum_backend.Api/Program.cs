using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using podsticarijum_backend;
using podsticarijum_backend.DTO;
using podsticarijum_backend.Repository;
using podsticarijum_backend.Api.Options;

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


app.MapPost("/email", async (MailDto emailDto, IPodsticarijumMailService mailService) =>
{
    try
    {
        var expertMail = emailDto.ExpertMail ?? string.Empty;
        var body = emailDto.Body ?? string.Empty;
        var userMailAddress = emailDto.UserMailAddress ?? string.Empty;
        var appPackageName = emailDto.AppPackageName ?? string.Empty;

        body = body + $"\n Email poslat od strane {emailDto.UserMailAddress}";

        mailService.Subject = userMailAddress;
        mailService.AppPackageName = emailDto.AppPackageName;
        mailService.Body = body;

        ArgumentNullException.ThrowIfNull(mailService.AppPackageName);
        ArgumentNullException.ThrowIfNull(mailService.Subject);
        ArgumentNullException.ThrowIfNull(body);
        ArgumentNullException.ThrowIfNull(userMailAddress);

        await mailService.sendEmail(expertMail);
        return Results.Ok();
    }
    catch (Exception ex)
    {
        Debug.WriteLine(ex.ToString());
        return Results.BadRequest("There was an error");
    }
})
.WithName("sendEmailEndpoint");

app.Run();