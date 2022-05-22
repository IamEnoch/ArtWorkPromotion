using ArtworkPromotion.Constants.Storage;
using ArtWorkPromotion.web.Infrastructure;
using Blazored.LocalStorage;
using MudBlazor;

public class ClientPreferenceManager : IClientPreferenceManager
{
        private readonly ILocalStorageService _localStorageService;

        public ClientPreferenceManager(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

    public async Task<MudTheme> GetCurrentThemeAsync()
    {
            var preference = await GetPreference() as Preference;
           
            return Theme.DefaultTheme;

    }

    public Task<bool> ToggleDarkModeAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> ToggleLayoutDirection()
    {
        throw new NotImplementedException();
    }

        public async Task<IPreference> GetPreference()
        {
            return await _localStorageService.GetItemAsync<Preference>(Constants.Local.Preference) ?? new Preference();
        }
        public async Task SetPreference(IPreference preference)
        {
            await _localStorageService.SetItemAsync(Constants.Local.Preference, preference as Preference);
        }

}