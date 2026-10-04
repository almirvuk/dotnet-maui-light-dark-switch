namespace MauiThemeDemo.Pages;

public class CodePage : ContentPage
{
	readonly Label _currentThemeLabel;

	public CodePage()
	{
		Title = "Code";

		var label = new Label
		{
			Text = "This color is set with SetAppThemeColor",
			FontSize = 18
		};
		label.SetAppThemeColor(Label.TextColorProperty, Colors.Black, Colors.White);

		var image = new Image { HeightRequest = 60 };
		image.SetAppTheme<FileImageSource>(Image.SourceProperty, "logo_dark.png", "logo_light.png");

		_currentThemeLabel = new Label { FontSize = 16 };

		Content = new VerticalStackLayout
		{
			Padding = 20,
			Spacing = 16,
			Children = { image, label, _currentThemeLabel }
		};
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		Application.Current!.RequestedThemeChanged += OnRequestedThemeChanged;
		UpdateThemeLabel(Application.Current.RequestedTheme);
	}

	protected override void OnDisappearing()
	{
		base.OnDisappearing();
		Application.Current!.RequestedThemeChanged -= OnRequestedThemeChanged;
	}

	void OnRequestedThemeChanged(object? sender, AppThemeChangedEventArgs e)
	{
		UpdateThemeLabel(e.RequestedTheme);
	}

	void UpdateThemeLabel(AppTheme theme)
	{
		_currentThemeLabel.Text = $"Current theme: {theme}";
	}
}
