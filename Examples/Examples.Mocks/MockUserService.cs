using System.Security.Claims;

namespace Examples.Mocks;

public static class MockUserService
{
    public static string GetCurrentUserEmail(ClaimsPrincipal user)
    {
        // Get the current user from the user claims identity
        // NOTE: This requires authentication mechanism to be set up and [Authorize] attribute 
        return user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value ?? "dummy@livethecode.com";
    }

    public static string GetCurrentUserPhoneNumber(ClaimsPrincipal user)
    {
        // Get the current user from the user claims identity
        // NOTE: This requires authentication mechanism to be set up and [Authorize] attribute 
        return user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.MobilePhone)?.Value ?? "+0123456789";
    }
}
