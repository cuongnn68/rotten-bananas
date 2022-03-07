using System.Net;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;

namespace RatingService.Auth;

public class CustomAuthHandler : AuthenticationHandler<CustomSchemeOption> {
    private static HttpClient httpClient;
    private Uri baseUri;
    static CustomAuthHandler() {
        httpClient = new HttpClient();
    }

    public CustomAuthHandler(
        IOptionsMonitor<CustomSchemeOption> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock,
        IConfiguration config) : base(options, logger, encoder, clock) 
    {
        // httpClient.BaseAddress = new Uri($@"http://{config["Services:UserManagerService"]}");
        baseUri = new Uri($@"http://{config["Services:UserManagerService"]}/api/auth");
    }
    protected override async Task<AuthenticateResult> HandleAuthenticateAsync() {
        Console.WriteLine($" ====> Request.Headers.Authorization: {Request.Headers.Authorization.ToString()}");
        var request = new HttpRequestMessage {
            Method = HttpMethod.Get,
            RequestUri = baseUri,
            // Headers = {
            //     {HeaderNames.Authorization, Request.Headers.Authorization.ToString()}
            // },
        };

        // foreach(var pair in Request.Headers) {
        //     request.Headers.Add(pair.Key, pair.Value.ToString());
        // }

        if(! string.IsNullOrWhiteSpace(Request.Headers.Authorization.ToString()))
            request.Headers.Add(HeaderNames.Authorization, Request.Headers.Authorization.ToString());
        
        
        using(var response = await httpClient.SendAsync(request)) {
            if(response.IsSuccessStatusCode) {
                var res = await response.Content.ReadFromJsonAsync<AuthResponse>();
                var claims = res?.Claims.Select(claimRP => new Claim(claimRP.Type, claimRP.Value));

                // NOTE: if dont have name authenticationType, it will throw forbiden, dont know why though
                var claimIdentity = new ClaimsIdentity(claims, nameof(CustomAuthHandler)); 
                var ticket = new AuthenticationTicket(
                    new ClaimsPrincipal(claimIdentity), this.Scheme.Name
                );
                return AuthenticateResult.Success(ticket);
            }
            this.Response.Headers.WWWAuthenticate = response.Headers.WwwAuthenticate.ToString();
            return AuthenticateResult.Fail(JsonSerializer.Serialize(response.Headers.WwwAuthenticate));
        }
    }
}