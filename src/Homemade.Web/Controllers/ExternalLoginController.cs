using Homemade.Database.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Homemade.Web.Controllers;

/// <summary>
/// Contains route delegates for the external login process.
/// </summary>
[NonController]
public sealed class ExternalLoginController
{
    /// <summary>
    /// Issues the challenge for the external authentication provider.
    /// </summary>
    public static IResult ExternalLogin(
        [FromForm] string? provider,
        [FromServices] ILogger<ExternalLoginController> logger,
        [FromServices] SignInManager<User> signInManager,
        HttpContext httpContext
    )
    {
        if (string.IsNullOrEmpty(provider))
            return Results.BadRequest();

        var redirectUrl = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}/Account/Login/Callback";
        var properties = signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

        logger.LogInformation("Sending challenge for {Provider}", provider);
        return Results.Challenge(properties, [provider]);
    }

    /// <summary>
    /// Handles the callback to fetch the external authentication data and attach it to a user.
    /// This effectively "logs in" the user.
    /// </summary>
    public static async Task<IResult> ExternalLoginCallback(
        [FromServices] SignInManager<User> signInManager,
        [FromServices] UserManager<User> userManager,
        [FromServices] ILogger<ExternalLoginController> logger,
        HttpContext httpContext)
    {
        var info = await signInManager.GetExternalLoginInfoAsync();
        if (info is null)
        {
            logger.LogWarning("External login info was null");
            return Results.Redirect("/Account/Login?error=Error loading external login information");
        }

        // Try to sign in with the external provider
        var result = await signInManager.ExternalLoginSignInAsync(
            info.LoginProvider,
            info.ProviderKey,
            isPersistent: false,
            bypassTwoFactor: true
        );

        if (result.Succeeded)
        {
            logger.LogInformation("User logged in with {Provider}", info.LoginProvider);

            return Results.Redirect("/");
        }

        if (result.IsLockedOut)
        {
            logger.LogWarning("User account locked out");

            return Results.Redirect("/Account/Login?error=Your account is locked");
        }

        return Results.Redirect("/Account/Login?error=Account not found, register first");
    }
}