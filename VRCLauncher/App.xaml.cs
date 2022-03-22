using System.Windows;

namespace VRCLauncher;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
    private void Application_Startup(object sender, StartupEventArgs e)
    {
        View.MainWindow wnd = new View.MainWindow(e.Args);
        wnd.Show();
    }
}