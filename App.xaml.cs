namespace MauiThemeDemo;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		// Restore the theme the user picked on the Settings tab (Unspecified = follow the system)
		UserAppTheme = (AppTheme)Preferences.Default.Get("app_theme", (int)AppTheme.Unspecified);
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new Window(new AppShell());
	}
}
