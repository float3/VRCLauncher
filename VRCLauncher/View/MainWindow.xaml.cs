using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using VRCLauncher.Model;

namespace VRCLauncher.View;

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

        CommandBindings.Add(new CommandBinding(SystemCommands.CloseWindowCommand, OnCloseWindow));
        CommandBindings.Add(new CommandBinding(SystemCommands.MaximizeWindowCommand, OnMaximizeWindow,
            OnCanResizeWindow));
        CommandBindings.Add(new CommandBinding(SystemCommands.MinimizeWindowCommand, OnMinimizeWindow,
            OnCanMinimizeWindow));
        CommandBindings.Add(new CommandBinding(SystemCommands.RestoreWindowCommand, OnRestoreWindow,
            OnCanResizeWindow));

        Process[] processList = Process.GetProcessesByName("VRCLauncher");

        if (processList.Length > 1)
        {
            MessageBoxResult result = MessageBox.Show("VRCLauncher is already running, start another instance?",
                "VRCLauncher", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
                return;
            if (result == MessageBoxResult.No)
                Environment.Exit(0);
        }

        string[] args = Environment.GetCommandLineArgs();

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
        _viewModel.Config.Save();
        Process process = new Process();
        process.StartInfo.FileName = _viewModel.Config.FindVRCexePath();
        process.StartInfo.WorkingDirectory = Config.FindVRCPath();
        List<string> args = _viewModel.Config.GetArgs();
        string arguments = string.Join(" ", args);
        process.StartInfo.Arguments = arguments;
        process.Start();
        _viewModel.Config.LaunchApps(args);

        if (_viewModel.Config.CloseOnLaunch) Environment.Exit(0);
    }

    private void ValidateFloatTextBox(object sender, TextCompositionEventArgs e)
    {
        if (sender is TextBox)
        {
            string text = (sender as TextBox).Text + e.Text;
            e.Handled = !float.TryParse(text, out _) || text.Contains(",");
        }
    }

    private void OnCanResizeWindow(object sender, CanExecuteRoutedEventArgs e)
    {
        e.CanExecute = ResizeMode == ResizeMode.CanResize || ResizeMode == ResizeMode.CanResizeWithGrip;
    }

    private void OnCanMinimizeWindow(object sender, CanExecuteRoutedEventArgs e)
    {
        e.CanExecute = ResizeMode != ResizeMode.NoResize;
    }

    private void OnCloseWindow(object target, ExecutedRoutedEventArgs e)
    {
        SystemCommands.CloseWindow(this);
    }

    private void OnMaximizeWindow(object target, ExecutedRoutedEventArgs e)
    {
        SystemCommands.MaximizeWindow(this);
    }

    private void OnMinimizeWindow(object target, ExecutedRoutedEventArgs e)
    {
        SystemCommands.MinimizeWindow(this);
    }

    private void OnRestoreWindow(object target, ExecutedRoutedEventArgs e)
    {
        SystemCommands.RestoreWindow(this);
    }

    private void Remove(object sender, RoutedEventArgs e)
    {
        // if nothing is selected remove last element in list            
        int index = CompanionApps.SelectedIndex == -1
            ? CompanionApps.Items.Count - 1
            : CompanionApps.SelectedIndex;
        _viewModel.CompanionApps.RemoveAt(index);

        // set selection back to where it was before
        CompanionApps.SelectedIndex = index;
    }

    private void Add(object sender, RoutedEventArgs e)
    {
        _viewModel.CompanionApps.Add(new());
    }
}