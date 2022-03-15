using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows;
using Microsoft.Win32;

// ReSharper disable InconsistentNaming

namespace VRCLauncher.Model
{
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
        public int Monitor { get; set; }
        public bool UdonDebugLogging { get; set; }
        public bool DebugGUI { get; set; }
        public bool SDKLogLevels { get; set; }
        public bool VerboseLogging { get; set; }
        public string MidiDevice { get; set; }
        public string OSCPorts { get; set; }
        public string LaunchInstance { get; set; }

        public Config()
        {
            NoVR = false;
            FPS = 90;
            LegacyFBTCalibrate = false;
            Profile = 0;
            WatchWorlds = false;
            WatchAvatars = false;
            Fullscreen = true;
            Width = 0;
            Height = 0;
            Monitor = 0;
            UdonDebugLogging = false;
            DebugGUI = false;
            SDKLogLevels = false;
            VerboseLogging = false;
            MidiDevice = "";
            OSCPorts = "";
            LaunchInstance = "";
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
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                                 "\\3\\VRCLauncher";
            if (!Directory.Exists(appDataPath)) Directory.CreateDirectory(appDataPath);

            string json = JsonSerializer.Serialize(this);
            File.WriteAllText(appDataPath + "\\config.json", json);
        }

        public static Config Load()
        {
            Config config = new();
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                                 "\\3\\VRCLauncher";
            if (File.Exists(appDataPath + "\\config.json"))
            {
                string json = File.ReadAllText(appDataPath + "\\config.json");
                try
                {
                    config = JsonSerializer.Deserialize<Config>(json)!;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error loading config.json: \n" + e.Message + "\n this might be due to a update");
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

            args.Add("-profile=" + Profile);

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

            args.Add("-monitor");
            args.Add(Monitor.ToString());

            if (MidiDevice != "") args.Add("-midi=" + MidiDevice);

            if (OSCPorts != "") args.Add("-osc-ports=" + OSCPorts);

            if (LaunchInstance != "") args.Add(LaunchInstance);

            return args;
        }
    }
}