using Microsoft.AspNetCore.Authentication;

namespace Homemade.Web.Extensions;

public static class AuthenticationBuilderExtensions
{
    public static AuthenticationBuilder AddGithub(this AuthenticationBuilder builder, IConfiguration configuration)
    {
        builder.AddOAuth("Github", "Github", options =>
        {
            options.ClientId = configuration["ClientId"]!;
            options.ClientSecret = configuration["ClientSecret"]!;
            options.CallbackPath = "/signin-github";
            options.AuthorizationEndpoint = "https://github.com/login/oauth/authorize";
            options.TokenEndpoint = "https://github.com/login/oauth/access_token";
            options.UserInformationEndpoint = "https://api.github.com/user";

            options.Scope.Add("user:email");
            options.ClaimActions.MapJsonKey(System.Security.Claims.ClaimTypes.NameIdentifier, "id");
            options.ClaimActions.MapJsonKey(System.Security.Claims.ClaimTypes.Name, "login");
            options.ClaimActions.MapJsonKey(System.Security.Claims.ClaimTypes.Email, "email");

            options.Events = new Microsoft.AspNetCore.Authentication.OAuth.OAuthEvents
            {
                OnCreatingTicket = async context =>
                {
                    var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
                    request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", context.AccessToken);

                    var response = await context.Backchannel.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, context.HttpContext.RequestAborted);
                    response.EnsureSuccessStatusCode();

                    var user = await response.Content.ReadFromJsonAsync<System.Text.Json.JsonElement>();
                    context.RunClaimActions(user);
                }
            };
        });

        return builder;
    }
}