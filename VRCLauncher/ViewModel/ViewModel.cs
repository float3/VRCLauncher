using VRCLauncher.Model;

namespace VRCLauncher.ViewModel
{
	public class ViewModel
	{
		public Config Config { get; set; }

		public ViewModel()
		{
			Config = Config.Load();
			_noVr = NoVR;
			_fps = FPS;
			_legacyFbtCalibrate = LegacyFBTCalibrate;
			_profile = Profile;
			_watchWorlds = WatchWorlds;
			_watchAvatars = WatchAvatars;
			_fullscreen = Fullscreen;
			_width = Width;
			_height = Height;
			_udonDebugLogging = UdonDebugLogging;
			_debugGui = DebugGUI;
			_sdkLogLevels = SdkLogLevels;
			_verboseLogging = VerboseLogging;
			_midiDevice = MidiDevice;
			_oscPorts = OSCPorts;
		}

		private bool _noVr;

		public bool NoVR
		{
			get => Config.NoVR;
			set
			{
				if (_noVr != value)
				{
					Config.NoVR = value;
					Config.Save();
				}
			}
		}

		private int _fps;

		public int FPS
		{
			get => Config.FPS;
			set
			{
				if (_fps != value)
				{
					Config.FPS = value;
					Config.Save();
				}
			}
		}

		private bool _legacyFbtCalibrate;

		public bool LegacyFBTCalibrate
		{
			get => Config.LegacyFBTCalibrate;
			set
			{
				if (_legacyFbtCalibrate != value)
				{
					Config.LegacyFBTCalibrate = value;
					Config.Save();
				}
			}
		}

		private int _profile;

		public int Profile
		{
			get => Config.Profile;
			set
			{
				if (_profile != value)
				{
					Config.Profile = value;
					Config.Save();
				}
			}
		}

		private bool _watchWorlds;

		public bool WatchWorlds
		{
			get => Config.WatchWorlds;
			set
			{
				if (_watchWorlds != value)
				{
					Config.WatchWorlds = value;
					Config.Save();
				}
			}
		}

		private bool _watchAvatars;

		public bool WatchAvatars
		{
			get => Config.WatchAvatars;
			set
			{
				if (_watchAvatars != value)
				{
					Config.WatchAvatars = value;
					Config.Save();
				}
			}
		}

		private bool _fullscreen;

		public bool Fullscreen
		{
			get => Config.Fullscreen;
			set
			{
				if (_fullscreen != value)
				{
					Config.Fullscreen = value;
					Config.Save();
				}
			}
		}

		private int _height;

		public int Height
		{
			get => Config.Height;
			set
			{
				if (_height != value)
				{
					Config.Height = value;
					Config.Save();
				}
			}
		}

		private int _width;

		public int Width
		{
			get => Config.Width;
			set
			{
				if (_width != value)
				{
					Config.Width = value;
					Config.Save();
				}
			}
		}

		private bool _udonDebugLogging;

		public bool UdonDebugLogging
		{
			get => Config.UdonDebugLogging;
			set
			{
				if (_udonDebugLogging != value)
				{
					Config.UdonDebugLogging = value;
					Config.Save();
				}
			}
		}

		private bool _debugGui;

		public bool DebugGUI
		{
			get => Config.DebugGUI;
			set
			{
				if (_debugGui != value)
				{
					Config.DebugGUI = value;
					Config.Save();
				}
			}
		}

		private bool _sdkLogLevels;

		public bool SdkLogLevels
		{
			get => Config.SDKLogLevels;
			set
			{
				if (_sdkLogLevels != value)
				{
					Config.SDKLogLevels = value;
					Config.Save();
				}
			}
		}
		
		private bool _verboseLogging;

		public bool VerboseLogging
		{
			get => Config.VerboseLogging;
			set
			{
				if (_verboseLogging != value)
				{
					Config.VerboseLogging = value;
					Config.Save();
				}
			}
		}

		private string _midiDevice;

		public string MidiDevice
		{
			get => Config.MidiDevice;
			set
			{
				if (_midiDevice != value)
				{
					Config.MidiDevice = value;
					Config.Save();
				}
			}
		}

		private string _oscPorts;

		public string OSCPorts
		{
			get => Config.OSCPorts;
			set
			{
				if (_oscPorts != value)
				{
					Config.OSCPorts = value;
					Config.Save();
				}
			}
		}
	}
}