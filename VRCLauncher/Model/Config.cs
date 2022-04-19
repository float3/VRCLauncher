using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;
using Microsoft.Win32;

// ReSharper disable InconsistentNaming

namespace VRCLauncher.Model;

public class Config
{
    public bool NoVR { get; set; }
    public int FPS { get; set; }
    public bool LegacyFBTCalibrate { get; set; }
    public int Profile { get; set; }
    public bool WatchWorlds { get; set; }
    public bool WatchAvatars { get; set; }
    public bool Fullscreen { get; set; }
    public int Width { get; set; }

    public int Height { get; set; }

    // public int Monitor { get; set; }
    public bool UdonDebugLogging { get; set; }
    public bool DebugGUI { get; set; }
    public bool SDKLogLevels { get; set; }
    public bool VerboseLogging { get; set; }
    public string MidiDevice { get; set; }
    public string OSCPorts { get; set; }
    public string CustomArmRatio { get; set; }
    public bool DisableShoulderTracking { get; set; }
    public string LaunchInstance { get; set; }
    public string ArbitraryArguments { get; set; }
    public ObservableCollection<CompanionApp> CompanionApps { get; set; }
    public bool LaunchCompanionApps { get; set; }

    [JsonIgnore] public const string UserFolderPath = @"%AppData%\..\LocalLow\VRCLauncher\";
    [JsonIgnore] public static string ExpandedUserFolderPath = Environment.ExpandEnvironmentVariables(UserFolderPath);
    [JsonIgnore] public const string ConfigName = "config.json";

    public Config()
    {
        NoVR = false;
        FPS = 90;
        Profile = 0;

        WatchWorlds = false;
        WatchAvatars = false;

        Fullscreen = true;
        Width = 0;
        Height = 0;
        // Monitor = 0;

        UdonDebugLogging = false;
        DebugGUI = false;
        SDKLogLevels = false;
        VerboseLogging = false;

        LegacyFBTCalibrate = false;
        CustomArmRatio = "0.4537";
        DisableShoulderTracking = false;

        MidiDevice = "";
        OSCPorts = "";
        LaunchInstance = "";
        ArbitraryArguments = "";

        CompanionApps = new();
        LaunchCompanionApps = true;
    }

    // ReSharper disable once IdentifierTypo
    public static string FindVRCexePath()
    {
        try
        {
            return Registry.LocalMachine
                .OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App " + 438100)!
                .GetValue("InstallLocation")!.ToString() ?? throw new InvalidOperationException();
        }
        catch
        {
            MessageBox.Show("Error - Registry entry not present or null" + "\n VRChat not installed through steam");
            throw new Exception("VRChat not installed through steam");
        }
    }

    public void Save()
    {
        if (!Directory.Exists(ExpandedUserFolderPath)) Directory.CreateDirectory(ExpandedUserFolderPath);

        string json = JsonSerializer.Serialize(this);
        File.WriteAllText(ExpandedUserFolderPath + ConfigName, json);
    }

    public static Config Load()
    {
        Config config = new();

        if (File.Exists(ExpandedUserFolderPath + ConfigName))
        {
            string json = File.ReadAllText(ExpandedUserFolderPath + ConfigName);
            try
            {
                config = JsonSerializer.Deserialize<Config>(json)!;
                config.LaunchInstance = "";
            }
            catch (Exception e) // JsonException
            {
                MessageBox.Show($"Error loading {ConfigName}: \n" + e.Message + "\n this might be due to a update",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                config = new();
            }
        }

        return config;
    }

    public List<string> GetArgs()
    {
        List<string> args = new();

        if (NoVR) args.Add("--no-vr");

        args.Add("--fps=" + FPS);

        if (LegacyFBTCalibrate) args.Add("--legacy-fbt-calibrate");

        args.Add("--profile=" + Profile);

        if (WatchWorlds) args.Add("--watch-worlds");

        if (WatchAvatars) args.Add("--watch-avatars");

        if (UdonDebugLogging) args.Add("--enable-udon-debug-logging");

        if (DebugGUI) args.Add("--enable-debug-gui");

        if (SDKLogLevels) args.Add("--enable-sdk-log-levels");

        if (VerboseLogging) args.Add("--enable-verbose-logging");

        args.Add("-screen-fullscreen");
        args.Add(Fullscreen ? "1" : "0");

        if (Width != 0)
        {
            args.Add("-screen-width");
            args.Add(Width.ToString());
        }

        if (Height != 0)
        {
            args.Add("-screen-height");
            args.Add(Height.ToString());
        }

        // args.Add("-monitor");
        // args.Add(Monitor.ToString());

        if (MidiDevice != "") args.Add("--midi=" + MidiDevice);

        if (OSCPorts != "") args.Add("--osc-ports=" + OSCPorts);

        if (CustomArmRatio != "") args.Add("--custom-arm-ratio=" + CustomArmRatio);

        if (DisableShoulderTracking) args.Add("--disable-shoulder-tracking");

        if (LaunchInstance != "") args.Add(LaunchInstance);

        if (ArbitraryArguments != "")
        {
            args.AddRange(ArbitraryArguments.Split(";"));
        }

        return args;
    }

    public void LaunchApps(List<string> args)
    {
        if (LaunchCompanionApps)
        {
            foreach (CompanionApp app in CompanionApps)
            {
                bool launch = true;

                if (app.Enabled)
                {
                    if (app.Rules != "")
                    {
                        foreach (string rule in app.Rules.Split(";"))
                        {
                            if (rule.StartsWith("!"))
                            {
                                if (args.Contains(rule.Substring(1)))
                                {
                                    launch = false;
                                    break;
                                }
                            }
                            else
                            {
                                if (!args.Contains(rule))
                                {
                                    launch = false;
                                    break;
                                }
                            }
                        }
                    }

                    if (launch)
                    {
                        Process process = new();
                        process.StartInfo.FileName = app.Path;
                        process.StartInfo.WorkingDirectory = Path.GetDirectoryName(app.Path);
                        process.StartInfo.Arguments = app.Args;
                        process.Start();
                    }
                }
            }
        }
    }
}