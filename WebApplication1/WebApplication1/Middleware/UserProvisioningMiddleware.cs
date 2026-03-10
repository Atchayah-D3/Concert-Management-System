using System.Security.Claims;
using WebApplication1.Data;
using WebApplication1.Models;

public class UserProvisioningMiddleware
{
    private readonly RequestDelegate _next;

    public UserProvisioningMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, AppDbContext db)
    {
        if (context.User.Identity?.IsAuthenticated == true)
        {
            var keycloakId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var email = context.User.FindFirst(ClaimTypes.Email)?.Value;
            var username = context.User.FindFirst("preferred_username")?.Value;

            var user =  db.Users
                .FirstOrDefault(u => u.UUID == keycloakId);

            if (user == null)
            {
                user = new User
                {
                    UUID = keycloakId,
                    Email = email,
                    UserName = username
                };

                db.Users.Add(user);
                await db.SaveChangesAsync();
            }
        }

        await _next(context);
    }
}