using System;
using ArtWorkPromotion.PCL.Models;

namespace ArtWorkPromotion.API.Interfaces
{
	public interface IUserService
	{
		Task<UserManagerResponse> LoginUserAsync(LoginInfo loginInfo);
		Task<UserManagerResponse> RegisteruserAsync(RegistrationInfo registrationInfo);

	}


}

