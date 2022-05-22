using MudBlazor;

public interface IClientPreferenceManager
{
    Task<MudTheme> GetCurrentThemeAsync();
    Task<bool> ToggleLayoutDirection();
    Task<bool> ToggleDarkModeAsync();

}


public interface IPreference
{
    public string LanguageCode { get; set; }
}