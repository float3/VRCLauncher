using System.Diagnostics;
using System.Windows;
using VRCLauncher.Model;

namespace VRCLauncher.View;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    private ViewModel.ViewModel _viewModel = new();

    public MainWindow(string[] args)
    {
        InitializeComponent();
        DataContext = _viewModel;

        foreach (string arg in args)
        {
            if (arg.StartsWith("vrchat://")) _viewModel.LaunchInstance = arg;
            if (arg == "--no-vr") _viewModel.NoVR = true;
        }

        Application.Current.Exit += OnApplicationExit;
    }

    private void OnApplicationExit(object sender, ExitEventArgs e)
    {
        _viewModel.Config.Save();
    }

    private void Launch(object sender, RoutedEventArgs e)
    {
        Process process = new Process();
        process.StartInfo.FileName = Config.FindVRCexePath() + "\\VRChat.exe";
        process.StartInfo.WorkingDirectory = Config.FindVRCexePath();
        string arguments = string.Join(" ", _viewModel.Config.GetArgs());
        process.StartInfo.Arguments = arguments;
        process.Start();
    }
}