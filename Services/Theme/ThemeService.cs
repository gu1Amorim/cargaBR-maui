namespace CargaBR.Services.Theme;

public class ThemeService : IThemeService
{
    private const string PreferenceKey = "app_theme";

    public AppTheme CurrentTheme => Application.Current?.UserAppTheme ?? AppTheme.Unspecified;

    public void ApplyPersistedTheme()
    {
        var saved = Preferences.Default.Get(PreferenceKey, nameof(AppTheme.Unspecified));
        var theme = Enum.TryParse<AppTheme>(saved, out var parsed) ? parsed : AppTheme.Unspecified;

        if (Application.Current is not null)
            Application.Current.UserAppTheme = theme;
    }

    public void SetTheme(AppTheme theme)
    {
        if (Application.Current is not null)
            Application.Current.UserAppTheme = theme;

        Preferences.Default.Set(PreferenceKey, theme.ToString());
    }
}
