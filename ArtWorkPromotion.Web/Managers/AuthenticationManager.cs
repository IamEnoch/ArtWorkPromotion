using System.Security.Claims;
using ArtWorkPromotion.Web.Model;

public class AuthenticationManager : IAuthenticationManager
{
    public Task<ClaimsPrincipal> CurrentUser()
    {
        throw new NotImplementedException();
    }

    public Task<IResult> Login(TokenRequest model)
    {
        throw new NotImplementedException();
    }

    public Task<IResult> Logout()
    {
        throw new NotImplementedException();
    }

    public Task<string> RefreshToken()
    {
        throw new NotImplementedException();
    }

    public Task<string> TryRefreshToken()
    {
        throw new NotImplementedException();
    }
}