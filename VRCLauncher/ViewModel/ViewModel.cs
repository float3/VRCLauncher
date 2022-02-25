using System.ComponentModel;
using VRCLauncher.Model;

// ReSharper disable InconsistentNaming

namespace VRCLauncher.ViewModel
{
	public class ViewModel
	{
		public Config Config { get; set; }

		public ViewModel()
		{
			Config = Config.Load();
			noVR = NoVR;
			fps = FPS;
			legacyFBTCalibrate = LegacyFBTCalibrate;
			profile = Profile;
			watchWorlds = WatchWorlds;
			watchAvatars = WatchAvatars;
			fullscreen = Fullscreen;
			width = Width;
			height = Height;
			udonDebugLogging = UdonDebugLogging;
			debugGUI = DebugGUI;
			sdkLogLevels = SdkLogLevels;
			midiDevice = MidiDevice;
			oscPorts = OSCPorts;
		}

		private bool noVR;

		public bool NoVR
		{
			get => Config.NoVR;
			set
			{
				if (noVR != value)
				{
					Config.NoVR = value;
					Config.Save();
				}
			}
		}

		private int fps;

		public int FPS
		{
			get => Config.FPS;
			set
			{
				if (fps != value)
				{
					Config.FPS = value;
					Config.Save();
				}
			}
		}

		private bool legacyFBTCalibrate;

		public bool LegacyFBTCalibrate
		{
			get => Config.LegacyFBTCalibrate;
			set
			{
				if (LegacyFBTCalibrate != value)
				{
					Config.LegacyFBTCalibrate = value;
					Config.Save();
				}
			}
		}

		private int profile;

		public int Profile
		{
			get => Config.Profile;
			set
			{
				if (profile != value)
				{
					Config.Profile = value;
					Config.Save();
				}
			}
		}

		private bool watchWorlds;

		public bool WatchWorlds
		{
			get => Config.WatchWorlds;
			set
			{
				if (watchWorlds != value)
				{
					Config.WatchWorlds = value;
					Config.Save();
				}
			}
		}

		private bool watchAvatars;

		public bool WatchAvatars
		{
			get => Config.WatchAvatars;
			set
			{
				if (watchAvatars != value)
				{
					Config.WatchAvatars = value;
					Config.Save();
				}
			}
		}

		private bool fullscreen;

		public bool Fullscreen
		{
			get => Config.Fullscreen;
			set
			{
				if (fullscreen != value)
				{
					Config.Fullscreen = value;
					Config.Save();
				}
			}
		}

		private int height;

		public int Height
		{
			get => Config.Height;
			set
			{
				if (height != value)
				{
					Config.Height = value;
					Config.Save();
				}
			}
		}

		private int width;

		public int Width
		{
			get => Config.Width;
			set
			{
				if (width != value)
				{
					Config.Width = value;
					Config.Save();
				}
			}
		}

		private bool udonDebugLogging;

		public bool UdonDebugLogging
		{
			get => Config.UdonDebugLogging;
			set
			{
				if (udonDebugLogging != value)
				{
					Config.UdonDebugLogging = value;
					Config.Save();
				}
			}
		}

		private bool debugGUI;

		public bool DebugGUI
		{
			get => Config.DebugGUI;
			set
			{
				if (debugGUI != value)
				{
					Config.DebugGUI = value;
					Config.Save();
				}
			}
		}

		private bool sdkLogLevels;

		public bool SdkLogLevels
		{
			get => Config.SDKLogLevels;
			set
			{
				if (sdkLogLevels != value)
				{
					Config.SDKLogLevels = value;
					Config.Save();
				}
			}
		}

		private string midiDevice;

		public string MidiDevice
		{
			get => Config.MidiDevice;
			set
			{
				if (midiDevice != value)
				{
					Config.MidiDevice = value;
					Config.Save();
				}
			}
		}

		private string oscPorts;

		public string OSCPorts
		{
			get => Config.OSCPorts;
			set
			{
				if (oscPorts != value)
				{
					Config.OSCPorts = value;
					Config.Save();
				}
			}
		}
	}
}