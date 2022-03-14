using System.ComponentModel;
using System.Runtime.CompilerServices;
using VRCLauncher.Annotations;
using VRCLauncher.Model;

namespace VRCLauncher.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        public Config Config { get; set; }

        public ViewModel()
        {
            Config = Config.Load();
            _noVR = NoVR;
            _fps = FPS;
            _legacyFBTCalibrate = LegacyFBTCalibrate;
            _profile = Profile;
            _watchWorlds = WatchWorlds;
            _watchAvatars = WatchAvatars;
            _fullscreen = Fullscreen;
            _width = Width;
            _height = Height;
            _monitor = Monitor;
            _udonDebugLogging = UdonDebugLogging;
            _debugGUI = DebugGUI;
            _sdkLogLevels = SDKLogLevels;
            _verboseLogging = VerboseLogging;
            _midiDevice = MidiDevice;
            _oscPorts = OSCPorts;
            _launchInstance = LaunchInstance;
        }

        private bool _noVR;

        public bool NoVR
        {
            get => Config.NoVR;
            set
            {
                if (_noVR != value)
                {
                    _noVR = value;
                    Config.NoVR = value;
                    Config.Save();
                    OnPropertyChanged(nameof(NoVR));
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
                    _fps = value;
                    Config.FPS = value;
                    Config.Save();
                    OnPropertyChanged(nameof(FPS));
                }
            }
        }

        private bool _legacyFBTCalibrate;

        public bool LegacyFBTCalibrate
        {
            get => Config.LegacyFBTCalibrate;
            set
            {
                if (_legacyFBTCalibrate != value)
                {
                    _legacyFBTCalibrate = value;
                    Config.LegacyFBTCalibrate = value;
                    Config.Save();
                    OnPropertyChanged(nameof(LegacyFBTCalibrate));
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
                    _profile = value;
                    Config.Profile = value;
                    Config.Save();
                    OnPropertyChanged(nameof(Profile));
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
                    _watchWorlds = value;
                    Config.WatchWorlds = value;
                    Config.Save();
                    OnPropertyChanged(nameof(WatchWorlds));
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
                    _watchAvatars = value;
                    Config.WatchAvatars = value;
                    Config.Save();
                    OnPropertyChanged(nameof(WatchAvatars));
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
                    _fullscreen = value;
                    Config.Fullscreen = value;
                    Config.Save();
                    OnPropertyChanged(nameof(Fullscreen));
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
                    _height = value;
                    Config.Height = value;
                    Config.Save();
                    OnPropertyChanged(nameof(Height));
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
                    _width = value;
                    Config.Width = value;
                    Config.Save();
                    OnPropertyChanged(nameof(Width));
                }
            }
        }

        private int _monitor;

        public int Monitor
        {
            get => Config.Monitor;
            set
            {
                if (_monitor != value)
                {
                    _monitor = value;
                    Config.Monitor = value;
                    Config.Save();
                    OnPropertyChanged(nameof(Monitor));
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
                    _udonDebugLogging = value;
                    Config.UdonDebugLogging = value;
                    Config.Save();
                    OnPropertyChanged(nameof(UdonDebugLogging));
                }
            }
        }

        private bool _debugGUI;

        public bool DebugGUI
        {
            get => Config.DebugGUI;
            set
            {
                if (_debugGUI != value)
                {
                    _debugGUI = value;
                    Config.DebugGUI = value;
                    Config.Save();
                    OnPropertyChanged(nameof(DebugGUI));
                }
            }
        }

        private bool _sdkLogLevels;

        public bool SDKLogLevels
        {
            get => Config.SDKLogLevels;
            set
            {
                if (_sdkLogLevels != value)
                {
                    _sdkLogLevels = value;
                    Config.SDKLogLevels = value;
                    Config.Save();
                    OnPropertyChanged(nameof(VerboseLogging));
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
                    _verboseLogging = value;
                    Config.VerboseLogging = value;
                    Config.Save();
                    OnPropertyChanged(nameof(VerboseLogging));
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
                    _midiDevice = value;
                    Config.MidiDevice = value;
                    Config.Save();
                    OnPropertyChanged(nameof(MidiDevice));
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
                    _oscPorts = value;
                    Config.OSCPorts = value;
                    Config.Save();
                    OnPropertyChanged(nameof(OSCPorts));
                }
            }
        }

        private string _launchInstance;

        public string LaunchInstance
        {
            get => Config.LaunchInstance;
            set
            {
                if (_launchInstance != value)
                {
                    _launchInstance = value;
                    Config.LaunchInstance = value;
                    Config.Save();
                    OnPropertyChanged(nameof(LaunchInstance));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}