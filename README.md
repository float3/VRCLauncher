# VRCLauncher
![VRCLauncher_Cnl7rw1dXt](https://user-images.githubusercontent.com/86748455/167714516-a8ba3909-b3f3-4e94-9a25-6018dee0dd7a.png)

For In-Depth explanations for most of the flags go to

https://docs.vrchat.com/docs/launch-options

https://docs.unity3d.com/2019.4/Documentation/Manual/PlayerCommandLineArguments.html

Arguments that aren't covered by those links can be found below

| argument                                                                                  | default value                | explanation                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     | source                                                                                                                               |
|-------------------------------------------------------------------------------------------|------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------------------------------------------------------------------------------------------------------------------------------|
| --osc=inPort:senderIP:outPort                                                             | --osc=9000:127.0.0.1:9001    | https://github.com/vrchat-community/osc/wiki#vrchat-ports                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       | https://github.com/vrchat-community/osc/wiki#vrchat-ports                                                                            |
|                                                                                           |                              |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 |                                                                                                                                      |
| vrchat://launch?id=                                                                       |                              | Specify launch instance                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         |                                                                                                                                      |
| --url=create?roomId={10RandomNumbers}&hidden=true&name=BuildAndRun&url=file:///{FilePath} |                              | Specify VRCW path to open locally, like the SDKs "build and test" functionality                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 |                                                                                                                                      | 
|                                                                                           |                              |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 |                                                                                                                                      | 
| --log-debug-levels=                                                                       |                              | extends logging. know "debug-levels" include (this information is most likely out of date): <br/><br/> --log-debug-levels="Always;API;AssetBundleDownloadManager;ContentCreator;All;NetworkTransport;NetworkData;NetworkProcessing"                                                                                                                                                                                                                                                                                                                                                             |                                                                                                                                      |
|                                                                                           |                              |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 |                                                                                                                                      | 
| --custom-arm-ratio=                                                                       | --custom-arm-ratio="0.4537"  | The IK-Beta 2.0 Changelog of VRChat 2022.1.1p3, build 11721 states:<br/><br/>- Added --custom-arm-ratio="0.4537" launch option. "0.4537" is default, "0.415" will approximate previous beta arm scale                                                                                                                                                                                                                                                                                                                                                                                           | An announcement on the VRChat Discord server: https://discord.com/channels/189511567539306508/503009489486872583/955619620310646814  |
| --disable-shoulder-tracking                                                               |                              | The IK-Beta 2.0 Changelog of VRChat 2022.1.1p4, build 11731 states:<br/><br/>- Added --disable-shoulder-tracking launch option. Use this to avoid issues with some types of IMU-only based arm trackers.                                                                                                                                                                                                                                                                                                                                                                                        | An announcement on the VRChat Discord server: https://discord.com/channels/189511567539306508/503009489486872583/958535824490758144  |
| --calibration-range=                                                                      | --calibration-range="0.6"    | The IK-Beta 2.0 Changelog of VRChat 2022.1.1p5, build 11748 states:<br/><br/>- **Added the --calibration-range="0.3" launch option**. This determines the distance from predicted supported binding points that the calibration will search (in meters)<br/>- The default value is 0.3, corresponding to a 30cm radius sphere around possible binding points <br/><br/> The IK-Beta 2.0 Changelog of VRChat 2022.1.2p4, build 11946 states:<br/><br/>  - Increased the default calibration range from 0.3m to 0.6m. As usual this is adjustable via the --calibration-range="0.6" launch option | An announcement on the VRChat Discord server: https://discord.com/channels/189511567539306508/503009489486872583/966575806522466305  | 
| --enable-ik-debug-logging                                                                 | forced on during IK 2.0 Beta | The IK-Beta 2.0 Changelog of VRChat 2022.1.2p4, build 11942 states:<br/><br/>- Added the --enable-ik-debug-logging launch argument - use this when providing us with logs and feedback during the Beta period!                                                                                                                                                                                                                                                                                                                                                                                  | An announcement on the VRChat Discord server: https://discord.com/channels/419351657743253524/623967007733186560/971839050937950259  |
| --freeze-tracking-on-disconnect                                                           |                              | The IK-Beta 2.0 Changelog of VRChat 2022.1.2p4, build 11946 states:<br/><br/>- Added the --freeze-tracking-on-disconnect launch option. Enabling this will cause trackers to freeze in place relative to the player when they are disconnected. To remove frozen trackers you can calibrate again. If all your trackers have disconnected so the calibration option is no longer visible, cycling the Avatar Measurement option will also unfreeze them                                                                                                                                         | An announcement on the VRChat Discord server: https://discord.com/channels/419351657743253524/623967007733186560/973670442206388276  |
|                                                                                           |                              |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 |                                                                                                                                      | 
| --enable-avpro-in-proton                                                                  |                              | enables avpro video player in proton                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            | An announcement on the VRChat Discord server: https://discord.com/channels/189511567539306508/503009489486872583/1049876453828862022 |
| --disable-hw-video-decoding                                                               |                              | will force software video decoding on AVPro video players                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       | An announcement on the VRChat Discord server:                                                                                        |