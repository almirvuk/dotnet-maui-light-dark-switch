# .NET MAUI: Light and Dark Mode with AppThemeBinding

A small .NET MAUI sample that shows light and dark mode with `AppThemeBinding`. It is the companion project for the blog post [.NET MAUI: Light and Dark Mode with AppThemeBinding](https://almirvuk.com/net-maui-light-and-dark-mode-with-appthemebinding/), so the code is kept simple: no MVVM libraries and no extra NuGet packages.

📖 **Read the blog post:** https://almirvuk.com/net-maui-light-and-dark-mode-with-appthemebinding/

## What it demonstrates

| Tab | What you'll see |
| --- | --- |
| **Basics** | Inline `{AppThemeBinding Light=..., Dark=...}` and the `Default` fallback |
| **Styled** | A page with no hardcoded colors. Everything comes from implicit and keyed styles (`SecondaryLabel`, `Card`), plus a theme-aware `Image` |
| **Code** | The same ideas in C#: `SetAppThemeColor`, `SetAppTheme<FileImageSource>`, and `RequestedThemeChanged` |
| **Settings** | Lets the user pick System / Light / Dark via `UserAppTheme`, saved with `Preferences` |

Where to look:

- `Resources/Styles/Colors.xaml`: all theme colors, with a Light and a Dark value for each role
- `Resources/Styles/Styles.xaml`: implicit `ContentPage`, `Label` and `Button` styles, and the `SecondaryLabel` and `Card` styles
- `App.xaml.cs`: restores the saved theme at startup
- `Platforms/Android/MainActivity.cs`: `ConfigChanges.UiMode` lets the app react to theme changes without restarting the activity

## Requirements

- .NET 10 SDK with the MAUI workload (`dotnet workload install maui`)
- Android SDK and an emulator or device
- macOS with Xcode for iOS

## Run it

```bash
# Android (starts on the running emulator or connected device)
dotnet build MauiThemeDemo.csproj -t:Run -f net10.0-android

# iOS simulator
dotnet build MauiThemeDemo.csproj -t:Run -f net10.0-ios
```

Or open `MauiThemeDemo.slnx` in Visual Studio 2022 (17.13+) or Rider, pick a device and press Run. In VS Code, open the folder and press F5.

## Switching dark mode on and off

**Android emulator**

- Settings > Display > Dark theme, or
- from a terminal:
  ```bash
  adb shell "cmd uimode night yes"   # dark
  adb shell "cmd uimode night no"    # light
  ```

**iOS simulator**

- Settings > Developer > Dark Appearance, or
- press **Cmd+Shift+A** while the Simulator window is focused.

The theme you choose on the app's **Settings** tab overrides the system setting. Choose **Use system setting** to follow the device again.
