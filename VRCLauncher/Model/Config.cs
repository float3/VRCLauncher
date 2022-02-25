using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Windows;
using Microsoft.Win32;

// ReSharper disable InconsistentNaming

namespace VRCLauncher.Model
{
	public class Config
	{
		static string AppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\3\\VRCLauncher";

		//private static string ExpandedUserFolderPath = Environment.ExpandEnvironmentVariables(@"%AppData%\..\LocalLow\VRCLauncher");
		//private static string _VRChatLocation = FindVRCexePath();
		//public string GetLocalResourcePath(string path) => Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + path;

		public bool NoVR { get; set; }
		public int FPS { get; set; }
		public bool LegacyFBTCalibrate { get; set; }
		public int Profile { get; set; }
		public bool WatchWorlds { get; set; }
		public bool WatchAvatars { get; set; }
		public bool Fullscreen { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
		public bool UdonDebugLogging { get; set; }
		public bool DebugGUI { get; set; }
		public bool SDKLogLevels { get; set; }
		public string MidiDevice { get; set; }
		public string OSCPorts { get; set; }

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
			UdonDebugLogging = false;
			DebugGUI = false;
			SDKLogLevels = false;
			MidiDevice = "";
			OSCPorts = "";
		}

		// ReSharper disable once IdentifierTypo
		public static string FindVRCexePath()
		{
			try
			{
				return Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App " + 438100).GetValue("InstallLocation").ToString();
			}
			catch
			{
				MessageBox.Show("Error - Registry entry not present or null");
				throw new Exception("VRChat not installed through steam");
			}
		}

		public void Save()
		{
			if (!Directory.Exists(AppDataPath)) Directory.CreateDirectory(AppDataPath);

			string json = JsonSerializer.Serialize(this);
			File.WriteAllText(AppDataPath + "\\config.json", json);
		}

		public static Config Load()
		{
			if (File.Exists(AppDataPath + "\\config.json"))
			{
				string json = File.ReadAllText(AppDataPath + "\\config.json");
				return JsonSerializer.Deserialize<Config>(json)!;
			}
			else
			{
				return new Config();
			}
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

			if (Fullscreen) args.Add("-screen-fullscreen 1");

			if (Width != 0) args.Add("-screen-width " + Width);

			if (Height != 0) args.Add("-screen-height " + Height);

			if (MidiDevice != "") args.Add("-midi=" + MidiDevice);

			if (OSCPorts != "") args.Add("-osc-ports=" + OSCPorts);

			return args;
		}
	}
}