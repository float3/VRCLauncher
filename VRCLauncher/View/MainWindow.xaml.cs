using System.Diagnostics;
using System.Windows;
using VRCLauncher.Model;

namespace VRCLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private ViewModel.ViewModel _viewModel = new();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _viewModel;
            Application.Current.Exit += OnApplicationExit;
        }

        private void OnApplicationExit(object sender, ExitEventArgs e)
        {
            _viewModel.Config.Save();
        }

        private void Launch(object sender, RoutedEventArgs e)
        {
            Process.Start(Config.FindVRCexePath() + "\\VRChat.exe", _viewModel.Config.GetArgs());
        }
    }
}