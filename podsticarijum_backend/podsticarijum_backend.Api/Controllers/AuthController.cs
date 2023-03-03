using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using podsticarijum_backend.Api.Viewmodels;
using podsticarijum_backend.Domain.Entities;
using podsticarijum_backend.Repository.Abstractions;

namespace podsticarijum_backend.Api.Controllers;

public class AuthController : Controller
{
    private readonly IMainRepository _mainRepository;

    public AuthController(IMainRepository mainRepository)
    {
        _mainRepository = mainRepository;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Login(
        [FromForm] LoginViewModel loginViewModel,
        [FromQuery] string ReturnUrl = "/")
    {

        if (string.IsNullOrEmpty(loginViewModel.Username)
        || string.IsNullOrEmpty(loginViewModel.Password))
        {
            return BadRequest();
        }

        User? user = await _mainRepository.GetUser(
            loginViewModel.Username,
            loginViewModel.Password);

        if (user == null)
        {
            return BadRequest();
        }

        await loginUser(loginViewModel);

        return LocalRedirect(ReturnUrl);
    }

    private async Task loginUser(LoginViewModel loginViewModel)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, loginViewModel.Username),
            new Claim(ClaimTypes.Role, "Administrator"),
        };

        var claimsIdentity = new ClaimsIdentity(
            claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var authProperties = new AuthenticationProperties
        {
            AllowRefresh = true,
            // Refreshing the authentication session should be allowed.

            //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
            // The time at which the authentication ticket expires. A 
            // value set here overrides the ExpireTimeSpan option of 
            // CookieAuthenticationOptions set with AddCookie.
            IsPersistent = true

            //IssuedUtc = <DateTimeOffset>,
            // The time at which the authentication ticket was issued.

            //RedirectUri = <string>
            // The full path or absolute URI to be used as an http 
            // redirect response value.
        };

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authProperties);
    }
}
