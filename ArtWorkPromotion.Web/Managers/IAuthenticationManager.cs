using System.Security.Claims;
using ArtWorkPromotion.Managers;
using ArtWorkPromotion.Web.Model;

public interface IAuthenticationManager : IManager
    {
        Task<IResult> Login(TokenRequest model);

        Task<IResult> Logout();

        Task<string> RefreshToken();

        Task<string> TryRefreshToken();

        Task<ClaimsPrincipal> CurrentUser();
    }
