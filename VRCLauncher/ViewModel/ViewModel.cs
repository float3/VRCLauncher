using System.Collections.ObjectModel;
using System.ComponentModel;
using VRCLauncher.Annotations;
using VRCLauncher.Model;

namespace VRCLauncher.ViewModel;

public class ViewModel : INotifyPropertyChanged
{
    public Config Config { get; set; }

    public ViewModel()
    {
        Config = Config.Load();
        NoVR = Config.NoVR;
        FPS = Config.FPS;
        Profile = Config.Profile;

        WatchWorlds = Config.WatchWorlds;
        WatchAvatars = Config.WatchAvatars;

        Fullscreen = Config.Fullscreen;
        Width = Config.Width;
        Height = Config.Height;
        Monitor = Config.Monitor;

        UdonDebugLogging = Config.UdonDebugLogging;
        DebugGUI = Config.DebugGUI;
        SDKLogLevels = Config.SDKLogLevels;
        VerboseLogging = Config.VerboseLogging;

        LegacyFBTCalibrate = Config.LegacyFBTCalibrate;
        CustomArmRatio = Config.CustomArmRatio;
        DisableShoulderTracking = Config.DisableShoulderTracking;
        CalibrationRange = Config.CalibrationRange;
        FreezeTrackingOnDisconnect = Config.FreezeTrackingOnDisconnect;
        EnableIKDebugLogging = Config.EnableIKDebugLogging;

        MidiDevice = Config.MidiDevice;
        OSCPorts = Config.OSCPorts;
        LaunchInstance = Config.LaunchInstance;
        LocalTestVRCWPath = Config.LocalTestVRCWPath;
        ArbitraryArguments = Config.ArbitraryArguments;

        LaunchCompanionApps = Config.LaunchCompanionApps;
        CompanionApps = Config.CompanionApps;

        RememberLaunchInstance = Config.RememberLaunchInstance;
        CloseOnLaunch = Config.CloseOnLaunch;
    }


    #region Main

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
                OnPropertyChanged(nameof(FPS));
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
                OnPropertyChanged(nameof(Profile));
            }
        }
    }

    #endregion

    #region Watchers

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
                OnPropertyChanged(nameof(WatchAvatars));
            }
        }
    }

    #endregion

    #region Screen

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
                if (value < 1) value = 1; // Monitor is specified by a 1-based index number 
                _monitor = value;
                Config.Monitor = value;
                OnPropertyChanged(nameof(Monitor));
            }
        }
    }

    #endregion

    #region Logging

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
                OnPropertyChanged(nameof(SDKLogLevels));
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
                OnPropertyChanged(nameof(VerboseLogging));
            }
        }
    }

    private bool _enableIKDebugLogging;

    public bool EnableIKDebugLogging
    {
        get => Config.EnableIKDebugLogging;
        set
        {
            if (_enableIKDebugLogging != value)
            {
                _enableIKDebugLogging = value;
                Config.EnableIKDebugLogging = value;
                OnPropertyChanged(nameof(EnableIKDebugLogging));
            }
        }
    }

    #endregion

    #region IK

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
                OnPropertyChanged(nameof(LegacyFBTCalibrate));
            }
        }
    }

    private string _customArmRatio;

    public string CustomArmRatio
    {
        get => Config.CustomArmRatio;
        set
        {
            if (_customArmRatio != value)
            {
                _customArmRatio = value;
                Config.CustomArmRatio = value;
                OnPropertyChanged(nameof(CustomArmRatio));
            }
        }
    }

    private bool _disableShoulderTracking;

    public bool DisableShoulderTracking
    {
        get => Config.DisableShoulderTracking;
        set
        {
            if (_disableShoulderTracking != value)
            {
                _disableShoulderTracking = value;
                Config.DisableShoulderTracking = value;
                OnPropertyChanged(nameof(DisableShoulderTracking));
            }
        }
    }

    private string _calibrationRange;

    public string CalibrationRange
    {
        get => Config.CalibrationRange;
        set
        {
            if (_calibrationRange != value)
            {
                _calibrationRange = value;
                Config.CalibrationRange = value;
                OnPropertyChanged(nameof(CalibrationRange));
            }
        }
    }

    private bool _freezeTrackingOnDisconnect;

    public bool FreezeTrackingOnDisconnect
    {
        get => Config.FreezeTrackingOnDisconnect;
        set
        {
            if (_freezeTrackingOnDisconnect != value)
            {
                _freezeTrackingOnDisconnect = value;
                Config.FreezeTrackingOnDisconnect = value;
                OnPropertyChanged(nameof(FreezeTrackingOnDisconnect));
            }
        }
    }

    #endregion

    #region MISC

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
                string instance = value;
                if (instance.StartsWith("https://vrchat.com/home/launch?worldId="))
                {
                    instance = instance.Replace("https://vrchat.com/home/launch?worldId=", "vrchat://launch?id=");
                    instance = instance.Replace("&instanceId=", ":");
                }

                _launchInstance = instance;
                Config.LaunchInstance = instance;
                OnPropertyChanged(nameof(LaunchInstance));
            }
        }
    }

    private string _localTestVRCWPath;

    public string LocalTestVRCWPath
    {
        get => Config.LocalTestVRCWPath;
        set
        {
            if (_localTestVRCWPath != value)
            {
                _localTestVRCWPath = value;
                Config.LocalTestVRCWPath = value;
                OnPropertyChanged(nameof(LocalTestVRCWPath));
            }
        }
    }

    private string _arbitraryArguments;

    public string ArbitraryArguments
    {
        get => Config.ArbitraryArguments;
        set
        {
            if (_arbitraryArguments != value)
            {
                _arbitraryArguments = value;
                Config.ArbitraryArguments = value;
                OnPropertyChanged(nameof(ArbitraryArguments));
            }
        }
    }

    private ObservableCollection<CompanionApp> _companionApps;

    public ObservableCollection<CompanionApp> CompanionApps
    {
        get => Config.CompanionApps;
        set
        {
            if (_companionApps != value)
            {
                _companionApps = value;
                Config.CompanionApps = value;
                OnPropertyChanged(nameof(CompanionApps));
            }
        }
    }

    private bool _launchCompanionApps;

    public bool LaunchCompanionApps
    {
        get => Config.LaunchCompanionApps;
        set
        {
            if (_launchCompanionApps != value)
            {
                _launchCompanionApps = value;
                Config.LaunchCompanionApps = value;
                OnPropertyChanged(nameof(LaunchCompanionApps));
            }
        }
    }

    private bool _closeOnLaunch;

    public bool CloseOnLaunch
    {
        get => Config.CloseOnLaunch;
        set
        {
            if (_closeOnLaunch != value)
            {
                _closeOnLaunch = value;
                Config.CloseOnLaunch = value;
                OnPropertyChanged(nameof(CloseOnLaunch));
            }
        }
    }

    private bool _rememberLaunchInstance;

    public bool RememberLaunchInstance
    {
        get => Config.RememberLaunchInstance;
        set
        {
            if (_rememberLaunchInstance != value)
            {
                _rememberLaunchInstance = value;
                Config.RememberLaunchInstance = value;
                OnPropertyChanged(nameof(RememberLaunchInstance));
            }
        }
    }

    #endregion

    public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}