namespace MauiThemeDemo.Pages;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
		UpdateSelectedLabel();
	}

	void OnSystemClicked(object? sender, EventArgs e)
	{
		SetTheme(AppTheme.Unspecified);
		UpdateSelectedLabel();
	}

	void OnLightClicked(object? sender, EventArgs e)
	{
		SetTheme(AppTheme.Light);
		UpdateSelectedLabel();
	}

	void OnDarkClicked(object? sender, EventArgs e)
	{
		SetTheme(AppTheme.Dark);
		UpdateSelectedLabel();
	}

	static void SetTheme(AppTheme theme)
	{
		Application.Current!.UserAppTheme = theme;
		Preferences.Default.Set("app_theme", (int)theme);
	}

	void UpdateSelectedLabel()
	{
		SelectedLabel.Text = Application.Current!.UserAppTheme switch
		{
			AppTheme.Light => "Selected: Light",
			AppTheme.Dark => "Selected: Dark",
			_ => "Selected: Use system setting"
		};
	}
}
