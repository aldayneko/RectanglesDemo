using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text;
using Microsoft.Extensions.Logging;

namespace RectanglesDemo
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        readonly IUserService _userService;

        public BasicAuthenticationHandler(IUserService userService,
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
            _userService = userService;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                if (authHeader == null || string.IsNullOrEmpty(authHeader.Parameter))
                {
                    throw new Exception("There is no authorization header");
                }

                var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Parameter)).Split(':');
                if (credentials.Length < 2)
                {
                    throw new Exception("Failed to get username and password");
                }

                var username = credentials.FirstOrDefault();
                var password = credentials.LastOrDefault();

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    throw new Exception("Username or password empty");
                }

                if (!_userService.ValidateCredentials(username, password))
                {
                    throw new ArgumentException("Invalid credentials");
                }

                var claims = new[] {
                    new Claim(ClaimTypes.Name, username)
                };

                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                return Task.FromResult(AuthenticateResult.Success(ticket));
            }
            catch (Exception ex)
            {
                return Task.FromResult(AuthenticateResult.Fail($"Authentication failed: {ex.Message}"));
            }
        }
    }
}
