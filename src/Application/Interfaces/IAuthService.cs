using System.Security.Claims;

namespace GroceryBackend.src.Application.Interfaces
{
    public interface IAuthService
    {
        string GenerateJwtToken(string userId, string email, string role);
        ClaimsPrincipal? ValidateJwtToken(string token);
    }
}
