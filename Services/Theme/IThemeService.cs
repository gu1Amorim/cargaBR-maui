namespace CargaBR.Services.Theme;

public interface IThemeService
{
    AppTheme CurrentTheme { get; }

    void ApplyPersistedTheme();

    void SetTheme(AppTheme theme);
}
