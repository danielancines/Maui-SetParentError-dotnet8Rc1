using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Windows.Win32;

namespace Maui.SetParentError;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        Application.Current.OpenWindow(new MyWindow(new ContentPage()));
    }
}

public class MyWindow : Window
{
    public MyWindow(Page page) : base(page)
    {
        
    }
}

public class MyWindowHandler : WindowHandler
{
    protected override void ConnectHandler(Microsoft.UI.Xaml.Window platformView)
    {
        base.ConnectHandler(platformView);

        var mainWindowHandle = (Application.Current.MainPage.Window.Handler.PlatformView as MauiWinUIWindow).GetWindowHandle();
        var childWindowHandle = this.PlatformView.GetWindowHandle();

        PInvoke.SetParent(new Windows.Win32.Foundation.HWND(childWindowHandle), new Windows.Win32.Foundation.HWND(mainWindowHandle));
    }
}
